﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Services.AppAuthentication;
using WStorageApp.Models;

namespace WStorageApp.Controllers
{

    public class HomeController : Controller
    {
        static string accountName = "mystoractacct";
        static string containerName = "webcontainer";

        public async Task<IActionResult> Index()
        {
            var newFile = await CreateBlockBlobAsync(accountName, containerName);
            ViewData["File"] = newFile;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        async Task<string> CreateBlockBlobAsync(string accountName, string containerName)
        {
            string rval = string.Empty;
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
                    rval = blobName;
                }
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
            return rval;
        }

        //private async Task<string> GetAccessTokenAsync()
        //{
        //    var tokenProvider = new AzureServiceTokenProvider();
        //    return await tokenProvider.GetAccessTokenAsync("https://storage.azure.com/");
        //}

    }
}
