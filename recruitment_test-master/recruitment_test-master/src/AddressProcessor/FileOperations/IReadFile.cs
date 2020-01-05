using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressProcessing.FileOperations
{
    public interface IReadFile
    {
        bool Read();
        bool Read(out string name, out string address);
    }
}
