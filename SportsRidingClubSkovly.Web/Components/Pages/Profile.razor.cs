using System.Net.Mail;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SportsRidingClubSkovly.Web.DTO.UserManagement;
using SportsRidingClubSkovly.Web.Services.Interface;
using SportsRidingClubSkovly.Web.ViewModels;

namespace SportsRidingClubSkovly.Web.Components.Pages;

[Authorize]
public partial class Profile : ComponentBase
{
    [CascadingParameter] public HttpContext? HttpContext { get; set; }
    //[Inject] public HttpContextAccessor HttpContextAccessor { get; set; }
    [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject] public IUserManagementProxy UserManagementProxy { get; set; }
    
    [SupplyParameterFromForm]
    public ProfileViewModel Model { get; set; } = new ProfileViewModel();
    private UserFullResponse User { get; set; }
    
    private bool IsEditingProfile { get; set; }
    private bool IsSaving { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        var userIdStr = user.FindFirst(ClaimTypes.Sid)?.Value;
        var userId = Guid.Parse(userIdStr);
        User = await UserManagementProxy.GetUserById(userId);

        Model.FirstName = User.FirstName;
        Model.LastName = User.LastName;
        Model.Email = User.Email;
        Model.Phone = User.Phone;

    }

    private async void SaveProfile()
    {
        IsSaving = true;
        IsEditingProfile = false;

        var success = await UserManagementProxy.UpdateUser(
            new UpdateUserRequest(
                User.Id, 
                Model.FirstName,
                Model.LastName,
                Model.Phone,
                Model.Email));

        if (!success) return;
        
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        var userIdStr = user.FindFirst(ClaimTypes.Sid)?.Value;
        var userId = Guid.Parse(userIdStr);
        User = await UserManagementProxy.GetUserById(userId);
        IsSaving = false;
        StateHasChanged();
    }

    private void EditProfile()
    {
        IsEditingProfile = true;
    }

    private void CloseEditProfile()
    {
        IsEditingProfile = false;
    }

}