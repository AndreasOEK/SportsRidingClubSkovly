using Microsoft.AspNetCore.Components;
using SportsRidingClubSkovly.Web.DTO.UserSession;

namespace SportsRidingClubSkovly.Web.Components.Component
{
    public partial class SessionCardBase : ComponentBase
    {
        [Parameter]
        public SessionResponse Session { get; set; }
    }
}
