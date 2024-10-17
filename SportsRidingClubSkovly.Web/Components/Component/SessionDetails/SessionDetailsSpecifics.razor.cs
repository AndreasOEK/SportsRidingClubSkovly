using Microsoft.AspNetCore.Components;
using SportsRidingClubSkovly.Web.DTO.UserSession;

namespace SportsRidingClubSkovly.Web.Components.Component.SessionDetails
{
    public partial class SessionDetailsSpecificsBase : ComponentBase
    {
        [Parameter]
        public SessionResponse Session { get; set; }
    }
}
