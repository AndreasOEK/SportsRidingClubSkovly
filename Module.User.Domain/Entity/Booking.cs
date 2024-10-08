namespace Module.User.Domain.Entity
{
    public class Booking
    {
        public Guid Id { get; protected set; }
        public User User { get; protected set; }

        protected Booking() { }

        private Booking(User user, IEnumerable<Booking> otherBookings)
        {
            User = user;

            AssureUserHasNotBookedSessionAlready(otherBookings);
        }

        public static Booking Create(User user, IEnumerable<Booking> otherBookings)
            => new Booking(user, otherBookings);
        

        #region Booking Domain Logic
        protected void AssureUserHasNotBookedSessionAlready(IEnumerable<Booking> otherBookings)
        {
            if (otherBookings.Any(b => User.Id == b.User.Id))
                throw new ArgumentException("A User cannot book the same session twice");
        }
        #endregion
    }
}
