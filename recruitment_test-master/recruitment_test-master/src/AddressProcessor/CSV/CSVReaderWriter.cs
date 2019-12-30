using System;

namespace AddressProcessing.CSV
{
    /*
        2) Refactor this class into clean, elegant, rock-solid & well performing code, without over-engineering.
           Assume this code is in production and backwards compatibility must be maintained.
    */

    public class CSVReaderWriter
    {
        private readonly CSVReader _csvReader;
        private readonly CSVWriter _csvWriter;

        // read only fields so only one file associated with an instance of the ReaderWriter
        public CSVReaderWriter()
        {
            _csvReader = new CSVReader();
            _csvWriter = new CSVWriter();
        }

        [Flags]
        public enum Mode { Read = 1, Write = 2 };

        public object Open(string fileName, Mode mode)
        {
            object stream;
            if (mode == Mode.Read)
            {
                stream = _csvReader.Open(fileName);
            }
            else if (mode == Mode.Write)
            {
                stream = _csvWriter.Open(fileName);
            }
            else
            {
                throw new Exception("Unknown file mode for " + fileName);
            }

            return stream;
        }

        public bool Read(string name, string address)
        {
            return _csvReader.Read(name, address);
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
            if (_csvWriter != null)
            {
                _csvWriter.Close();
            }
            if (_csvReader != null)
            {
                _csvReader.Close();
            }
        }
    }
}
