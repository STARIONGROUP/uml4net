// -------------------------------------------------------------------------------------------------
// <copyright file="InstanceSpecification.cs" company="RHEA System S.A.">
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

namespace Uml.Classification
{
    using System.Collections.Generic;
    using Uml.Assembler;
    using Uml.Attributes;
    using Uml.CommonStructure;
    using Uml.Deployments;
    using Uml.Values;

    /// <summary>
    /// An InstanceSpecification is a model element that represents an instance in a modeled system. An InstanceSpecification can act as a DeploymentTarget in a Deployment relationship, in the case that it represents an instance of a Node. It can also act as a DeployedArtifact, if it represents an instance of an <see cref="Artifact"/>.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "EnumerationLiteral")]
    public interface InstanceSpecification : DeploymentTarget, PackageableElement, DeployedArtifact
    {
        /// <summary>
        /// The <see cref="Classifier"/> or <see cref="Classifier"/>s of the represented instance. If multiple <see cref="Classifier"/>s are specified, the instance is classified by all of them.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        List<Classifier> Classifier { get; set; }

        /// <summary>
        /// A Slot giving the value or values of a <see cref="StructuralFeature"/> of the instance. An <see cref="InstanceSpecification"/> can have one Slot per <see cref="StructuralFeature"/> of its <see cref="Classifier"/>s, including inherited features. It is not necessary to model a Slot for every <see cref="StructuralFeature"/>, in which case the <see cref="InstanceSpecification"/> is a partial description.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<Slot> Slot { get; set; }

        /// <summary>
        /// A specification of how to compute, derive, or construct the instance.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<ValueSpecification> Specification { get; set; }
    }
}