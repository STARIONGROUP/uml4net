// -------------------------------------------------------------------------------------------------
// <copyright file="ParameterDirectionKind .cs" company="RHEA System S.A.">
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
namespace Uml.Classification
{
    /// <summary>
    /// ParameterDirectionKind is an Enumeration that defines literals used to specify direction of parameters.
    /// </summary>
    public enum ParameterDirectionKind
    {
        /// <summary>
        /// Indicates that Parameter values are passed in by the caller. 
        /// </summary>
        In,

        /// <summary>
        /// Indicates that Parameter values are passed in by the caller and (possibly different) values passed out to the caller.
        /// </summary>
        Inout,

        /// <summary>
        /// Indicates that Parameter values are passed out to the caller.
        /// </summary>
        Out,

        /// <summary>
        /// Indicates that Parameter values are passed as return values back to the caller.
        /// </summary>
        Return
    }
}