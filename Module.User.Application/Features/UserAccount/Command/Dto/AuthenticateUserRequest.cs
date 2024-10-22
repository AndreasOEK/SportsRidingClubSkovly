namespace Module.User.Application.Features.UserAccount.Command.Dto;

public record AuthenticateUserRequest(
    string Username,
    string Password);