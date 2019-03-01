// -------------------------------------------------------------------------------------------------
// <copyright file="Extension.cs" company="RHEA System S.A.">
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
    using Uml.Assembler;
    using Uml.StructuredClassifiers;

    /// <summary>
    /// An extension is used to indicate that the properties of a metaclass are extended through a stereotype, and gives the ability to flexibly add (and later remove) stereotypes to classes.
    /// </summary>
    public interface Extension : Association
    {
        /// <summary>
        /// Indicates whether an instance of the extending stereotype must be created when an instance of the extended class is created. The attribute value is derived from the value of the lower property of the ExtensionEnd referenced by Extension::ownedEnd; a lower value of 1 means that isRequired is true, but otherwise it is false. Since the default value of ExtensionEnd::lower is 0, the default value of isRequired is false.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        bool isRequired { get; }

        /// <summary>
        /// References the <see cref="Class"/> that is extended through an <see cref="Extension"/>. The property is derived from the type of the memberEnd that is not the ownedEnd.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        Class MetaClass { get; }

        /// <summary>
        /// References the end of the extension that is typed by a Stereotype.
        /// </summary>
        OwnerList<ExtensionEnd> OwnedEnd { get; set; }
    }
}