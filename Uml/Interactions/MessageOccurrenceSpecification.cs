// -------------------------------------------------------------------------------------------------
// <copyright file="MessageOccurrenceSpecification.cs" company="RHEA System S.A.">
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

namespace Uml.Interactions
{
    using Uml.Actions;
    using Uml.Attributes;
    using Uml.Classification;
    using Uml.SimpleClassifiers;

    /// <summary>
    /// A <see cref="MessageOccurrenceSpecification"/> specifies the occurrence of <see cref="Message"/> events, such as sending and receiving of <see cref="Signal"/>s or invoking or receiving of <see cref="Operation"/> calls. A <see cref="MessageOccurrenceSpecification"/> is a kind of <see cref="MessageEnd"/>. <see cref="Message"/>s are generated either by synchronous <see cref="Operation"/> calls or asynchronous Signal sends. They are received by the execution of corresponding <see cref="AcceptEventAction"/>s.
    /// </summary>
    [Class(IsAbstract = false, IsActive = false, Specializations = "DestructionOccurrenceSpecification")]
    public interface MessageOccurrenceSpecification : MessageEnd, OccurrenceSpecification
    {
    }
}