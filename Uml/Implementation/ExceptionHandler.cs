// -------------------------------------------------------------------------------------------------
// <copyright file="ExceptionHandler.cs" company="RHEA System S.A.">
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

namespace Implementation.Activities
{
    using System;
    using Uml.CommonStructure;

    /// <summary>
    /// An <see cref="ExceptionHandler"/> is an <see cref="Element"/> that specifies a handlerBody <see cref="ExecutableNode"/> to execute in case the specified exception occurs during the execution of the protected <see cref="ExecutableNode"/>.
    /// </summary>
    public class ExceptionHandler : Element, Uml.Activities.ExceptionHandler
    {
        /// <summary>
        /// Gets the <see cref="Element"/> that owns this <see cref="Element"/>.
        /// </summary>
        /// <remarks>
        /// derived property
        /// </remarks>
        public Element Owner { get; set; }


        public string Id { get; set; }
    }
}
