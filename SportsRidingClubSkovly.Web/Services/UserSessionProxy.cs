using SportsRidingClubSkovly.Web.DTO.TrainerSession;
using SportsRidingClubSkovly.Web.DTO.UserSession;
using SportsRidingClubSkovly.Web.Services.Interface;
using System.Text;
using System.Text.Json;

namespace SportsRidingClubSkovly.Web.Services
{
    public class UserSessionProxy : IUserSessionProxy
    {
        private readonly HttpClient _httpClient;

        public UserSessionProxy(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("API");
        }

        public async Task<bool> CreateBooking(CreateBookingRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("Session/booking", request);
            return response.IsSuccessStatusCode;
        }

        async Task<SessionResponse> IUserSessionProxy.GetSessionByIdAsync(Guid sessionId)
            => await _httpClient.GetFromJsonAsync<SessionResponse>($"Session/{sessionId}") ??
               throw new ArgumentException("Session not found");


        async Task<IEnumerable<SessionResponse>> IUserSessionProxy.GetSessionsAsync()
            => await _httpClient.GetFromJsonAsync<IEnumerable<SessionResponse>>("Sessions") ?? [];

        async Task<bool> IUserSessionProxy.UpdateSession(UpdateSessionRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync("Session", request);
            return response.IsSuccessStatusCode;
        }

        async Task<bool> IUserSessionProxy.DeleteBooking(DeleteBookingRequest deleteBookingRequest)
        {
            var requestUri = new Uri($"http://localhost:9000/Session/Booking/{deleteBookingRequest.BookingId}");
            var response = await _httpClient.DeleteAsync(requestUri);
            return response.IsSuccessStatusCode;
        }
    }
}