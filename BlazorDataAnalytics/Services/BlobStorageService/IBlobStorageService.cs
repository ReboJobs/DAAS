
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using BlazorDataAnalytics.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using Parquet;
using Persistence.Config.Entities;


namespace BlazorDataAnalytics.Services.BlobStorageService
{

    public interface IBlobStorageService
    {
        Task<string> UploadFileToBlob(FileUploadModel fileUploadModel);
        Task DeleteBlobData(string fileUrl, string container, string subDirectory);
        Task<List<ParquetData>> GetAzureStorageContainerData(string praquetPath);
        List<BlobItem> getBlobFilesAsync();
    }
}
    