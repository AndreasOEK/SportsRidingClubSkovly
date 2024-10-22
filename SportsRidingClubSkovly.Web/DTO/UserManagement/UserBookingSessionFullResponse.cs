using SportsRidingClubSkovly.Web.Abstractions.Enums;

namespace SportsRidingClubSkovly.Web.DTO.UserManagement;

public record UserBookingSessionFullResponse(
    Guid Id,
    DateTime StartTime,
    TimeSpan Duration,
    UserBookingSessionTrainerFullResponse AssignedTrainer,
    int MaxNumberOfParticipants,
    SkillLevel DifficultyLevel,
    SessionType Type);