using Module.User.Domain.Entity;
using Module.User.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.User.Domain.Test.Fakes
{
    public class FakeSession : Session
    {
        public FakeSession(DateTime startTime, DateTime endTime) : base()
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public new void AssureStartTimeInFuture(DateTime startTime, DateTime now)
        {
            base.AssureStartTimeInFuture(startTime, now);
        }

        public new void AssureEndTimeAfterStartTime(DateTime startTime, DateTime endTime)
        {
            base.AssureEndTimeAfterStartTime(startTime, endTime);
        }
    }
}
