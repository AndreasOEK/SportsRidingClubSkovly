using Microsoft.AspNetCore.Components;
using SportsRidingClubSkovly.Web.DTO.UserSession;

namespace SportsRidingClubSkovly.Web.Components.Component.SessionDetails
{
    public partial class SessionDetailsBookingInformationBase : ComponentBase
    {
        [Parameter]
        public SessionResponse Session { get; set; }

        protected string SlotsLeft()
            => (Session.MaxNumberOfParticipants - Session.Bookings.ToList().Count).ToString();
    }
}
