using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AddressProcessing.CSV;
using NUnit.Framework;

namespace Csv.Tests
{
    [TestFixture]
    public class CSVReaderWriterTests
    {
        private const string _testFile = @"test_data\contacts.csv";
        private CSVReaderWriter _csvReaderWriter;

        [SetUp]
        public void SetUp()
        {
            _csvReaderWriter = new CSVReaderWriter();
        }

        [TearDown]
        public void TearDown()
        {
            _csvReaderWriter.Close();
        }

        // how do I make tests for open & close independent from one another? Do I return the filestream?
        [Datapoint]
        public CSVReaderWriter.Mode read = CSVReaderWriter.Mode.Read;
        [Datapoint]
        public CSVReaderWriter.Mode write = CSVReaderWriter.Mode.Write;

        [Theory]
        public void CloseClosesFile(CSVReaderWriter.Mode mode)
        {
            bool wasClosed;

            _csvReaderWriter.Open(_testFile, mode);
            _csvReaderWriter.Close();
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
        
        [Theory]
        public void OpenOpensFileInModeRequested(CSVReaderWriter.Mode mode)
        {
            _csvReaderWriter.Open(_testFile, mode);
            bool isOpen = false;
            
            try
            {
                FileStream fs =
                    new FileStream(_testFile, FileMode.Open);
                fs.Close();
            }
            catch (IOException)
            {
                isOpen = true;
            }

            Assert.IsTrue(isOpen);
        }
        
        // Why do my tests not run properly when chained but run fine individually? Do I need to use async?
        [Test]
        public void ReadReturnsTrueWhenCSVInputNotEmpty()
        {
            _csvReaderWriter.Open(_testFile, CSVReaderWriter.Mode.Read);
            var column1 = string.Empty;
            var column2 = string.Empty;

            var result = _csvReaderWriter.Read(column1, column2);

            Assert.IsTrue(result);
        }

        [Test]
        public void ReadReturnsFalseWhenCSVInputEmpty()
        {
            var emptyFile = File.Create(@"test_data\EmptyContacts.csv");
            emptyFile.Close();

            _csvReaderWriter.Open(@"test_data\EmptyContacts.csv", CSVReaderWriter.Mode.Read);
            var column1 = string.Empty;
            var column2 = string.Empty;

            var result = _csvReaderWriter.Read(column1, column2);

            Assert.IsFalse(result);
        }
        

        [Test]
        public void ReadOverloadReturnsExpectedValuesWhenCSVInputNotEmpty()
        {
            _csvReaderWriter.Open(_testFile, CSVReaderWriter.Mode.Read);
            var result = _csvReaderWriter.Read(out string column1, out string column2);

            Assert.IsTrue(result);
            Assert.AreEqual("Shelby Macias", column1);
            Assert.AreEqual("3027 Lorem St.|Kokomo|Hertfordshire|L9T 3D5|England", column2);
        }

        [Test]
        public void ReadOverloadReturnsFalseWhenCSVInputEmpty()
        {
            var emptyFile = File.Create(@"test_data\EmptyContacts.csv");
            emptyFile.Close();
            _csvReaderWriter.Open(@"test_data\EmptyContacts.csv", CSVReaderWriter.Mode.Read);
            var result = _csvReaderWriter.Read(out string column1, out string column2);

            Assert.IsFalse(result);
            Assert.AreEqual(null, column1);
            Assert.AreEqual(null, column2);
        }
        
        [Test]
        public void ReadOverloadReturnsFalseWhenCSVLineBlank()
        {
            // do I need a test for a single empty line? What's the best way of going about this? Feels like reading the same file each time is ineffective
        }

        [Test]
        public void WriteReturnsTabDelimitedConcatenatedStringInput()
        {
            // how do I even test this??
            _csvReaderWriter.Open(_testFile, CSVReaderWriter.Mode.Write);
            _csvReaderWriter.Write();
        }

    }
}
