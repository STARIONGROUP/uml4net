// -------------------------------------------------------------------------------------------------
// <copyright file="GeneralizationSet.cs" company="RHEA System S.A.">
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
    using Uml.Attributes;
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="GeneralizationSet"/> is a <see cref="PackageableElement"/> whose instances represent sets of <see cref="Generalization"/> relationships.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface GeneralizationSet : PackageableElement
    {
        /// <summary>
        /// Designates the instances of <see cref="Generalization"/> that are members of this <see cref="GeneralizationSet"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        List<Generalization> Generalization { get; set; }

        /// <summary>
        /// Indicates (via the associated Generalizations) whether or not the set of specific <see cref="Classifier"/>s are covering for a particular general classifier. When isCovering is true, every instance of a particular general <see cref="Classifier"/> is also an instance of at least one of its specific <see cref="Classifier"/>s for the <see cref="GeneralizationSet"/>. When isCovering is false, there are one or more instances of the particular general <see cref="Classifier"/> that are not instances of at least one of its specific <see cref="Classifier"/>s defined for the <see cref="GeneralizationSet"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsCovering { get; set; }

        /// <summary>
        /// Indicates whether or not the set of specific Classifiers in a <see cref="Generalization"/> relationship have instance in common. If isDisjoint is true, the specific <see cref="Classifier"/>s for a particular <see cref="GeneralizationSet"/> have no members in common; that is, their intersection is empty. If isDisjoint is false, the specific <see cref="Classifier"/>s in a particular <see cref="GeneralizationSet"/> have one or more members in common; that is, their intersection is not empty.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsDisjoint { get; set; }

        /// <summary>
        /// Designates the <see cref="Classifier"/> that is defined as the power type for the associated <see cref="GeneralizationSet"/>, if there is one.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        Classifier PowerType { get; set; }
    }
}