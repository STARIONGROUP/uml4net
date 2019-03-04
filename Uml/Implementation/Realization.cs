// -------------------------------------------------------------------------------------------------
// <copyright file="Realization.cs" company="RHEA System S.A.">
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
    using Uml.Values;

    /// <summary>
    /// <see cref="Realization"/> is a specialized <see cref="Abstraction"/> relationship between two sets of model <see cref="Element"/>s, one representing a specification (the supplier) and the other represents an implementation of the latter (the client). Realization can be used to model stepwise refinement, optimizations, transformations, templates, model synthesis, framework composition, etc.
    /// </summary>
    internal class Realization : Implementation.CommonStructure.Element, Uml.CommonStructure.Realization
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Realization"/> class.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="Realization"/>
        /// </param>
        public Realization(string id) : base(id)
        {
            this.NameExpression = new OwnerList<StringExpression>(this);
            this.Client = new List<NamedElement>();
            this.Supplier = new List<NamedElement>();
            this.Mapping = new OwnerList<OpaqueExpression>(this);
        }

        /// <summary>
        /// Specifies the elements related by the <see cref="Realization"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public IEnumerable<Uml.CommonStructure.Element> RelatedElement()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Specifies the source Element(s) of the <see cref="Realization"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public IEnumerable<Uml.CommonStructure.Element> Source()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Specifies the target Element(s) of the <see cref="Realization"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public IEnumerable<Uml.CommonStructure.Element> Target()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The formal <see cref="TemplateParameter"/> that owns this <see cref="Realization"/>.
        /// </summary>
        /// <remarks>
        /// subsets <see cref="Element.Owner"/>
        /// </remarks>
        public Uml.CommonStructure.TemplateParameter OwningTemplateParameter { get; set; }
        
        /// <summary>
        /// The <see cref="TemplateParameter"/> that exposes this <see cref="Realization"/> as a formal parameter.
        /// </summary>
        public Uml.CommonStructure.TemplateParameter TemplateParameter { get; set; }
        
        /// <summary>
        /// Indicates the Dependencies that reference this <see cref="Realization"/> as a client.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public IEnumerable<Uml.CommonStructure.Dependency> ClientDependency()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The name of the <see cref="Realization"/>.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The <see cref="StringExpression"/> used to define the name of this <see cref="Realization"/>.
        /// </summary>
        public OwnerList<StringExpression> NameExpression { get; set; }
        
        /// <summary>
        /// Specifies the <see cref="Namespace"/> that owns the <see cref="Realization"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public Namespace Namespace()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// A name that allows the <see cref="Realization"/> to be identified within a hierarchy of nested <see cref="Namespace"/>s. It is constructed from the names of the containing <see cref="Namespace"/>s starting at the root of the hierarchy and ending with the name of the <see cref="Realization"/> itself.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public string QualifiedName()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether and how the <see cref="Realization"/> is visible outside its owning <see cref="Namespace"/>.
        /// </summary>
        public VisibilityKind Visibility { get; set; }
        
        /// <summary>
        /// The <see cref="Element"/>(s) dependent on the supplier <see cref="Element"/>(s). In some cases (such as a trace Abstraction) the assignment of direction (that is, the designation of the client Element) is at the discretion of the modeler and is a stipulation.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="DirectedRelationship.Source"/>
        /// </remarks>
        public List<NamedElement> Client { get; set; }
        
        /// <summary>
        /// The <see cref="Element"/>(s) on which the client <see cref="Element"/>(s) depend in some respect. The modeler may stipulate a sense of Dependency direction suitable for their domain.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="DirectedRelationship.Target"/>
        /// </remarks>
        public List<NamedElement> Supplier { get; set; }
        
        public OwnerList<OpaqueExpression> Mapping { get; set; }
    }
}