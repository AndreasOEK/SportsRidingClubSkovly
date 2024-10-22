using Module.User.Domain.Enums;

namespace Module.User.Application.Features.UserManagement.Query.Dto;

public record UserBookingSessionFullResponse(
    Guid Id,
    DateTime StartTime,
    TimeSpan Duration,
    UserBookingSessionTrainerFullResponse AssignedTrainer,
    int MaxNumberOfParticipants,
    SkillLevel DifficultyLevel,
    SessionType Type);