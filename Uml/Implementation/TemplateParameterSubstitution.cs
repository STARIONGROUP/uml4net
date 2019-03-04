// -------------------------------------------------------------------------------------------------
// <copyright file="TemplateParameterSubstitution.cs" company="RHEA System S.A.">
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

using System;

namespace Implementation.CommonStructure
{
    using Uml.Assembler;
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="TemplateParameterSubstitution"/> relates the actual parameter to a formal <see cref="TemplateParameter"/> as part of a template binding.
    /// </summary>
    internal class TemplateParameterSubstitution : Implementation.CommonStructure.Element, Uml.CommonStructure.TemplateParameterSubstitution
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateParameterSubstitution"/> class.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="TemplateParameterSubstitution"/>
        /// </param>
        public TemplateParameterSubstitution(string id) : base(id)
        {
            this.OwnedActual = new OwnerList<ParameterableElement>(this);
        }

        /// <summary>
        /// The <see cref="ParameterableElement"/> that is the actual parameter for this <see cref="TemplateParameterSubstitution"/>.
        /// </summary>
        public ParameterableElement Actual { get; set; }

        /// <summary>
        /// The formal <see cref="TemplateParameter"/> that is associated with this <see cref="TemplateParameterSubstitution"/>.
        /// </summary>
        public Uml.CommonStructure.TemplateParameter Formal { get; set; }

        /// <summary>
        /// The <see cref="ParameterableElement"/> that is owned by this <see cref="TemplateParameterSubstitution"/> as its actual parameter.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="Element.OwnedElement"/>
        /// </remarks>
        public OwnerList<ParameterableElement> OwnedActual { get; set; }

        /// <summary>
        /// The <see cref="TemplateBinding"/> that owns this <see cref="TemplateParameterSubstitution"/>.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="Element.Owner"/>
        /// </remarks>
        public Uml.CommonStructure.TemplateBinding TemplateBinding
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}