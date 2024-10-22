using SportsRidingClubSkovly.Web.Abstractions.Enums;

namespace SportsRidingClubSkovly.Web.DTO.UserManagement;

public record TrainerSessionResponse(
    Guid Id,
    DateTime StartTime,
    TimeSpan Duration,
    SkillLevel DifficultyLevel,
    SessionType Type);