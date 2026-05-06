using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;
        private const string Destination = "c:\\temp\\setup.msi";

        [SetUp]
        public void Setup()
        {
            //Arrange
            _fileDownloader = new Mock<IFileDownloader>();
           _installerHelper = new InstallerHelper(_fileDownloader.Object);
            //_installerHelper. = Destination;
            // Use reflection to set the private _setupDestinationFile field
            var field = typeof(InstallerHelper).GetField("_setupDestinationFile", BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(_installerHelper, Destination);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnsFalse1()
        {
            _fileDownloader.Setup(fd => fd.DownloadFile("", "")).Throws<WebException>();

            //Act will not work because the parameters are not matching, so we need to use It.IsAny<string>() for both parameters
            var result = _installerHelper.DownloadInstaller("customer", "installer");
            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnsFalse2()
        {
            _fileDownloader.Setup(fd => fd.DownloadFile("http://example.com/customer/installer", null)).Throws<WebException>();

            //Act will work because the parameters are matching, but we need to use It.IsAny<string>() for both parameters to make it more flexible and avoid hardcoding the parameters
            var result = _installerHelper.DownloadInstaller("customer", "installer");
            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnsFalse3()
        {
            _fileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();


            var result = _installerHelper.DownloadInstaller("customer", "installer");
            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_DownloadSucceeds_ReturnsTrue()
        {
            //_fileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()));

            var result = _installerHelper.DownloadInstaller("customer", "installer");
            Assert.That(result, Is.True);
        }

        [Test]
        public void DownloadInstaller_DownloadSucceeds_ReturnsTrueAndCallsDownloader()
        {
            _fileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()));

            var result = _installerHelper.DownloadInstaller("customer", "setup.exe");

            Assert.That(result, Is.True);
            _fileDownloader.Verify(d => d.DownloadFile("http://example.com/customer/setup.exe", null), Times.Once);
        }

        [Test]
        public void DownloadInstaller_DownloadSucceeds_ReturnsTrueAndCallsDownloader2()
        {
            _fileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()));

            var result = _installerHelper.DownloadInstaller("customer", "setup.exe");

            Assert.That(result, Is.True);
            _fileDownloader.Verify(d => d.DownloadFile("http://example.com/customer/setup.exe", Destination), Times.Once);
        }

    }
}
