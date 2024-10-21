using System.Text;
using Newtonsoft.Json;
using SportsRidingClubSkovly.Web.DTO.Account;
using SportsRidingClubSkovly.Web.Services.Interface;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SportsRidingClubSkovly.Web.Services;

public class AccountProxy : IAccountProxy
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AccountProxy(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    async Task<UserAccountResponse> IAccountProxy.AuthenticateUser(string username, string password)
    {
        var content = new StringContent(JsonSerializer.Serialize(new AuthenticateUserRequest(username, password)), Encoding.UTF8, "application/json");
        var response = await _httpClientFactory.CreateClient("API").PostAsync("Authenticate", content);
        if (!response.IsSuccessStatusCode)
            return null;

        var resultJson = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<UserAccountResponse>(resultJson);
    }

    //TODO: System.InvalidOperationException: JavaScript interop calls cannot be issued at this time. This is because the component is being statically rendered. When prerendering is enabled, JavaScript interop calls can only be performed during the OnAfterRenderAsync lifecycle method.
    // at Microsoft.AspNetCore.Components.Server.Circuits.RemoteJSRuntime.BeginInvokeJS(Int64 asyncHandle, String identifier, String argsJson, JSCallResultType resultType, Int64 targetInstanceId)
    // at Microsoft.JSInterop.JSRuntime.InvokeAsync[TValue](Int64 targetInstanceId, String identifier, CancellationToken cancellationToken, Object[] args)
    // at Microsoft.JSInterop.JSRuntime.InvokeAsync[TValue](String identifier, CancellationToken cancellationToken, Object[] args)
    // at Blazored.SessionStorage.BrowserStorageProvider.GetItemAsync(String key, CancellationToken cancellationToken)
    // at Blazored.SessionStorage.SessionStorageService.GetItemAsync[T](String key, CancellationToken cancellationToken)
    // at SportsRidingClubSkovly.Web.Services.AuthenticationService.SportsRidingClubSkovly.Web.Services.Interface.IAuthenticationService.GetJwtAsync() in D:\Development\Github\SportsRidingClubSkovly\SportsRidingClubSkovly.Web\Services\AuthenticationService.cs:line 62
    // at SportsRidingClubSkovly.Web.Handlers.AuthenticationHandler.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) in D:\Development\Github\SportsRidingClubSkovly\SportsRidingClubSkovly.Web\Handlers\AuthenticationHandler.cs:line 22
    // at Microsoft.Extensions.Http.Logging.LoggingScopeHttpMessageHandler.<SendCoreAsync>g__Core|4_0(HttpRequestMessage request, Boolean useAsync, CancellationToken cancellationToken)
    // at System.Net.Http.HttpClient.<SendAsync>g__Core|83_0(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationTokenSource cts, Boolean disposeCts, CancellationTokenSource pendingRequestsCts, CancellationToken originalCancellationToken)
    // at SportsRidingClubSkovly.Web.Services.AccountProxy.SportsRidingClubSkovly.Web.Services.Interface.IAccountProxy.SignUpUser(String username, String password, String firstName, String lastName, String phone, String email) in D:\Development\Github\SportsRidingClubSkovly\SportsRidingClubSkovly.Web\Services\AccountProxy.cs:line 32
    
    //TODO: Does not return a jwt
    
    async Task<UserAccountResponse> IAccountProxy.SignUpUser(string username, string password, string firstName, string lastName, string phone, string email)
    {
        var content = new StringContent(JsonSerializer.Serialize(new SignUpUserRequest(username, password, firstName, lastName, phone, email)), Encoding.UTF8, "application/json");
        var response = await _httpClientFactory.CreateClient("API").PostAsync("signup", content);
        if (!response.IsSuccessStatusCode)
            return null;

        var resultJson = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<UserAccountResponse>(resultJson);
    }
}