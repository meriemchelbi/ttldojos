using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace AddressProcessing.CSV
{
    public class CSVWriter: IWriter, IDisposable
    {
        // removed initialisation to null as null by default
        private StreamWriter _streamWriter;
        private bool _disposed;
        readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

        public bool Open(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);
            _streamWriter = fileInfo.CreateText();
            return true;
        }
        
        public void Close()
        {
            _streamWriter?.Close();
            Dispose();
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
            // Could also use .Join (Linq)
            var builder = new StringBuilder();
            columns.ToList().ForEach(c => builder.Append($"{c}\t"));
            
            var output = builder.ToString().Trim();

            return output;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _handle.Dispose();
            }

            _disposed = true;
        }
    }
}
