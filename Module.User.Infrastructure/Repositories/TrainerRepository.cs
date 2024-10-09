using Microsoft.EntityFrameworkCore;
using Module.User.Application.Abstractions;
using Module.User.Domain.Entity;
using Module.User.Infrastructure.DbContexts;

namespace Module.User.Infrastructure.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly UserDbContext _dbContext;

        public TrainerRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<Trainer> ITrainerRepository.GetTrainerById(Guid trainerId)
            => await _dbContext.Trainers.SingleAsync(t => t.Id == trainerId);
        
    }
}
