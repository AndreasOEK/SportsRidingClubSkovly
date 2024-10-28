using Microsoft.AspNetCore.Components;
using SportsRidingClubSkovly.Web.ViewModels;

namespace SportsRidingClubSkovly.Web.Components.Component;

public partial class CreateSessionEditForm : ComponentBase
{
    public CreateSessionViewModel CreateSessionViewModel { get; set; } = new(){ StartTime = DateTime.Now.AddDays(1), EndTimeOnly = TimeOnly.FromDateTime(DateTime.Now.AddHours(1)) };
    [Parameter]
    public Func<CreateSessionViewModel,Task<bool>> CreateSessionDelegate { get; set; }

    protected void CreateSession()
    {
        CreateSessionDelegate.Invoke(CreateSessionViewModel);
    }

}