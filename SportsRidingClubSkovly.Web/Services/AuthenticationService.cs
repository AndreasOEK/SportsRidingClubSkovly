using System.Security.Claims;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components;
using SportsRidingClubSkovly.Web.DTO.Account;
using SportsRidingClubSkovly.Web.Services.Interface;
using SportsRidingClubSkovly.Web.ViewModels;
using IAuthenticationService = SportsRidingClubSkovly.Web.Services.Interface.IAuthenticationService;

namespace SportsRidingClubSkovly.Web.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAccountProxy _accountProxy;
    private readonly NavigationManager _navigationManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthenticationService(
        IAccountProxy accountProxy,
        NavigationManager navigationManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _accountProxy = accountProxy;
        _navigationManager = navigationManager;
        _httpContextAccessor = httpContextAccessor;
    }
    
    async Task IAuthenticationService.LoginAsync(LoginViewModel viewModel)
    {
        var userResponse = await _accountProxy.AuthenticateUser(viewModel.Username, viewModel.Password);

        await HttpSignIn(userResponse);
        
        _navigationManager.NavigateTo("/"); 
    }

    async Task IAuthenticationService.SignUpAsync(SignUpViewModel viewModel)
    {
        var userResponse = await _accountProxy.SignUpUser(
            viewModel.Username, 
            viewModel.Password,
            viewModel.FirstName, 
            viewModel.LastName, 
            viewModel.Phone, 
            viewModel.Username);

        if (userResponse is null)
            return;

        await HttpSignIn(userResponse);
        
        _navigationManager.NavigateTo("/"); 
    }

    private async Task HttpSignIn(UserAccountResponse response)
    {
        var httpContext = _httpContextAccessor.HttpContext 
                          ?? throw new InvalidOperationException("HttpContext is not available");

        // 1. Prepare claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, response.FullName),
            new Claim(ClaimTypes.Email, response.Email),
            new Claim(ClaimTypes.Sid, response.Id.ToString()),
            new Claim(ClaimTypes.Role, response.IsTrainer ? "Trainer" : "User"),
            // Store the JWT token as a claim instead of a separate cookie
            new Claim("jwt_token", response.Token)
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        // 2. Configure authentication properties
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7),
            IssuedUtc = DateTimeOffset.UtcNow,
            // Add any additional properties you need
            // Items =
            // {
            //     {"jwt_token", response.Token}
            // }
        };

        // 3. Perform sign-in with all data included
        await httpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);
    }

    async Task IAuthenticationService.LogoutAsync()
    {
        var httpContext = _httpContextAccessor.HttpContext 
                          ?? throw new InvalidOperationException("HttpContext is not available");
        
        await httpContext.SignOutAsync();
        _navigationManager.NavigateTo("/login"); 
    }

    async Task<string> IAuthenticationService.GetJwtAsync()
    {
        var httpContext = _httpContextAccessor.HttpContext 
                          ?? throw new InvalidOperationException("HttpContext is not available");
    
        if (httpContext.User.Identity.IsAuthenticated == false)
            return String.Empty;
        
        // Try to get from claims
        var jwtToken = httpContext.User.Claims.FirstOrDefault(c => c.Type == "jwt_token")?.Value;
        if (!string.IsNullOrEmpty(jwtToken))
            return jwtToken;

        return string.Empty;
    }
}