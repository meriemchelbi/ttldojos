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

        public void ReadReturnsTrueWhenCSVInputNotEmpty()
        {
            _csvReader.Open(_testFile);

            var column1 = string.Empty;
            var column2 = string.Empty;

            var result = _csvReader.Read(column1, column2);

            Assert.IsTrue(result);
        }

        [Test]
        public void ReadReturnsFalseWhenCSVInputEmpty()
        {
            _csvReader.Open(@"test_data\emptyContacts.csv");

            var name = string.Empty;
            var address = string.Empty;

            var result = _csvReader.Read(name, address);
            _csvReader.Close();

            Assert.IsFalse(result);
        }
               
        [Test]
        public void ReadOverloadReturnsExpectedValuesWhenCSVInputNotEmpty()
        {
            _csvReader.Open(_testFile);
            var result = _csvReader.Read(out string column1, out string column2);

            Assert.IsTrue(result);
            Assert.AreEqual("Shelby Macias", column1);
            Assert.AreEqual("3027 Lorem St.|Kokomo|Hertfordshire|L9T 3D5|England", column2);
        }

        [Test]
        public void ReadOverloadReturnsFalseWhenCSVInputEmpty()
        {
            _csvReader.Open(@"test_data\emptyContacts.csv");
            var result = _csvReader.Read(out string column1, out string column2);
            _csvReader.Close();

            Assert.IsFalse(result);
            Assert.AreEqual(null, column1);
            Assert.AreEqual(null, column2);
        }

        [Test]
        public void ReadOverloadReturnsFalseWhenCSVLineBlank()
        {
            _csvReader.Open(@"test_data\contactsEmptyLine.csv");
            var result = _csvReader.Read(out string name, out string address);
            _csvReader.Close();

            Assert.IsFalse(result);
            Assert.AreEqual(null, name);
            Assert.AreEqual(null, address);
        }
    }
}
