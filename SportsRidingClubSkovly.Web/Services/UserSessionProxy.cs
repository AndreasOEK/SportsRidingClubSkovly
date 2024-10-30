using SportsRidingClubSkovly.Web.DTO.TrainerSession;
using SportsRidingClubSkovly.Web.DTO.UserSession;
using SportsRidingClubSkovly.Web.Services.Interface;
using System.Text;
using System.Text.Json;

namespace SportsRidingClubSkovly.Web.Services
{
    public class UserSessionProxy : IUserSessionProxy
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public UserSessionProxy(IHttpClientFactory httpClient, IConfiguration configuration)
        {
            _configuration = configuration;

            var httpClientName = _configuration["ApiHttpClientName"];
            _httpClient = httpClient.CreateClient(httpClientName ?? string.Empty);
        }

        public async Task<bool> CreateBooking(CreateBookingRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("Session/Booking", request);
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

        async Task<bool> IUserSessionProxy.CreateSession(CreateSessionRequest createSessionRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("Session", createSessionRequest);
            return response.IsSuccessStatusCode;
        }

        async Task<IEnumerable<SessionResponse>> IUserSessionProxy.GetFutureSessionsAsync()
            => await _httpClient.GetFromJsonAsync<IEnumerable<SessionResponse>>("Sessions/InFuture") ?? [];
    }
}