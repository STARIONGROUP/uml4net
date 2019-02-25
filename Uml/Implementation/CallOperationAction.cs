// -------------------------------------------------------------------------------------------------
// <copyright file="CallOperationAction.cs" company="RHEA System S.A.">
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

namespace Implementation.Actions
{
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="CallOperationAction"/> is a <see cref="CallAction"/> that transmits an <see cref="Operation"/> call request to the target object, where it may cause the invocation of associated <see cref="Behavior"/>. The argument values of the <see cref="CallOperationAction"/> are passed on the input Parameters of the <see cref="Operation"/>. If call is synchronous, the execution of the <see cref="CallOperationAction"/> waits until the execution of the invoked <see cref="Operation"/> completes and the values of output <see cref="Parameter"/>s of the <see cref="Operation"/> are placed on the result <see cref="OutputPin"/>s. If the call is asynchronous, the <see cref="CallOperationAction"/> completes immediately and no results values can be provided.
    /// </summary>
    internal class CallOperationAction : Element, Uml.Actions.CallOperationAction
    {
    }
}
