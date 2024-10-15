using Microsoft.AspNetCore.Components;
using SportsRidingClubSkovly.Web.DTO.UserManagement;
using SportsRidingClubSkovly.Web.Services.Interface;

namespace SportsRidingClubSkovly.Web.Components.Pages;

public partial class BrowseAllUsers : ComponentBase
{
    [Inject] public IUserManagementProxy UserManagementProxy { get; set; }

    private IEnumerable<UserResponse> Users { get; set; } = [];
    
    protected override async Task OnInitializedAsync()
    {
        Users = await UserManagementProxy.GetAllUsers();
        await base.OnInitializedAsync();
    }
}