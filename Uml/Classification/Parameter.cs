// -------------------------------------------------------------------------------------------------
// <copyright file="Parameter.cs" company="RHEA System S.A.">
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

namespace Uml.Classification
{
    using System.Collections.Generic;
    using Uml.CommonStructure;
    using Uml.StructuredClassifiers;

    /// <summary>
    /// A Parameter is a specification of an argument used to pass information into or out of an invocation of a BehavioralFeature.  Parameters can be treated as ConnectableElements within Collaborations.
    /// </summary>
    public interface Parameter : MultiplicityElement, ConnectableElement
    {
        /// <summary>
        /// A String that represents a value to be used when no argument is supplied for the Parameter.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        string Default { get; set; }

        /// <summary>
        /// Indicates whether a parameter is being sent into or out of a behavioral element.
        /// </summary>
        ParameterDirectionKind Direction { get; set; }

        /// <summary>
        /// Specifies the effect that executions of the owner of the Parameter have on objects passed in or out of the parameter.
        /// </summary>
        ParameterEffectKind Effect { get; set; }

        /// <summary>
        /// Tells whether an output parameter may emit a value to the exclusion of the other outputs.
        /// </summary>
        bool IsException { get; set; }

        /// <summary>
        /// Tells whether an input parameter may accept values while its behavior is executing, or whether an output parameter may post values while the behavior is executing.
        /// </summary>
        bool IsStream { get; set; }

        /// <summary>
        /// The Operation owning this parameter.
        /// </summary>
        Operation Operation { get; set; }

        /// <summary>
        /// The ParameterSets containing the parameter. See ParameterSet.
        /// </summary>
        List<ParameterSet>  ParameterSet { get; set; }
    }
}