namespace Module.User.Application.Features.UserManagement.Query.Dto;

public record UserBookingResponse(
    Guid Id,
    UserBookingSessionResponse Session);