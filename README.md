# Mananged System Identities and Storage Account Access Code Demo

## Setup

- Deploy a VM, Storage account and Web App to a resource group
- Create a system managed identity for the Web App and the VM
- Grant the role of Storage Account Contributor and Storage Blob Data Contributor to the MI for the VM and Web App
- Access and install VS2019 on the VM
> **Note:** Testing of the console app has to be done from the VM with the MSI. Otherwise, the test will fail.
- Create a solution with two projects (console and MVC app) based on the code at this link:
  - https://docs.microsoft.com/en-us/azure/storage/common/storage-auth-aad-msi
- Run the console app
- Deploy the web app to the app service, and test the app
