using System.IO;

namespace SolidPrinciples.SRP.Example1.SRP
{
    public abstract class DataStorage
    {
        public abstract string GetData(string filePath);

        public abstract void SaveData(string data, string filePath);

    }

    public class FileSystemStorage : DataStorage
    {
        public override string GetData(string filePath)
        {
            using (var sourceStream = File.OpenRead(filePath))
            using (var sourceStreamReader = new StreamReader(sourceStream))
            {
                return sourceStreamReader.ReadToEnd();
            }
        }

        public override void SaveData(string data, string filePath)
        {
            using (var outputStream = File.Open(filePath, FileMode.Create, FileAccess.Write))
            using (var outputStreamWriter = new StreamWriter(outputStream))
            {
                outputStreamWriter.Write(data);
            }
        }
    }
}
