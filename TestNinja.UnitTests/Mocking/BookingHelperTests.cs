using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {

    [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
           var repository = new Mock<IBookingRepository>();

            repository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>
            {
                new Booking
                {
                    Id = 2,
                    ArrivalDate = new DateTime(2024, 6, 20),
                    DepartureDate = new DateTime(2024, 6, 30),
                    Reference = "a"
                }

            }.AsQueryable());


            var newBooking = new Booking
            {
                Id = 1,
                ArrivalDate = new DateTime(2024, 6, 10),
                DepartureDate = new DateTime(2024, 6, 14),
                Reference = "b"
            };
            var result = BookingHelper.OverlappingBookingsExist(newBooking, repository.Object);
            Assert.That(result, Is.Empty);
        }
    }
}
