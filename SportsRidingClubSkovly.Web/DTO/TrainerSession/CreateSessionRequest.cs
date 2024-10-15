using SportsRidingClubSkovly.Web.Abstractions.Enums;

namespace SportsRidingClubSkovly.Web.DTO.TrainerSession
{
    public record CreateSessionRequest
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid AssignedTrainerId { get; set; }
        public int MaxNumberOfParticipants { get; set; }
        public SkillLevel DifficultyLevel { get; set; }
        public SessionType Type { get; set; }
    }
}
