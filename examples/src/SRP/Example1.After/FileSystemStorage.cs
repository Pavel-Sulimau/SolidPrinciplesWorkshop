using System.IO;

namespace SolidPrinciples.SRP.Example1.After
{
    public class FileSystemStorage
    {
        public string GetData(string filePath)
        {
            using (var sourceStream = File.OpenRead(filePath))
            using (var sourceStreamReader = new StreamReader(sourceStream))
            {
                return sourceStreamReader.ReadToEnd();
            }
        }

        public void SaveData(string data, string filePath)
        {
            using (var outputStream = File.Open(filePath, FileMode.Create, FileAccess.Write))
            using (var outputStreamWriter = new StreamWriter(outputStream))
            {
                outputStreamWriter.Write(data);
            }
        }
    }
}
