using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]  //[TestClass]
    public class ReservationUnitTest
    {
        [Test]//[TestMethod]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var resevatioin = new Reservation();
            var user = new User { IsAdmin = true };

            //Act
            var result = resevatioin.CanBeCancelledBy(user);

            //Assert
            //Assert.IsTrue(result);
            
            //or
            Assert.That(result, Is.True);
            //Assert.That(result == true);
        }

        [Test]//[TestMethod]
        public void CanBeCancelledBy_UserIsSameAsMadeBy_ReturnsTrue()
        {
            //Arrange
            var resevatioin = new Reservation();

            var madeBy = new User { IsAdmin = false };
            resevatioin.MadeBy = madeBy;

            //Act
            var result = resevatioin.CanBeCancelledBy(madeBy);

            //Assert
            //Assert.IsTrue(result);

            Assert.That(result, Is.True);

            //or

            //var user = new User();
            //var resevatioin2 = new Reservation { MadeBy = user };

            //var result2 = resevatioin2.CanBeCancelledBy(user);

            //Assert.IsTrue(result2);
        }

        [Test]//[TestMethod]
        public void CanBeCancelledBy_SomeOtherUser_ReturnsFalse()
        {
            //Arrange
            var resevatioin = new Reservation();
            var user = new User { IsAdmin = false };

            //Act
            var result = resevatioin.CanBeCancelledBy(user);

            //Assert
            //Assert.IsFalse(result);
            Assert.That(result, Is.False);
            Assert.That(result == false);
        }
    }
}
