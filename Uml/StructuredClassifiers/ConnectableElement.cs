// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectableElement.cs" company="RHEA System S.A.">
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

namespace Uml.StructuredClassifiers
{
    using System.Collections.Generic;
    using Uml.Attributes;
    using Uml.Classification;
    using Uml.CommonStructure;

    /// <summary>
    /// <see cref="ConnectableElement"/> is an abstract metaclass representing a set of instances that play roles of a <see cref="StructuredClassifier"/>. <see cref="ConnectableElement"/>s may be joined by attached <see cref="Connector"/>s and specify configurations of linked instances to be created within an instance of the containing <see cref="StructuredClassifier"/>.
    /// </summary>
    [Class(IsAbstract = true, IsActive = false, Specializations = "Variable|Parameter|Property")]
    public interface ConnectableElement : TypedElement, ParameterableElement
    {
        /// <summary>
        /// A set of <see cref="ConnectorEnd"/>s that attach to this <see cref="ConnectableElement"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = true, IsDerivedUnion = false, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        IEnumerable<ConnectorEnd> End { get; set; }

        /// <summary>
        /// The <see cref="ConnectableElementTemplateParameter"/> for this <see cref="ConnectableElement"/> parameter.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "ParameterableElement.TemplateParameter")]
        ConnectableElementTemplateParameter TemplateParameter { get; set; }
    }
}