// -------------------------------------------------------------------------------------------------
// <copyright file="Variable.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.Activities
{
    using System;
    using System.Collections.Generic;
    using uml4net.Decorators;
    using uml4net.POCO.Classification;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.Values;

    /// <summary>
    /// A Variable is a ConnectableElement that may store values during the execution of an Activity.
    /// Reading and writing the values of a Variable provides an alternative means for passing data than
    /// the use of ObjectFlows. A Variable may be owned directly by an Activity, in which case it is accessible
    /// from anywhere within that activity, or it may be owned by a StructuredActivityNode, in which case it
    /// is only accessible within that node.
    /// </summary>
    public class Variable : IVariable
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Element in the XMI document
        /// </summary>
        [Implements(implementation: "IXmiElement.XmiId")]
        public string XmiId { get; set; }

        /// <summary>
        /// Gets or sets the GUID unique identifier of the Element in the XMI document
        /// </summary>
        [Implements(implementation: "IXmiElement.XmiGuid")]
        public string XmiGuid { get; set; }

        /// <summary>
        /// Gets or sets the name of the xmi type
        /// </summary>
        [Implements(implementation: "IXmiElement.XmiType")]
        public string XmiType { get; set; }

        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [Implements(implementation: "IElement.OwnedComment")]
        public List<IComment> OwnedComment { get; set; }

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
        /// For a multivalued multiplicity, this attribute specifies whether the values in an instantiation
        /// of this MultiplicityElement are sequentially ordered.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "IMultiplicityElement.IsOrdered")]
        public bool IsOrdered { get; set; }

        /// <summary>
        /// For a multivalued multiplicity, this attributes specifies whether the values in an instantiation
        /// of this MultiplicityElement are unique.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "IMultiplicityElement.IsUnique")]
        public bool IsUnique { get; set; }

        /// <summary>
        /// The lower bound of the multiplicity interval.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isDerived: true)]
        [Implements(implementation: "IMultiplicityElement.Lower")]
        public int Lower { get; set; }

        /// <summary>
        /// The specification of the lower bound for this multiplicity.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isDerived: true)]
        [Implements(implementation: "IMultiplicityElement.LowerValue")]
        public IValueSpecification LowerValue { get; set; }

        /// <summary>
        /// The upper bound of the multiplicity interval.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isDerived: true)]
        [Implements(implementation: "IMultiplicityElement.Upper")]
        public ILiteralUnlimitedNatural Upper { get; set; }

        /// <summary>
        /// The specification of the upper bound for this multiplicity.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isDerived: true)]
        [Implements(implementation: "IMultiplicityElement.UpperValue")]
        public IValueSpecification UpperValue { get; set; }

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
        /// The type of the TypedElement.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "ITypedElement.Type")]
        public IType Type { get; set; }
    }
}
