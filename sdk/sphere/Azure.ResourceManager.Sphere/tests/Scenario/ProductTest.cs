// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.Sphere.Models;
using System;

namespace Azure.ResourceManager.Sphere.Tests.Scenario
{
    internal class ProductsTests : SphereManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;
        private string _subscriptionId;
        private string _resourceGroupName;
        private string _catalogName;
        public ProductsTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            _subscriptionId = GlobalClient.GetDefaultSubscriptionAsync().Result.Data.Id.SubscriptionId;
            _resourceGroupName = "sdkTestRG";
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroupAsync(_resourceGroupName);
            _resourceGroupIdentifier = rgLro.Value.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await Client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        public async Task CreateProductAsync()
        {
            // First create the catalog
            _catalogName = Recording.GenerateAssetName("catalog-");
            CatalogData data = new CatalogData("global");
            ArmOperation<CatalogResource> catalog = await _resourceGroup.GetCatalogs().CreateOrUpdateAsync(WaitUntil.Completed, _catalogName, data);

            // Verify that the catalog has been created
            Assert.IsNotNull(catalog);
            Assert.AreEqual(_catalogName, catalog.Value.Data.Name);

            // Then create the Product
            string productName = "testProduct";
            ProductData productData = new ProductData();
            productData.Description = "A test product";
            Task<ArmOperation<ProductResource>> createdProduct = catalog.Value.GetProducts().CreateOrUpdateAsync(WaitUntil.Completed, productName, productData);

            // Verify that the Product Create was a success
            Assert.IsNotNull(createdProduct);
            Assert.AreEqual(createdProduct.Result.Value.Data.Name, productName,
                $"The expected product name: '{productName}' does not match the actual product name: '{createdProduct.Result.Value.Data.Name}'");
            Assert.AreEqual(createdProduct.Result.Value.Data.Description, productData.Description,
                $"The expected product description: '{productData.Description}' does not match the actual product description: '{createdProduct.Result.Value.Data.Name}'");

            // Fetch the Product
            Response<ProductResource> fetchedProduct = await Client.GetProductResource(createdProduct.Result.Value.Id).GetAsync();

            // Verify we fetched the right product
            Assert.IsNotNull(fetchedProduct);
            Assert.AreEqual(fetchedProduct.Value.Data.Id, createdProduct.Result.Value.Id,
                "The expected product Id does not match the actual product Id");

            // Update the Product
            ProductData productPatch = new ProductData
            {
                Description = "A new test description"
            };
            var updatedProduct = await catalog.Value.GetProducts().CreateOrUpdateAsync(WaitUntil.Completed, productName, productPatch);

            // Verify that the product has been updated
            Assert.IsNotNull(createdProduct);
            Assert.AreEqual(productPatch.Description, updatedProduct.Value.Data.Description,
                $"The expected product description: '{productPatch.Description}' does not match the actual product description: '{updatedProduct.Value.Data.Description}'");
        }

        [TearDown]
        public async Task CleanupAsync()
        {
            // Delete the catalog
            var catalog = await CreateCatalog(_resourceGroup, _catalogName);
            bool flag = await _resourceGroup.GetCatalogs().ExistsAsync(_catalogName);
            Assert.IsTrue(flag);
            await catalog.DeleteAsync(WaitUntil.Completed);
            flag = await _resourceGroup.GetCatalogs().ExistsAsync(_catalogName);
            Assert.IsFalse(flag);
        }
    }
}
