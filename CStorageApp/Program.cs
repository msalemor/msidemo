using Azure;
using Azure.Identity;
using Azure.Storage.Blobs;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CStorageApp
{
    class Program
    {
        static string accountName = "mystorageacct";
        static string containerName = "consolecontainer";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            await CreateBlockBlobAsync(accountName, containerName);
        }

        async static Task CreateBlockBlobAsync(string accountName, string containerName)
        {
            // Construct the blob container endpoint from the arguments.
            string containerEndpoint = $"https://{accountName}.blob.core.windows.net/{containerName}";

            // Get a credential and create a client object for the blob container.
            var credential = new DefaultAzureCredential();
            BlobContainerClient containerClient = new BlobContainerClient(new Uri(containerEndpoint),
                                                                            credential);

            try
            {
                // Create the container if it does not exist.
                await containerClient.CreateIfNotExistsAsync();

                // Upload text to a new block blob.
                string blobContents = "This is a block blob.";
                byte[] byteArray = Encoding.ASCII.GetBytes(blobContents);

                using (MemoryStream stream = new MemoryStream(byteArray))
                {
                    var blobName = System.Environment.TickCount.ToString() + ".txt";
                    await containerClient.UploadBlobAsync(blobName, stream);
                }
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }
    }
}
