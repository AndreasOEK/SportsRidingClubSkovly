using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.User.Application.Features.UserSession.Query;
using Module.User.Application.Features.UserSession.Query.Dto;
using Module.User.Domain.Entity;
using Module.User.Infrastructure.DbContexts;

namespace Module.User.Infrastructure.Features.Sessions
{
    public class GetAllSessionsQueryHandler : IRequestHandler<GetAllSessionsQuery, IEnumerable<SessionResponse>>
    {
        private readonly UserDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllSessionsQueryHandler(UserDbContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Session, SessionResponse>();
                cfg.CreateMap<Trainer, SessionTrainerResponse>();
                cfg.CreateMap<Domain.Entity.User, SessionTrainerUserResponse>();
                cfg.CreateMap<Booking, SessionBookingResponse>();
            }).CreateMapper();
        }

        async Task<IEnumerable<SessionResponse>> IRequestHandler<GetAllSessionsQuery, IEnumerable<SessionResponse>>.Handle(
            GetAllSessionsQuery request,
            CancellationToken cancellationToken)
            => await _dbContext.Sessions
            .AsNoTracking()
            .Include(s => s.AssignedTrainer)
            .ProjectTo<SessionResponse>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
