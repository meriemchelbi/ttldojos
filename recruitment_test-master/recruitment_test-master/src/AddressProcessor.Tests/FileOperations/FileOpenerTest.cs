using System.IO;
using AddressProcessing.FileOperations;
using FluentAssertions;
using NUnit.Framework;

namespace AddressProcessing.Tests.FileOperations
{
    [TestFixture]
    public class FileOpenerTest
    {
        private const string _testFile = @"test_data\contacts.csv";
        private FileOpener _fileOpener;

        [SetUp]
        public void SetUp()
        {
            _fileOpener = new FileOpener();
        }

        [Test]
        public void OpenReadReturnsStreamReader()
        {
            var result = _fileOpener.OpenRead(_testFile);
            result.Close();

            result.Should().BeOfType(typeof(StreamReader));
        }

        [Test]
        public void OpenWriteReturnsStreamWriter()
        {
            var result = _fileOpener.OpenWrite(_testFile);
            result.Close();

            result.Should().BeOfType(typeof(StreamWriter));
        }
    }
}
