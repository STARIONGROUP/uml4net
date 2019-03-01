// -------------------------------------------------------------------------------------------------
// <copyright file="DeploymentSpecification.cs" company="RHEA System S.A.">
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
    /// <summary>
    /// A deployment specification specifies a set of properties that determine execution parameters of a component artifact that is deployed on a node. A deployment specification can be aimed at a specific type of container. An artifact that reifies or implements deployment specification properties is a deployment descriptor.
    /// </summary>
    public interface DeploymentSpecification : Artifact
    {
        /// <summary>
        /// The deployment with which the <see cref="DeploymentSpecification"/> is associated.
        /// </summary>
        Deployment Deployment { get; set; }

        /// <summary>
        /// The location where an <see cref="Artifact"/> is deployed onto a Node. This is typically a 'directory' or 'memory address.'
        /// </summary>
        string DeploymentLocation { get; set; }

        /// <summary>
        /// The location where a component <see cref="Artifact"/> executes. This may be a local or remote location.
        /// </summary>
        string ExecutionLocation { get; set; }
    }
}