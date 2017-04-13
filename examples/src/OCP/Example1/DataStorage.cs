using System;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace SolidPrinciples.OCP.Example1
{
    public abstract class DataStorageBase
    {
        public abstract string GetData(string key);

        public abstract void SaveData(string data, string key);
    }

    public class FileSystemDataStorage : DataStorageBase
    {
        public override string GetData(string key)
        {
            using (var sourceStream = File.OpenRead(key))
            using (var sourceStreamReader = new StreamReader(sourceStream))
            {
                return sourceStreamReader.ReadToEnd();
            }
        }

        public override void SaveData(string data, string key)
        {
            using (var outputStream = File.Open(key, FileMode.Create, FileAccess.Write))
            using (var outputStreamWriter = new StreamWriter(outputStream))
            {
                outputStreamWriter.Write(data);
            }
        }
    }

    public class AzureBlobDataStorage : DataStorageBase
    {
        private readonly CloudBlobClient _blobClient;

        public AzureBlobDataStorage(string storageAccount, string storageKey)
        {
            var account = new CloudStorageAccount(new StorageCredentials(storageAccount, storageKey), true);
            _blobClient = account.CreateCloudBlobClient();
        }

        public override string GetData(string key)
        {
            // ToDo: download string from blob storage

            return null;
        }

        public override void SaveData(string data, string key)
        {
            // ToDo: upload string to blob storage
        }
    }

    public class HttpDataRetriever : DataStorageBase
    {
        public override string GetData(string key)
        {
            // ToDo: download data from some public site

            return null;
        }

        public override void SaveData(string data, string key)
        {
            throw new NotSupportedException();
        }
    }
}
