using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_WhenSpeedLessThanZeroOrGreateThanSpeedLimit_ShouldReturnArgumentOutOfRangeException(int speed)
        {
            var demeritPointCalculator = new DemeritPointsCalculator();

            Assert.That(() => demeritPointCalculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CalculateDemeritPoints_WhenSpeedLessThanExpectedSpeedLimit_ShouldReturnZero()
        {
            var demeritPointCalculator = new DemeritPointsCalculator();

            Assert.That(() => demeritPointCalculator.CalculateDemeritPoints(64), Is.EqualTo(0));
        }


        [Test]
        public void CalculateDemeritPoints_WhenSpeedGreaterThanSpeedLimitAndLessThanMaxSpeed_ShouldReturnZero()
        {
            var demeritPointCalculator = new DemeritPointsCalculator();

            Assert.That(() => demeritPointCalculator.CalculateDemeritPoints(64), Is.EqualTo(0));
        }

        //---------------- From GitHub Copilot ----------------

        private DemeritPointsCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_InvalidSpeed_ThrowsArgumentOutOfRangeException(int speed)
        {
            Assert.That(() => _calculator.CalculateDemeritPoints(speed), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0)]
        [TestCase(64)]
        [TestCase(65)]
        public void CalculateDemeritPoints_SpeedAtOrBelowSpeedLimit_ReturnsZero(int speed)
        {
            var result = _calculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase(66, 0)]   // integer division: (66-65)/5 == 0
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        [TestCase(130, 13)]
        [TestCase(300, 47)] // boundary: MaxSpeed allowed
        public void CalculateDemeritPoints_SpeedAboveLimit_ReturnsExpectedDemeritPoints(int speed, int expected)
        {
            var result = _calculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
