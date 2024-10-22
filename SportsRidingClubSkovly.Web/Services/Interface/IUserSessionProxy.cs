using SportsRidingClubSkovly.Web.DTO.TrainerSession;
using SportsRidingClubSkovly.Web.DTO.UserSession;

namespace SportsRidingClubSkovly.Web.Services.Interface
{
    public interface IUserSessionProxy
    {
        Task<IEnumerable<SessionResponse>> GetSessionsAsync();
        Task<SessionResponse> GetSessionByIdAsync(Guid sessionId);
        Task CreateBooking(CreateBookingRequest request);
        Task UpdateSession(UpdateSessionRequest updateSessionRequest);
    }
}
