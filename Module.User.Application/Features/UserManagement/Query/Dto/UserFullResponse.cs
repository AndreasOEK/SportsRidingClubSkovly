namespace Module.User.Application.Features.UserManagement.Query.Dto;

public record UserFullResponse(
    Guid Id, 
    string FirstName, 
    string LastName, 
    string Phone, 
    string Email, 
    List<UserBookingFullResponse> Bookings);