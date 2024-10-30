using Module.User.Domain.Entity;
using Module.User.Domain.Test.Fakes;
using Xunit;

namespace Module.User.Domain.Test
{
    public class BookingTests
    {
        [Theory]
        [MemberData(nameof(ValidBookingData))]
        public void Given_Valid_Data_Then_Booking_Created(FakeUser user, FakeSession session)
        {
            // Act
            var booking = Booking.Create(user, session, []);

            // Assert
            Assert.NotNull(booking);
        }

        [Theory]
        [MemberData(nameof(SameUserToBookTwiceData))]
        public void Given_User_Who_Has_Already_Booked_Then_Throw_ArgumentException(FakeUser user,
            List<FakeBooking> otherBookings)
        {
            // Arrange
            var sut = new FakeBooking(user);

            // Act && Assert
            Assert.Throws<ArgumentException>(() => sut.AssureUserHasNotBookedSessionAlready(otherBookings));
        }

        #region MemberData Methods

        public static IEnumerable<object[]> ValidBookingData()
        {
            yield return new object[]
            {
                new FakeUser(new Guid()),
                new FakeSession(DateTime.Now.AddDays(1), TimeSpan.MinValue),
            };
        }

        public static IEnumerable<object[]> SameUserToBookTwiceData()
        {
            var guid = new Guid();
            yield return new object[]
            {
                new FakeUser(guid),
                new List<FakeBooking>() { new FakeBooking(new FakeUser(guid)) }
            };
        }

        #endregion
    }
}