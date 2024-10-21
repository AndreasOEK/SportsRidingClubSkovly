﻿using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using IAuthenticationService = SportsRidingClubSkovly.Web.Services.Interface.IAuthenticationService;

namespace SportsRidingClubSkovly.Web.Components.Pages.Account;

public partial class Logout : ComponentBase
{
    [CascadingParameter] public HttpContext HttpContext { get; set; }
    
    [Inject] public IAuthenticationService AuthenticationService { get; set; }
    [Inject] public IHttpContextAccessor HttpContextAccessor { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await HttpContextAccessor.HttpContext.SignOutAsync();
        NavigationManager.NavigateTo("/login"); 
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