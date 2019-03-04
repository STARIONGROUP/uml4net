// -------------------------------------------------------------------------------------------------
// <copyright file="VisibilityKind.cs" company="RHEA System S.A.">
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
    /// <summary>
    /// VisibilityKind is an enumeration type that defines literals to determine the visibility of Elements in a model.
    /// </summary>
    public enum VisibilityKind
    {
        /// <summary>
        /// A <see cref="NamedElement"/> with public visibility is visible to all elements that can access the contents of the <see cref="Namespace"/> that owns it.
        /// </summary>
        Public,

        /// <summary>
        /// A NamedE<see cref="NamedElement"/>lement with private visibility is only visible inside the <see cref="Namespace"/> that owns it.
        /// </summary>
        Private,

        /// <summary>
        /// A <see cref="NamedElement"/> with protected visibility is visible to <see cref="Element"/>s that have a generalization relationship to the <see cref="Namespace"/> that owns it.
        /// </summary>
        Protected,

        /// <summary>
        /// A <see cref="NamedElement"/> with package visibility is visible to all <see cref="Element"/>s within the nearest enclosing <see cref="Package"/> (given that other owning Elements have proper visibility). Outside the nearest enclosing Package, a <see cref="NamedElement"/> marked as having package visibility is not visible.  Only <see cref="NamedElement"/>s that are not owned by <see cref="Package"/>s can be marked as having package visibility. 
        /// </summary>
        Package
    }
}