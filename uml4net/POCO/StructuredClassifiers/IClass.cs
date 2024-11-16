// -------------------------------------------------------------------------------------------------
// <copyright file="IClass.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.StructuredClassifiers
{
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.POCO.Classification;
    using uml4net.POCO.Packages;
    using uml4net.POCO.SimpleClassifiers;
    using uml4net.Utils;

    /// <summary>
    /// A Class classifies a set of objects and specifies the features that characterize the structure and behavior
    /// of those objects.  A Class may have an internal structure and Ports
    /// </summary>
    public interface IClass : IBehavioredClassifier, IEncapsulatedClassifier
    {
        /// <summary>
        /// This property is used when the Class is acting as a metaclass. It references the Extensions that specify
        /// additional properties of the metaclass. The property is derived from the Extensions whose memberEnds are
        /// typed by the Class.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived:true)]
        public List<IExtension> Extension { get; }

        /// <summary>
        /// If true, the Class does not provide a complete declaration and cannot be instantiated. An abstract Class
        /// is typically used as a target of Associations or Generalizations.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        [RedefinedProperty("Classifier-isAbstract")]
        public new bool IsAbstract { get; set; }

        /// <summary>
        /// Determines whether an object specified by this Class is active or not. If true, then the owning Class is
        /// referred to as an active Class. If false, then such a Class is referred to as a passive Class.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        public bool IsActive { get; set; }

        /// <summary>
        /// The Classifiers owned by the Class that are not ownedBehaviors.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("A_redefinitionContext_redefinableElement-redefinableElement")]
        [SubsettedProperty("Namespace-ownedMember")]
        public List<IClassifier> NestedClassifier { get; set; }

        /// <summary>
        /// The attributes (i.e., the Properties) owned by the Class.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered:true)]
        [RedefinedProperty("StructuredClassifier-ownedAttribute")]
        [SubsettedProperty("Classifier-attribute")]
        [SubsettedProperty("Namespace-ownedMember")]
        public IContainerList<IProperty> OwnedAttribute { get; set; }

        /// <summary>
        /// The Operations owned by the Class.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true)]
        [SubsettedProperty("A_redefinitionContext_redefinableElement-redefinableElement")]
        [SubsettedProperty("Classifier-feature")]
        [SubsettedProperty("Namespace-ownedMember")]
        public IContainerList<IOperation> OwnedOperation { get; set; }

        /// <summary>
        /// The Receptions owned by the Class.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("Classifier-feature")]
        [SubsettedProperty("Namespace-ownedMember")]
        public IContainerList<IReception> OwnedReception { get; set; }

        /// <summary>
        /// The superclasses of a Class, derived from its Generalizations.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isDerived:true)]
        [RedefinedProperty("Class-superClass")]
        public List<IClass> SuperClass { get; }
    }
}
