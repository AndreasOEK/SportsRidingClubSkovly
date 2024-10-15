using Microsoft.AspNetCore.Components;
using SportsRidingClubSkovly.Web.DTO.UserManagement;

namespace SportsRidingClubSkovly.Web.Components.Cards;

public partial class UserBookingCard : ComponentBase
{
    [Parameter] public UserBookingResponse Booking { get; set; }
}