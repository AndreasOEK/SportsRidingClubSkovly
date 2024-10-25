using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SportsRidingClubSkovly.Web.DTO.TrainerSession;
using SportsRidingClubSkovly.Web.DTO.UserSession;
using SportsRidingClubSkovly.Web.Services.Interface;
using System.Security.Claims;

namespace SportsRidingClubSkovly.Web.Components.Pages
{
    public class SessionDetailsBase : ComponentBase
    {
        [Parameter]
        public Guid SessionId { get; set; }

        public Guid UserId { get; set; }
        public SessionResponse Session { get; set; }
        [Inject]
        public IUserSessionProxy UserSessionProxy { get; set; }
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        public TimeOnly EndTime { get; set; }
        public bool IsInEditMode { get; set; } = false;
        protected bool IsSaving;
        protected bool IsBooking;
        protected bool IsRemovingBooking;

        protected override async Task OnInitializedAsync()
        {
            Session = await UserSessionProxy.GetSessionByIdAsync(SessionId);
            EndTime = TimeOnly.FromTimeSpan(Session.Duration);
            
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var userIdStr = user.FindFirst(ClaimTypes.Sid)?.Value;
            UserId = Guid.Parse(userIdStr);
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
            
            var succes = await UserSessionProxy.CreateBooking(
                new CreateBookingRequest()
                {
                    sessionId = Session.Id,
                    userId = UserId
                });

            if (!succes) return;

            Session = await UserSessionProxy.GetSessionByIdAsync(SessionId);
            IsBooking = false;
        }

        protected async Task RemoveBooking()
        {
            IsRemovingBooking = true;
            var booking = Session.Bookings.FirstOrDefault(b => b.UserId == UserId);
            
            var succes = await UserSessionProxy.DeleteBooking(
                new DeleteBookingRequest(
                    BookingId: booking.Id,
                    SessionId: Session.Id,
                    RowVersion: booking.RowVersion));
            
            if (!succes) return;
            
            Session = await UserSessionProxy.GetSessionByIdAsync(SessionId);
            IsRemovingBooking = false;
        }
    }
}
