using AddressProcessing.FileOperations;
using System;

namespace AddressProcessing.CSV
{
    /*
        2) Refactor this class into clean, elegant, rock-solid & well performing code, without over-engineering.
           Assume this code is in production and backwards compatibility must be maintained.
    */

    public class CSVReaderWriter
    {
        private CSVReader _csvReader;
        private CSVWriter _csvWriter;

        // read only fields so only one file associated with an instance of the ReaderWriter
        public CSVReaderWriter()
        {
            _csvWriter = new CSVWriter();
        }

        [Flags]
        public enum Mode { Read = 1, Write = 2 };

        public void Open(string fileName, Mode mode)
        {
            var fileOpener = new FileOpener();

            switch (mode)
            {
                case Mode.Read:
                    var streamReader = fileOpener.OpenRead(fileName);
                    _csvReader = new CSVReader(streamReader);
                    break;
                case Mode.Write:
                    _csvWriter.Open(fileName);
                    break;
                default:
                    throw new Exception("Unknown file mode for " + fileName);
            }
        }

        public bool Read(string name, string address)
        {
            // removed parameters as not being used. Can't remove from calling method as part of contract
            return _csvReader.Read();
        }

        public bool Read(out string name, out string address)
        {
            return _csvReader.Read(out name, out address);
        }

        // moved private methods readline & writeline, as not consumers' concern 
        public void Write()
        {
            _csvWriter.Write();
        }

        public void Close()
        {
            _csvWriter?.Close();
            _csvReader?.Close();
        }
    }
}
