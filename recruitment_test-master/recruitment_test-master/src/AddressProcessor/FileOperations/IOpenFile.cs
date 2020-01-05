using System.IO;

namespace AddressProcessing.FileOperations
{
    public interface IOpenFile
    {
        StreamReader OpenRead(string filename);
        StreamWriter OpenWrite(string filename);
    }
}
