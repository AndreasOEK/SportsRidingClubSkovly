using Module.User.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.User.Application.Features.TrainerSession.Command.Dto
{
    public record UpdateSessionRequest
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid AssignedTrainerId { get; set; }
        public int MaxNumberOfParticipants { get; set; }
        public SkillLevel DifficultyLevel { get; set; }
    }
}
