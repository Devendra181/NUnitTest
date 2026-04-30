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
    public class OrderServiceTests
    {
        private Mock<IStorage> _moqStorage;
        private OrderService _orderService;

        [SetUp]
        public void SetUp()
        {
            _moqStorage = new Mock<IStorage>();
            _orderService = new OrderService(_moqStorage.Object);
        }


        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            var order = new Order();
            _orderService.PlaceOrder(order);
            _moqStorage.Verify(s => s.Store(order)); //verify method is called with the same order object
        }
    }
}
