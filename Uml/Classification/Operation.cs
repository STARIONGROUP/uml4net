// -------------------------------------------------------------------------------------------------
// <copyright file="Operation.cs" company="RHEA System S.A.">
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
    using Uml.Assembler;
    using Uml.CommonStructure;
    using Uml.SimpleClassifiers;
    using Uml.StructuredClassifiers;

    /// <summary>
    /// An <see cref="Operation"/> is a <see cref="BehavioralFeature"/> of a <see cref="Classifier"/> that specifies the name, type, parameters, and constraints for invoking an associated <see cref="Behavior"/>. An <see cref="Operation"/> may invoke both the execution of method behaviors as well as other behavioral responses. <see cref="Operation"/> specializes <see cref="TemplateableElement"/> in order to support specification of template operations and bound operations. <see cref="Operation"/> specializes <see cref="ParameterableElement"/> to specify that an operation can be exposed as a formal template parameter, and provided as an actual parameter in a binding of a template.
    /// </summary>
    public interface Operation : TemplateableElement, ParameterableElement, BehavioralFeature
    {
        /// <summary>
        /// An optional <see cref="Constraint"/> on the result values of an invocation of this <see cref="Operation"/>.
        /// </summary>
        OwnerList<Constraint> BodyCondition { get; set; }

        /// <summary>
        /// The <see cref="Class"/> that owns this operation, if any.
        /// </summary>
        Class Class { get; set; }

        /// <summary>
        /// The <see cref="DataType"/> that owns this <see cref="Operation"/>, if any.
        /// </summary>
        DataType DataType { get; set; }

        /// <summary>
        /// The <see cref="Interface"/> that owns this Operation, if any.
        /// </summary>
        Interface Interface { get; set; } 

        /// <summary>
        /// Specifies whether the return parameter is ordered or not, if present. This information is derived from the return result for this <see cref="Operation"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        bool IsOrdered { get; }

        /// <summary>
        /// Specifies whether an execution of the <see cref="BehavioralFeature"/> leaves the state of the system unchanged (isQuery=true) or whether side effects may occur (isQuery=false).
        /// </summary>
        bool IsQuery { get; set; }

        /// <summary>
        /// Specifies whether the return parameter is unique or not, if present. This information is derived from the return result for this <see cref="Operation"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        bool IsUnique { get; }

        /// <summary>
        /// Specifies the lower multiplicity of the return parameter, if present. This information is derived from the return result for this <see cref="Operation"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        int Lower { get;  }

        /// <summary>
        /// The parameters owned by this <see cref="Operation"/>.
        /// </summary>
        OwnerList<Parameter> OwnedParameter { get; set; }

        /// <summary>
        /// An optional set of Constraints specifying the state of the system when the <see cref="Operation"/> is completed.
        /// </summary>
        OwnerList<Constraint> Postcondition { get; set; }

        /// <summary>
        /// An optional set of <see cref="Constraint"/>s on the state of the system when the <see cref="Operation"/> is invoked.
        /// </summary>
        OwnerList<Constraint> Precondition { get; set; }

        /// <summary>
        /// The <see cref="Type"/>s representing exceptions that may be raised during an invocation of this operation.
        /// </summary>
        List<Type> RaisedException { get; set; }

        /// <summary>
        /// The <see cref="Operation"/>s that are redefined by this <see cref="Operation"/>.
        /// </summary>
        List<Operation> RedefinedOperation { get; set; }

        /// <summary>
        /// The <see cref="OperationTemplateParameter"/> that exposes this element as a formal parameter.
        /// </summary>
        OperationTemplateParameter TemplateParameter { get; set; }

        /// <summary>
        /// The return type of the operation, if present. This information is derived from the return result for this <see cref="Operation"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        Type Type { get; }

        /// <summary>
        /// The upper multiplicity of the return parameter, if present. This information is derived from the return result for this <see cref="Operation"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        string Upper { get; }
    }
}