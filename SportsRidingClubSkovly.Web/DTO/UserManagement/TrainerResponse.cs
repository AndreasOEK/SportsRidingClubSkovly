using Module.User.Application.Features.UserSession.Query.Dto;

namespace Module.User.Application.Features.UserManagement.Query.Dto;

public record TrainerResponse(Guid Id, IEnumerable<TrainerSessionResponse> AssignedSessions, UserResponse User);