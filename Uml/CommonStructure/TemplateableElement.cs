// -------------------------------------------------------------------------------------------------
// <copyright file="TemplateableElement.cs" company="RHEA System S.A.">
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
    using Uml.Assembler;

    /// <summary>
    /// A <see cref="TemplateableElement"/> is an <see cref="Element"/> that can optionally be defined as a template and bound to other templates.
    /// </summary>
    public interface TemplateableElement : Element
    {
        /// <summary>
        /// The optional <see cref="TemplateSignature"/> specifying the formal <see cref="TemplateParameter"/>s for this <see cref="TemplateableElement"/>. If a <see cref="TemplateableElement"/> has a <see cref="TemplateSignature"/>, then it is a template.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="Element.OwnedElement"/>
        /// </remarks>
        OwnerList<TemplateSignature> OwnedTemplateSignature { get; set; }

        /// <summary>
        /// The optional <see cref="TemplateBinding"/>s from this <see cref="TemplateableElement"/> to one or more templates.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="Element.OwnedElement"/>
        /// </remarks>
        OwnerList<TemplateBinding> TemplateBinding { get; set; }
    }
}