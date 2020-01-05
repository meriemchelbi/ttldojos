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

        //[Test]
        //public void ComposeContactLineReturnsExpectedString()
        //{
        //    var stream = new MemoryStream();
        //    _csvWriter.Write("Test", "my", "stuff");
        //    var actual = Encoding.UTF8.GetString(stream.ToArray());
        //    Assert.AreEqual("Test   my  stuff", actual);
        //}
    }
}
