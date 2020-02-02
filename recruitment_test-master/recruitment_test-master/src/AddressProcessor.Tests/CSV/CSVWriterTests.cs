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
    public class CSVWriterTests
    {
        private const string _testFile = @"test_data\contacts.csv";
        private CSVWriter _csvWriter;

        [SetUp]
        public void SetUp()
        {
            _csvWriter = new CSVWriter();
            _csvWriter.Open(_testFile);
        }

        [TearDown]
        public void TearDown()
        {
            _csvWriter.Close();
        }

        [Test]
        public void CloseClosesFile()
        {
            bool wasClosed;
            _csvWriter.Close();

            try
            {
                FileStream fs = new FileStream(_testFile, FileMode.Open);
                wasClosed = true;
                fs.Close();
            }
            catch (Exception)
            {
                wasClosed = false;
            }

            Assert.IsTrue(wasClosed);
        }

        [Test]
        public void OpenOpensFile()
        {
            bool isOpen = false;
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

        // TODO: add test for Write
        
    }
}
