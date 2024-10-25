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
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("Session/booking", content);
            return response.IsSuccessStatusCode;
        }

        async Task<SessionResponse> IUserSessionProxy.GetSessionByIdAsync(Guid sessionId)
        {
            var requestUrl = "Session/" + sessionId.ToString();
            var response = await _httpClient.GetAsync(requestUrl);
            return await response.Content.ReadFromJsonAsync<SessionResponse>() ?? new SessionResponse();
        }

        async Task<IEnumerable<SessionResponse>> IUserSessionProxy.GetSessionsAsync()
        {
            var response = await _httpClient.GetAsync("Sessions");
            return await response.Content.ReadFromJsonAsync<IEnumerable<SessionResponse>>() ?? [];
        }

        async Task<bool> IUserSessionProxy.UpdateSession(UpdateSessionRequest request)
        {
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("Session", content);
            return response.IsSuccessStatusCode;
        }

        async Task<bool> IUserSessionProxy.DeleteBooking(DeleteBookingRequest deleteBookingRequest)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"Session/Booking"),
                Content = new StringContent(JsonSerializer.Serialize(deleteBookingRequest), Encoding.UTF8, "application/json")
            };
            
            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }
    }
}
