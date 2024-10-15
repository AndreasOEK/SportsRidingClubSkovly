namespace SportsRidingClubSkovly.Web.DTO.UserSession
{
    public record SessionBookingResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
