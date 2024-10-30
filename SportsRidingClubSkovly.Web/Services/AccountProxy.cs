using System.Text;
using Newtonsoft.Json;
using SportsRidingClubSkovly.Web.DTO.Account;
using SportsRidingClubSkovly.Web.Services.Interface;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SportsRidingClubSkovly.Web.Services;

public class AccountProxy : IAccountProxy
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public AccountProxy(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _configuration = configuration;
        
        var httpclientName = _configuration["ApiHttpClientName"];
        _httpClient = httpClientFactory.CreateClient(httpclientName ?? string.Empty);
    }
    
    async Task<UserAccountResponse> IAccountProxy.AuthenticateUser(string username, string password)
    {
        var content = new StringContent(JsonSerializer.Serialize(new AuthenticateUserRequest(username, password)), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("Login", content);
        if (!response.IsSuccessStatusCode)
            throw new BadHttpRequestException(response.ReasonPhrase);

        var resultJson = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<UserAccountResponse>(resultJson);
    }

    async Task<UserAccountResponse> IAccountProxy.SignUpUser(string username, string password, string firstName, string lastName, string phone, string email)
    {
        var content = new StringContent(JsonSerializer.Serialize(new SignUpUserRequest(username, password, firstName, lastName, phone, email)), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("signup", content);
        if (!response.IsSuccessStatusCode)
            throw new BadHttpRequestException(response.ReasonPhrase);

        var resultJson = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<UserAccountResponse>(resultJson);
    }
}