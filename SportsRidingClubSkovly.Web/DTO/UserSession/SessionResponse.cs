using SportsRidingClubSkovly.Web.Abstractions.Enums;
using System.ComponentModel.DataAnnotations;

namespace SportsRidingClubSkovly.Web.DTO.UserSession
{
    public record SessionResponse
    {
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
        [Required(ErrorMessage = "Please provide Start Time")]
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public SessionTrainerResponse AssignedTrainer { get; set; }
        public int MaxNumberOfParticipants { get; set; }
        public SkillLevel DifficultyLevel { get; set; }
        public SessionType Type { get; set; }
        public IEnumerable<SessionBookingResponse> Bookings { get; set; }
    }
}
