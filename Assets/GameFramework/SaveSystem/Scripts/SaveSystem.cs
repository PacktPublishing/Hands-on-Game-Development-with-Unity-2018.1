using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MyCompany.GameFramework.SaveSystem.Interfaces;
using UnityEngine;

namespace MyCompany.GameFramework.SaveSystem
{
	public class SaveSystem
	{
		private readonly string savePath;
		private IFileWriter fileWriter;
		private IFileReader fileReader;
		
		public SaveSystem(IFileWriter fileWriter, IFileReader fileReader)
		{
			savePath = Application.persistentDataPath + "/save.dat";
			this.fileWriter = fileWriter;
			this.fileReader = fileReader;
		}

		public SaveSystem()
		{
			fileWriter = new DefaultFileWriter();
			fileReader = new DefaultFileReader();
		}

		public T Load<T>() where T : class
		{
			if (!File.Exists(savePath))
			{
				return null;
			}
			using (MemoryStream stream = new MemoryStream(fileReader.Read(savePath)))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				T o = formatter.Deserialize(stream) as T;
				return o;
			}
		}

		public void Save(object data)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (MemoryStream stream = new MemoryStream())
			{
				formatter.Serialize(stream, data);
				byte[] bytes = stream.ToArray();
				fileWriter.Write(bytes, savePath);
			}
		}
	}
}
