using System;

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
