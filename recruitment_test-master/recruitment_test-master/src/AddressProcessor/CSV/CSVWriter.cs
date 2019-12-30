using System.IO;

namespace AddressProcessing.CSV
{
    public class CSVWriter
    {
        // removed initialisation to null as null by default
        private StreamWriter _streamWriter;

        public StreamWriter Open(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);
            return _streamWriter = fileInfo.CreateText();
        }
        
        public void Close()
        {
            if (_streamWriter != null)
            {
                _streamWriter.Close();
            }
        }

        public void Write(params string[] columns)
        {
            string outPut = "";

            for (int i = 0; i < columns.Length; i++)
            {
                outPut += columns[i];
                if ((columns.Length - 1) != i)
                {
                    outPut += "\t";
                }
            }

            WriteLine(outPut);
        }

        private void WriteLine(string line)
        {
            _streamWriter.WriteLine(line);
        }
    }
}
