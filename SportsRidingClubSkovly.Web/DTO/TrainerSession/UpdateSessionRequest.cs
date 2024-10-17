using SportsRidingClubSkovly.Web.Abstractions.Enums;

namespace SportsRidingClubSkovly.Web.DTO.TrainerSession
{
    public record UpdateSessionRequest
    {
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public Guid AssignedTrainerId { get; set; }
        public int MaxNumberOfParticipants { get; set; }
        public SkillLevel DifficultyLevel { get; set; }
    }
}
