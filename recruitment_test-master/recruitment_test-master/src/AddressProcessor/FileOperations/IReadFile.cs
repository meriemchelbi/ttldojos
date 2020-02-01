namespace AddressProcessing.FileOperations
{
    public interface IReadFile
    {
        bool Read();
        bool Read(out string name, out string address);
    }
}
