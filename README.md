# Mananged System Identities and Storage Account Access Code Demo

## Setup

- Deploy a VM, Storage account and Web App to a resource group in Azure
- From the Azure porta, create a system managed identity for the Web App and the VM
- Go to the storage account and grant the role of Storage Account Contributor and Storage Blob Data Contributor to the MSI for the VM and Web App
- Access and install VS2019 on the VM
- Create a solution with two projects (console and MVC app) based on the code at this link:
  - https://docs.microsoft.com/en-us/azure/storage/common/storage-auth-aad-msi
> **Note:** Testing of the console app has to be done from the VM with the MSI. Otherwise, the test will fail.
- Run amd test the console app
- Deploy the web app to the app service, and test the app
