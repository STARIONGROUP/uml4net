// -------------------------------------------------------------------------------------------------
// <copyright file="Abstraction.cs" company="RHEA System S.A.">
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
    using System.Collections.Generic;
    using Uml.CommonStructure;
    using Uml.Assembler;
    using Uml.Values;
    
    /// <summary>
    /// An <see cref="Abstraction"/> is a <see cref="Relationship"/> that relates two <see cref="Element"/>s or sets of <see cref="Element"/>s that represent the same concept at different levels of abstraction or from different viewpoints.
    /// </summary>
    internal class Abstraction : Implementation.CommonStructure.Element, Uml.CommonStructure.Abstraction
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Abstraction"/>
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="Abstraction"/>
        /// </param>
        protected Abstraction(string id) : base(id)
        {
            this.NameExpression = new OwnerList<StringExpression>(this);
            this.Client = new List<Uml.CommonStructure.NamedElement>();
            this.Supplier = new List<Uml.CommonStructure.NamedElement>();
            this.Mapping = new OwnerList<OpaqueExpression>(this);
        }

        /// <summary>
        /// Specifies the elements related by the <see cref="Abstraction"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public IEnumerable<Uml.CommonStructure.Element> RelatedElement()
        {
            throw new System.NotImplementedException();
        }
       
        /// <summary>
        /// Specifies the source Element(s) of the <see cref="Abstraction"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public IEnumerable<Uml.CommonStructure.Element> Source()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Specifies the target Element(s) of the <see cref="Abstraction"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public IEnumerable<Uml.CommonStructure.Element> Target()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The formal <see cref="TemplateParameter"/> that owns this <see cref="Abstraction"/>.
        /// </summary>
        public Uml.CommonStructure.TemplateParameter OwningTemplateParameter { get; set; }
        
        /// <summary>
        /// The <see cref="TemplateParameter"/> that exposes this <see cref="Abstraction"/> as a formal parameter.
        /// </summary>
        public Uml.CommonStructure.TemplateParameter TemplateParameter { get; set; }
        
        /// <summary>
        /// Indicates the Dependencies that reference this <see cref="Abstraction"/> as a client.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        IEnumerable<Uml.CommonStructure.Dependency> Uml.CommonStructure.NamedElement.ClientDependency()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The name of the <see cref="Abstraction"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The <see cref="StringExpression"/> used to define the name of this <see cref="Abstraction"/>.
        /// </summary>
        public OwnerList<StringExpression> NameExpression { get; set; }

        /// <summary>
        /// Specifies the <see cref="Namespace"/> that owns the <see cref="Abstraction"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public Uml.CommonStructure.Namespace Namespace()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// A name that allows the NamedElement to be identified within a hierarchy of nested Namespaces. It is constructed from the names of the containing Namespaces starting at the root of the hierarchy and ending with the name of the NamedElement itself.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public string QualifiedName()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Determines whether and how the <see cref="Abstraction"/> is visible outside its owning <see cref="Namespace"/>.
        /// </summary>
        public VisibilityKind Visibility { get; set; }

        /// <summary>
        /// The <see cref="Uml.CommonStructure.Element"/>(s) dependent on the supplier <see cref="Uml.CommonStructure.Element"/>(s). In some cases (such as a trace Abstraction) the assignment of direction (that is, the designation of the client Element) is at the discretion of the modeler and is a stipulation.
        /// </summary>
        public List<Uml.CommonStructure.NamedElement> Client { get; set; }
        
        /// <summary>
        /// The <see cref="Uml.CommonStructure.Element"/>(s) on which the client <see cref="Element"/>(s) depend in some respect. The modeler may stipulate a sense of Dependency direction suitable for their domain.
        /// </summary>
        public List<Uml.CommonStructure.NamedElement> Supplier { get; set; }
        
        /// <summary>
        /// An <see cref="OpaqueExpression"/> that states the abstraction relationship between the supplier(s) and the client(s). In some cases, such as derivation, it is usually formal and unidirectional; in other cases, such as trace, it is usually informal and bidirectional. The mapping expression is optional and may be omitted if the precise relationship between the Elements is not specified.
        /// </summary>
        public OwnerList<OpaqueExpression> Mapping { get; set; }
    }
}