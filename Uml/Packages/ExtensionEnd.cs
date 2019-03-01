﻿// -------------------------------------------------------------------------------------------------
// <copyright file="ExtensionEnd.cs" company="RHEA System S.A.">
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

namespace Uml.Packages
{
    using Uml.Classification;

    /// <summary>
    /// An extension end is used to tie an extension to a stereotype when extending a metaclass.
    /// The default multiplicity of an extension end is 0..1.
    /// </summary>
    public interface ExtensionEnd : Property
    {
        /// <summary>
        /// This redefinition changes the default multiplicity of association ends, since model elements are usually extended by 0 or 1 instance of the extension stereotype.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        int lower { get; }

        /// <summary>
        /// References the type of the <see cref="ExtensionEnd"/>. Note that this association restricts the possible types of an ExtensionEnd to only be <see cref="Stereotype"/>s.
        /// </summary>
        Stereotype Type { get; set; }
    }
}