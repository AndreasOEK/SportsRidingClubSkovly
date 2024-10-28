using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using SportsRidingClubSkovly.Web.Services.Interface;
using SportsRidingClubSkovly.Web.ViewModels;

namespace SportsRidingClubSkovly.Web.Components.Pages.Account;

public partial class Login : ComponentBase
{
    [CascadingParameter] public HttpContext? HttpContext { get; set; }

    [SupplyParameterFromForm] public LoginViewModel Model { get; set; } = new LoginViewModel();

    [Inject] public IAccountProxy AccountProxy { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public ILogger<Login> Logger { get; set; }

    private string? errorMessage;

    private async Task Authenticate()
    {
        try
        {
            var user = await AccountProxy.AuthenticateUser(Model.Username, Model.Password);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Sid, user.Id.ToString())
            };
        
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);
        
            HttpContext.Response.Redirect("/");
        }
        catch (Exception e)
        {
            errorMessage = "Username or password is incorrect";
        }

    }
}