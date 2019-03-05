// -------------------------------------------------------------------------------------------------
// <copyright file="TemplateParameter.cs" company="RHEA System S.A.">
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
    /// A <see cref="TemplateParameter"/> exposes a <see cref="ParameterableElement"/> as a formal parameter of a template.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "ConnectableElementTemplateParameter|ClassifierTemplateParameter|OperationTemplateParameter")]
    public interface TemplateParameter : Element
    {
        /// <summary>
        /// The <see cref="ParameterableElement"/> that is the default for this formal <see cref="TemplateParameter"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        ParameterableElement Default { get; set; }

        /// <summary>
        /// The <see cref="ParameterableElement"/> that is owned by this <see cref="TemplateParameter"/> for the purpose of providing a default.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement|TemplateParameter.Default", RedefinedProperty = "")]
        OwnerList<ParameterableElement> OwnedDefault { get; set; }

        /// <summary>
        /// The <see cref="ParameterableElement"/> that is owned by this <see cref="TemplateParameter"/> for the purpose of exposing it as the parameteredElement.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement|TemplateParameter.ParameteredElement", RedefinedProperty = "")]
        OwnerList<ParameterableElement> OwnedParameteredElement { get; set; }

        /// <summary>
        /// The <see cref="ParameterableElement"/> exposed by this <see cref="TemplateParameter"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        ParameterableElement ParameterableElement { get; set; }

        /// <summary>
        /// The <see cref="TemplateSignature"/> that owns this <see cref="TemplateParameter"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "Element.Owner", RedefinedProperty = "")]
        TemplateSignature Signature { get; set; }
    }
}