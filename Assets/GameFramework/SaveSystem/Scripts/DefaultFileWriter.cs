using System.IO;
using MyCompany.GameFramework.SaveSystem.Interfaces;

namespace MyCompany.GameFramework.SaveSystem
{
	public class DefaultFileWriter : IFileWriter
	{
		public void Write(byte[] data, string path)
		{
			File.WriteAllBytes(path, data);
		}
	}
}
