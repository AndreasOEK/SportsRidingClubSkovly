namespace Module.User.Application.Features.UserAccount.Command.Dto;

public record UserAccountResponse(
    Guid Id,
    string Email,
    string FullName,
    bool isTrainer,
    string Token);