// -------------------------------------------------------------------------------------------------
// <copyright file="DeploymentTargetExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Deployments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.CommonStructure;

    /// <summary>
    /// The <see cref="DeploymentTargetExtensions"/> class provides extensions methods for <see cref="IDeploymentTarget"/>
    /// </summary>
    internal static class DeploymentTargetExtensions
    {
        /// <summary>
        /// Queries The set of elements that are manifested in an Artifact that is involved in Deployment to a
        /// DeploymentTarget. Per the UML 2.5.1 metamodel this is derived as:
        /// <c>deployment.deployedArtifact->select(oclIsKindOf(Artifact))->collect(oclAsType(Artifact).manifestation)
        /// ->collect(utilizedElement)->asSet()</c>.
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
            if (deploymentTarget == null)
            {
                throw new ArgumentNullException(nameof(deploymentTarget));
            }

            return deploymentTarget.Deployment
                .SelectMany(deployment => deployment.DeployedArtifact)
                .OfType<IArtifact>()
                .SelectMany(artifact => artifact.Manifestation)
                .Select(manifestation => manifestation.UtilizedElement)
                .Distinct()
                .ToList();
        }
    }
}
