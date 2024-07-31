// -------------------------------------------------------------------------------------------------
// <copyright file="IStructuredActivityNode.cs" company="Starion Group S.A.">
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
    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// A StructuredActivityNode is an Action that is also an ActivityGroup and whose behavior is 
    /// specified by the ActivityNodes and ActivityEdges it so contains. Unlike other kinds of
    /// ActivityGroup, a StructuredActivityNode owns the ActivityNodes and ActivityEdges it contains,
    /// and so a node or edge can only be directly contained in one StructuredActivityNode, though 
    /// StructuredActivityNodes may be nested.
    /// </summary>
    public interface IStructuredActivityNode : INamespace, IActivityGroup, IAction
    {
    }
}
