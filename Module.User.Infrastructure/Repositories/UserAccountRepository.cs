using Microsoft.EntityFrameworkCore;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserAccount.Command.Dto;
using Module.User.Domain.Entity;
using Module.User.Infrastructure.DbContexts;

namespace Module.User.Infrastructure.Repositories;

public class UserAccountRepository : IUserAccountRepository
{
    private readonly UserDbContext _dbContext;

    public UserAccountRepository(UserDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    async Task<UserAccountResponse> IUserAccountRepository.AuthenticateUser(AuthenticateUserRequest request)
        => await GetUserAccount(request);

    async Task<UserAccountResponse> IUserAccountRepository.SignUpUser(SignUpUserRequest request)
    {
        var user = Domain.Entity.User.Create(request.FirstName, request.LastName, request.Phone, request.Email);
        var userAccount = UserAccount.Create(request.Username, request.Password, user);
        
        await _dbContext.UserAccounts.AddAsync(userAccount);

        await _dbContext.SaveChangesAsync();

        return await GetUserAccount(new AuthenticateUserRequest(request.Username, request.Password));
    }

    private async Task<UserAccountResponse> GetUserAccount(AuthenticateUserRequest request)
    {
        var account = await _dbContext.UserAccounts.Include(userAccount => userAccount.User).SingleAsync(userAccount =>
            userAccount.Username == request.Username && userAccount.Password == request.Password);

        var isTrainer = await _dbContext.Trainers.Include(trainer => trainer.User)
            .AnyAsync(trainer => trainer.User.Id == account.Id);

        return new UserAccountResponse(
            account.User.Id,
            account.User.FirstName,
            account.User.LastName,
            account.User.Email,
            isTrainer);
    }
}