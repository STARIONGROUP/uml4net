// -------------------------------------------------------------------------------------------------
// <copyright file="IClause.cs" company="Starion Group S.A.">
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

namespace uml4net.Actions
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
    /// A Clause is an Element that represents a single branch of a ConditionalNode, including a test and a
    /// body section. The body section is executed only if (but not necessarily if) the test section
    /// evaluates to true.
    /// </summary>
    [Class(xmiId: "Clause", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface IClause : IElement
    {
        /// <summary>
        /// The set of ExecutableNodes that are executed if the test evaluates to true and the Clause is chosen
        /// over other Clauses within the ConditionalNode that also have tests that evaluate to true.
        /// </summary>
        [Property(xmiId: "Clause-body", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<IExecutableNode> Body { get; set; }

        /// <summary>
        /// The OutputPins on Actions within the body section whose values are moved to the result OutputPins of
        /// the containing ConditionalNode after execution of the body.
        /// </summary>
        [Property(xmiId: "Clause-bodyOutput", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<IOutputPin> BodyOutput { get; set; }

        /// <summary>
        /// An OutputPin on an Action in the test section whose Boolean value determines the result of the test.
        /// </summary>
        [Property(xmiId: "Clause-decider", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public IOutputPin Decider { get; set; }

        /// <summary>
        /// A set of Clauses whose tests must all evaluate to false before this Clause can evaluate its test.
        /// </summary>
        [Property(xmiId: "Clause-predecessorClause", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<IClause> PredecessorClause { get; set; }

        /// <summary>
        /// A set of Clauses that may not evaluate their tests unless the test for this Clause evaluates to
        /// false.
        /// </summary>
        [Property(xmiId: "Clause-successorClause", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<IClause> SuccessorClause { get; set; }

        /// <summary>
        /// The set of ExecutableNodes that are executed in order to provide a test result for the Clause.
        /// </summary>
        [Property(xmiId: "Clause-test", aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: true, defaultValue: null)]
        public List<IExecutableNode> Test { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
