using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using SportsRidingClubSkovly.Web.DTO.UserManagement;
using SportsRidingClubSkovly.Web.Services.Interface;

namespace SportsRidingClubSkovly.Web.Components.Pages;

//[Authorize(Roles = "Trainer")]
[Authorize(Roles = "Admin")]
public partial class ManageUsers : ComponentBase
{
    [Inject] public IUserManagementProxy UserManagementProxy { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    private IEnumerable<UserResponse> Users { get; set; } = [];
    private IEnumerable<TrainerResponse> Trainers { get; set; } = [];
    private IEnumerable<UserResponse> RegularUsers { get; set; } = [];

    
    protected override async Task OnInitializedAsync()
    {
        Users = await UserManagementProxy.GetAllUsers();
        Trainers = await UserManagementProxy.GetAllTrainers();
        RegularUsers = Users.Where(user => Trainers.All(trainer => trainer.User.Id != user.Id));
        await base.OnInitializedAsync();
    }

    private async Task Demote(Guid id)
    {
        var success = await UserManagementProxy.DeleteTrainer(new DeleteTrainerRequest(id));
        if (success)
            NavigationManager.NavigateTo(NavigationManager.Uri, true);

    }

    private async Task Promote(Guid id)
    {
        var success = await UserManagementProxy.CreateTrainer(new CreateTrainerRequest(id));
        if (success)
            NavigationManager.NavigateTo(NavigationManager.Uri, true);
        
    }
}