// -------------------------------------------------------------------------------------------------
// <copyright file="ClassifierTemplateParameter.cs" company="RHEA System S.A.">
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
    /// A <see cref="ClassifierTemplateParameter"/> exposes a <see cref="Classifier"/> as a formal template parameter.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface ClassifierTemplateParameter : TemplateParameter
    {
        /// <summary>
        /// Constrains the required relationship between an actual parameter and the parameteredElement for this formal parameter.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool AllowSubstitutable { get; set; }

        /// <summary>
        /// The classifiers that constrain the argument that can be used for the parameter. If the allowSubstitutable attribute is true, then any <see cref="Classifier"/> that is compatible with this constraining <see cref="Classifier"/> can be substituted; otherwise, it must be either this <see cref="Classifier"/> or one of its specializations. If this property is empty, there are no constraints on the <see cref="Classifier"/> that can be used as an argument.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        List<Classifier> ConstrainingClassifier { get; set; }

        /// <summary>
        /// The Classifier exposed by this <see cref="ClassifierTemplateParameter"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "TemplateParameter.ParameteredElement")]
        Classifier ParameteredElement { get; set; }
    }
}