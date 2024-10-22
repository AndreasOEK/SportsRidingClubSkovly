using SportsRidingClubSkovly.Web.DTO.UserManagement;

namespace SportsRidingClubSkovly.Web.Services.Interface;

public interface IUserManagementProxy
{
       Task<UserFullResponse> GetUserById(Guid id);
       Task<IEnumerable<UserResponse>> GetAllUsers();
       Task<IEnumerable<TrainerResponse>> GetAllTrainers();

       Task<bool> UpdateUser(UpdateUserRequest request);
       Task<bool> DeleteUser(DeleteUserRequest request);
       Task<bool> DeleteTrainer(DeleteTrainerRequest request);
       Task<bool> CreateTrainer(CreateTrainerRequest request);
}