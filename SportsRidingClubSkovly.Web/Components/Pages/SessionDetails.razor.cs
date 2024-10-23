using Microsoft.AspNetCore.Components;
using SportsRidingClubSkovly.Web.DTO.TrainerSession;
using SportsRidingClubSkovly.Web.DTO.UserSession;
using SportsRidingClubSkovly.Web.Services.Interface;

namespace SportsRidingClubSkovly.Web.Components.Pages
{
    public class SessionDetailsBase : ComponentBase
    {
        [Parameter]
        public Guid SessionId { get; set; }
        public SessionResponse Session { get; set; }
        [Inject]
        public IUserSessionProxy UserSessionProxy { get; set; }
        public TimeOnly EndTime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Session = await UserSessionProxy.GetSessionByIdAsync(SessionId);
            EndTime = TimeOnly.FromTimeSpan(Session.Duration);
        }

        protected async Task BookSlot()
        {
            await UserSessionProxy.CreateBooking(new CreateBookingRequest() { sessionId = Session.Id, userId = new Guid() });
            Session = await UserSessionProxy.GetSessionByIdAsync(SessionId);
        }

        protected bool IsInEditMode = false;
        protected bool IsSaving = false;

        protected async void EditDetails()
        {
            IsInEditMode = true;
        }

        protected async Task UpdateSession()
        {
            IsSaving = true;

            await UserSessionProxy.UpdateSession(
                new UpdateSessionRequest()
                {
                    Id = Session.Id,
                    AssignedTrainerId = Session.AssignedTrainer.Id,
                    StartTime = Session.StartTime,
                    Duration = CalculateDuration(),
                    DifficultyLevel = Session.DifficultyLevel,
                    Type = Session.Type,
                    MaxNumberOfParticipants = Session.MaxNumberOfParticipants,
                    RowVersion = Session.RowVersion
                });

            IsSaving = false;
            IsInEditMode = false;
        }

        private TimeSpan CalculateDuration()
        {
            TimeSpan duration = EndTime - TimeOnly.FromDateTime(Session.StartTime);
            return duration;
        }
    }
}
