using Microsoft.EntityFrameworkCore;
using Module.User.Application.Abstractions;
using Module.User.Application.Abstractions.Authentication;
using Module.User.Application.Features.UserAccount.Command.Dto;
using Module.User.Domain.Entity;
using Module.User.Infrastructure.DbContexts;

namespace Module.User.Infrastructure.Repositories;

public class UserAccountRepository : IUserAccountRepository
{
    private readonly UserDbContext _dbContext;
    private readonly IPasswordHasher _passwordHasher;

    public UserAccountRepository(UserDbContext dbContext, IPasswordHasher passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }
    
    
    async Task IUserAccountRepository.AddAccount(UserAccount account)
    {
        await _dbContext.UserAccounts.AddAsync(account);
        await _dbContext.SaveChangesAsync();
    }

    async Task<UserAccount> IUserAccountRepository.GetAccountByUsername(string username)
    {
        return await _dbContext.UserAccounts.Include(userAccount => userAccount.User).SingleAsync(userAccount =>
            userAccount.Username == username);
    }

    async Task<bool> IUserAccountRepository.DoesEmailExist(string signupRequestUsername)
    {
        return await _dbContext.UserAccounts.AnyAsync(account => account.Username == signupRequestUsername);
    }
}