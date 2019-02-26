// -------------------------------------------------------------------------------------------------
// <copyright file="StartObjectBehaviorAction.cs" company="RHEA System S.A.">
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
    /// A <see cref="StartObjectBehaviorAction"/> is an <see cref="InvocationAction"/> that starts the execution either of a directly instantiated <see cref="Behavior"/> or of the classifierBehavior of an object. Argument values may be supplied for the input <see cref="Parameter"/>s of the <see cref="Behavior"/>. If the <see cref="Behavior"/> is invoked synchronously, then output values may be obtained for output <see cref="Parameter"/>s.
    /// </summary>
    public interface StartObjectBehaviorAction
    {
    }
}