using Module.User.Domain.Enums;

namespace Module.User.Application.Features.TrainerSession.Command.Dto
{
    public record UpdateSessionRequest
    {
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid AssignedTrainerId { get; set; }
        public int MaxNumberOfParticipants { get; set; }
        public SkillLevel DifficultyLevel { get; set; }
    }
}
