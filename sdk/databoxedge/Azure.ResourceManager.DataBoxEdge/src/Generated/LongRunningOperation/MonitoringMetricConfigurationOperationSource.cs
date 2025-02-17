// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.DataBoxEdge
{
    internal class MonitoringMetricConfigurationOperationSource : IOperationSource<MonitoringMetricConfigurationResource>
    {
        private readonly ArmClient _client;

        internal MonitoringMetricConfigurationOperationSource(ArmClient client)
        {
            _client = client;
        }

        MonitoringMetricConfigurationResource IOperationSource<MonitoringMetricConfigurationResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = MonitoringMetricConfigurationData.DeserializeMonitoringMetricConfigurationData(document.RootElement);
            return new MonitoringMetricConfigurationResource(_client, data);
        }

        async ValueTask<MonitoringMetricConfigurationResource> IOperationSource<MonitoringMetricConfigurationResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = MonitoringMetricConfigurationData.DeserializeMonitoringMetricConfigurationData(document.RootElement);
            return new MonitoringMetricConfigurationResource(_client, data);
        }
    }
}
