// -------------------------------------------------------------------------------------------------
// <copyright file="ILoopNode.cs" company="Starion Group S.A.">
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

    using uml4net.Utils;

    /// <summary>
    /// A LoopNode is a StructuredActivityNode that represents an iterative loop with setup, test, and body
    /// sections.
    /// </summary>
    [Class(xmiId: "LoopNode", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    [GeneratedCode("uml4net", "latest")]
    public partial interface ILoopNode : IStructuredActivityNode
    {
        /// <summary>
        /// The OutputPins on Actions within the bodyPart, the values of which are moved to the loopVariable
        /// OutputPins after the completion of each execution of the bodyPart, before the next iteration of the
        /// loop begins or before the loop exits.
        /// </summary>
        [Property(xmiId: "LoopNode-bodyOutput", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IOutputPin> BodyOutput { get; set; }

        /// <summary>
        /// The set of ExecutableNodes that perform the repetitive computations of the loop. The bodyPart is
        /// executed as long as the test section produces a true value.
        /// </summary>
        [Property(xmiId: "LoopNode-bodyPart", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IExecutableNode> BodyPart { get; set; }

        /// <summary>
        /// An OutputPin on an Action in the test section whose Boolean value determines whether to continue
        /// executing the loop bodyPart.
        /// </summary>
        [Property(xmiId: "LoopNode-decider", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IOutputPin Decider { get; set; }

        /// <summary>
        /// If true, the test is performed before the first execution of the bodyPart. If false, the bodyPart is
        /// executed once before the test is performed.
        /// </summary>
        [Property(xmiId: "LoopNode-isTestedFirst", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: "false")]
        public bool IsTestedFirst { get; set; }

        /// <summary>
        /// A list of OutputPins that hold the values of the loop variables during an execution of the loop.
        /// When the test fails, the values are moved to the result OutputPins of the loop.
        /// </summary>
        [Property(xmiId: "LoopNode-loopVariable", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-ownedElement")]
        public IContainerList<IOutputPin> LoopVariable { get; set; }

        /// <summary>
        /// A list of InputPins whose values are moved into the loopVariable Pins before the first iteration of
        /// the loop.
        /// </summary>
        [Property(xmiId: "LoopNode-loopVariableInput", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [RedefinedProperty(propertyName: "StructuredActivityNode-structuredNodeInput")]
        public new IContainerList<IInputPin> LoopVariableInput { get; set; }

        /// <summary>
        /// A list of OutputPins that receive the loopVariable values after the last iteration of the loop and
        /// constitute the output of the LoopNode.
        /// </summary>
        [Property(xmiId: "LoopNode-result", aggregation: AggregationKind.Composite, lowerValue: 0, upperValue: int.MaxValue, isOrdered: true, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [RedefinedProperty(propertyName: "StructuredActivityNode-structuredNodeOutput")]
        public new IContainerList<IOutputPin> Result { get; set; }

        /// <summary>
        /// The set of ExecutableNodes executed before the first iteration of the loop, in order to initialize
        /// values or perform other setup computations.
        /// </summary>
        [Property(xmiId: "LoopNode-setupPart", aggregation: AggregationKind.None, lowerValue: 0, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IExecutableNode> SetupPart { get; set; }

        /// <summary>
        /// The set of ExecutableNodes executed in order to provide the test result for the loop.
        /// </summary>
        [Property(xmiId: "LoopNode-test", aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IExecutableNode> Test { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
