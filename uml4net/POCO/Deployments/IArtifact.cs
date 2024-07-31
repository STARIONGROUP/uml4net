// -------------------------------------------------------------------------------------------------
// <copyright file="IArtifact.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.Deployments
{
    using uml4net.POCO.Classification;

    /// <summary>
    /// An artifact is the specification of a physical piece of information that is used or produced 
    /// by a software development process, or by deployment and operation of a system. Examples of 
    /// artifacts include model files, source files, scripts, and binary executable files, a table
    /// in a database system, a development deliverable, or a word-processing document, a mail message.
    /// An artifact is the source of a deployment to a node.
    /// </summary>
    public interface IArtifact : IClassifier, IDeployedArtifact
    {
    }
}
