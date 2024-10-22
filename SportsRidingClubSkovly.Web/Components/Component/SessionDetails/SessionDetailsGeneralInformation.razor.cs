using Microsoft.AspNetCore.Components;
using SportsRidingClubSkovly.Web.DTO.UserSession;

namespace SportsRidingClubSkovly.Web.Components.Component.SessionDetails
{
    public partial class SessionDetailsGeneralInformationBase : ComponentBase
    {
        [Parameter]
        public SessionResponse Session { get; set; }
        [Parameter]
        public bool IsEditMode { get; set; }
        protected TimeOnly UpdatedEndTime { get; set; }
        protected DateTime UpdatedStartTime { get; set; }
        [Parameter]
        public Action<SessionResponse> ValuesUpdated { get; set; }

        protected override void OnInitialized()
        {

            if (Session != null)
            {
                UpdatedEndTime = TimeOnly.FromTimeSpan(Session.Duration);
                UpdatedStartTime = Session.StartTime;
            }
            else
            {
                UpdatedEndTime = new TimeOnly();
                UpdatedStartTime = new DateTime();
            }
        }

        protected void OnValuesChanged()
        {
            if (HasValuesChanged())
                ValuesUpdated?.Invoke(Session);
        }

        private bool HasValuesChanged()
        {
            TimeSpan newDuration = UpdatedEndTime.ToTimeSpan();
            if (Session.Duration != newDuration)
            {
                Session.Duration = newDuration;
                return true;
            }
            if (Session.StartTime != UpdatedStartTime)
            {
                Session.StartTime = UpdatedStartTime;
                return true;
            }

            return false;
        }
    }
}
