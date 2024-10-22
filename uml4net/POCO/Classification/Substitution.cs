// -------------------------------------------------------------------------------------------------
// <copyright file="Substitution.cs" company="Starion Group S.A.">
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
    using System;
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.Values;

    /// <summary>
    /// A substitution is a relationship between two classifiers signifying that the substituting classifier 
    /// complies with the contract specified by the contract classifier. This implies that instances of the 
    /// substituting classifier are runtime substitutable where instances of the contract classifier are expected.
    /// </summary>
    public class Substitution : XmiElement, ISubstitution
    {
        /// <summary>
        /// An OpaqueExpression that states the abstraction relationship between the supplier(s) and the client(s). 
        /// In some cases, such as derivation, it is usually formal and unidirectional; in other cases, such as trace, 
        /// it is usually informal and bidirectional. The mapping expression is optional and may be omitted if the
        /// precise relationship between the Elements is not specified.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "IAbstraction.Mapping")]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
        public IOpaqueExpression Mapping { get; set; }

        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [Implements(implementation: "IElement.OwnedComment")]
        public List<IComment> OwnedComment { get; set; } = new List<IComment>();

        /// <summary>
        /// The Elements owned by this Element
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IElement.OwnedElement")]
        public List<IElement> OwnedElement => throw new NotImplementedException();

        /// <summary>
        /// The Element that owns this Element.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IElement.Owner")]
        public IElement Owner => throw new NotImplementedException();

        /// <summary>
        /// The Element(s) dependent on the supplier Element(s). In some cases (such as a trace Abstraction)
        /// the assignment of direction (that is, the designation of the client Element) is at the discretion 
        /// of the modeler and is a stipulation.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue)]
        [Implements(implementation: "IDependency.Client")]
        [SubsettedProperty(propertyName: "DirectedRelationship.Source")]
        public List<INamedElement> Client { get; set; } = new List<INamedElement>();

        /// <summary>
        /// The Element(s) on which the client Element(s) depend in some respect. The modeler may stipulate
        /// a sense of Dependency direction suitable for their domain.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue)]
        [Implements(implementation: "IDependency.Supplier")]
        [SubsettedProperty(propertyName: "DirectedRelationship.Target")]
        public List<INamedElement> Supplier { get; set; } = new List<INamedElement>();

        /// <summary>
        /// Specifies the source Element(s) of the DirectedRelationship.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IDirectedRelationship.Source")]
        [SubsettedProperty(propertyName: "Relationship.RelatedElement")]
        public List<IElement> Source => throw new NotImplementedException();

        /// <summary>
        /// Specifies the target Element(s) of the DirectedRelationship.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IDirectedRelationship.Target")]
        [SubsettedProperty(propertyName: "Relationship.RelatedElement")]
        public List<IElement> Target => throw new NotImplementedException();

        /// <summary>
        /// Indicates the Dependencies that reference this NamedElement as a client."
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isDerived: true)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship.DirectedRelationship")]
        [Implements(implementation: "INamedElement.ClientDependency")]
        public List<IDependency> ClientDependency => throw new NotImplementedException();

        /// <summary>
        /// The name of the NamedElement.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "INamedElement.Name")]
        public string Name { get; set; }

        /// <summary>
        /// The StringExpression used to define the name of this NamedElement.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
        [Implements(implementation: "INamedElement.NameExpression")]
        public IStringExpression NameExpression { get; set; }

        /// <summary>
        /// Specifies the Namespace that owns the NamedElement.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [SubsettedProperty(propertyName: "A_member_memberNamespace.MemberNamespace")]
        [SubsettedProperty(propertyName: "Element.Owner")]
        [Implements(implementation: "INamedElement.Namespace")]
        public INamespace Namespace => throw new NotImplementedException();

        /// <summary>
        /// A name that allows the NamedElement to be identified within a hierarchy of nested Namespaces. It is constructed from the names of 
        /// the containing Namespaces starting at the root of the hierarchy and ending with the name of the NamedElement itself.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true)]
        [Implements(implementation: "INamedElement.QualifiedName")]
        public string QualifiedName => throw new NotImplementedException();

        /// <summary>
        /// Determines whether and how the NamedElement is visible outside its owning Namespace.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "INamedElement.Visibility")]
        public VisibilityKind Visibility { get; set; }

        /// <summary>
        /// The formal TemplateParameter that owns this ParameterableElement
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "IParameterableElement.OwningTemplateParameter")]
        [SubsettedProperty(propertyName: "Element.Owner")]
        [SubsettedProperty(propertyName: "ParameterableElement.TemplateParameter")]
        public ITemplateParameter OwningTemplateParameter { get; set; }

        /// <summary>
        /// ParameterableElement-templateParameter-_ownedComment.0" body="The TemplateParameter that exposes this 
        /// ParameterableElement as a formal parameter.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "IParameterableElement.TemplateParameter")]
        public ITemplateParameter TemplateParameter { get; set; }

        /// <summary>
        /// Specifies the elements related by the Relationship.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IRelationship.RelatedElement")]
        public List<IElement> RelatedElement => throw new NotImplementedException();

        /// <summary>
        /// The contract with which the substituting classifier complies.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "ISubstitution.Contract")]
        public IClassifier Contract { get; set; }

        /// <summary>
        /// Instances of the substituting classifier are runtime substitutable where instances
        /// of the contract classifier are expected.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "ISubstitution.SubstitutingClassifier")]
        [SubsettedProperty(propertyName: "Dependency.Client")]
        [SubsettedProperty(propertyName: "Element.Owner")]
        public IClassifier SubstitutingClassifier { get; set; }
    }
}
