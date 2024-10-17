namespace SportsRidingClubSkovly.Web.DTO.UserManagement;

public record UserFullResponse(
    Guid Id, 
    string FirstName, 
    string LastName, 
    string Phone, 
    string Email, 
    List<UserBookingFullResponse> Bookings);