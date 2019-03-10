// -------------------------------------------------------------------------------------------------
// <copyright file="ValueSpecification.cs" company="RHEA System S.A.">
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

namespace Uml.Values
{
    using Uml.CommonStructure;
    using Uml.Attributes;
    using Uml.Classification;

    /// <summary>
    /// A <see cref="ValueSpecification"/> is the specification of a (possibly empty) set of values. A <see cref="ValueSpecification"/> is a <see cref="ParameterableElement"/> that may be exposed as a formal <see cref="TemplateParameter"/> and provided as the actual parameter in the binding of a template.
    /// </summary>
    [Class(IsAbstract = true, IsActive = false, Specializations = "Duration|Expression|Interval|LiteralSpecification|OpaqueExpression|TimeExpression|InstanceValue")]
    public interface ValueSpecification : TypedElement, PackageableElement
    {
    }
}