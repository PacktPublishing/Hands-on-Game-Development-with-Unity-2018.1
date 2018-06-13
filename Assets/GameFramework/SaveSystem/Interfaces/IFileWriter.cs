namespace MyCompany.GameFramework.SaveSystem.Interfaces
{
    public interface IFileWriter
    {
        void Write(byte[] data, string path);
    }
}
