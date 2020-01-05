using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressProcessing.FileOperations
{
    public class FileOpener : IOpenFile
    {
        public StreamReader OpenRead(string filename)
        {
            return File.OpenText(filename);
        }

        public StreamWriter OpenWrite(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);
            return fileInfo.CreateText();
        }
    }
}
