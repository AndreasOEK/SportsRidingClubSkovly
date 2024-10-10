namespace Module.User.Application.Features.UserManagement.Command.Dto;

public record UpdateUserRequest(
    Guid Guid,
    string FirstName,
    string LastName,
    string Phone,
    string Email);