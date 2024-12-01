// -------------------------------------------------------------------------------------------------
// <copyright file="Parameter.cs" company="Starion Group S.A.">
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
    /// A Parameter is a specification of an argument used to pass information into or out of an invocation
    /// of a BehavioralFeature.  Parameters can be treated as ConnectableElements within Collaborations.
    /// </summary>
    [Class(xmiId: "Parameter", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial class Parameter : XmiElement, IParameter
    {
        /// <summary>
        /// Gets or sets the container of this <see cref="IElement"/>
        /// </summary>
        public IElement Possessor { get; set; }

        /// <summary>
        /// Indicates the Dependencies that reference this NamedElement as a client.
        /// </summary>
        [Property(xmiId: "NamedElement-clientDependency", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_source_directedRelationship-directedRelationship")]
        [Implements(implementation: "INamedElement.ClientDependency")]
        public List<IDependency> ClientDependency => this.QueryClientDependency();

        /// <summary>
        /// A String that represents a value to be used when no argument is supplied for the Parameter.
        /// </summary>
        [Property(xmiId: "Parameter-default", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IParameter.Default")]
        public string Default => this.QueryDefault();

        /// <summary>
        /// Specifies a ValueSpecification that represents a value to be used when no argument is supplied for
        /// the Parameter.
        /// </summary>
        [Property(xmiId: "Parameter-defaultValue", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IParameter.DefaultValue")]
        public IContainerList<IValueSpecification> DefaultValue
        {
            get => this.defaultValue ??= new ContainerList<IValueSpecification>(this);
            set => this.defaultValue = value;
        }

        /// <summary>
        /// Backing field for <see cref="DefaultValue"/>
        /// </summary>
        private IContainerList<IValueSpecification> defaultValue;

        /// <summary>
        /// Indicates whether a parameter is being sent into or out of a behavioral element.
        /// </summary>
        [Property(xmiId: "Parameter-direction", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "in")]
        [Implements(implementation: "IParameter.Direction")]
        public ParameterDirectionKind Direction { get; set; }

        /// <summary>
        /// Specifies the effect that executions of the owner of the Parameter have on objects passed in or out
        /// of the parameter.
        /// </summary>
        [Property(xmiId: "Parameter-effect", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IParameter.Effect")]
        public ParameterEffectKind Effect { get; set; }

        /// <summary>
        /// A set of ConnectorEnds that attach to this ConnectableElement.
        /// </summary>
        [Property(xmiId: "ConnectableElement-end", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IConnectableElement.End")]
        public List<IConnectorEnd> End => this.QueryEnd();

        /// <summary>
        /// Tells whether an output parameter may emit a value to the exclusion of the other outputs.
        /// </summary>
        [Property(xmiId: "Parameter-isException", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        [Implements(implementation: "IParameter.IsException")]
        public bool IsException { get; set; }

        /// <summary>
        /// For a multivalued multiplicity, this attribute specifies whether the values in an instantiation of
        /// this MultiplicityElement are sequentially ordered.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-isOrdered", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        [Implements(implementation: "IMultiplicityElement.IsOrdered")]
        public bool IsOrdered { get; set; }

        /// <summary>
        /// Tells whether an input parameter may accept values while its behavior is executing, or whether an
        /// output parameter may post values while the behavior is executing.
        /// </summary>
        [Property(xmiId: "Parameter-isStream", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        [Implements(implementation: "IParameter.IsStream")]
        public bool IsStream { get; set; }

        /// <summary>
        /// For a multivalued multiplicity, this attributes specifies whether the values in an instantiation of
        /// this MultiplicityElement are unique.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-isUnique", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "true")]
        [Implements(implementation: "IMultiplicityElement.IsUnique")]
        public bool IsUnique { get; set; }

        /// <summary>
        /// The lower bound of the multiplicity interval.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-lower", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IMultiplicityElement.Lower")]
        public int Lower => this.QueryLower();

        /// <summary>
        /// The specification of the lower bound for this multiplicity.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-lowerValue", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IMultiplicityElement.LowerValue")]
        public IContainerList<IValueSpecification> LowerValue
        {
            get => this.lowerValue ??= new ContainerList<IValueSpecification>(this);
            set => this.lowerValue = value;
        }

        /// <summary>
        /// Backing field for <see cref="LowerValue"/>
        /// </summary>
        private IContainerList<IValueSpecification> lowerValue;

        /// <summary>
        /// The name of the NamedElement.
        /// </summary>
        [Property(xmiId: "NamedElement-name", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "INamedElement.Name")]
        public string Name { get; set; }

        /// <summary>
        /// The StringExpression used to define the name of this NamedElement.
        /// </summary>
        [Property(xmiId: "NamedElement-nameExpression", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "INamedElement.NameExpression")]
        public IContainerList<IStringExpression> NameExpression
        {
            get => this.nameExpression ??= new ContainerList<IStringExpression>(this);
            set => this.nameExpression = value;
        }

        /// <summary>
        /// Backing field for <see cref="NameExpression"/>
        /// </summary>
        private IContainerList<IStringExpression> nameExpression;

        /// <summary>
        /// Specifies the Namespace that owns the NamedElement.
        /// </summary>
        [Property(xmiId: "NamedElement-namespace", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_member_memberNamespace-memberNamespace")]
        [SubsettedProperty(propertyName: "Element-owner")]
        [Implements(implementation: "INamedElement.Namespace")]
        public INamespace Namespace => this.QueryNamespace();

        /// <summary>
        /// The Operation owning this parameter.
        /// </summary>
        [Property(xmiId: "Parameter-operation", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "A_ownedParameter_ownerFormalParam-ownerFormalParam")]
        [Implements(implementation: "IParameter.Operation")]
        public IOperation Operation { get; set; }

        /// <summary>
        /// The Comments owned by this Element.
        /// </summary>
        [Property(xmiId: "Element-ownedComment", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IElement.OwnedComment")]
        public IContainerList<IComment> OwnedComment
        {
            get => this.ownedComment ??= new ContainerList<IComment>(this);
            set => this.ownedComment = value;
        }

        /// <summary>
        /// Backing field for <see cref="OwnedComment"/>
        /// </summary>
        private IContainerList<IComment> ownedComment;

        /// <summary>
        /// The Elements owned by this Element.
        /// </summary>
        [Property(xmiId: "Element-ownedElement", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IElement.OwnedElement")]
        public IContainerList<IElement> OwnedElement => this.QueryOwnedElement();

        /// <summary>
        /// The Element that owns this Element.
        /// </summary>
        [Property(xmiId: "Element-owner", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: true, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IElement.Owner")]
        public IElement Owner => this.QueryOwner();

        /// <summary>
        /// The formal TemplateParameter that owns this ParameterableElement.
        /// </summary>
        [Property(xmiId: "ParameterableElement-owningTemplateParameter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-owner")]
        [SubsettedProperty(propertyName: "ParameterableElement-templateParameter")]
        [Implements(implementation: "IParameterableElement.OwningTemplateParameter")]
        public ITemplateParameter OwningTemplateParameter { get; set; }

        /// <summary>
        /// The ParameterSets containing the parameter. See ParameterSet.
        /// </summary>
        [Property(xmiId: "Parameter-parameterSet", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IParameter.ParameterSet")]
        public List<IParameterSet> ParameterSet { get; set; } = new();

        /// <summary>
        /// A name that allows the NamedElement to be identified within a hierarchy of nested Namespaces. It is
        /// constructed from the names of the containing Namespaces starting at the root of the hierarchy and
        /// ending with the name of the NamedElement itself.
        /// </summary>
        [Property(xmiId: "NamedElement-qualifiedName", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "INamedElement.QualifiedName")]
        public string QualifiedName => this.QueryQualifiedName();

        /// <summary>
        /// The ConnectableElementTemplateParameter for this ConnectableElement parameter.
        /// </summary>
        [Property(xmiId: "ConnectableElement-templateParameter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [RedefinedProperty(propertyName: "ParameterableElement-templateParameter")]
        [Implements(implementation: "IConnectableElement.TemplateParameter")]
        public new IConnectableElementTemplateParameter TemplateParameter { get; set; }

        /// <summary>
        /// The TemplateParameter that exposes this ParameterableElement as a formal parameter.
        /// </summary>
        [Property(xmiId: "ParameterableElement-templateParameter", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [RedefinedByProperty("IConnectableElement.TemplateParameter")]
        [Implements(implementation: "IParameterableElement.TemplateParameter")]
        ITemplateParameter IParameterableElement.TemplateParameter { get; set; }

        /// <summary>
        /// The type of the TypedElement.
        /// </summary>
        [Property(xmiId: "TypedElement-type", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "ITypedElement.Type")]
        public IType Type { get; set; }

        /// <summary>
        /// The upper bound of the multiplicity interval.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-upper", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: true, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "IMultiplicityElement.Upper")]
        public int Upper => this.QueryUpper();

        /// <summary>
        /// The specification of the upper bound for this multiplicity.
        /// </summary>
        [Property(xmiId: "MultiplicityElement-upperValue", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        [Implements(implementation: "IMultiplicityElement.UpperValue")]
        public IContainerList<IValueSpecification> UpperValue
        {
            get => this.upperValue ??= new ContainerList<IValueSpecification>(this);
            set => this.upperValue = value;
        }

        /// <summary>
        /// Backing field for <see cref="UpperValue"/>
        /// </summary>
        private IContainerList<IValueSpecification> upperValue;

        /// <summary>
        /// Determines whether and how the NamedElement is visible outside its owning Namespace.
        /// </summary>
        [Property(xmiId: "NamedElement-visibility", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [Implements(implementation: "INamedElement.Visibility")]
        public VisibilityKind Visibility { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------