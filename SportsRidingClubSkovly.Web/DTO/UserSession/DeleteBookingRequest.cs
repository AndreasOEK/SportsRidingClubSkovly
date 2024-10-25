namespace SportsRidingClubSkovly.Web.DTO.UserSession;

public record DeleteBookingRequest(
    Guid BookingId,
    Guid SessionId,
    byte[] RowVersion);