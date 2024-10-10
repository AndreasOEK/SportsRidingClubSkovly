using Module.User.Domain.Entity;

namespace Module.User.Application.Abstractions
{
    public interface ISessionRepository
    {
        Task AddSessionAsync(Session session);
        Task AddBookingAsync();
        Task<Session> GetSessionByIdAsync(Guid sessionId);
        Task UpdateSessionAsync();
    }
}
