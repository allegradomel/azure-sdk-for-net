// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> Route Policy condition model. </summary>
    public partial class RoutePolicyPropertiesConditionsItem : AnnotationResource
    {
        /// <summary> Initializes a new instance of RoutePolicyPropertiesConditionsItem. </summary>
        public RoutePolicyPropertiesConditionsItem()
        {
        }

        /// <summary> Initializes a new instance of RoutePolicyPropertiesConditionsItem. </summary>
        /// <param name="annotation"> Switch configuration description. </param>
        /// <param name="sequenceNumber"> sequenceNumber of the route policy. </param>
        /// <param name="match"> Route policy match properties. </param>
        /// <param name="action"> Route policy action properties. </param>
        internal RoutePolicyPropertiesConditionsItem(string annotation, int? sequenceNumber, RoutePolicyPropertiesConditionsItemMatch match, RoutePolicyConditionsItemAction action) : base(annotation)
        {
            SequenceNumber = sequenceNumber;
            Match = match;
            Action = action;
        }

        /// <summary> sequenceNumber of the route policy. </summary>
        public int? SequenceNumber { get; set; }
        /// <summary> Route policy match properties. </summary>
        public RoutePolicyPropertiesConditionsItemMatch Match { get; set; }
        /// <summary> Route policy action properties. </summary>
        public RoutePolicyConditionsItemAction Action { get; set; }
    }
}
