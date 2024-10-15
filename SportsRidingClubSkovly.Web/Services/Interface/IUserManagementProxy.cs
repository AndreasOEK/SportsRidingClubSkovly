using SportsRidingClubSkovly.Web.DTO.UserManagement;

namespace SportsRidingClubSkovly.Web.Services.Interface;

public interface IUserManagementProxy
{
       Task<UserResponse> GetUserById(Guid id);
       Task<IEnumerable<UserResponse>> GetAllUsers();

       Task<bool> UpdateUser(UpdateUserRequest request);
       Task<bool> DeleteUser(DeleteUserRequest request);
}