using Module.User.Domain.Enums;

namespace Module.User.Application.Features.TrainerSession.Command.Dto
{
    public record CreateSessionRequest
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid AssignedTrainerId { get; set; }
        public int AvailableSlots { get; set; }
        public SkillLevel DifficultyLevel { get; set; }
        public SessionType Type { get; set; }
    }
}
