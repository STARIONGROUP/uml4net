// -------------------------------------------------------------------------------------------------
// <copyright file="Deployment.cs" company="RHEA System S.A.">
//   Copyright (c) 2018-2019 RHEA System S.A.
//
//   This file is part of uml-sharp
//
//   uml-sharp is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//   
//   uml-sharp is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//   GNU General Public License for more details.
//
//   You should have received a copy of the GNU General Public License
//   along with uml-sharp. If not, see<http://www.gnu.org/licenses/>.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Uml.Deployments
{
    using System.Collections.Generic;
    using Uml.Assembler;
    using Uml.CommonStructure;

    /// <summary>
    /// A deployment is the allocation of an artifact or artifact instance to a deployment target.
    /// A component deployment is the deployment of one or more artifacts or artifact instances to a deployment target, optionally parameterized by a deployment specification.Examples are executables and configuration files.
    /// </summary>
    public interface Deployment : Dependency
    {
        /// <summary>
        /// The specification of properties that parameterize the deployment and execution of one or more <see cref="Artifact"/>s.
        /// </summary>
        OwnerList<DeploymentSpecification> Configuration { get; set; }

        /// <summary>
        /// The <see cref="Artifact"/>s that are deployed onto a Node. This association specializes the supplier association.
        /// </summary>
        List<DeployedArtifact> DeployedArtifact { get; set; }

        /// <summary>
        /// The <see cref="DeployedTarget"/> which is the target of a <see cref="Deployment"/>.
        /// </summary>
        DeploymentTarget Location { get; set; }
    }
}