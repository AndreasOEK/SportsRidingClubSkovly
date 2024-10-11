using Module.User.Application.Features.UserSession.Query.Dto;

namespace Module.User.Application.Features.UserManagement.Query.Dto;

public record UserResponse(
    Guid Id, 
    string FirstName, 
    string LastName, 
    string Phone, 
    string Email, 
    List<UserBookingResponse> Bookings);