using System.ComponentModel.DataAnnotations.Schema;

namespace Module.User.Domain.Entity
{
    public class Booking
    {
        public Guid Id { get; protected set; }
        public byte[] RowVersion { get; protected set; }
        public User User { get; protected set; }
        public Session Session { get; protected set; }

        protected Booking() { }

        private Booking(User user, IEnumerable<Booking> otherBookings)
        {
            User = user;

            AssureUserHasNotBookedSessionAlready(otherBookings ?? new List<Booking>());
            AssureUserIsNotTheAssignedTrainer();
        }



        public static Booking Create(User user, IEnumerable<Booking> otherBookings)
            => new Booking(user, otherBookings);
        

        #region Booking Domain Logic
        protected void AssureUserHasNotBookedSessionAlready(IEnumerable<Booking> otherBookings)
        {
            if (otherBookings.Any(b => User.Id == b.User.Id))
                throw new ArgumentException("A User cannot book the same session twice");
        }

        private void AssureUserIsNotTheAssignedTrainer()
        {
            if (User.Id == Session.AssignedTrainer.User.Id)
                throw new ArgumentException("A Trainer cannot book their own session");
        }
        #endregion
    }
}
