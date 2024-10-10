using Microsoft.EntityFrameworkCore;
using Module.User.Application.Abstractions;
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

        async Task ISessionRepository.AddBookingAsync()
            => await _dbContext.SaveChangesAsync();      

        async Task ISessionRepository.AddSessionAsync(Session session)
        {
            await _dbContext.Sessions.AddAsync(session);
            await _dbContext.SaveChangesAsync();
        }

        async Task<Session> ISessionRepository.GetSessionByIdAsync(Guid sessionId)
            => await _dbContext.Sessions.SingleAsync(session => session.Id == sessionId);

        async Task ISessionRepository.UpdateSessionAsync(Session session, byte[] rowVersion)
        {
            _dbContext.Entry(session).Property(s => s.RowVersion).OriginalValue = rowVersion;
            await _dbContext.SaveChangesAsync();
        }
    }
}
