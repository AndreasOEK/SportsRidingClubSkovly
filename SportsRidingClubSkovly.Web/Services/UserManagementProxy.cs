using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using SportsRidingClubSkovly.Web.DTO.UserManagement;
using SportsRidingClubSkovly.Web.Services.Interface;

namespace SportsRidingClubSkovly.Web.Services;

public class UserManagementProxy : IUserManagementProxy
{
    private readonly HttpClient _httpClient;

    public UserManagementProxy(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("API");
    }

    async Task<UserFullResponse> IUserManagementProxy.GetUserById(Guid id)
        => await _httpClient.GetFromJsonAsync<UserFullResponse>($"User/{id}") ?? throw new Exception("User did not exist");

    async Task<IEnumerable<UserResponse>> IUserManagementProxy.GetAllUsers()
        => await _httpClient.GetFromJsonAsync<IEnumerable<UserResponse>>("User") ?? [];

    async Task<bool> IUserManagementProxy.UpdateUser(UpdateUserRequest request)
    {
        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync("User", content);
        return response.IsSuccessStatusCode;
    }

    async Task<bool> IUserManagementProxy.DeleteUser(DeleteUserRequest request)
    {
        throw new NotImplementedException();
    }
}