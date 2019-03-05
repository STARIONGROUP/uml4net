// -------------------------------------------------------------------------------------------------
// <copyright file="TemplateableElement.cs" company="RHEA System S.A.">
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
    /// A <see cref="TemplateableElement"/> is an <see cref="Element"/> that can optionally be defined as a template and bound to other templates.
    /// </summary>
    [Class(IsAbstract = true, IsActive = false, Specializations = "StringExpression|Package|Classifier|Operation")]
    public interface TemplateableElement : Element
    {
        /// <summary>
        /// The optional <see cref="TemplateSignature"/> specifying the formal <see cref="TemplateParameter"/>s for this <see cref="TemplateableElement"/>. If a <see cref="TemplateableElement"/> has a <see cref="TemplateSignature"/>, then it is a template.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<TemplateSignature> OwnedTemplateSignature { get; set; }

        /// <summary>
        /// The optional <see cref="TemplateBinding"/>s from this <see cref="TemplateableElement"/> to one or more templates.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<TemplateBinding> TemplateBinding { get; set; }
    }
}