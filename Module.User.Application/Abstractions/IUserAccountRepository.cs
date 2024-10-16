using SportsRidingClubSkovly.Web.DTO.Account;

namespace Module.User.Application.Abstractions;

public interface IUserAccountRepository
{
    public Task<UserAccountResponse> AuthenticateUser(AuthenticateUserRequest request);
    public Task<UserAccountResponse> SignUpUser(SignUpUserRequest request);
}