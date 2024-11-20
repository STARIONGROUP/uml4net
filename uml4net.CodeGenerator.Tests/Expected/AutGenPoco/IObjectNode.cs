// -------------------------------------------------------------------------------------------------
// <copyright file="IObjectNode.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.Activities
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
    /// An ObjectNode is an abstract ActivityNode that may hold tokens within the object flow in an Activity.
    /// ObjectNodes also support token selection, limitation on the number of tokens held, specification of
    /// the state required for tokens being held, and carrying control values.
    /// </summary>
    public interface IObjectNode : ITypedElement, IActivityNode
    {

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------