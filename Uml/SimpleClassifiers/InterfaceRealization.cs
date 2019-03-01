// -------------------------------------------------------------------------------------------------
// <copyright file="InterfaceRealization.cs" company="RHEA System S.A.">
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

namespace Uml.SimpleClassifiers
{
    using Uml.CommonStructure;

    /// <summary>
    /// An InterfaceRealization is a specialized realization relationship between a <see cref="BehavioredClassifier"/> and an Interface. This relationship signifies that the realizing BehavioredClassifier conforms to the contract specified by the Interface.
    /// </summary>
    public interface InterfaceRealization : Realization
    {
        /// <summary>
        /// References the <see cref="Interface"/> specifying the conformance contract.
        /// </summary>
        Interface Contract { get; set; }

        /// <summary>
        /// References the <see cref="BehavioredClassifier"/> that owns this InterfaceRealization, i.e., the <see cref="BehavioredClassifier"/> that realizes the Interface to which it refers.
        /// </summary>
        BehavioredClassifier ImplementingClassifier { get; set; }
    }
}