using Module.User.Domain.Enums;

namespace Module.User.Application.Features.UserManagement.Query.Dto;

public record TrainerSessionResponse(
    Guid Id,
    DateTime StartTime,
    TimeSpan Duration,
    SkillLevel DifficultyLevel,
    SessionType Type);