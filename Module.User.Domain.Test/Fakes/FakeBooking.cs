using Module.User.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.User.Domain.Test.Fakes
{
    public class FakeBooking : Booking
    {
        public FakeBooking(Module.User.Domain.Entity.User user) : base()
        {
            User = user;
        }

        public new void AssureUserHasNotBookedSessionAlready(IEnumerable<Booking> otherBookings)
        {
            base.AssureUserHasNotBookedSessionAlready(otherBookings);
        }
    }
}
