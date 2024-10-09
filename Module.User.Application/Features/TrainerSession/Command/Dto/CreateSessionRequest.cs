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
        public Guid Id { get; protected set; }
        public DateTime StartTime { get; protected set; }
        public DateTime EndTime { get; protected set; }
        public Guid AssignedTrainerId { get; protected set; }
        public int AvailableSlots { get; protected set; }
        public SkillLevel DifficultyLevel { get; protected set; }
        public SessionType Type { get; protected set; }
    }
}
