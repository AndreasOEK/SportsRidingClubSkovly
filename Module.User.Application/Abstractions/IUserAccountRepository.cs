using Module.User.Application.Features.UserAccount.Command.Dto;
using Module.User.Domain.Entity;

namespace Module.User.Application.Abstractions;

public interface IUserAccountRepository
{
    public Task AddAccount(UserAccount account);
    public Task<UserAccount> GetAccountByUsername(string username);
    Task<bool> DoesEmailExist(string signupRequestUsername);
}