namespace SportsRidingClubSkovly.Web.DTO.Account;

public record AuthenticateUserRequest(
    string Username,
    string Password);