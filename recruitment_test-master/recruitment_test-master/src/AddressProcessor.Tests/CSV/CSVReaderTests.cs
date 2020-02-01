using System.IO;
using AddressProcessing.CSV;
using NUnit.Framework;

namespace Csv.Tests
{
    [TestFixture]
    public class CSVReaderTests
    {
        private const string _testFile = @"test_data\contacts.csv";
        private CSVReader _csvReader;
        private StreamReader _streamReader;

        [SetUp]
        public void SetUp()
        {
            _streamReader = File.OpenText(_testFile);
            _csvReader = new CSVReader(_streamReader);
        }

        [TearDown]
        public void TearDown()
        {
            _streamReader.Close();
        }

        [TestCase(_testFile, true)]
        [TestCase(@"test_data\emptyContacts.csv", false)]
        [TestCase(@"test_data\contactsEmptyLine.csv", false)]
        public void ReadReturnsExpectedResultWithDifferentContactsData(string fileName, bool expectedResult)
        {
            var streamReader = File.OpenText(fileName);
            var csvReader = new CSVReader(streamReader);
            var result = csvReader.Read();

            Assert.AreEqual(expectedResult, result);
        }
               
        [TestCase(_testFile, true, "Shelby Macias", "3027 Lorem St.|Kokomo|Hertfordshire|L9T 3D5|England")]
        [TestCase(@"test_data\emptyContacts.csv", false, null, null)]
        [TestCase(@"test_data\contactsEmptyLine.csv", false, null, null)]
        public void ReadOverloadReturnsExpectedValuesWhenCSVInputNotEmpty(string fileName, bool expectedResult, string expectedName, string expectedAddress)
        {
            var streamReader = File.OpenText(fileName);
            var csvReader = new CSVReader(streamReader);
            var result = csvReader.Read(out string name, out string address);

            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedName, name);
            Assert.AreEqual(expectedAddress, address);
        }
    }
}
