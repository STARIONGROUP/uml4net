// -------------------------------------------------------------------------------------------------
// <copyright file="IInstanceSpecification.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.Classification
{
    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.Deployments;

    /// <summary>
    /// An InstanceSpecification is a model element that represents an instance in a modeled system. 
    /// An InstanceSpecification can act as a DeploymentTarget in a Deployment relationship, in the 
    /// case that it represents an instance of a Node. It can also act as a DeployedArtifact, if it 
    /// represents an instance of an Artifact.
    /// </summary>
    public interface IInstanceSpecification : IDeploymentTarget, IPackageableElement, IDeployedArtifact
    {
    }
}
