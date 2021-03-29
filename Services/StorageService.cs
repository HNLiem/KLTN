
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IStorageService
    {

        Task DeleteBlob(string filePath, string containerName);
        Task UploadBlob(string filePath, Stream formFile, string containerName, string type);
        Task DeleteDirectory(string filePath, string containerName);
        Task<string> GetSAS(string filePath, string containerName);
        Task<Boolean> CheckBlob(string filePath, string containerName);
        
    }
    public class StorageService : IStorageService
    {
        public readonly CloudStorageAccount _storageAccount;
        public StorageService(IConfiguration configuration)
        {
            var storageConnectionString = configuration["ConnectionStrings:AzureStorageConnectionString"];
            if (CloudStorageAccount.TryParse(storageConnectionString, out CloudStorageAccount storageAccount))
            {
                _storageAccount = storageAccount;
            }           
        }

        public async Task DeleteDirectory(string filePath, string containerName)
        {
            CloudBlobClient blobClient = _storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);

            foreach (IListBlobItem blob in blobContainer.GetDirectoryReference(filePath).ListBlobs(true))
            {
                if (blob.GetType() == typeof(CloudBlob) || blob.GetType().BaseType == typeof(CloudBlob))
                {
                    await ((CloudBlob)blob).DeleteIfExistsAsync();
                }
            }
        }

        public async Task DeleteBlob(string filePath, string containerName)
        {
            CloudBlobClient blobClient = _storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);

            var cloudBlobDirectory = blobContainer.GetBlockBlobReference(filePath);
            await cloudBlobDirectory.DeleteIfExistsAsync();
        }

        public async Task<string> GetSAS(string filePath, string containerName)
        {
            CloudBlobClient blobClient = _storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);

            await blobContainer.CreateIfNotExistsAsync();

            SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy()
            {
                Permissions = SharedAccessBlobPermissions.Create 
                            | SharedAccessBlobPermissions.Write,
                SharedAccessStartTime = DateTime.UtcNow,
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(30)               
            };

            var picBlob = blobContainer.GetBlockBlobReference(filePath);

            return $"{picBlob.Uri}{picBlob.GetSharedAccessSignature(sasConstraints)}";
        }

        public async Task UploadBlob(string filePath, Stream stream, string containerName, string type)
        {
            CloudBlobClient blobClient = _storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);

            await blobContainer.CreateIfNotExistsAsync();

            var temp = blobContainer.GetBlockBlobReference(filePath);
            temp.Properties.ContentType = type;

            await temp.UploadFromStreamAsync(stream);
        }

        public async Task<bool> CheckBlob(string filePath, string containerName)
        {
            CloudBlobClient blobClient = _storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);

            var cloudBlobDirectory = blobContainer.GetBlockBlobReference(filePath);
            return await cloudBlobDirectory.ExistsAsync();
        }
    }
}
