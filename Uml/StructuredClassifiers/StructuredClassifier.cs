// -------------------------------------------------------------------------------------------------
// <copyright file="StructuredClassifier.cs" company="RHEA System S.A.">
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
    using Uml.Assembler;
    using Uml.Classification;

    /// <summary>
    /// StructuredClassifiers may contain an internal structure of connected elements each of which plays a role in the overall Behavior modeled by the StructuredClassifier.
    /// </summary>
    public interface StructuredClassifier : Classifier
    {
        /// <summary>
        /// The Properties owned by the <see cref="StructuredClassifier"/>.
        /// </summary>
        OwnerList<Property> OwnedAttribute { get; set; }

        /// <summary>
        /// The connectors owned by the <see cref="StructuredClassifier"/>.
        /// </summary>
        OwnerList<Connector> OwnedConnector { get; set; }

        /// <summary>
        /// The Properties specifying instances that the <see cref="StructuredClassifier"/> owns by composition. This collection is derived, selecting those owned Properties where isComposite is true.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        IEnumerable<Property> Part { get; }

        /// <summary>
        /// The roles that instances may play in this <see cref="StructuredClassifier"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        IEnumerable<ConnectableElement> Role { get; }
    }
}