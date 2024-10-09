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

        async Task<Trainer> IUserRepository.GetTrainerById(Guid trainerId)
            => await _dbContext.Trainers.SingleAsync(t => t.Id == trainerId);

        async Task<Domain.Entity.User> IUserRepository.GetUserById(Guid userId)
            => await _dbContext.Users.SingleAsync(u => u.Id == userId);
    }
}
