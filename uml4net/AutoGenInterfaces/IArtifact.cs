// -------------------------------------------------------------------------------------------------
// <copyright file="IArtifact.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
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
    /// An artifact is the specification of a physical piece of information that is used or produced by a
    /// software development process, or by deployment and operation of a system. Examples of artifacts
    /// include model files, source files, scripts, and binary executable files, a table in a database
    /// system, a development deliverable, or a word-processing document, a mail message.An artifact is the
    /// source of a deployment to a node.
    /// </summary>
    [Class(xmiId: "Artifact", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IArtifact : IClassifier, IDeployedArtifact
    {
        /// <summary>
        /// A concrete name that is used to refer to the Artifact in a physical context. Example: file system
        /// name, universal resource locator.
        /// </summary>
        [Property(xmiId: "Artifact-fileName", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public string FileName { get; set; }

        /// <summary>
        /// The set of model elements that are manifested in the Artifact. That is, these model elements are
        /// utilized in the construction (or generation) of the artifact.
        /// </summary>
        [Property(xmiId: "Artifact-manifestation", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [SubsettedProperty(propertyName: "NamedElement-clientDependency")]
        public IContainerList<IManifestation> Manifestation { get; set; }

        /// <summary>
        /// The Artifacts that are defined (nested) within the Artifact. The association is a specialization of
        /// the ownedMember association from Namespace to NamedElement.
        /// </summary>
        [Property(xmiId: "Artifact-nestedArtifact", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IArtifact> NestedArtifact { get; set; }

        /// <summary>
        /// The attributes or association ends defined for the Artifact. The association is a specialization of
        /// the ownedMember association.
        /// </summary>
        [Property(xmiId: "Artifact-ownedAttribute", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "Classifier-attribute")]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IProperty> OwnedAttribute { get; set; }

        /// <summary>
        /// The Operations defined for the Artifact. The association is a specialization of the ownedMember
        /// association.
        /// </summary>
        [Property(xmiId: "Artifact-ownedOperation", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_redefinitionContext_redefinableElement-redefinableElement")]
        [SubsettedProperty(propertyName: "Classifier-feature")]
        [SubsettedProperty(propertyName: "Namespace-ownedMember")]
        public IContainerList<IOperation> OwnedOperation { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
