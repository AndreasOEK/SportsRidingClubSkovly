using System.Runtime.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using SportsRidingClubSkovly.Web.DTO.UserManagement;

namespace SportsRidingClubSkovly.Web.Components.Tables;

public partial class UserBookingView : ComponentBase
{
    [Parameter] public IEnumerable<UserBookingFullResponse> Bookings { get; set; } = [];
    
    [Inject] public NavigationManager NavigationManager { get; set; }

    private void NavigateToSessions()
    {
        NavigationManager.NavigateTo("/browsesessions");
    }
}