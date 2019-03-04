// -------------------------------------------------------------------------------------------------
// <copyright file="TemplateParameter.cs" company="RHEA System S.A.">
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

namespace Implementation.CommonStructure
{
    using System;
    using Uml.Assembler;
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="TemplateParameter"/> exposes a <see cref="ParameterableElement"/> as a formal parameter of a template.
    /// </summary>
    internal class TemplateParameter : Implementation.CommonStructure.Element, Uml.CommonStructure.TemplateParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateParameter"/> class.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="TemplateParameter"/>
        /// </param>
        public TemplateParameter(string id) : base(id)
        {
            this.OwnedDefault = new OwnerList<ParameterableElement>(this);
            this.OwnedParameteredElement = new OwnerList<ParameterableElement>(this);
        }

        /// <summary>
        /// The <see cref="ParameterableElement"/> that is the default for this formal <see cref="TemplateParameter"/>.
        /// </summary>
        public ParameterableElement Default { get; set; }

        /// <summary>
        /// The <see cref="ParameterableElement"/> that is owned by this <see cref="TemplateParameter"/> for the purpose of providing a default.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="Element.OwnedElement"/>
        /// </remarks>
        public OwnerList<ParameterableElement> OwnedDefault
        {
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// The <see cref="ParameterableElement"/> that is owned by this <see cref="TemplateParameter"/> for the purpose of exposing it as the parameteredElement.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="Element.OwnedElement"/>
        /// </remarks>
        public OwnerList<ParameterableElement> OwnedParameteredElement
        {
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// The <see cref="ParameterableElement"/> exposed by this <see cref="TemplateParameter"/>.
        /// </summary>
        public ParameterableElement ParameterableElement { get; set; }

        /// <summary>
        /// The <see cref="TemplateSignature"/> that owns this <see cref="TemplateParameter"/>.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="Element.Owner"/>
        /// </remarks>
        public Uml.CommonStructure.TemplateSignature Signature
        {
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException();
        }
    }
}