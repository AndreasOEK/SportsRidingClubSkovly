namespace Module.User.Application.Features.UserAccount.Command.Dto;

public record SignUpUserRequest(
    string Username, 
    string Password, 
    string FirstName, 
    string LastName, 
    string Phone, 
    string Email);