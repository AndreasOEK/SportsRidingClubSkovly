using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using SportsRidingClubSkovly.Web.Services.Interface;
using SportsRidingClubSkovly.Web.ViewModels;

namespace SportsRidingClubSkovly.Web.Components.Pages.Account;

public partial class SignUp : ComponentBase
{
    [CascadingParameter] public HttpContext? HttpContext { get; set; }
    
    [SupplyParameterFromForm]
    public SignUpViewModel Model { get; set; } = new SignUpViewModel();
    
    [Inject] public IAccountProxy AccountProxy { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    private string? errorMessage;

    private async Task SignUpUser()
    {
        var user = await AccountProxy.SignUpUser(Model.Username, Model.Password, Model.FirstName, Model.LastName, Model.Phone, Model.Username);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, Model.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, "User")
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        await HttpContext.SignInAsync(principal);
        
        NavigationManager.NavigateTo("/");
    }
}