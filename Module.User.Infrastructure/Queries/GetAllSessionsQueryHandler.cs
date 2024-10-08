using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserBrowseAllSessions.Query.Dto;
using Module.User.Domain.Entity;
using Module.User.Infrastructure.DbContexts;

namespace Module.User.Application.Features.UserBrowseAllSessions.Query
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
            }).CreateMapper();
        }

        async Task<IEnumerable<SessionResponse>> IRequestHandler<GetAllSessionsQuery, IEnumerable<SessionResponse>>.Handle(
            GetAllSessionsQuery request,
            CancellationToken cancellationToken)
            => await _dbContext.Sessions.AsNoTracking().ProjectTo<SessionResponse>(_mapper.ConfigurationProvider).ToListAsync();
    }
}
