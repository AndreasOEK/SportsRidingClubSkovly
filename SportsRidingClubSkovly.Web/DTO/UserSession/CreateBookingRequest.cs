namespace Module.User.Application.Features.UserBooksSession.Command.Dto
{
    public record CreateBookingRequest
    {
        public Guid userId { get; set; }
        public Guid sessionId { get; set; }
    }
}
