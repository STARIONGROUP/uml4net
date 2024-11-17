// -------------------------------------------------------------------------------------------------
// <copyright file="IOperation.cs" company="Starion Group S.A.">
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
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.SimpleClassifiers;
    using uml4net.POCO.StructuredClassifiers;
    using uml4net.Utils;

    /// <summary>
    /// An Operation is a BehavioralFeature of a Classifier that specifies the name, type, parameters, 
    /// and constraints for invoking an associated Behavior. An Operation may invoke both the execution of 
    /// method behaviors as well as other behavioral responses. Operation specializes TemplateableElement in 
    /// order to support specification of template operations and bound operations. Operation specializes 
    /// ParameterableElement to specify that an operation can be exposed as a formal template parameter, 
    /// and provided as an actual parameter in a binding of a template.
    /// </summary>
    public interface IOperation : ITemplateableElement, IParameterableElement, IBehavioralFeature
    {
        /// <summary>
        /// An optional Constraint on the result values of an invocation of this Operation.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("Namespace-ownedRule")]
        public IConstraint BodyCondition { get; set; }

        /// <summary>
        /// The Class that owns this operation, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("Feature-featuringClassifier")]
        [SubsettedProperty("NamedElement-namespace")]
        [SubsettedProperty("RedefinableElement-redefinitionContext")]
        public IClass Class { get; set; }

        /// <summary>
        /// The DataType that owns this Operation, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("Feature-featuringClassifier")]
        [SubsettedProperty("NamedElement-namespace")]
        [SubsettedProperty("RedefinableElement-redefinitionContext")]
        public IDataType DataType { get; set; }

        /// <summary>
        /// The Interface that owns this Operation, if any.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [SubsettedProperty("Feature-featuringClassifier")]
        [SubsettedProperty("NamedElement-namespace")]
        [SubsettedProperty("RedefinableElement-redefinitionContext")]
        public IInterface Interface { get; set; }

        /// <summary>
        /// Specifies whether the return parameter is ordered or not, if present.  
        /// This information is derived from the return result for this Operation.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isReadOnly:true, isDerived:true)]
        public bool IsOrdered { get; }

        /// <summary>
        /// Specifies whether an execution of the BehavioralFeature leaves the state of the system unchanged
        /// (isQuery=true) or whether side effects may occur (isQuery=false).
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, defaultValue:"false")]
        public bool IsQuery { get; set; }

        /// <summary>
        /// Specifies whether the return parameter is unique or not, if present. This information
        /// is derived from the return result for this Operation.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isReadOnly: true, isDerived: true)]
        public bool IsUnique { get; }

        /// <summary>
        /// Specifies the lower multiplicity of the return parameter, if present. This information is derived 
        /// from the return result for this Operation.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true)]
        public int Lower { get; }

        /// <summary>
        /// The parameters owned by this Operation.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered:true)]
        [RedefinedByProperty("BehavioralFeature-ownedParameter")]
        public new IContainerList<IParameter> OwnedParameter { get; set; }

        /// <summary>
        /// An optional set of Constraints specifying the state of the system when the Operation is completed.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("Namespace-ownedRule")]
        public List<IConstraint> Postcondition { get; set; }

        /// <summary>
        /// An optional set of Constraints on the state of the system when the Operation is invoked.
        /// </summary>
        [Property(aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue)]
        [SubsettedProperty("Namespace-ownedRule")]
        public List<IConstraint> Precondition { get; set; }

        /// <summary>
        /// The Types representing exceptions that may be raised during an invocation of this operation.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        [RedefinedProperty("BehavioralFeature-raisedException")]
        public new List<IType> RaisedException { get; set; }

        /// <summary>
        /// The Operations that are redefined by this Operation.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue)]
        [RedefinedProperty("RedefinableElement-redefinedElement")]
        public List<IOperation> RedefinedOperation { get; set; }

        /// <summary>
        /// The OperationTemplateParameter that exposes this element as a formal parameter.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1)]
        [RedefinedProperty("ParameterableElement-templateParameter")]
        public new IOperationTemplateParameter TemplateParameter { get; set; }

        /// <summary>
        /// The return type of the operation, if present. This information is derived from
        /// the return result for this Operation.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly:true, isDerived:true)]
        public IType Type { get; }

        /// <summary>
        /// The upper multiplicity of the return parameter, if present. This information is derived 
        /// from the return result for this Operation.
        /// </summary>
        [Property(aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isReadOnly: true, isDerived: true)]
        public int Upper { get; }
    }
}
