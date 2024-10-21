namespace Module.User.Application.Features.UserAccount.Command.Dto;

public record UserAccountResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    bool IsTrainer);