using Module.User.Domain.Entity;

namespace Module.User.Application.Abstractions
{
    public interface ISessionRepository
    {
        #region Session
        Task AddSessionAsync(Session session);
        Task<Session> GetSessionByIdAsync(Guid sessionId);
        Task UpdateSessionAsync(Session session, byte[] rowVersion);
        #endregion
        
        #region Booking
        Task AddBookingAsync();
        Task DeleteBookingAsync(Booking booking);
        Task<Booking> GetBookingByIdAsync(Guid bookingId);
        #endregion
    }
}
