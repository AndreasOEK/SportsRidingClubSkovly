namespace Module.User.Application.Features.UserManagement.Query.Dto;

public record UserBookingSessionTrainerFullResponse(
    Guid Id,
    UserBookingSessionTrainerUserFullResponse User);