// -------------------------------------------------------------------------------------------------
// <copyright file="ParameterEffectKind .cs" company="RHEA System S.A.">
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
namespace Uml.Classification
{
    /// <summary>
    /// ParameterEffectKind is an Enumeration that indicates the effect of a Behavior on values passed in or out of its parameters.
    /// </summary>
    public enum ParameterEffectKind
    {
        /// <summary>
        /// Indicates that the behavior creates values.
        /// </summary>
        Create,

        /// <summary>
        /// Indicates objects that are values of the parameter have values of their properties, or links in which they participate, or their classifiers retrieved during executions of the behavior.
        /// </summary>
        Read,

        /// <summary>
        /// Indicates objects that are values of the parameter have values of their properties, or links in which they participate, or their classification changed during executions of the behavior.
        /// </summary>
        Update,

        /// <summary>
        /// Indicates objects that are values of the parameter do not exist after executions of the behavior are finished.
        /// </summary>
        Delete
    }
}