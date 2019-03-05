// -------------------------------------------------------------------------------------------------
// <copyright file="ClassAttribute.cs" company="RHEA System S.A.">
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

namespace Uml.Attributes
{
    using System;

    /// <summary>
    /// The purpose of this <see cref="Attribute"/> is to decorate classes and interfaces to make Uml properties explicit
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Interface, AllowMultiple = false)]
    public class ClassAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassAttribute"/> attribute
        /// </summary>
        /// <param name="isAbstract">
        /// a value indicating whether the decorated class is abstract
        /// </param>
        /// <param name="isActive">
        /// a value indicating whether the decorated class is active
        /// </param>
        public ClassAttribute()
        {
            this.IsAbstract = false;
            this.IsAbstract = true;
            this.Specializations = "";
        }

        /// <summary>
        /// Gets a value indicating whether the decorated class is abstract
        /// </summary>
        public bool IsAbstract { get; set; }

        /// <summary>
        /// Gets a value indicating whether the decorated class is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets a list of class names that are Specializations of the current class. The class names are separated using a pipe (|) symbol
        /// </summary>
        public string Specializations { get; set; }
    }
}