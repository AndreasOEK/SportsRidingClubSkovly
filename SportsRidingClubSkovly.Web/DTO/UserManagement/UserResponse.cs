namespace SportsRidingClubSkovly.Web.DTO.UserManagement;

public record UserResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Phone,
    string Email,
    List<UserBookingResponse> Bookings);