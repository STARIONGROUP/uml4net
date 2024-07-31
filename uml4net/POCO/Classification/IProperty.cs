// -------------------------------------------------------------------------------------------------
// <copyright file="IProperty.cs" company="Starion Group S.A.">
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
    using uml4net.POCO.Deployments;
    using uml4net.POCO.StructuredClassifiers;

    /// <summary>
    /// A Property is a StructuralFeature. A Property related by ownedAttribute to a Classifier 
    /// (other than an association) represents an attribute and might also represent an association end.
    /// It relates an instance of the Classifier to a value or set of values of the type of the attribute. 
    /// A Property related by memberEnd to an Association represents an end of the Association. The type 
    /// of the Property is the type of the end of the Association. A Property has the capability of being
    /// a DeploymentTarget in a Deployment relationship. This enables modeling the deployment to hierarchical 
    /// nodes that have Properties functioning as internal parts.  Property specializes ParameterableElement 
    /// to specify that a Property can be exposed as a formal template parameter, and provided as an actual 
    /// parameter in a binding of a template.
    /// </summary>
    public interface IProperty : IConnectableElement, IDeploymentTarget, IStructuralFeature
    {
    }
}
