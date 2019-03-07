// -------------------------------------------------------------------------------------------------
// <copyright file="Feature.cs" company="RHEA System S.A.">
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
    using Uml.Attributes;

    /// <summary>
    /// A <see cref="Feature"/> declares a behavioral or structural characteristic of <see cref="Classifier"/>s.
    /// </summary>
    [Class(IsAbstract = true, IsActive = false, Specializations = "BehavioralFeature|StructuralFeature|Connector")]
    public interface Feature : RedefinableElement
    {
        /// <summary>
        /// The <see cref="Classifier"/>s that have this <see cref="Feature"/> as a feature.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = true, IsDerivedUnion = true, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        Classifier FeaturingClassifier { get; }

        /// <summary>
        /// Specifies whether this Feature characterizes individual instances classified by the Classifier (false) or the Classifier itself (true).
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsStatic { get; set; }
    }
}