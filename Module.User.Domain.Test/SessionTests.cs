using Module.User.Domain.Entity;
using Module.User.Domain.Enums;
using Module.User.Domain.Test.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Module.User.Domain.Test
{
    public class SessionTests
    {
        [Theory]
        [MemberData(nameof(ValidCreateData))]
        public void Given_Valid_Data_Then_Session_Created(DateTime startTime, DateTime endTime, FakeTrainer assignedTrainer, 
            int availableSlots, SkillLevel difficultyLevel, SessionType type)
        {
            // Act
            var session = Session.Create(startTime, endTime, assignedTrainer, availableSlots, difficultyLevel, type);

            // Assert
            Assert.NotNull(session);
        }

        public static IEnumerable<object[]> ValidCreateData()
        {
            yield return new object[]{
                DateTime.Now.AddDays(1),
                DateTime.Now.AddDays(2),
                new FakeTrainer(),
                6,
                SkillLevel.Professional,
                SessionType.Dressage
            };
        }
    }
}
