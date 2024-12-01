// -------------------------------------------------------------------------------------------------
// <copyright file="IInstanceSpecification.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.Classification
{
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.Actions;
    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.CommonBehavior;
    using uml4net.CommonStructure;
    using uml4net.Deployments;
    using uml4net.InformationFlows;
    using uml4net.Interactions;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Values;

    using uml4net.Utils;

    /// <summary>
    /// An InstanceSpecification is a model element that represents an instance in a modeled system. An
    /// InstanceSpecification can act as a DeploymentTarget in a Deployment relationship, in the case that
    /// it represents an instance of a Node. It can also act as a DeployedArtifact, if it represents an
    /// instance of an Artifact.
    /// </summary>
    [Class(xmiId: "InstanceSpecification", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface IInstanceSpecification : IDeploymentTarget, IPackageableElement, IDeployedArtifact
    {
        /// <summary>
        /// The Classifier or Classifiers of the represented instance. If multiple Classifiers are specified,
        /// the instance is classified by all of them.
        /// </summary>
        [Property(xmiId: "InstanceSpecification-classifier", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IClassifier> Classifier { get; set; }

        /// <summary>
        /// A Slot giving the value or values of a StructuralFeature of the instance. An InstanceSpecification
        /// can have one Slot per StructuralFeature of its Classifiers, including inherited features. It is not
        /// necessary to model a Slot for every StructuralFeature, in which case the InstanceSpecification is a
        /// partial description.
        /// </summary>
        [Property(xmiId: "InstanceSpecification-slot", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<ISlot> Slot { get; set; }

        /// <summary>
        /// A specification of how to compute, derive, or construct the instance.
        /// </summary>
        [Property(xmiId: "InstanceSpecification-specification", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IValueSpecification> Specification { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------