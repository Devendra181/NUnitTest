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
    }
}
