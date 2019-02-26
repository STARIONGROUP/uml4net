// -------------------------------------------------------------------------------------------------
// <copyright file="Dependency.cs" company="RHEA System S.A.">
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
//   along with Foobar.  If not, see<http://www.gnu.org/licenses/>.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Uml.CommonStructure
{
    /// <summary>
    /// A <see cref="Dependency"/> is a <see cref="Relationship"/> that signifies that a single model <see cref="Element"/> or a set of model <see cref="Element"/>s requires other model <see cref="Element"/>s for their specification or implementation. This means that the complete semantics of the client <see cref="Element"/>(s) are either semantically or structurally dependent on the definition of the supplier <see cref="Element"/>(s).
    /// </summary>
    public interface Dependency
    {
    }
}