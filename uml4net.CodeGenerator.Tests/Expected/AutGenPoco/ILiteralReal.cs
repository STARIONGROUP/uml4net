// -------------------------------------------------------------------------------------------------
// <copyright file="ILiteralReal.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.Values
{
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.POCO.Actions;
    using uml4net.POCO.Activities;
    using uml4net.POCO.Classification;
    using uml4net.POCO.CommonBehavior;
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.Deployments;
    using uml4net.POCO.InformationFlows;
    using uml4net.POCO.Interactions;
    using uml4net.POCO.Packages;
    using uml4net.POCO.SimpleClassifiers;
    using uml4net.POCO.StateMachines;
    using uml4net.POCO.StructuredClassifiers;
    using uml4net.POCO.UseCases;
    using uml4net.POCO.Values;
    using uml4net.Utils;

    /// <summary>
    /// A LiteralReal is a specification of a Real value.
    /// </summary>
    [Class(xmiId: "LiteralReal", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public interface ILiteralReal : ILiteralSpecification
    {
        /// <summary>
        /// The specified Real value.
        /// </summary>
        [Property(xmiId: "LiteralReal-value", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public double Value { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------