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
        public bool HasValuesChanged { get; set; }

        protected override async Task OnInitializedAsync()      
           => Session = await UserSessionProxy.GetSessionByIdAsync(SessionId);   
        
        protected async Task BookSlot()
        {
            await UserSessionProxy.CreateBooking(new CreateBookingRequest() { sessionId = Session.Id, userId = new Guid()});
            Session = await UserSessionProxy.GetSessionByIdAsync(SessionId);
        }

        protected bool IsEditMode = false;
        protected async void ToggleEditMode()
        {
            if (HasValuesChanged && IsEditMode)
            {
                await UpdateSession();
            }

            IsEditMode = !IsEditMode;
        }
        protected void ValuesChanged(SessionResponse sessionResponse)
        {
            Session = sessionResponse;
            HasValuesChanged = true;
        }

        protected async Task UpdateSession()
        {
            await UserSessionProxy.UpdateSession(
                new UpdateSessionRequest()
                {
                    Id = Session.Id,
                    AssignedTrainerId = Session.AssignedTrainer.Id,
                    StartTime = Session.StartTime,
                    Duration = Session.Duration,
                    DifficultyLevel = Session.DifficultyLevel,
                    Type = Session.Type,
                    MaxNumberOfParticipants = Session.MaxNumberOfParticipants,
                    RowVersion = Session.RowVersion
                });
        }
    }
}
