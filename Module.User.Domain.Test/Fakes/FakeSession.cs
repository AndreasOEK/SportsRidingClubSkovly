using Module.User.Domain.Entity;

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
