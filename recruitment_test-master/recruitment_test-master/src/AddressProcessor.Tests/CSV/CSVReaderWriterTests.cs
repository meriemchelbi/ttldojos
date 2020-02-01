using System.IO;
using AddressProcessing.CSV;
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
        // Should I be mocking the call to the fileOpener here?
        // TODO add testing for negative scenario (throw exception)
        [TestCase(CSVReaderWriter.Mode.Read)]
        [TestCase(CSVReaderWriter.Mode.Write)]
        public void OpenOpensFileInCorrectMode(CSVReaderWriter.Mode mode)
        {
            bool isOpen = false;
            _csvReaderWriter.Open(_testFile, mode);
            
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
        
        [TestCase(CSVReaderWriter.Mode.Read)]
        [TestCase(CSVReaderWriter.Mode.Write)]
        public void CloseClosesFile(CSVReaderWriter.Mode mode)
        {
           
            
        }
       
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
