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

        public async Task CreateBooking(CreateBookingRequest request)
        {
            var requestUrl = $"/Session/{request.sessionId}/booking";
            var jsonData = JsonSerializer.Serialize(request);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(requestUrl, content);
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
    }
}
