using Module.User.Application.Features.UserAccount.Command.Dto;

namespace Module.User.Application.Abstractions;

public interface IUserAccountRepository
{
    public Task<UserAccountResponse> AuthenticateUser(AuthenticateUserRequest request);
    public Task<UserAccountResponse> SignUpUser(SignUpUserRequest request);
}