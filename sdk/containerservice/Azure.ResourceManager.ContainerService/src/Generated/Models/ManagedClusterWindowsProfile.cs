// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> Profile for Windows VMs in the managed cluster. </summary>
    public partial class ManagedClusterWindowsProfile
    {
        /// <summary> Initializes a new instance of ManagedClusterWindowsProfile. </summary>
        /// <param name="adminUsername"> Specifies the name of the administrator account. &lt;br&gt;&lt;br&gt; **Restriction:** Cannot end in "." &lt;br&gt;&lt;br&gt; **Disallowed values:** "administrator", "admin", "user", "user1", "test", "user2", "test1", "user3", "admin1", "1", "123", "a", "actuser", "adm", "admin2", "aspnet", "backup", "console", "david", "guest", "john", "owner", "root", "server", "sql", "support", "support_388945a0", "sys", "test2", "test3", "user4", "user5". &lt;br&gt;&lt;br&gt; **Minimum-length:** 1 character &lt;br&gt;&lt;br&gt; **Max-length:** 20 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="adminUsername"/> is null. </exception>
        public ManagedClusterWindowsProfile(string adminUsername)
        {
            Argument.AssertNotNull(adminUsername, nameof(adminUsername));

            AdminUsername = adminUsername;
        }

        /// <summary> Initializes a new instance of ManagedClusterWindowsProfile. </summary>
        /// <param name="adminUsername"> Specifies the name of the administrator account. &lt;br&gt;&lt;br&gt; **Restriction:** Cannot end in "." &lt;br&gt;&lt;br&gt; **Disallowed values:** "administrator", "admin", "user", "user1", "test", "user2", "test1", "user3", "admin1", "1", "123", "a", "actuser", "adm", "admin2", "aspnet", "backup", "console", "david", "guest", "john", "owner", "root", "server", "sql", "support", "support_388945a0", "sys", "test2", "test3", "user4", "user5". &lt;br&gt;&lt;br&gt; **Minimum-length:** 1 character &lt;br&gt;&lt;br&gt; **Max-length:** 20 characters. </param>
        /// <param name="adminPassword"> Specifies the password of the administrator account. &lt;br&gt;&lt;br&gt; **Minimum-length:** 8 characters &lt;br&gt;&lt;br&gt; **Max-length:** 123 characters &lt;br&gt;&lt;br&gt; **Complexity requirements:** 3 out of 4 conditions below need to be fulfilled &lt;br&gt; Has lower characters &lt;br&gt;Has upper characters &lt;br&gt; Has a digit &lt;br&gt; Has a special character (Regex match [\W_]) &lt;br&gt;&lt;br&gt; **Disallowed values:** "abc@123", "P@$$w0rd", "P@ssw0rd", "P@ssword123", "Pa$$word", "pass@word1", "Password!", "Password1", "Password22", "iloveyou!". </param>
        /// <param name="licenseType"> The license type to use for Windows VMs. See [Azure Hybrid User Benefits](https://azure.microsoft.com/pricing/hybrid-benefit/faq/) for more details. </param>
        /// <param name="isCsiProxyEnabled"> For more details on CSI proxy, see the [CSI proxy GitHub repo](https://github.com/kubernetes-csi/csi-proxy). </param>
        /// <param name="gmsaProfile"> The Windows gMSA Profile in the Managed Cluster. </param>
        internal ManagedClusterWindowsProfile(string adminUsername, string adminPassword, WindowsVmLicenseType? licenseType, bool? isCsiProxyEnabled, WindowsGmsaProfile gmsaProfile)
        {
            AdminUsername = adminUsername;
            AdminPassword = adminPassword;
            LicenseType = licenseType;
            IsCsiProxyEnabled = isCsiProxyEnabled;
            GmsaProfile = gmsaProfile;
        }

        /// <summary> Specifies the name of the administrator account. &lt;br&gt;&lt;br&gt; **Restriction:** Cannot end in "." &lt;br&gt;&lt;br&gt; **Disallowed values:** "administrator", "admin", "user", "user1", "test", "user2", "test1", "user3", "admin1", "1", "123", "a", "actuser", "adm", "admin2", "aspnet", "backup", "console", "david", "guest", "john", "owner", "root", "server", "sql", "support", "support_388945a0", "sys", "test2", "test3", "user4", "user5". &lt;br&gt;&lt;br&gt; **Minimum-length:** 1 character &lt;br&gt;&lt;br&gt; **Max-length:** 20 characters. </summary>
        public string AdminUsername { get; set; }
        /// <summary> Specifies the password of the administrator account. &lt;br&gt;&lt;br&gt; **Minimum-length:** 8 characters &lt;br&gt;&lt;br&gt; **Max-length:** 123 characters &lt;br&gt;&lt;br&gt; **Complexity requirements:** 3 out of 4 conditions below need to be fulfilled &lt;br&gt; Has lower characters &lt;br&gt;Has upper characters &lt;br&gt; Has a digit &lt;br&gt; Has a special character (Regex match [\W_]) &lt;br&gt;&lt;br&gt; **Disallowed values:** "abc@123", "P@$$w0rd", "P@ssw0rd", "P@ssword123", "Pa$$word", "pass@word1", "Password!", "Password1", "Password22", "iloveyou!". </summary>
        public string AdminPassword { get; set; }
        /// <summary> The license type to use for Windows VMs. See [Azure Hybrid User Benefits](https://azure.microsoft.com/pricing/hybrid-benefit/faq/) for more details. </summary>
        public WindowsVmLicenseType? LicenseType { get; set; }
        /// <summary> For more details on CSI proxy, see the [CSI proxy GitHub repo](https://github.com/kubernetes-csi/csi-proxy). </summary>
        public bool? IsCsiProxyEnabled { get; set; }
        /// <summary> The Windows gMSA Profile in the Managed Cluster. </summary>
        public WindowsGmsaProfile GmsaProfile { get; set; }
    }
}
