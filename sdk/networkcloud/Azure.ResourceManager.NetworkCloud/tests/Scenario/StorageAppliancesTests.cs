// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetworkCloud.Tests.ScenarioTests
{
    public class StorageAppliancesTests : NetworkCloudManagementTestBase
    {
        public StorageAppliancesTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public StorageAppliancesTests(bool isAsync) : base(isAsync) {}

        [Test]
        public async Task StorageAppliances()
        {
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ClusterManagedRG);
            ResourceGroupResource clusterRGResource = Client.GetResourceGroupResource(resourceGroupResourceId);
            StorageApplianceCollection collection = clusterRGResource.GetStorageAppliances();

            // List by Resource Group
            var listByResourceGroup = new List<StorageApplianceResource>();
            await foreach (var item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // Use first StorageAppliance in list
            var firstStorageAppliance = listByResourceGroup[0].Data;
            string storageApplianceName = firstStorageAppliance.Name;

            // Get
            var getResult = await collection.GetAsync(storageApplianceName);
            Assert.AreEqual(storageApplianceName, getResult.Value.Data.Name);

            // Update
            StorageApplianceResource storageAppliance = Client.GetStorageApplianceResource(new ResourceIdentifier(firstStorageAppliance.Id));
            getResult = await storageAppliance.GetAsync();
            var originalTags = getResult.Value.Data.Tags;
            StorageAppliancePatch patch = new StorageAppliancePatch(){};
            var testKey = "test-key";
            var testValue = "test-value";
            patch.Tags.Add(testKey, testValue);
            foreach (var key in originalTags.Keys)
            {
                patch.Tags.Add(key, originalTags[key]);
            }
            ArmOperation<StorageApplianceResource> updateResult = await storageAppliance.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(patch.Tags, updateResult.Value.Data.Tags);

            patch.Tags.Remove(testKey);
            updateResult = await storageAppliance.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(patch.Tags, updateResult.Value.Data.Tags, "tag reversion failed");

            // List by Subscription
            var listBySubscription = new List<StorageApplianceResource>();
            await foreach (var item in SubscriptionResource.GetStorageAppliancesAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);
        }
    }
}