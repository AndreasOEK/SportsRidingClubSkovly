namespace SportsRidingClubSkovly.Web.DTO.Account;

public record UserAccountResponse(
    Guid Id,
    string Email,
    string FullName,
    bool IsTrainer,
    string Token);