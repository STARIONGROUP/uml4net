// -------------------------------------------------------------------------------------------------
// <copyright file="Artifact.cs" company="RHEA System S.A.">
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
    using Uml.Assembler;
    using Uml.Classification;

    /// <summary>
    /// An artifact is the specification of a physical piece of information that is used or produced by a software development process, or by deployment and operation of a system. Examples of artifacts include model files, source files, scripts, and binary executable files, a table in a database system, a development deliverable, or a word-processing document, a mail message.
    /// An artifact is the source of a deployment to a node.
    /// </summary>
    public interface Artifact : Classifier, DeployedArtifact
    {
        /// <summary>
        /// A concrete name that is used to refer to the <see cref="Artifact"/> in a physical context. Example: file system name, universal resource locator.
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// The set of model elements that are manifested in the Artifact. That is, these model elements are utilized in the construction (or generation) of the artifact.
        /// </summary>
        OwnerList<Manifestation> Manifestation { get; set; }

        /// <summary>
        /// The <see cref="Artifact"/>s that are defined (nested) within the <see cref="Artifact"/>. The association is a specialization of the ownedMember association from Namespace to <see cref="NamedElement"/>.
        /// </summary>
        OwnerList<Artifact> NestedArtifact { get; set; }

        /// <summary>
        /// The attributes or association ends defined for the <see cref="Artifact"/>. The association is a specialization of the ownedMember association.
        /// </summary>
        OwnerList<Property> OwnedAttribute { get; set; }

        /// <summary>
        /// The <see cref="Operation"/>s defined for the <see cref="Artifact"/>. The association is a specialization of the ownedMember association.
        /// </summary>
        OwnerList<Operation> OwnedOperation { get; set; }
    }
}