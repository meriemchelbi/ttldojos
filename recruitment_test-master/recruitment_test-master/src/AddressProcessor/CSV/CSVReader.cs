using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace AddressProcessing.CSV
{
    public class CSVReader: IDisposable
    {
        // removed initialisation to null as null by default
        private StreamReader _readerStream;
        private bool _disposed;
        readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

        public object Open(string fileName)
        {
            return _readerStream = File.OpenText(fileName);
        }
        
        public void Close()
        {
             _readerStream?.Close();
            Dispose();
        }

        public bool Read()
        {
            // simplified by calling other Read method 
            return Read(out var name, out var address);
        }

        // renamed parameters for clarity
        public bool Read(out string name, out string address)
        {
            // removed reference to Readline private method as doesn't add value splitting it out
            var columns = _readerStream.ReadLine()?.Split('\t');

            //would clarify requirements- do we want to return 'false' if no address provided? Assumed yes to tweaked length validation
            if (columns == null || columns.Length <= 2)
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
