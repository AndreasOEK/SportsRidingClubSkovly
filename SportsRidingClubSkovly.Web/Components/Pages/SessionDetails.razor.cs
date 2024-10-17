using Microsoft.AspNetCore.Components;
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

        protected override async Task OnInitializedAsync()      
           => Session = await UserSessionProxy.GetSessionByIdAsync(SessionId);
        

        
        protected async Task BookSlot()
        {
            await UserSessionProxy.CreateBooking(new CreateBookingRequest() { sessionId = Session.Id, userId = new Guid()});
            Session = await UserSessionProxy.GetSessionByIdAsync(SessionId);
        }
    }
}
