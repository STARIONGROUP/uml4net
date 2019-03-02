// -------------------------------------------------------------------------------------------------
// <copyright file="EncapsulatedClassifier.cs" company="RHEA System S.A.">
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

    /// <summary>
    /// An <see cref="EncapsulatedClassifier"/> may own <see cref="Port"/>s to specify typed interaction points.
    /// </summary>
    public interface EncapsulatedClassifier : StructuredClassifier
    {
        /// <summary>
        /// The <see cref="Port"/>s owned by the <see cref="EncapsulatedClassifier"/>.
        /// </summary>
        IEnumerable<Port> OwnedPort { get; }
    }
}