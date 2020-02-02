using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressProcessing.CSV
{
    public interface IReader
    {
        bool Open(string fileName);

        void Close();

        bool Read();

        bool Read(out string name, out string address);
    }
}
