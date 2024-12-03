// -------------------------------------------------------------------------------------------------
// <copyright file="IExtension.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
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

namespace uml4net.Packages
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
    /// An extension is used to indicate that the properties of a metaclass are extended through a
    /// stereotype, and gives the ability to flexibly add (and later remove) stereotypes to classes.
    /// </summary>
    [Class(xmiId: "Extension", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface IExtension : IAssociation
    {
        /// <summary>
        /// Indicates whether an instance of the extending stereotype must be created when an instance of the
        /// extended class is created. The attribute value is derived from the value of the lower property of
        /// the ExtensionEnd referenced by Extension::ownedEnd; a lower value of 1 means that isRequired is
        /// true, but otherwise it is false. Since the default value of ExtensionEnd::lower is 0, the default
        /// value of isRequired is false.
        /// </summary>
        [Property(xmiId: "Extension-isRequired", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public bool IsRequired { get; }

        /// <summary>
        /// References the Class that is extended through an Extension. The property is derived from the type of
        /// the memberEnd that is not the ownedEnd.
        /// </summary>
        [Property(xmiId: "Extension-metaclass", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IClass Metaclass { get; }

        /// <summary>
        /// References the end of the extension that is typed by a Stereotype.
        /// </summary>
        [Property(xmiId: "Extension-ownedEnd", aggregation: AggregationKind.Composite, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [RedefinedProperty(propertyName: "Association-ownedEnd")]
        public new IContainerList<IExtensionEnd> OwnedEnd { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
