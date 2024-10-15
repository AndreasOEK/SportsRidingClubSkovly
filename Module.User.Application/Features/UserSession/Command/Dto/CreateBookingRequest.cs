namespace Module.User.Application.Features.UserSession.Command.Dto
{
    public record CreateBookingRequest
    {
        public Guid userId { get; set; }
        public Guid sessionId { get; set; }
    }
}
