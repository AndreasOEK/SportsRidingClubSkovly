namespace Module.User.Application.Features.UserAccount.Command.Dto;

public record UserAccountResponse(
    Guid Id,
    string FullName,
    string Email,
    bool IsTrainer);