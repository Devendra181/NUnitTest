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
    public class ErrorLoggerTests
    {

        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            var logger = new ErrorLogger();

            logger.Log("a");

            //here we are testing the LastError property of the logger object to see if it is set to "a"
            //after calling the Log method with "a" as an argument.

            Assert.That(logger.LastError, Is.EqualTo("a"));
        }
    }
}
