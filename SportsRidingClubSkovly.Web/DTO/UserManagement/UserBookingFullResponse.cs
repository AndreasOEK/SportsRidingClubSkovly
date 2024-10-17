namespace SportsRidingClubSkovly.Web.DTO.UserManagement;

public record UserBookingFullResponse(
    Guid Id,
    UserBookingSessionFullResponse Session);