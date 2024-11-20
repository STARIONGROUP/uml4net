// -------------------------------------------------------------------------------------------------
// <copyright file="IExpression.cs" company="Starion Group S.A.">
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
    /// An Expression represents a node in an expression tree, which may be non-terminal or terminal. It
    /// defines a symbol, and has a possibly empty sequence of operands that are ValueSpecifications. It
    /// denotes a (possibly empty) set of values when evaluated in a context.
    /// </summary>
    public interface IExpression : IValueSpecification
    {

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------