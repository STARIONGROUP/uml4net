﻿// -------------------------------------------------------------------------------------------------
// <copyright file="IVariable.cs" company="Starion Group S.A.">
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
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.StructuredClassifiers;

    /// <summary>
    /// A Variable is a ConnectableElement that may store values during the execution of an Activity.
    /// Reading and writing the values of a Variable provides an alternative means for passing data than
    /// the use of ObjectFlows. A Variable may be owned directly by an Activity, in which case it is accessible
    /// from anywhere within that activity, or it may be owned by a StructuredActivityNode, in which case it
    /// is only accessible within that node.
    /// </summary>
    public interface IVariable : IConnectableElement, IMultiplicityElement
    {
    }
}
