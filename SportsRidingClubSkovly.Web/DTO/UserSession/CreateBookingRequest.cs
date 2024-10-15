namespace SportsRidingClubSkovly.Web.DTO.UserSession
{
    public record CreateBookingRequest
    {
        public Guid userId { get; set; }
        public Guid sessionId { get; set; }
    }
}
