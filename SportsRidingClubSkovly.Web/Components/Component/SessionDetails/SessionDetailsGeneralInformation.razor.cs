using Microsoft.AspNetCore.Components;
using SportsRidingClubSkovly.Web.DTO.UserSession;

namespace SportsRidingClubSkovly.Web.Components.Component.SessionDetails
{
    public partial class SessionDetailsGeneralInformationBase : ComponentBase
    {
        [Parameter]
        public SessionResponse Session { get; set; }
    }
}
