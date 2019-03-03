// -------------------------------------------------------------------------------------------------
// <copyright file="StructuredActivityNode.cs" company="RHEA System S.A.">
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

namespace Implementation.Actions
{
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="StructuredActivityNode"/> is an <see cref="Action"/> that is also an <see cref="ActivityGroup"/> and whose behavior is specified by the <see cref="ActivityNode"/>s and <see cref="ActivityEdge"/>s it so contains. Unlike other kinds of <see cref="ActivityGroup"/>, a <see cref="StructuredActivityNode"/> owns the <see cref="ActivityNode"/>s and <see cref="ActivityEdge"/>s it contains, and so a node or edge can only be directly contained in one <see cref="StructuredActivityNode"/>, though <see cref="StructuredActivityNode"/>s may be nested.
    /// </summary>
    internal class StructuredActivityNode : Element, Uml.Actions.StructuredActivityNode
    {
    }
}