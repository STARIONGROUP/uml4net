﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="DeploymentTargetExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.Deployments
{
    using System;
    using System.Collections.Generic;

    using uml4net.CommonStructure;

    /// <summary>
    /// The <see cref="DeploymentTargetExtensions"/> class provides extensions methods for <see cref="IDeploymentTarget"/>
    /// </summary>
    internal static class DeploymentTargetExtensions
    {
        /// <summary>
        /// Queries The set of elements that are manifested in an Artifact that is involved in Deployment to a
        /// DeploymentTarget.
        /// </summary>
        /// <param name="deploymentTarget">
        /// The subject <see cref="IDeploymentTarget"/>
        /// </param>
        /// <returns>
        /// The set of elements that are manifested in an Artifact that is involved in Deployment to a
        /// DeploymentTarget.
        /// </returns>
        internal static List<IPackageableElement> QueryDeployedElement(this IDeploymentTarget deploymentTarget)
        {
            throw new NotSupportedException();
        }
    }
}
