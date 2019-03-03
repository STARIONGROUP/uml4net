// -------------------------------------------------------------------------------------------------
// <copyright file="ParameterSet.cs" company="RHEA System S.A.">
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

namespace Uml.Classification
{
    using System.Collections.Generic;
    using Uml.Assembler;
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="ParameterSet"/> designates alternative sets of inputs or outputs that a Behavior may use.
    /// </summary>
    public interface ParameterSet : NamedElement
    {
        /// <summary>
        /// A constraint that should be satisfied for the owner of the Parameters in an input ParameterSet to start execution using the values provided for those Parameters, or the owner of the Parameters in an output ParameterSet to end execution providing the values for those Parameters, if all preconditions and conditions on input ParameterSets were satisfied.
        /// </summary>
        OwnerList<Constraint> Condition { get; set; }

        /// <summary>
        /// Parameters in the ParameterSet.
        /// </summary>
        List<Parameter> Parameter { get; set; }
    }
}