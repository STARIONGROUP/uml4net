// -------------------------------------------------------------------------------------------------
// <copyright file="Operation.cs" company="Starion Group S.A.">
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
    using uml4net.POCO.CommonBehavior;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.SimpleClassifiers;
    using uml4net.POCO.StructuredClassifiers;
    using uml4net.POCO.Values;

    /// <summary>
    /// An Operation is a BehavioralFeature of a Classifier that specifies the name, type, parameters, 
    /// and constraints for invoking an associated Behavior. An Operation may invoke both the execution of 
    /// method behaviors as well as other behavioral responses. Operation specializes TemplateableElement in 
    /// order to support specification of template operations and bound operations. Operation specializes 
    /// ParameterableElement to specify that an operation can be exposed as a formal template parameter, 
    /// and provided as an actual parameter in a binding of a template.
    /// </summary>
    public class Operation : IOperation
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
        /// References the ElementImports owned by the Namespace.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship.directedRelationship")]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
        [Implements(implementation: "INamespace.ElementImport")]
        public List<ElementImport> ElementImport { get; set; }

        /// <summary>
        /// References the PackageableElements that are members of this Namespace as a result of either PackageImports or ElementImports.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true)]
        [SubsettedProperty(propertyName: "Namespace.Member")]
        [Implements(implementation: "INamespace.ImportedMember")]
        public List<IPackageableElement> ImportedMember { get; }

        /// <summary>
        /// A collection of NamedElements owned by the Namespace.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
        [SubsettedProperty(propertyName: "Namespace.Member")]
        [Implements(implementation: "INamespace.OwnedMember")]
        public List<INamedElement> OwnedMember { get; }

        /// <summary>
        /// Specifies a set of Constraints owned by this Namespace.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Namespace.OwnedMember")]
        [Implements(implementation: "INamespace.OwnedRule")]
        public List<IConstraint> OwnedRule { get; set; }

        /// <summary>
        /// References the PackageImports owned by the Namespace.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
        [Implements(implementation: "INamespace.PackageImport")]
        public List<IPackageImport> PackageImport { get; set; }

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
        [RedefinedByProperty("IOperation.TemplateParameter")]
        ITemplateParameter IParameterableElement.TemplateParameter { get; set; }

        /// <summary>
        /// The optional TemplateSignature specifying the formal TemplateParameters for this TemplateableElement.
        /// If a TemplateableElement has a TemplateSignature, then it is a template.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1)]
        [Implements(implementation: "ITemplateableElement.OwnedTemplateSignature")]
        public ITemplateSignature OwnedTemplateSignature { get; set; }

        /// <summary>
        /// The optional TemplateSignature specifying the formal TemplateParameters for this TemplateableElement.
        /// If a TemplateableElement has a TemplateSignature, then it is a template.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [Implements(implementation: "ITemplateableElement.TemplateBinding")]
        [SubsettedProperty(propertyName: "Element.OwnedElement")]
        [SubsettedProperty(propertyName: "A_source_directedRelationship.DirectedRelationship")]
        public List<TemplateBinding> TemplateBinding { get; set; }

        /// <summary>
        /// Specifies the semantics of concurrent calls to the same passive instance (i.e., an instance originating
        /// from a Class with isActive being false). Active instances control access to their own BehavioralFeatures.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "CallConcurrencyKind.Sequential")]
        [Implements(implementation: "IBehavioralFeature.Concurrency")]
        public CallConcurrencyKind Concurrency { get; set; } = CallConcurrencyKind.Sequential;

        /// <summary>
        /// If true, then the BehavioralFeature does not have an implementation, and one must be supplied by a more 
        /// specific Classifier. If false, the BehavioralFeature must have an implementation in the Classifier or 
        /// one must be inherited.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1)]
        [Implements(implementation: "IBehavioralFeature.IsAbstract")]
        public bool IsAbstract { get; set; } = false;

        /// <summary>
        /// A Behavior that implements the BehavioralFeature. There may be at most one Behavior for a particular pairing 
        /// of a Classifier (as owner of the Behavior) and a BehavioralFeature (as specification of the Behavior).
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        [Implements(implementation: "IBehavioralFeature.Method")]
        public List<IBehavior> Method { get; set; }

        /// <summary>
        /// The ordered set of formal Parameters of this BehavioralFeature.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true)]
        [Implements(implementation: "IBehavioralFeature.OwnedParameter")]
        [SubsettedProperty(propertyName: "Namespace.OwnedMember")]
        [RedefinedByProperty("IOperation.OwnedParameter")]
        List<IParameter> IBehavioralFeature.OwnedParameter { get; set; }

        /// <summary>
        /// The ParameterSets owned by this BehavioralFeature.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [Implements(implementation: "IBehavioralFeature.OwnedParameterSet")]
        [SubsettedProperty(propertyName: "Namespace.OwnedMember")]
        [RedefinedByProperty("IOperation.RaisedException")]
        List<IParameterSet> IBehavioralFeature.OwnedParameterSet { get; set; }

        /// <summary>
        /// The Types representing exceptions that may be raised during an invocation of this BehavioralFeature.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        [Implements(implementation: "IBehavioralFeature.RaisedException")]
        [RedefinedByProperty("IOperation.RaisedException")]
        List<IType> IBehavioralFeature.RaisedException { get; set; }

        /// <summary>
        /// The Classifiers that have this Feature as a feature.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IFeature.FeaturingClassifier")]
        public IClassifier FeaturingClassifier => throw new NotImplementedException();

        /// <summary>
        /// Specifies whether this Feature characterizes individual instances classified by the Classifier (false)
        /// or the Classifier itself (true).
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        [Implements(implementation: "IFeature.IsStatic")]
        public bool IsStatic { get; set; } = false;

        /// <summary>
        /// An optional Constraint on the result values of an invocation of this Operation.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("Namespace-ownedRule")]
        [Implements(implementation: "IOperation.BodyCondition")]
        public IConstraint BodyCondition { get; set; }

        /// <summary>
        /// The Class that owns this operation, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("Feature-featuringClassifier")]
        [SubsettedProperty("NamedElement-namespace")]
        [SubsettedProperty("RedefinableElement-redefinitionContext")]
        [Implements(implementation: "IOperation.Class")]
        public IClass Class { get; set; }

        /// <summary>
        /// The DataType that owns this Operation, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("Feature-featuringClassifier")]
        [SubsettedProperty("NamedElement-namespace")]
        [SubsettedProperty("RedefinableElement-redefinitionContext")]
        [Implements(implementation: "IOperation.DataType")]
        public IDataType DataType { get; set; }

        /// <summary>
        /// The Interface that owns this Operation, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("Feature-featuringClassifier")]
        [SubsettedProperty("NamedElement-namespace")]
        [SubsettedProperty("RedefinableElement-redefinitionContext")]
        [Implements(implementation: "IOperation.Interface")]
        public IInterface Interface { get; set; }

        /// <summary>
        /// Specifies whether the return parameter is ordered or not, if present.  
        /// This information is derived from the return result for this Operation.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isReadOnly: true, isDerived: true)]
        [Implements(implementation: "IOperation.IsOrdered")]
        public bool IsOrdered => throw new NotImplementedException();

        /// <summary>
        /// Specifies whether an execution of the BehavioralFeature leaves the state of the system unchanged
        /// (isQuery=true) or whether side effects may occur (isQuery=false).
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        [Implements(implementation: "IOperation.IsQuery")]
        public bool IsQuery { get; set; }

        /// <summary>
        /// Specifies whether the return parameter is unique or not, if present. This information
        /// is derived from the return result for this Operation.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isReadOnly: true, isDerived: true)]
        [Implements(implementation: "IOperation.IsUnique")]
        public bool IsUnique => throw new NotImplementedException();

        /// <summary>
        /// Specifies the lower multiplicity of the return parameter, if present. This information is derived 
        /// from the return result for this Operation.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true)]
        [Implements(implementation: "IOperation.Lower")]
        public int Lower => throw new NotImplementedException();

        /// <summary>
        /// The parameters owned by this Operation.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true)]
        [RedefinedByProperty("BehavioralFeature-ownedParameter")]
        [Implements(implementation: "IOperation.OwnedParameter")]
        public List<IParameter> OwnedParameter { get; set; }

        /// <summary>
        /// An optional set of Constraints specifying the state of the system when the Operation is completed.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("Namespace-ownedRule")]
        [Implements(implementation: "IOperation.Postcondition")]
        public List<IConstraint> Postcondition { get; set; }

        /// <summary>
        /// An optional set of Constraints on the state of the system when the Operation is invoked.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("Namespace-ownedRule")]
        [Implements(implementation: "IOperation.Precondition")]
        public List<IConstraint> Precondition { get; set; }

        /// <summary>
        /// The Types representing exceptions that may be raised during an invocation of this operation.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        [RedefinedProperty("BehavioralFeature-raisedException")]
        [Implements(implementation: "IOperation.RaisedException")]
        public List<IType> RaisedException { get; set; }

        /// <summary>
        /// The Operations that are redefined by this Operation.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        [RedefinedProperty("RedefinableElement-redefinedElement")]
        [Implements(implementation: "IOperation.RedefinedOperation")]
        public List<IOperation> RedefinedOperation { get; set; }

        /// <summary>
        /// The OperationTemplateParameter that exposes this element as a formal parameter.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [RedefinedProperty("ParameterableElement-templateParameter")]
        [Implements(implementation: "IOperation.TemplateParameter")]
        public IOperationTemplateParameter TemplateParameter { get; set; }

        /// <summary>
        /// The return type of the operation, if present. This information is derived from
        /// the return result for this Operation.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true)]
        [Implements(implementation: "IOperation.Type")]
        public IType Type { get; }

        /// <summary>
        /// The upper multiplicity of the return parameter, if present. This information is derived 
        /// from the return result for this Operation.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true)]
        [Implements(implementation: "IOperation.Upper")]
        public int Upper { get; }

        /// <summary>
        /// Indicates whether it is possible to further redefine a RedefinableElement. If the value is
        /// true, then it is not possible to further redefine the RedefinableElement.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue: "false")]
        [Implements(implementation: "IRedefinableElement.IsLeaf")]
        public bool IsLeaf { get; set; } = false;

        /// <summary>
        /// The RedefinableElement that is being redefined by this element.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IRedefinableElement.RedefinedElement")]
        public IRedefinableElement RedefinedElement => throw new NotImplementedException();

        /// <summary>
        /// The contexts that this element may be redefined from.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isReadOnly: true, isDerived: true, isDerivedUnion: true)]
        [Implements(implementation: "IRedefinableElement.RedefinitionContext")]
        public IClassifier RedefinitionContext => throw new NotImplementedException();
    }
}
