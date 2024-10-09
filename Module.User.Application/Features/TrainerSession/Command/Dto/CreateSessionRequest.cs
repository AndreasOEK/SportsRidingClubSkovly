using Module.User.Domain.Entity;
using Module.User.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
