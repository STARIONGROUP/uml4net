// -------------------------------------------------------------------------------------------------
// <copyright file="IOpaqueExpression.cs" company="Starion Group S.A.">
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

namespace uml4net.Values
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
    /// An OpaqueExpression is a ValueSpecification that specifies the computation of a collection of values
    /// either in terms of a UML Behavior or based on a textual statement in a language other than UML
    /// </summary>
    [Class(xmiId: "OpaqueExpression", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IOpaqueExpression : IValueSpecification
    {
        /// <summary>
        /// Specifies the behavior of the OpaqueExpression as a UML Behavior.
        /// </summary>
        [Property(xmiId: "OpaqueExpression-behavior", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IBehavior Behavior { get; set; }

        /// <summary>
        /// A textual definition of the behavior of the OpaqueExpression, possibly in multiple languages.
        /// </summary>
        [Property(xmiId: "OpaqueExpression-body", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<string> Body { get; set; }

        /// <summary>
        /// Specifies the languages used to express the textual bodies of the OpaqueExpression.  Languages are
        /// matched to body Strings by order. The interpretation of the body depends on the languages. If the
        /// languages are unspecified, they may be implicit from the expression body or the context.
        /// </summary>
        [Property(xmiId: "OpaqueExpression-language", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<string> Language { get; set; }

        /// <summary>
        /// If an OpaqueExpression is specified using a UML Behavior, then this refers to the single required
        /// return Parameter of that Behavior. When the Behavior completes execution, the values on this
        /// Parameter give the result of evaluating the OpaqueExpression.
        /// </summary>
        [Property(xmiId: "OpaqueExpression-result", aggregation: AggregationKind.None, lowerValue: 0, upperValue: 1, isOrdered: false, isReadOnly: true, isDerived: true, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IParameter Result { get; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
