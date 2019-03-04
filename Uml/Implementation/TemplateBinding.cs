// -------------------------------------------------------------------------------------------------
// <copyright file="TemplateBinding.cs" company="RHEA System S.A.">
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
    using System.Collections.Generic;
    using Uml.Assembler;    
    using Uml.CommonStructure;

    /// <summary>
    /// A <see cref="TemplateBinding"/> is a <see cref="DirectedRelationship"/> between a <see cref="TemplateableElement"/> and a template. A <see cref="TemplateBinding"/> specifies the <see cref="TemplateParameterSubstitution"/>s of actual parameters for the formal parameters of the template.
    /// </summary>
    internal class TemplateBinding : Implementation.CommonStructure.Element, Uml.CommonStructure.TemplateBinding
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateBinding"/> class.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="TemplateBinding"/>
        /// </param>
        public TemplateBinding(string id) : base(id)
        {
            this.ParameterSubstitution = new OwnerList<Uml.CommonStructure.TemplateParameterSubstitution>(this);
        }

        /// <summary>
        /// Specifies the elements related by the <see cref="TemplateBinding"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public IEnumerable<Uml.CommonStructure.Element> RelatedElement()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Specifies the source Element(s) of the <see cref="TemplateBinding"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public IEnumerable<Uml.CommonStructure.Element> Source()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Specifies the target Element(s) of the <see cref="TemplateBinding"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public IEnumerable<Uml.CommonStructure.Element> Target()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The <see cref="TemplateableElement"/> that is bound by this <see cref="TemplateBinding"/>.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="DirectedRelationship.Source"/>
        /// </remarks>
        public TemplateableElement BoundElement
        {
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// The <see cref="TemplateableElement"/> that is bound by this <see cref="TemplateBinding"/>.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="Element.OwnedElement"/>
        /// </remarks>
        public OwnerList<Uml.CommonStructure.TemplateParameterSubstitution> ParameterSubstitution
        {
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// The <see cref="TemplateSignature"/> for the template that is the target of this <see cref="TemplateBinding"/>.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="DirectedRelationship.Target"/>
        /// </remarks>
        public Uml.CommonStructure.TemplateSignature Signature
        {
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException();
        }
    }
}