using System.IO;
using Microsoft.WindowsAzure.Storage.Blob;

namespace SolidPrinciples.DIP.Example1
{
    public interface IDataRetriever
    {
        string GetData(string key);
    }

    public interface IDataPersister
    {
        void SaveData(string data, string key);
    }

    public abstract class DataStorageBase : IDataRetriever, IDataPersister
    {
        public abstract string GetData(string key);

        public abstract void SaveData(string data, string key);
    }

    public class FileSystemStorage : DataStorageBase
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

    public class AzureBlobStorage : DataStorageBase
    {
        private readonly CloudBlobClient _blobClient;

        public AzureBlobStorage(string storageAccount, string storageKey)
        {
        }

        public override string GetData(string fileName)
        {
            // ToDo: download string from blob storage

            return null;
        }

        public override void SaveData(string serializedDocument, string targetFileName)
        {
            // ToDo: upload string to blob storage
        }
    }

    public class HttpDataRetriever : IDataRetriever
    {
        public string GetData(string fileName)
        {
            // ToDo: download data from some public site

            return null;
        }
    }
}
