// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.OperationalInsights.Models
{
    /// <summary> The key vault properties. </summary>
    public partial class OperationalInsightsKeyVaultProperties
    {
        /// <summary> Initializes a new instance of OperationalInsightsKeyVaultProperties. </summary>
        public OperationalInsightsKeyVaultProperties()
        {
        }

        /// <summary> Initializes a new instance of OperationalInsightsKeyVaultProperties. </summary>
        /// <param name="keyVaultUri"> The Key Vault uri which holds they key associated with the Log Analytics cluster. </param>
        /// <param name="keyName"> The name of the key associated with the Log Analytics cluster. </param>
        /// <param name="keyVersion"> The version of the key associated with the Log Analytics cluster. </param>
        /// <param name="keyRsaSize"> Selected key minimum required size. </param>
        internal OperationalInsightsKeyVaultProperties(Uri keyVaultUri, string keyName, string keyVersion, int? keyRsaSize)
        {
            KeyVaultUri = keyVaultUri;
            KeyName = keyName;
            KeyVersion = keyVersion;
            KeyRsaSize = keyRsaSize;
        }

        /// <summary> The Key Vault uri which holds they key associated with the Log Analytics cluster. </summary>
        public Uri KeyVaultUri { get; set; }
        /// <summary> The name of the key associated with the Log Analytics cluster. </summary>
        public string KeyName { get; set; }
        /// <summary> The version of the key associated with the Log Analytics cluster. </summary>
        public string KeyVersion { get; set; }
        /// <summary> Selected key minimum required size. </summary>
        public int? KeyRsaSize { get; set; }
    }
}
