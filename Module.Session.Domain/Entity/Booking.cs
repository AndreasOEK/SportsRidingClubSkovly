namespace Module.Session.Domain.Entity
{
    public class Booking
    {
        public User User { get; protected set; }

        private Booking(User user, IEnumerable<Booking> otherBookings)
        {
            User = user;

            AssureUserHasNotBookedSessionAlready(otherBookings);
        }

        public static Booking Create(User user, IEnumerable<Booking> otherBookings)
        {
            return new Booking(user, otherBookings);
        }

        protected void AssureUserHasNotBookedSessionAlready(IEnumerable<Booking> otherBookings)
        {
            if (otherBookings.Any(b => this.User.Id == b.User.Id)) 
                throw new ArgumentException("A User cannot book the same session twice");
        }
    }
}
