using SportsRidingClubSkovly.Web.Abstractions.Enums;

namespace SportsRidingClubSkovly.Web.DTO.UserManagement;

public record TrainerSessionResponse(
    Guid Id,
    DateTime StartTime,
    DateTime EndTime,
    SkillLevel DifficultyLevel,
    SessionType Type);