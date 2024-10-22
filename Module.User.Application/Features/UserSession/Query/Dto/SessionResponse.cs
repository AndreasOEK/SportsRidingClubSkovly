using Module.User.Domain.Entity;
using Module.User.Domain.Enums;

namespace Module.User.Application.Features.UserSession.Query.Dto
{
    public record SessionResponse
    {
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public SessionTrainerResponse AssignedTrainer { get; set; }
        public int MaxNumberOfParticipants { get; set; }
        public SkillLevel DifficultyLevel { get; set; }
        public SessionType Type { get; set; }
        public IEnumerable<SessionBookingResponse> Bookings { get; set; }
    }
}
