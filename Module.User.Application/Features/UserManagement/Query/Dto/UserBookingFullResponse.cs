namespace Module.User.Application.Features.UserManagement.Query.Dto;

public record UserBookingFullResponse(
    Guid Id,
    UserBookingSessionFullResponse Session);