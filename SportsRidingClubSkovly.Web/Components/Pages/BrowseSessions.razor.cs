using Microsoft.AspNetCore.Authorization;
using SportsRidingClubSkovly.Web.DTO.UserSession;

namespace SportsRidingClubSkovly.Web.Components.Pages;

[Authorize]
public partial class BrowseSessions
{
    private IEnumerable<SessionResponse> sessions = [];

    protected override async Task OnInitializedAsync()
    {
        sessions = await userSessionProxy.GetSessionsAsync();
    }

    public int CalculateSlotsLeft(SessionResponse session)
    {
        return session.MaxNumberOfParticipants - session.Bookings.Count();
    }
}