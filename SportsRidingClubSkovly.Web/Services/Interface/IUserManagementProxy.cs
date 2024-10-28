using Module.User.Application.Features.UserManagement.Query.Dto;
using SportsRidingClubSkovly.Web.DTO.UserManagement;
using SportsRidingClubSkovly.Web.DTO.UserSession;

namespace SportsRidingClubSkovly.Web.Services.Interface;

public interface IUserManagementProxy
{
       Task<UserFullResponse> GetUserById(Guid id);
       Task<IEnumerable<UserResponse>> GetAllUsers();
       Task<IEnumerable<TrainerResponse>> GetAllTrainers();
       Task<IEnumerable<UserBookingFullResponse>> GetUserPastBookings(GetUserPreviousBookingsRequest request);
       Task<CreateSessionTrainerResponse> GetTrainerByUserId(GetTrainerByUserIdRequest request);

       Task<bool> UpdateUser(UpdateUserRequest request);
       Task<bool> DeleteUser(DeleteUserRequest request);
       Task<bool> DeleteTrainer(DeleteTrainerRequest request);
       Task<bool> CreateTrainer(CreateTrainerRequest request);
}