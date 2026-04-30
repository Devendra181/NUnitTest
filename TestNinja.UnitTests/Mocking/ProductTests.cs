using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class ProductTests
    {

        [Test]
        public void GetPrice_CustomerIsGold_Returns70PercentOfListPrice()
        {
            var product = new Product { ListPrice = 100 };
            var customer = new Customer { IsGold = true };
            var result = product.GetPrice(customer);
            Assert.That(result, Is.EqualTo(70));
        }


        //Below is mock abuse, we are testing the mock instead of the actual code,
        //we should avoid this and use the actual class instead of mock when possible
        [Test]
        public void GetPrice_CustomerIsGold_Returns70PercentOfListPrice2()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(c => c.IsGold).Returns(true);

            var product = new Product { ListPrice = 100 };

            var result = product.GetPrice(customer.Object);

            Assert.That(result, Is.EqualTo(70));
        }


        [Test]
        public void GetPrice_CustomerIsNotGold_ReturnsListPrice()
        {
            var product = new Product { ListPrice = 100 };
            var customer = new Customer { IsGold = false };
            var result = product.GetPrice(customer);
            Assert.That(result, Is.EqualTo(100));
        }

        [Test]
        public void GetPrice_CustomerIsNull_ThrowsArgumentNullException()
        {
            var product = new Product { ListPrice = 100 };
            Assert.That(() => product.GetPrice(null), Throws.ArgumentNullException);
        }
    }
}
