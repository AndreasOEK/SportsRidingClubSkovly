namespace SportsRidingClubSkovly.Web.DTO.UserManagement;

public record UpdateUserRequest(
    Guid Guid,
    string FirstName,
    string LastName,
    string Phone,
    string Email);