// -------------------------------------------------------------------------------------------------
// <copyright file="IBehavioralFeature.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.POCO.Classification
{
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.POCO.CommonBehavior;
    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// A BehavioralFeature is a feature of a Classifier that specifies an aspect of the behavior of its instances.
    /// A BehavioralFeature is implemented (realized) by a Behavior. A BehavioralFeature specifies that a Classifier
    /// will respond to a designated request by invoking its implementing method.
    /// </summary>
    public interface IBehavioralFeature : IFeature, INamespace
    {
        /// <summary>
        /// Specifies the semantics of concurrent calls to the same passive instance (i.e., an instance originating
        /// from a Class with isActive being false). Active instances control access to their own BehavioralFeatures.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "CallConcurrencyKind.Sequential")]
        public CallConcurrencyKind Concurrency { get; set; }

        /// <summary>
        /// If true, then the BehavioralFeature does not have an implementation, and one must be supplied by a more 
        /// specific Classifier. If false, the BehavioralFeature must have an implementation in the Classifier or 
        /// one must be inherited.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        public bool IsAbstract { get; set; }

        /// <summary>
        /// A Behavior that implements the BehavioralFeature. There may be at most one Behavior for a particular pairing 
        /// of a Classifier (as owner of the Behavior) and a BehavioralFeature (as specification of the Behavior).
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        public List<IBehavior> Method { get; set; }

        /// <summary>
        /// The ordered set of formal Parameters of this BehavioralFeature.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered:true)]
        [SubsettedProperty(propertyName: "Namespace.OwnedMember")]
        public List<IParameter> OwnedParameter { get; set; }

        /// <summary>
        /// The ParameterSets owned by this BehavioralFeature.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Namespace.OwnedMember")]
        public List<IParameterSet> OwnedParameterSet { get; set; }

        /// <summary>
        /// The Types representing exceptions that may be raised during an invocation of this BehavioralFeature.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        public List<IType> RaisedException { get; set; }
     }
}
