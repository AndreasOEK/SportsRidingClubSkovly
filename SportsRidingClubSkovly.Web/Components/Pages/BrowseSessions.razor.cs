using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using SportsRidingClubSkovly.Web.DTO.UserSession;
using SportsRidingClubSkovly.Web.DTO.TrainerSession;
using SportsRidingClubSkovly.Web.ViewModels;

namespace SportsRidingClubSkovly.Web.Components.Pages;

[Authorize]
public partial class BrowseSessions
{
    private IEnumerable<SessionResponse> _sessions = [];

    protected override async Task OnInitializedAsync()
    {
        _sessions = await userSessionProxy.GetSessionsAsync();
    }

    public int CalculateSlotsLeft(SessionResponse session)
        => session.MaxNumberOfParticipants - session.Bookings.Count();

    private Task<bool> CreateSessionAsync(CreateSessionViewModel createSessionViewModel)
    {
        return Task.FromResult(false);
    }
}