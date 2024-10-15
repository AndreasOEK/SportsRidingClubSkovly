namespace SportsRidingClubSkovly.Web.DTO.UserManagement;

public record TrainerResponse(Guid Id, IEnumerable<TrainerSessionResponse> AssignedSessions, UserResponse User);