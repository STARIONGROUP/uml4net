﻿// -------------------------------------------------------------------------------------------------
// <copyright file="IDeployment.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
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

namespace uml4net.Deployments
{
    using System.CodeDom.Compiler;
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

    /// <summary>
    /// A deployment is the allocation of an artifact or artifact instance to a deployment target.A
    /// component deployment is the deployment of one or more artifacts or artifact instances to a
    /// deployment target, optionally parameterized by a deployment specification. Examples are executables
    /// and configuration files.
    /// </summary>
    [Class(xmiId: "Deployment", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IDeployment : IDependency
    {
        /// <summary>
        /// The specification of properties that parameterize the deployment and execution of one or more
        /// Artifacts.
        /// </summary>
        [Property(xmiId: "Deployment-configuration", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IDeploymentSpecification> Configuration { get; set; }

        /// <summary>
        /// The Artifacts that are deployed onto a Node. This association specializes the supplier association.
        /// </summary>
        [Property(xmiId: "Deployment-deployedArtifact", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Dependency-supplier")]
        public List<IDeployedArtifact> DeployedArtifact { get; set; }

        /// <summary>
        /// The DeployedTarget which is the target of a Deployment.
        /// </summary>
        [Property(xmiId: "Deployment-location", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Dependency-client")]
        [SubsettedProperty(propertyName: "Element-owner")]
        public IDeploymentTarget Location { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
