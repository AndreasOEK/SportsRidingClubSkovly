using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SportsRidingClubSkovly.Web.Services.Interface;

namespace SportsRidingClubSkovly.Web.Components.Pages.Account;

public partial class Logout : ComponentBase
{
    [CascadingParameter] public HttpContext HttpContext { get; set; }
    
    [Inject] public IAuthenticationService AuthenticationService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await AuthenticationService.LogoutAsync();
    }

    // protected override async Task OnInitializedAsync()
    // {
    //     await base.OnInitializedAsync();
    //     if (HttpContext.User.Identity.IsAuthenticated)
    //         await HttpContext.SignOutAsync();
    //     
    //     NavigationManager.NavigateTo("/login");
    // }
}