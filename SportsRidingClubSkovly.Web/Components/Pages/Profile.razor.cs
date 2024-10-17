using Microsoft.AspNetCore.Components;
using SportsRidingClubSkovly.Web.DTO.UserManagement;
using SportsRidingClubSkovly.Web.Services.Interface;

namespace SportsRidingClubSkovly.Web.Components.Pages;

public partial class Profile : ComponentBase
{
    [Inject] public IUserManagementProxy UserManagementProxy { get; set; }
    [Parameter] public Guid UserId { get; set; }

    private UserResponse OriginalUser { get; set; }
    private UserResponse User { get; set; }

    private string Email { get; set; }
    private string Phone { get; set; }
    
    private bool IsEditingProfile { get; set; }
    private bool IsSaving { get; set; }
    
    

    protected override async Task OnInitializedAsync()
    {
        User = await UserManagementProxy.GetUserById(UserId);
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
        
        User = await UserManagementProxy.GetUserById(UserId);
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