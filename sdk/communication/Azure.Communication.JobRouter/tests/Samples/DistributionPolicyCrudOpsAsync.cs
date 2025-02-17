﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class DistributionPolicyCrudOpsAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task DistributionPolicyCrud()
        {
            // create a client
            RouterAdministrationClient routerAdministrationClient = new RouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateDistributionPolicy_Async

            string distributionPolicyId = "my-distribution-policy";

            Response<DistributionPolicy> distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(
                    distributionPolicyId: distributionPolicyId,
                    offerTtl: TimeSpan.FromMinutes(1),
                    mode: new LongestIdleMode())
                {
                    Name = "My distribution policy"
                }
            );

            Console.WriteLine($"Distribution Policy successfully created with id: {distributionPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateDistributionPolicy_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicy_Async

            Response<DistributionPolicy> queriedDistributionPolicy = await routerAdministrationClient.GetDistributionPolicyAsync(distributionPolicyId);

            Console.WriteLine($"Successfully fetched distribution policy with id: {queriedDistributionPolicy.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicy_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateDistributionPolicyRemoveProp_Async

            Response updatedDistributionPolicyWithoutName = await routerAdministrationClient.UpdateDistributionPolicyAsync(distributionPolicyId,
                RequestContent.Create(new { Name = (string?)null }));

            Response<DistributionPolicy> queriedDistributionPolicyWithoutName = await routerAdministrationClient.GetDistributionPolicyAsync(distributionPolicyId);

            Console.WriteLine($"Distribution policy successfully updated: 'Name' has been removed. Status: Status: {string.IsNullOrWhiteSpace(queriedDistributionPolicyWithoutName.Value.Name)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateDistributionPolicyRemoveProp_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateDistributionPolicy_Async

            Response<DistributionPolicy> updatedDistributionPolicy = await routerAdministrationClient.UpdateDistributionPolicyAsync(
                new UpdateDistributionPolicyOptions(distributionPolicyId)
                {
                    // you can update one or more properties of distribution policy
                    Mode = new RoundRobinMode(),
                });

            Console.WriteLine($"Distribution policy successfully update with new distribution mode. Mode Type: {updatedDistributionPolicy.Value.Mode.Kind}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateDistributionPolicy_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicies_Async

            AsyncPageable<DistributionPolicyItem> distributionPolicies = routerAdministrationClient.GetDistributionPoliciesAsync();
            await foreach (Page<DistributionPolicyItem> asPage in distributionPolicies.AsPages(pageSizeHint: 10))
            {
                foreach (DistributionPolicyItem? policy in asPage.Values)
                {
                    Console.WriteLine($"Listing distribution policy with id: {policy.DistributionPolicy.Id}");
                }
            }

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetDistributionPolicies_Async

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteDistributionPolicy_Async

            _ = await routerAdministrationClient.DeleteDistributionPolicyAsync(distributionPolicyId);

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteDistributionPolicy_Async
        }
    }
}
