using SportsRidingClubSkovly.Web.DTO.Account;

namespace SportsRidingClubSkovly.Web.Services.Interface;

public interface IAccountProxy
{
    public Task<UserAccountResponse> AuthenticateUser(string username, string password);

    public Task<UserAccountResponse> SignUpUser(string username, string password, string firstName, string lastName,
        string phone, string email);
}