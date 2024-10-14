namespace Module.User.Application.Features.UserSession.Command.Dto
{
    public record CreateBookingRequest(
        Guid userId,
        Guid sessionId
    );
}
