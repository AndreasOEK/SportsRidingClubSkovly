using SportsRidingClubSkovly.Web.Abstractions.Enums;

namespace SportsRidingClubSkovly.Web.DTO.UserManagement;

public record UserBookingSessionFullResponse(
    Guid Id,
    DateTime StartTime,
    DateTime EndTime,
    UserBookingSessionTrainerFullResponse AssignedTrainer,
    int MaxNumberOfParticipants,
    SkillLevel DifficultyLevel,
    SessionType Type);