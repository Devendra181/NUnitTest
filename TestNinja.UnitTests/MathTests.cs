using NUnit.Framework;
using Maths = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Maths _math;

        [SetUp]
        public void SetUp()
        {
            // This method will be called before each test is run.
            _math = new Maths();
        }

        [Test]
        [Ignore("Because I wanted to!")]
        public void Add_WhenCalled_ResultTheSumOfArguments()
        {
            var result = _math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));

            //Below is not truswothy test because it will pass even if the Add method is not implemented correctly.
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            var result = _math.Max(2, 1);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            var result = _math.Max(1, 2);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_ArgumentAreEqual_ReturnTheSameArgument()
        {
            var result = _math.Max(1, 1);
            Assert.That(result, Is.EqualTo(1));
        }

        //Parameterized Test for Max method
        //Below is More Generic Test for Max method

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnsTheGreatestArgument(int a, int b, int expextedResult)
        {
            var result = _math.Max(a, b);
            Assert.That(result, Is.EqualTo(expextedResult));
        }


        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            //General
            //Assert.That(result, Is.Not.Empty);
            //Assert.That(result.Count(), Is.EqualTo(3));

            //Specific
            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));

            //More Specific
            //Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 })); // This will pass even if the order of numbers is not correct.
            Assert.That(result, Is.EqualTo(new[] { 1, 3, 5 })); // This will fail if the order of numbers is not correct.

            //Assert.That(result, Is.Ordered); // This will pass if the numbers are in ascending order.
            //Assert.That(result, Is.Unique); // This will pass if there are no duplicate numbers in the result.
        }
    }
}
