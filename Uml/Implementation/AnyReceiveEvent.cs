// -------------------------------------------------------------------------------------------------
// <copyright file="AnyReceiveEvent.cs" company="RHEA System S.A.">
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

namespace Implementation.CommonBehavior
{
    using Uml.CommonStructure;

    /// <summary>
    /// A trigger for an <see cref="AnyReceiveEvent"/> is triggered by the receipt of any message that is not explicitly handled by any related trigger.
    /// </summary>
    internal class AnyReceiveEvent : Element, Uml.CommonBehavior.AnyReceiveEvent
    {
    }
}
