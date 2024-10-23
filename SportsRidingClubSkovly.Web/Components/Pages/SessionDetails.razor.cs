using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SportsRidingClubSkovly.Web.DTO.TrainerSession;
using SportsRidingClubSkovly.Web.DTO.UserSession;
using SportsRidingClubSkovly.Web.Services.Interface;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace SportsRidingClubSkovly.Web.Components.Pages
{
    [Authorize]
    public class SessionDetailsBase : ComponentBase
    {
        [Parameter]
        public Guid SessionId { get; set; }
        public SessionResponse Session { get; set; }
        [Inject]
        public IUserSessionProxy UserSessionProxy { get; set; }
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        public TimeOnly EndTime { get; set; }
        public bool IsInEditMode { get; set; } = false;
        protected bool IsSaving = false;
        protected bool IsBooking = false;

        protected override async Task OnInitializedAsync()
        {
            Session = await UserSessionProxy.GetSessionByIdAsync(SessionId);
            EndTime = TimeOnly.FromTimeSpan(Session.Duration);
        }

        protected void ToggleEditMode()
        {
            IsInEditMode = !IsInEditMode;
        }

        protected async Task UpdateSession()
        {
            IsSaving = true;

            var succes = await UserSessionProxy.UpdateSession(
                new UpdateSessionRequest()
                {
                    Id = Session.Id,
                    AssignedTrainerId = Session.AssignedTrainer.Id,
                    StartTime = Session.StartTime,
                    Duration = EndTime.ToTimeSpan(),
                    DifficultyLevel = Session.DifficultyLevel,
                    Type = Session.Type,
                    MaxNumberOfParticipants = Session.MaxNumberOfParticipants,
                    RowVersion = Session.RowVersion
                });

            if (!succes) return;

            Session = await UserSessionProxy.GetSessionByIdAsync(SessionId);
            IsSaving = false;
            ToggleEditMode();
        }

        protected string SlotsLeft()
            => (Session.MaxNumberOfParticipants - Session.Bookings.ToList().Count).ToString();

        protected async Task BookSlot()
        {
            IsBooking = true;

            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var userIdStr = user.FindFirst(ClaimTypes.Sid)?.Value;
            var userIdGuid = Guid.Parse(userIdStr);

            var succes = await UserSessionProxy.CreateBooking(
                new CreateBookingRequest()
                {
                    sessionId = Session.Id,
                    userId = userIdGuid
                });

            if (!succes) return;

            Session = await UserSessionProxy.GetSessionByIdAsync(SessionId);
            IsBooking = false;
        }
    }
}
