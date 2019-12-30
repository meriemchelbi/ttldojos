using System.IO;

namespace AddressProcessing.CSV
{
    public class CSVReader
    {
        // removed initialisation to null as null by default
        private StreamReader _readerStream;

        public object Open(string fileName)
        {
            return _readerStream = File.OpenText(fileName);
        }
        public void Close()
        {
            if (_readerStream != null)
            {
                _readerStream.Close();
            }
        }

        public bool Read(string name, string address)
        {
            const int FIRST_COLUMN = 0;
            const int SECOND_COLUMN = 1;

            string line;
            string[] columns;

            char[] separator = { '\t' };

            line = ReadLine();

            if (line == null)
            {
                return false;
            }
            // add null checking here- if line null blows up
            columns = line.Split(separator);
                       
            if (columns.Length == 1)
            {
                name = null;
                address = null;

                return false;
            }
            else
            {
                name = columns[FIRST_COLUMN];
                address = columns[SECOND_COLUMN];

                return true;
            }
        }

        public bool Read(out string column1, out string column2)
        {
            const int FIRST_COLUMN = 0;
            const int SECOND_COLUMN = 1;

            string line;
            string[] columns;

            char[] separator = { '\t' };

            line = ReadLine();

            if (line == null)
            {
                column1 = null;
                column2 = null;

                return false;
            }

            columns = line.Split(separator);

            if (columns.Length == 1)
            {
                column1 = null;
                column2 = null;

                return false;
            }
            else
            {
                column1 = columns[FIRST_COLUMN];
                column2 = columns[SECOND_COLUMN];

                return true;
            }
        }

        private string ReadLine()
        {
            return _readerStream.ReadLine();
        }

    }
}
