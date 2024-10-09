using Module.User.Domain.Entity;

namespace Module.User.Application.Abstractions
{
    public interface ISessionRepository
    {
        Task AddSessionAsync(Session session);
        Task AddBookingAsync();
        Task<Session> GetSessionById(Guid sessionId);
    }
}
