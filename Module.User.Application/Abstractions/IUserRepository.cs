using Module.User.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.User.Application.Abstractions
{
    public interface IUserRepository
    {
        #region Trainer

        Task<Trainer> GetTrainerByIdAsync(Guid trainerId);
        Task<Trainer> GetTrainerFromUserId(Guid id);

        Task<bool> DoesTrainerExistAsync(Guid trainerId);
        Task CreateTrainerAsync(Trainer user);
        Task DeleteTrainerAsync(Trainer user);


        #endregion

        #region User

        Task<Domain.Entity.User> GetUserByIdAsync(Guid userId);
        Task CreateUserAsync(Domain.Entity.User user);
        Task UpdateUserAsync(Domain.Entity.User user);
        Task DeleteUserAsync(Domain.Entity.User user);
        Task<bool> IsUserTrainer(Guid userId);
        Task<bool> DoesUserExist(string email);

        #endregion
    }
}