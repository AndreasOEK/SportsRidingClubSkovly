using System.Security.Claims;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SportsRidingClubSkovly.Web.Services;
using SportsRidingClubSkovly.Web.Services.Interface;
using SportsRidingClubSkovly.Web.ViewModels;
using IAuthenticationService = SportsRidingClubSkovly.Web.Services.Interface.IAuthenticationService;

namespace SportsRidingClubSkovly.Web.Components.Pages.Account;

public partial class Login : ComponentBase
{
    [CascadingParameter] public HttpContext? HttpContext { get; set; }
    
    [SupplyParameterFromForm]
    public LoginViewModel Model { get; set; } = new LoginViewModel();

    [Inject] public IAuthenticationService AuthenticationService { get; set; }
    [Inject] public IAccountProxy AccountProxy { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IHttpContextAccessor HttpContextAccessor { get; set; }

    private string? errorMessage;

    // private async Task Authenticate()
    // {
    //     await AuthenticationService.LoginAsync(Model);
    // }
    
    private async Task Authenticate()
    {
        var user = await AccountProxy.AuthenticateUser(Model.Username, Model.Password);
    
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, Model.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.IsTrainer ? "Trainer" : "User"),
            new Claim(ClaimTypes.Sid, user.Id.ToString()),
            new Claim("jwt_token", user.Token)
        };
        
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        await HttpContextAccessor.HttpContext.SignInAsync(principal);
        
        NavigationManager.NavigateTo("/");
    }
}