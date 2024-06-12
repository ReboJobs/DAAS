
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;
using MimeTypes;
using System.Data;
using Parquet;
using System.Xml.Linq;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Parquet.Data;

namespace BlazorDataAnalytics.Services.BlobStorageService
{
    public class BlobStorageService : IBlobStorageService
    {
        string QtxdaaasstorageConString = string.Empty;
        string accessKey = string.Empty;
        private readonly IConfiguration _config;

        public BlobStorageService(IConfiguration config)
        {
            this._config = config;
            this.accessKey = _config.GetConnectionString("DAaaSBlobStorageConnection");
            this.QtxdaaasstorageConString = config.GetConnectionString("Qtxdaaasstorage");
        }

        public async Task<string> UploadFileToBlob(FileUploadModel fileUploadModel)
        {
            try
            { 
                string fileUrl = await this.UploadFileToBlobAsync(fileUploadModel);
                return fileUrl;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task DeleteBlobData(string fileUrl, string container, string subDirectory)
        {
            if (string.IsNullOrEmpty(fileUrl))
            {
                return;
            }

            Uri uriObj = new Uri(fileUrl);
            string BlobName = Path.GetFileName(uriObj.LocalPath);

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(accessKey);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(container);

            string pathPrefix = subDirectory + "/";
            CloudBlobDirectory blobDirectory = cloudBlobContainer.GetDirectoryReference(pathPrefix);
            // get block blob refarence    
            CloudBlockBlob blockBlob = blobDirectory.GetBlockBlobReference(BlobName);

            // delete blob from container        
            await blockBlob.DeleteAsync();
        }


        private string GenerateFileName(string fileName, string subDirectory)
        {
            string strFileName = string.Empty;
            string[] strName = fileName.Split('.');
            strFileName = subDirectory + "/" + DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THHmmssfff") + "." + strName[strName.Length - 1];
            return strFileName;
        }

        private async Task<string> UploadFileToBlobAsync(FileUploadModel fileUploadModel)
        {
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(accessKey);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(fileUploadModel.Container);
                string fileName = this.GenerateFileName(fileUploadModel.FileName, fileUploadModel.SubDirectory);

                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                }

                if (fileName != null && fileUploadModel.FileByte != null)
                {
                    string fileMimeType = MimeTypeMap.GetMimeType(fileUploadModel.FileMimeType);
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
                    cloudBlockBlob.Properties.ContentType = fileMimeType;
                    await cloudBlockBlob.UploadFromByteArrayAsync(fileUploadModel.FileByte, 0, fileUploadModel.FileByte.Length);
                    return cloudBlockBlob.Uri.AbsoluteUri;
                }
                return "";
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<BlobItem> getBlobFilesAsync() {
            CloudStorageAccount storageacc = CloudStorageAccount.Parse(QtxdaaasstorageConString);
            List<BlobItem> blobItem = new List<BlobItem>();
            //Create Reference to Azure Blob
            CloudBlobClient blobClient = storageacc.CreateCloudBlobClient();

            //The next 2 lines create if not exists a container named "democontainer"
            CloudBlobContainer container = blobClient.GetContainerReference("qtx-daaas-filesystem");

            BlobServiceClient blobServiceClient = new BlobServiceClient(QtxdaaasstorageConString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("qtx-daaas-filesystem");
 
                foreach ( BlobItem item in containerClient.GetBlobs())
                {
                if(item.Name.ToString().ToUpper().Contains("PARQUET"))
                   blobItem.Add(item); 
                   
                }

            return blobItem;    
            }
        public async Task<List<ParquetData>> GetAzureStorageContainerData(string praquetPath) {

            List<ParquetData> parquetsData = new List<ParquetData>();
            // Create Reference to Azure Storage Account
            CloudStorageAccount storageacc = CloudStorageAccount.Parse(QtxdaaasstorageConString);

            //Create Reference to Azure Blob
            CloudBlobClient blobClient = storageacc.CreateCloudBlobClient();

            //The next 2 lines create if not exists a container named "democontainer"
            CloudBlobContainer container = blobClient.GetContainerReference("qtx-daaas-filesystem");

            BlobServiceClient blobServiceClient = new BlobServiceClient(QtxdaaasstorageConString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("qtx-daaas-filesystem");
            BlobClient blobClient2 = containerClient.GetBlobClient(praquetPath);
            try
            {
                   var response = await blobClient2.DownloadAsync();

                using (MemoryStream ms = new MemoryStream())
                {
                    response.Value.Content.CopyTo(ms);

                    // open parquet file reader
                    using (var parquetReader = new ParquetReader(ms))
                    {
                        // get file schema (available straight after opening parquet reader)
                        // however, get only data fields as only they contain data values
                        DataField[] dataFields = parquetReader.Schema.GetDataFields();

                        var test = parquetReader.ReadAsTable();

                        // enumerate through row groups in this file
                        for (int i = 0; i < parquetReader.RowGroupCount; i++)
                        {
                            // create row group reader
                            using (ParquetRowGroupReader groupReader = parquetReader.OpenRowGroupReader(i))
                            {
                                // read all columns inside each row group (you have an option to read only
                                // required columns if you need to.
                                Parquet.Data.DataColumn[] columns = dataFields.Select(groupReader.ReadColumn).ToArray();
                                foreach (var item in columns) {
                                    ParquetData dataItem = new ParquetData();
                                    dataItem.ColomnName = item.Field.Name;
                                    dataItem.data = item.Data;
                                    dataItem.Url = blobClient2.Uri.ToString();
                                    parquetsData.Add(dataItem);
                                }

                            }
                        }
                    }
                }
                

            }
            catch (Exception ex) { 
            }
            return parquetsData;
        }
    }
    public class ParquetData
    {
        public string ColomnName { get; set; }
        public Array data { get; set; }
        public string Url { get; set; }
    }


}
