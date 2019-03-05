// -------------------------------------------------------------------------------------------------
// <copyright file="Element.cs" company="RHEA System S.A.">
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
    using System.Collections.Generic;
    using Uml.Assembler;
    using Uml.Attributes;
    using Uml.Classification;

    /// <summary>
    /// An <see cref="Element"/> is a constituent of a model. As such, it has the capability of owning other <see cref="Element"/>s.
    /// </summary>
    [Class(IsAbstract = true, IsActive = false, Specializations = "Comment, MultiplicityElement|NamedElement|ParameterableElement|Relationship|TemplateableElement|TemplateParameter|TemplateParameterSubstitution|TemplateSignature|ExceptionHandler|Image|Slot|Clause|LinkEndData|QualifierValue")]
    public interface Element
    {
        /// <summary>
        /// Gets the unique Id of the <see cref="Element"/>
        /// </summary>
        /// <remarks>
        /// The Id is not specified in UML
        /// </remarks>
        string Id { get; }

        /// <summary>
        /// The Comments owned by this <see cref="Element"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = true, IsDerivedUnion = true, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<Comment> OwnedComment { get; set; }

        /// <summary>
        /// The <see cref="Element"/>s owned by this Element.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = true, IsDerivedUnion = true, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "", RedefinedProperty = "")]
        IEnumerable<Element> OwnedElement();

        /// <summary>
        /// Gets the <see cref="Element"/> that owns this <see cref="Element"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = true, IsDerivedUnion = true, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        Uml.CommonStructure.Element Owner { get;  }
    }
}