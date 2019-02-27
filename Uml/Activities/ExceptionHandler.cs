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

namespace Uml.Activities
{
    using System.Collections.Generic;
    using Uml.Classification;
    using Uml.CommonStructure;

    /// <summary>
    /// An <see cref="ExceptionHandler"/> is an <see cref="Element"/> that specifies a handlerBody <see cref="ExecutableNode"/> to execute in case the specified exception occurs during the execution of the protected <see cref="ExecutableNode"/>.
    /// </summary>
    public interface ExceptionHandler : Element
    {
        /// <summary>
        /// An <see cref="ObjectNode"/> within the handlerBody. When the <see cref="ExceptionHandler"/> catches an exception, the exception token is placed on this <see cref="ObjectNode"/>, causing the handlerBody to execute.
        /// </summary>
        ObjectNode ExceptionInput { get; set; }

        /// <summary>
        /// The <see cref="Classifier"/>s whose instances the <see cref="ExceptionHandler"/> catches as exceptions. If an exception occurs whose type is any exceptionType, the <see cref="ExceptionHandler"/> catches the exception and executes the handlerBody.
        /// </summary>
        List<Classifier> ExceptionType { get; set; }

        /// <summary>
        /// An <see cref="ExecutableNode"/> that is executed if the <see cref="ExceptionHandler"/> catches an exception.
        /// </summary>
        ExecutableNode HandlerBody { get; set; }

        /// <summary>
        /// The <see cref="ExecutableNode"/> protected by the <see cref="ExceptionHandler"/>. If an exception propagates out of the protectedNode and has a type matching one of the exceptionTypes, then it is caught by this <see cref="ExceptionHandler"/>.
        /// </summary>
        ExecutableNode ProtectedNode { get; set; }
    }
}