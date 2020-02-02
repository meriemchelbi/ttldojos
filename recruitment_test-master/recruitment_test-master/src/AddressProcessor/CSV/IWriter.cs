using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressProcessing.CSV
{
    public interface IWriter
    {
        bool Open(string filename);

        void Close();

        void Write(params string[] columns);
    }
}
