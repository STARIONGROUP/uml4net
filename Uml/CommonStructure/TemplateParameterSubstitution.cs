// -------------------------------------------------------------------------------------------------
// <copyright file="TemplateParameterSubstitution.cs" company="RHEA System S.A.">
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

namespace Uml.CommonStructure
{
    using Uml.Assembler;
    using Uml.Attributes;
    using Uml.Classification;

    /// <summary>
    /// A <see cref="TemplateParameterSubstitution"/> relates the actual parameter to a formal <see cref="TemplateParameter"/> as part of a template binding.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface TemplateParameterSubstitution : Element
    {
        /// <summary>
        /// The <see cref="ParameterableElement"/> that is the actual parameter for this <see cref="TemplateParameterSubstitution"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        ParameterableElement Actual { get; set; }

        /// <summary>
        /// The formal <see cref="TemplateParameter"/> that is associated with this <see cref="TemplateParameterSubstitution"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        TemplateParameter Formal { get; set; }

        /// <summary>
        /// The <see cref="ParameterableElement"/> that is owned by this <see cref="TemplateParameterSubstitution"/> as its actual parameter.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement|TemplateParameterSubstitution.Actual}", RedefinedProperty = "")]
        OwnerList<ParameterableElement> OwnedActual { get; set; }

        /// <summary>
        /// The <see cref="TemplateBinding"/> that owns this <see cref="TemplateParameterSubstitution"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "Element.Owner", RedefinedProperty = "")]
        TemplateBinding TemplateBinding { get; set; }
    }
}