using System;
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

        [SetUp]
        public void SetUp()
        {
            _csvReader = new CSVReader();
            
        }

        [TearDown]
        public void TearDown()
        {
            _csvReader.Close();
        }

        [Test]
        public void OpensOpensFile()
        {
            bool isOpen = false;
            _csvReader.Open(_testFile);

            try
            {
                FileStream fs = new FileStream(_testFile, FileMode.Open);
                fs.Close();
            }
            catch (IOException)
            {
                isOpen = true;
            }

            Assert.IsTrue(isOpen);
        }

        [Test]
        public void CloseClosesFile()
        {
            bool wasClosed;
            _csvReader.Open(_testFile);
            _csvReader.Close();

            try
            {
                FileStream fs =
                    new FileStream(_testFile, FileMode.Open);
                wasClosed = true;
                fs.Close();
            }
            catch (Exception)
            {
                wasClosed = false;
            }

            Assert.IsTrue(wasClosed);
        }

        [TestCase(_testFile, true)]
        [TestCase(@"test_data\emptyContacts.csv", false)]
        [TestCase(@"test_data\contactsEmptyLine.csv", false)]
        public void ReadReturnsExpectedResultWithDifferentContactsData(string fileName, bool expectedResult)
        {
            _csvReader.Open(fileName);

            var result = _csvReader.Read();

            Assert.AreEqual(expectedResult, result);
        }
               
        [TestCase(_testFile, true, "Shelby Macias", "3027 Lorem St.|Kokomo|Hertfordshire|L9T 3D5|England")]
        [TestCase(@"test_data\emptyContacts.csv", false, null, null)]
        [TestCase(@"test_data\contactsEmptyLine.csv", false, null, null)]
        public void ReadOverloadReturnsExpectedValuesWhenCSVInputNotEmpty(string fileName, bool expectedResult, string expectedName, string expectedAddress)
        {
            _csvReader.Open(fileName);
            var result = _csvReader.Read(out string name, out string address);

            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedName, name);
            Assert.AreEqual(expectedAddress, address);
        }
    }
}
