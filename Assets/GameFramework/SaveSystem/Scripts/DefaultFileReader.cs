using System.IO;
using MyCompany.GameFramework.SaveSystem.Interfaces;

namespace MyCompany.GameFramework.SaveSystem
{
    public class DefaultFileReader : IFileReader
    {
        public byte[] Read(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            else
            {
                return null;
            }
        }
    }
}
