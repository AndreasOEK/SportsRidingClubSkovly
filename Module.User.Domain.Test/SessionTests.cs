﻿using Module.User.Domain.Entity;
using Module.User.Domain.Enums;
using Module.User.Domain.Test.Fakes;
using Xunit;

namespace Module.User.Domain.Test
{
    public class SessionTests
    {
        [Theory]
        [MemberData(nameof(ValidCreateData))]
        public void Given_Valid_Data_Then_Session_Created(DateTime startTime, TimeSpan duration, FakeTrainer assignedTrainer, 
            int availableSlots, SkillLevel difficultyLevel, SessionType type)
        {
            // Act
            var session = Session.Create(startTime, duration, assignedTrainer, availableSlots, difficultyLevel, type);

            // Assert
            Assert.NotNull(session);
        }

        [Theory]
        [MemberData(nameof(StartTimeInPastData))]
        public void Given_StartTime_In_Past_Then_Throw_ArgumentException(DateTime startTime, DateTime nowDate)
        {
            // Arrange
            var sut = new FakeSession(startTime, new TimeSpan());

            // Act & Assert
            Assert.Throws<ArgumentException>(() => sut.AssureStartTimeInFuture(startTime, nowDate));
        }

        #region MemberData Methods
        public static IEnumerable<object[]> ValidCreateData()
        {
            yield return new object[]{
                DateTime.Now.AddDays(1),
                new TimeSpan(DateTime.Now.Hour + 1, DateTime.Now.Minute, DateTime.Now.Second),
                new FakeTrainer(),
                6,
                SkillLevel.Professional,
                SessionType.Dressage
            };
        }

        public static IEnumerable<object[]> StartTimeInPastData()
        {
            yield return new object[]
            {
                DateTime.Now.AddDays(-1),
                DateTime.Now
            };
        }
        #endregion
    }
}
