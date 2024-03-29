# Mananged System Identities and Storage Account Access Code Demo

Use Mananged System Identities (MSI) to authenticate to any service that supports Azure AD authentication, including Key Vault, **without any credentials in your code.**

## About this code demo

This demo creates a container and blobs on a VM and App Service having MSIs and no credentials.

## Setup

- Deploy a VM, Storage account and Web App to a resource group in Azure
- From the Azure portal, create a system managed identity for the Web App and the VM
- Go to the storage account and grant the role of Storage Account Contributor and Storage Blob Data Contributor to the MSIs for the VM and Web App
- Access and install Visual Studio 2019 on the VM
- Clone this repo and open the solution
- Test the console app in the VM
> **Note:** Testing of the console app has to be done from the VM with the MSI. Otherwise, the test will fail.
- Deploy the web app to the app service, and test the app

## How does it work

```c#
// Get a credential 
var credential = new DefaultAzureCredential();
// Create a client object for the blob container with the credentail
BlobContainerClient containerClient = new BlobContainerClient(new Uri(containerEndpoint), credential);
```                                                                            

## More Information

https://docs.microsoft.com/en-us/azure/storage/common/storage-auth-aad-msi
