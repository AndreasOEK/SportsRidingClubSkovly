namespace SportsRidingClubSkovly.Web.DTO.Account;

public record UserAccountResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    bool IsTrainer);