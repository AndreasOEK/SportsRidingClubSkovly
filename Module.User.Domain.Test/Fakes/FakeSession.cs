using Module.User.Domain.Entity;

namespace Module.User.Domain.Test.Fakes
{
    public class FakeSession : Session
    {
        public FakeSession(DateTime startTime, TimeSpan duration) : base()
        {
            StartTime = startTime;
            Duration = duration;
        }

        public new void AssureStartTimeInFuture(DateTime startTime, DateTime now)
        {
            base.AssureStartTimeInFuture(startTime, now);
        }
    }
}
