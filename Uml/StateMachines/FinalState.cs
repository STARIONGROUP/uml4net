// -------------------------------------------------------------------------------------------------
// <copyright file="FinalState.cs" company="RHEA System S.A.">
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

namespace Uml.StateMachines
{
    using Uml.Attributes;
    
    /// <summary>
    /// A special kind of State, which, when entered, signifies that the enclosing <see cref="Region"/> has completed. If the enclosing Region is directly contained in a <see cref="StateMachine"/> and all other <see cref="Region"/>s in that <see cref="StateMachine"/> also are completed, then it means that the entire <see cref="StateMachine"/> behavior is completed.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "")]
    public interface FinalState : State
    {
    }
}