// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    /// <summary> The UnknownGcpOrganizationalData. </summary>
    internal partial class UnknownGcpOrganizationalData : GcpOrganizationalInfo
    {
        /// <summary> Initializes a new instance of UnknownGcpOrganizationalData. </summary>
        /// <param name="organizationMembershipType"> The multi cloud account's membership type in the organization. </param>
        internal UnknownGcpOrganizationalData(OrganizationMembershipType organizationMembershipType) : base(organizationMembershipType)
        {
            OrganizationMembershipType = organizationMembershipType;
        }
    }
}
