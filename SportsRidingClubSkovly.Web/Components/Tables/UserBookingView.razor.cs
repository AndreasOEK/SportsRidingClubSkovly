using Microsoft.AspNetCore.Components;
using SportsRidingClubSkovly.Web.DTO.UserManagement;

namespace SportsRidingClubSkovly.Web.Components.Tables;

public partial class UserBookingView : ComponentBase
{
    [Parameter] public IEnumerable<UserBookingResponse> Bookings { get; set; } = [];
}