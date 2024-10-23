using Microsoft.AspNetCore.Http;
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

        async Task<Trainer> IUserRepository.GetTrainerFromUserId(Guid id)
            => await _dbContext.Trainers.Include(t => t.User)
                   .SingleOrDefaultAsync(t => t.User.Id == id) ??
               throw new BadHttpRequestException("User is not a trainer");
        
        async Task<bool> IUserRepository.DoesTrainerExistAsync(Guid id)
            => await _dbContext.Trainers.AnyAsync(trainer => trainer.Id == id);

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
        
        async Task<bool> IUserRepository.IsUserTrainer(Guid userId)
        {
            return await _dbContext.Trainers.Include(trainer => trainer.User)
                .AnyAsync(trainer => trainer.User.Id == userId);
        }

        async Task<bool> IUserRepository.DoesUserExist(string email)
        {
            return await _dbContext.Users.AnyAsync(user => user.Email == email);
        }

        #endregion
    }
}
