using Module.User.Domain.Entity;

namespace Module.User.Application.Abstractions
{
    public interface IUserRepository
    {
        Task<Trainer> GetTrainerByIdAsync(Guid trainerId);
        Task<Module.User.Domain.Entity.User> GetUserById(Guid userId);
    }
}
