// -------------------------------------------------------------------------------------------------
// <copyright file="ComponentRealization.cs" company="RHEA System S.A.">
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
    using Uml.Classification;
    using Uml.CommonStructure;

    /// <summary>
    /// <see cref="Realization"/> is specialized to (optionally) define the <see cref="Classifier"/>s that realize the contract offered by a <see cref="Component"/> in terms of its provided and required <see cref="Interface"/>s. The <see cref="Component"/> forms an abstraction from these various <see cref="Classifier"/>s.
    /// </summary>
    public interface ComponentRealization : Realization
    {
        /// <summary>
        /// The <see cref="Component"/> that owns this <see cref="ComponentRealization"/> and which is implemented by its realizing <see cref="Classifier"/>s.
        /// </summary>
        Component Abstraction { get; set; }

        /// <summary>
        /// The <see cref="Classifier"/>s that are involved in the implementation of the <see cref="Component"/> that owns this <see cref="Realization"/>.
        /// </summary>
        List<Classifier> RealizingClassifier { get; set; }
    }
}