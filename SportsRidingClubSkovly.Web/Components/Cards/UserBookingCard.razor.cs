using Microsoft.AspNetCore.Components;
using SportsRidingClubSkovly.Web.DTO.UserManagement;

namespace SportsRidingClubSkovly.Web.Components.Cards;

public partial class UserBookingCard : ComponentBase
{
    [Parameter] public UserBookingResponse Booking { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    
    private void NavigateToSession()
    {
        NavigationManager.NavigateTo($"Session/{Booking.Session.Id}"); 
    }
}