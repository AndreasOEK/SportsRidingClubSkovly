namespace SportsRidingClubSkovly.Web.DTO.Account;

public record SignUpUserRequest(
    string Username, 
    string Password, 
    string FirstName, 
    string LastName, 
    string Phone, 
    string Email);