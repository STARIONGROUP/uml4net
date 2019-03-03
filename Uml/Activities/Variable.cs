// -------------------------------------------------------------------------------------------------
// <copyright file="Variable.cs" company="RHEA System S.A.">
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

namespace Uml.Activities
{
    using Uml.Actions;
    using Uml.CommonStructure;
    using Uml.StructuredClassifiers;

    /// <summary>
    /// A <see cref="Variable"/> is a <see cref="ConnectableElement"/> that may store values during the execution of an <see cref="Activity"/>. Reading and writing the values of a Variable provides an alternative means for passing data than the use of <see cref="ObjectFlow"/>s. A Variable may be owned directly by an <see cref="Activity"/>, in which case it is accessible from anywhere within that activity, or it may be owned by a <see cref="StructuredActivityNode"/>, in which case it is only accessible within that node.
    /// </summary>
    public interface Variable : ConnectableElement, MultiplicityElement 
    {
        /// <summary>
        /// An Activity that owns the Variable.
        /// </summary>
        Activity ActivityScope { get; set; }

        /// <summary>
        /// A StructuredActivityNode that owns the Variable.
        /// </summary>
        StructuredActivityNode Scope { get; set; }
    }
}