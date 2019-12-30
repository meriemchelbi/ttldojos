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
        // not sure how to test this class without making the Reader & Writer properties public so I can substitute them? Feels wrong
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
        // Also not happy with returning value from Open to test method
        [TestCase(CSVReaderWriter.Mode.Read, typeof(StreamReader))]
        [TestCase(CSVReaderWriter.Mode.Write, typeof(StreamWriter))]
        public void OpenCallsCorrectOpenMethod(CSVReaderWriter.Mode mode, Type type)
        {
            var result = _csvReaderWriter.Open(_testFile, mode);

            Assert.AreEqual(type, result.GetType());
        }
        
        [TestCase(CSVReaderWriter.Mode.Read)]
        [TestCase(CSVReaderWriter.Mode.Write)]
        public void CloseCallsCorrectCloseMethod(CSVReaderWriter.Mode mode)
        {
           
            
        }
        
       
        // Tests don't run properly when chained but run fine individually? Do I need to configure the read timeout to be longer?
        [Test]
        public void ReadCallsCorrectReadMethod()
        {

        }

        [Test]
        public void ReadOverloadReturnsExpectedValuesWhenCSVInputNotEmpty()
        {

        }

        [Test]
        public void ReadOverloadCallsCorrectReadMethod()
        {

        }

        [Test]
        public void WriteCallsCorrectWriteMethod()
        {

        }
    }
}
