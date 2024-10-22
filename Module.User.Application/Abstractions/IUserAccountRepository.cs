using Module.User.Application.Features.UserAccount.Command.Dto;
using Module.User.Domain.Entity;

namespace Module.User.Application.Abstractions;

public interface IUserAccountRepository
{
    Task<bool> DoesEmailExist(string signupRequestUsername);
    Task<UserAccount> GetAccountByUsername(string username);
    Task AddAccount(UserAccount account);
}