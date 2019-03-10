// -------------------------------------------------------------------------------------------------
// <copyright file="Observation.cs" company="RHEA System S.A.">
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

namespace Uml.Values
{
    using Uml.CommonStructure;
    using Uml.Attributes;
    
    /// <summary>
    /// <see cref="Observation"/> specifies a value determined by observing an event or events that occur relative to other model <see cref="Element"/>s.
    /// </summary>
    [Class(IsAbstract = true, IsActive = false, Specializations = "DurationObservation|TimeObservation")]
    public interface Observation : PackageableElement
    {
    }
}