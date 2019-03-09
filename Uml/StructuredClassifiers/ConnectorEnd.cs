// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectorEnd.cs" company="RHEA System S.A.">
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
    using Uml.Attributes;
    using Uml.Classification;
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="ConnectorEnd"/> is an endpoint of a <see cref="Connector"/>, which attaches the <see cref="Connector"/> to a <see cref="ConnectableElement"/>.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface ConnectorEnd : MultiplicityElement
    {
        /// <summary>
        /// A derived property referencing the corresponding end on the <see cref="Association"/> which types the Connector owing this <see cref="ConnectorEnd"/>, if any. It is derived by selecting the end at the same place in the ordering of <see cref="Association"/> ends as this <see cref="ConnectorEnd"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = true, IsDerivedUnion = false, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        Property DefiningEnd { get; }

        /// <summary>
        /// Indicates the role of the internal structure of a <see cref="Classifier"/> with the <see cref="Port"/> to which the <see cref="ConnectorEnd"/> is attached.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        Property PartWithPort { get; set; }

        /// <summary>
        /// The <see cref="ConnectableElement"/> attached at this <see cref="ConnectorEnd"/>. When an instance of the containing <see cref="Classifier"/> is created, a link may (depending on the multiplicities) be created to an instance of the <see cref="Classifier"/> that types this <see cref="ConnectableElement"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        ConnectableElement Role { get; set; }
      }
}