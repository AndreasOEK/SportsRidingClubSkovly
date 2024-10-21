namespace Module.User.Application.Features.UserManagement.Command.Dto;

public record CreateUserRequest(string FirstName, string LastName, string Phone, string Email, string Password);
