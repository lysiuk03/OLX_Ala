using Azure.Storage.Blobs;

namespace OLX_Ala.Helpers
{
    public class AzureFileService : IFileService
    {
        private readonly string connectionString;
        private const string containerName = "images";

        public AzureFileService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AzureStorage");
        }

        public async Task<string> SaveAnnouncementImage(IFormFile file)
        {
            var client = new BlobContainerClient(connectionString, containerName);

            await client.CreateIfNotExistsAsync();
            await client.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

            // custom file name
            string name = Guid.NewGuid().ToString();    // random name
            string extension = Path.GetExtension(file.FileName); // get original extension
            string fileName = name + extension;         // full name: name.ext

            BlobClient blob = client.GetBlobClient(fileName);
            await blob.UploadAsync(file.OpenReadStream());
            return blob.Uri.ToString();
        }


        public Task<string> DeleteAnnouncementImage(string path)
        {
            throw new NotImplementedException();
        }
    }
}
