// -------------------------------------------------------------------------------------------------
// <copyright file="IExpansionNode.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.Actions
{
    using uml4net.POCO.Activities;

    /// <summary>
    /// An ExpansionNode is an ObjectNode used to indicate a collection input or output for an ExpansionRegion.
    /// A collection input of an ExpansionRegion contains a collection that is broken into its individual
    /// elements inside the region, whose content is executed once per element. A collection output of an
    /// ExpansionRegion combines individual elements produced by the execution of the region into a collection 
    /// for use outside the region.
    /// </summary>
    public interface IExpansionNode : IObjectNode
    {
    }
}
