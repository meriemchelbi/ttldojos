using AddressProcessing.FileOperations;
using System.IO;

namespace AddressProcessing.CSV
{
    public class CSVReader : IReadFile
    {
        public CSVReader(StreamReader streamReader)
        {
            _readerStream = streamReader;
        }
        // removed initialisation to null as null by default
        private StreamReader _readerStream;

        public void Close()
        {
            _readerStream?.Close();
        }

        public bool Read()
        {
            // removed reference to Readline private method as doesn't add value splitting it out
            var columns = _readerStream.ReadLine()?.Split('\t');

            return (columns == null || columns.Length <= 2)
                ? false
                : true;
        }

        // renamed parameters for clarity
        public bool Read(out string name, out string address)
        {
            // removed reference to Readline private method as doesn't add value splitting it out
            var columns = _readerStream.ReadLine()?.Split('\t');

            // would clarify requirements- do we want to return 'false' if no address provided? Assumed yes to tweaked length validation
            if (columns == null || columns.Length < 2)
            {
                name = null;
                address = null;

                return false;
            }
            else
            {
                name = columns[0];
                address = columns[1];

                return true;
            }
        }
    }
}
