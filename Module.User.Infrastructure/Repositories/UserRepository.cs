using Microsoft.EntityFrameworkCore;
using Module.User.Application.Abstractions;
using Module.User.Domain.Entity;
using Module.User.Infrastructure.DbContexts;

namespace Module.User.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Trainer

        async Task<Trainer> IUserRepository.GetTrainerByIdAsync(Guid trainerId)
            => await _dbContext.Trainers.SingleAsync(t => t.Id == trainerId);

        async Task IUserRepository.CreateTrainerAsync(Trainer trainer)
        {
            await _dbContext.Trainers.AddAsync(trainer);
            await _dbContext.SaveChangesAsync();
        }

        async Task IUserRepository.DeleteTrainerAsync(Trainer trainer)
        {
            _dbContext.Trainers.Remove(trainer);
            await _dbContext.SaveChangesAsync();
        }

        #endregion

        #region User

        async Task<Domain.Entity.User> IUserRepository.GetUserByIdAsync(Guid userId)
            => await _dbContext.Users.SingleAsync(u => u.Id == userId);

        async Task IUserRepository.CreateUserAsync(Domain.Entity.User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        async Task IUserRepository.UpdateUserAsync(Domain.Entity.User user)
        {
            await _dbContext.SaveChangesAsync();
        }

        async Task IUserRepository.DeleteUserAsync(Domain.Entity.User user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}
