namespace SportsRidingClubSkovly.Web.DTO.Account;

public record UserAccountResponse(
    Guid Id,
    string FullName,
    string Email,
    string Role);