using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using AddressProcessing.FileOperations;

namespace AddressProcessing.CSV
{
    public class CSVWriter : IWriteToFile
    {
        // removed initialisation to null as null by default
        private StreamWriter _streamWriter;

        public void Open(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);
            _streamWriter = fileInfo.CreateText();
        }
        
        public void Close()
        {
            _streamWriter?.Close();
        }

        // Using stringbuilder to reduce memory allocation
        // split out output generation for extensibility
        // removed dependency on WriteLine as didn't add value as a private method
        // not sure how to test?
        public void Write(params string[] columns)
        {
            var output = ComposeContactLine(columns);

            _streamWriter.WriteLine(output);
        }

        private string ComposeContactLine(params string[] columns)
        {
            var builder = new StringBuilder();
            columns.ToList().ForEach(c => builder.Append($"{c}\t"));
            
            var output = builder.ToString().Trim();

            return output;
        }

    }
}
