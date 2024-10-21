using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using SportsRidingClubSkovly.Web.DTO.UserManagement;
using SportsRidingClubSkovly.Web.Services.Interface;

namespace SportsRidingClubSkovly.Web.Components.Pages;

public partial class Profile : ComponentBase
{
    [CascadingParameter] public HttpContext? HttpContext { get; set; }
    [Inject] public IUserManagementProxy UserManagementProxy { get; set; }
    private UserFullResponse User { get; set; }

    private string Email { get; set; }
    private string Phone { get; set; }
    
    private bool IsEditingProfile { get; set; }
    private bool IsSaving { get; set; }
    
    

    protected override async Task OnInitializedAsync()
    {
        var userIdStr = HttpContext.User.FindFirst(ClaimTypes.Sid)?.Value;
        var userId = Guid.Parse(userIdStr);
        User = await UserManagementProxy.GetUserById(userId);
        Email = User.Email;
        Phone = User.Phone;
        await base.OnInitializedAsync();
    }

    private async void SaveProfile()
    {
        IsSaving = true;
        IsEditingProfile = false;

        var success = await UserManagementProxy.UpdateUser(
            new UpdateUserRequest(
                User.Id, 
                User.FirstName, 
                User.LastName, 
                Phone, 
                Email));

        if (!success) return;
        
        var userId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.Sid)?.Value);
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