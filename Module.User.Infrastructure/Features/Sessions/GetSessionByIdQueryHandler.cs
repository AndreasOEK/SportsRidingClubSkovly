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
    public class GetSessionByIdQueryHandler : IRequestHandler<GetSessionByIdQuery, SessionResponse>
    {
        private readonly UserDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSessionByIdQueryHandler(UserDbContext dbContext)
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

        public async Task<SessionResponse> Handle(GetSessionByIdQuery request, CancellationToken cancellationToken)
            => await _dbContext.Sessions
            .AsNoTracking()
            .Include(s => s.AssignedTrainer)
            .Where(s => s.Id == request.sessionId)
            .ProjectTo<SessionResponse>(_mapper.ConfigurationProvider)
            .SingleAsync();
    }
}
