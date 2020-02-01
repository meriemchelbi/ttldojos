namespace AddressProcessing.FileOperations
{
    public interface IWriteToFile
    {
        void Write(params string[] columns);
    }
}
