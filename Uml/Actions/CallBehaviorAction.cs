// -------------------------------------------------------------------------------------------------
// <copyright file="CallBehaviorAction.cs" company="RHEA System S.A.">
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

namespace Uml.Actions
{
    /// <summary>
    /// A <see cref="CallBehaviorAction"/> is a <see cref="CallAction"/> that invokes a <see cref="Behavior"/> directly. The argument values of the <see cref="CallBehaviorAction"/> are passed on the input <see cref="Parameter"/>s of the invoked <see cref="Behavior"/>. If the call is synchronous, the execution of the <see cref="CallBehaviorAction"/> waits until the execution of the invoked <see cref="Behavior"/> completes and the values of output <see cref="Parameter"/>s of the Behavior are placed on the result <see cref="OutputPin"/>s. If the call is asynchronous, the <see cref="CallBehaviorAction"/> completes immediately and no results values can be provided.
    /// </summary>
    public interface CallBehaviorAction
    {
    }
}
