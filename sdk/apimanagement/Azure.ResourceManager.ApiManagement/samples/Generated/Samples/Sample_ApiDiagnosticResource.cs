// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.ApiManagement;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement.Samples
{
    public partial class Sample_ApiDiagnosticResource
    {
        // ApiManagementHeadApiDiagnostic
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task GetEntityTag_ApiManagementHeadApiDiagnostic()
        {
            // Generated from example definition: specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/examples/ApiManagementHeadApiDiagnostic.json
            // this example is just showing the usage of "ApiDiagnostic_GetEntityTag" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ApiDiagnosticResource created on azure
            // for more information of creating ApiDiagnosticResource, please refer to the document of ApiDiagnosticResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string serviceName = "apimService1";
            string apiId = "57d1f7558aa04f15146d9d8a";
            string diagnosticId = "applicationinsights";
            ResourceIdentifier apiDiagnosticResourceId = ApiDiagnosticResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, serviceName, apiId, diagnosticId);
            ApiDiagnosticResource apiDiagnostic = client.GetApiDiagnosticResource(apiDiagnosticResourceId);

            // invoke the operation
            bool result = await apiDiagnostic.GetEntityTagAsync();

            Console.WriteLine($"Succeeded: {result}");
        }

        // ApiManagementGetApiDiagnostic
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Get_ApiManagementGetApiDiagnostic()
        {
            // Generated from example definition: specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/examples/ApiManagementGetApiDiagnostic.json
            // this example is just showing the usage of "ApiDiagnostic_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ApiDiagnosticResource created on azure
            // for more information of creating ApiDiagnosticResource, please refer to the document of ApiDiagnosticResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string serviceName = "apimService1";
            string apiId = "57d1f7558aa04f15146d9d8a";
            string diagnosticId = "applicationinsights";
            ResourceIdentifier apiDiagnosticResourceId = ApiDiagnosticResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, serviceName, apiId, diagnosticId);
            ApiDiagnosticResource apiDiagnostic = client.GetApiDiagnosticResource(apiDiagnosticResourceId);

            // invoke the operation
            ApiDiagnosticResource result = await apiDiagnostic.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DiagnosticContractData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // ApiManagementUpdateApiDiagnostic
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Update_ApiManagementUpdateApiDiagnostic()
        {
            // Generated from example definition: specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/examples/ApiManagementUpdateApiDiagnostic.json
            // this example is just showing the usage of "ApiDiagnostic_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ApiDiagnosticResource created on azure
            // for more information of creating ApiDiagnosticResource, please refer to the document of ApiDiagnosticResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string serviceName = "apimService1";
            string apiId = "echo-api";
            string diagnosticId = "applicationinsights";
            ResourceIdentifier apiDiagnosticResourceId = ApiDiagnosticResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, serviceName, apiId, diagnosticId);
            ApiDiagnosticResource apiDiagnostic = client.GetApiDiagnosticResource(apiDiagnosticResourceId);

            // invoke the operation
            ETag ifMatch = new ETag("*");
            DiagnosticContractData data = new DiagnosticContractData()
            {
                AlwaysLog = AlwaysLog.AllErrors,
                LoggerId = "/loggers/applicationinsights",
                Sampling = new SamplingSettings()
                {
                    SamplingType = SamplingType.Fixed,
                    Percentage = 50,
                },
                Frontend = new PipelineDiagnosticSettings()
                {
                    Request = new HttpMessageDiagnostic()
                    {
                        Headers =
{
"Content-type"
},
                        BodyBytes = 512,
                    },
                    Response = new HttpMessageDiagnostic()
                    {
                        Headers =
{
"Content-type"
},
                        BodyBytes = 512,
                    },
                },
                Backend = new PipelineDiagnosticSettings()
                {
                    Request = new HttpMessageDiagnostic()
                    {
                        Headers =
{
"Content-type"
},
                        BodyBytes = 512,
                    },
                    Response = new HttpMessageDiagnostic()
                    {
                        Headers =
{
"Content-type"
},
                        BodyBytes = 512,
                    },
                },
            };
            ApiDiagnosticResource result = await apiDiagnostic.UpdateAsync(ifMatch, data);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DiagnosticContractData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // ApiManagementDeleteApiDiagnostic
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("Only verifying that the sample builds")]
        public async Task Delete_ApiManagementDeleteApiDiagnostic()
        {
            // Generated from example definition: specification/apimanagement/resource-manager/Microsoft.ApiManagement/stable/2021-08-01/examples/ApiManagementDeleteApiDiagnostic.json
            // this example is just showing the usage of "ApiDiagnostic_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ApiDiagnosticResource created on azure
            // for more information of creating ApiDiagnosticResource, please refer to the document of ApiDiagnosticResource
            string subscriptionId = "subid";
            string resourceGroupName = "rg1";
            string serviceName = "apimService1";
            string apiId = "57d1f7558aa04f15146d9d8a";
            string diagnosticId = "applicationinsights";
            ResourceIdentifier apiDiagnosticResourceId = ApiDiagnosticResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, serviceName, apiId, diagnosticId);
            ApiDiagnosticResource apiDiagnostic = client.GetApiDiagnosticResource(apiDiagnosticResourceId);

            // invoke the operation
            ETag ifMatch = new ETag("*");
            await apiDiagnostic.DeleteAsync(WaitUntil.Completed, ifMatch);

            Console.WriteLine($"Succeeded");
        }
    }
}
