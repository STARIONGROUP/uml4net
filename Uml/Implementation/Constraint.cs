// -------------------------------------------------------------------------------------------------
// <copyright file="Constraint.cs" company="RHEA System S.A.">
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
    using Uml.Assembler;
    using Uml.CommonStructure;
    using Uml.Values;   

    /// <summary>
    /// A <see cref="Constraint"/> is a condition or restriction expressed in natural language text or in a machine readable language for the purpose of declaring some of the semantics of an <see cref="Element"/> or set of <see cref="Element"/>s.
    /// </summary>
    internal class Constraint : Uml.Implementation.Element, Uml.CommonStructure.Constraint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Comment"/> class.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="Abstraction"/>
        /// </param>
        public Constraint(string id) : base(id)
        {
            this.NameExpression = new OwnerList<StringExpression>(this);
            this.ConstrainedElement = new List<Element>();
            this.Specification = new OwnerList<ValueSpecification>(this);
        }

        /// <summary>
        /// The formal <see cref="TemplateParameter"/> that owns this <see cref="Constraint"/>.
        /// </summary>
        public Uml.CommonStructure.TemplateParameter OwningTemplateParameter { get; set; }
        
        /// <summary>
        /// The <see cref="TemplateParameter"/> that exposes this <see cref="Constraint"/> as a formal parameter.
        /// </summary>
        public Uml.CommonStructure.TemplateParameter TemplateParameter { get; set; }

        /// <summary>
        /// Indicates the Dependencies that reference this <see cref="Constraint"/> as a client.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public IEnumerable<Uml.CommonStructure.Dependency> ClientDependency()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The name of the <see cref="Constraint"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The <see cref="StringExpression"/> used to define the name of this <see cref="Constraint"/>.
        /// </summary>
        public OwnerList<StringExpression> NameExpression { get; set; }

        /// <summary>
        /// Specifies the <see cref="Namespace"/> that owns the <see cref="NamedConstraintElement"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public Uml.CommonStructure.Namespace Namespace()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// A name that allows the <see cref="Constraint"/> to be identified within a hierarchy of nested <see cref="Namespace"/>s. It is constructed from the names of the containing <see cref="Namespace"/>s starting at the root of the hierarchy and ending with the name of the <see cref="Constraint"/> itself.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public string QualifiedName()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Determines whether and how the <see cref="Constraint"/> is visible outside its owning <see cref="Namespace"/>.
        /// </summary>
        public VisibilityKind Visibility { get; set; }
        
        /// <summary>
        /// The ordered set of Elements referenced by this <see cref="Constraint"/>.
        /// </summary>
        public List<Element> ConstrainedElement { get; set; }
        
        /// <summary>
        /// Specifies the Namespace that owns the Constraint.
        /// </summary>
        public Uml.CommonStructure.Namespace Context { get; set; }
        
        /// <summary>
        /// A condition that must be true when evaluated in order for the <see cref="Constraint"/> to be satisfied.
        /// </summary>
        public OwnerList<ValueSpecification> Specification { get; set; }
    }
}