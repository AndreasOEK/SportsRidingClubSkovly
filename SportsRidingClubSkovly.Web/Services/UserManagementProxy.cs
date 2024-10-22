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

    async Task<IEnumerable<TrainerResponse>> IUserManagementProxy.GetAllTrainers()
        => await _httpClient.GetFromJsonAsync<IEnumerable<TrainerResponse>>("Trainer") ?? [];

    async Task<bool> IUserManagementProxy.UpdateUser(UpdateUserRequest request)
    {
        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync("User", content);
        return response.IsSuccessStatusCode;
    }

    async Task<bool> IUserManagementProxy.DeleteUser(DeleteUserRequest request)
    {
        var response = await _httpClient.DeleteAsync($"User/{request.Guid}");
        return response.IsSuccessStatusCode;
    }

    async Task<bool> IUserManagementProxy.DeleteTrainer(DeleteTrainerRequest request)
    {
        var response = await _httpClient.DeleteAsync($"User/{request.Guid}/Trainer");
        return response.IsSuccessStatusCode;
    }

    async Task<bool> IUserManagementProxy.CreateTrainer(CreateTrainerRequest request)
    {
        var response = await _httpClient.PostAsync($"User/{request.UserId}/Trainer", null);
        return response.IsSuccessStatusCode;
    }
}