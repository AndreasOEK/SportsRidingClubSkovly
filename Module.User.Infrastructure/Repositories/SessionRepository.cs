using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserBrowseAllSessions.Query.Dto;
using Module.User.Domain.Entity;
using Module.User.Infrastructure.DbContexts;

namespace Module.User.Infrastructure.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly UserDbContext _dbContext;

        public SessionRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task ISessionRepository.AddAsync(Session session)
        {
            await _dbContext.Sessions.AddAsync(session);

        }
    }
}
