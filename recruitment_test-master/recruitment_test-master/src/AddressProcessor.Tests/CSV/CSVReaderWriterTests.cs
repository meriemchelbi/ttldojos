using System;
using System.IO;
using AddressProcessing.CSV;
using NSubstitute;
using NUnit.Framework;

namespace Csv.Tests
{
    [TestFixture]
    public class CSVReaderWriterTests
    {
        private const string _testFile = @"test_data\contacts.csv";
        private CSVReaderWriter _csvReaderWriter;
        private readonly IWriter _csvWriter = Substitute.For<IWriter>();
        private readonly IReader _csvReader = Substitute.For<IReader>();

        [SetUp]
        public void SetUp()
        {
            _csvReaderWriter = new CSVReaderWriter(_csvWriter, _csvReader);
        }

        [TearDown]
        public void TearDown()
        {
            _csvReaderWriter.Close();
        }

        // how do I make tests for open & close independent from one another? Do I return the filestream?
        // TODO add testing for negative scenario (throw exception)
        [Test]
        public void OpenCallsCorrectOpenMethod()
        {
            _csvReader.Open(_testFile).Returns(true);
            var result = _csvReaderWriter.Open(_testFile, CSVReaderWriter.Mode.Read);

            Assert.IsTrue(result);
        }

        [Test]
        public void OpenWriteModeCallsCSVWriter()
        {
            _csvWriter.Open(_testFile).Returns(true);
            var result = _csvReaderWriter.Open(_testFile, CSVReaderWriter.Mode.Write);

            Assert.IsTrue(result);
        }

        [Test]
        public void ReadCallsCorrectReadMethod()
        {
            _csvReader.Read().Returns(true);
            _csvReader.Read(out string name, out string address).Returns(false);
            var result = _csvReaderWriter.Read("name", "address");

            Assert.IsTrue(result);
        }

        [Test]
        public void ReadOverloadCallsCorrectReadMethod()
        {
            _csvReader.Read().Returns(false);
            _csvReader.Read(out Arg.Any<string>(), out Arg.Any<string>())
                .Returns(x =>
                {
                    x[0] = "wibble";
                    x[1] = "wobble";
                    return true;
                });
            var result = _csvReaderWriter.Read(out var name, out var address);

            Assert.IsTrue(result);
            Assert.AreEqual(name, "wibble");
            Assert.AreEqual(address, "wobble");
        }

        //TODO work out whether tests for void methods required for a decorator like this
    }
}
