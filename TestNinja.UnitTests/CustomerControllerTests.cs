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
    public class CustomerControllerTests
    {

        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            Assert.That(result, Is.TypeOf<NotFound>()); //TypeOf is more specific than InstanceOf because it will fail if the result is a derived class of NotFound.
            Assert.That(result, Is.InstanceOf<NotFound>()); //InstanceOf is more general than TypeOf because it will pass if the result is a derived class of NotFound.


        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {
            var controller = new CustomerController();
            var result = controller.GetCustomer(1);
            Assert.That(result, Is.TypeOf<Ok>());

        }
    }
}
