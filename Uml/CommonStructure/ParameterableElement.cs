// -------------------------------------------------------------------------------------------------
// <copyright file="ParameterableElement.cs" company="RHEA System S.A.">
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

namespace Uml.CommonStructure
{
    using Uml.Attributes;

    /// <summary>
    /// A <see cref="ParameterableElement"/> is an <see cref="Element"/> that can be exposed as a formal <see cref="TemplateParameter"/> for a template, or specified as an actual parameter in a binding of a template.
    /// </summary>
    [Class(IsAbstract = true, IsActive = false)]
    public interface ParameterableElement : Element
    {
        /// <summary>
        /// The formal <see cref="TemplateParameter"/> that owns this <see cref="ParameterableElement"/>.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="Element.Owner"/>.
        /// </remarks>
        TemplateParameter OwningTemplateParameter { get; set; }

        /// <summary>
        /// The <see cref="TemplateParameter"/> that exposes this <see cref="ParameterableElement"/> as a formal parameter.
        /// </summary>
        TemplateParameter TemplateParameter { get; set; }
    }
}