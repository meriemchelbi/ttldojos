using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressProcessing.FileOperations
{
    public static class CloseExtensions
    {
        public static void Close(this IReadFile reader)
        {
            reader.Close();
        }

        public static void Close(this IWriteToFile writer)
        {
            throw new NotImplementedException();
        }
    }
}
