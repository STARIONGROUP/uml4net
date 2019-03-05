// -------------------------------------------------------------------------------------------------
// <copyright file="Duration.cs" company="RHEA System S.A.">
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

namespace Implementation.Values
{
    using System.Collections.Generic;
    using Uml.Assembler;
    using Uml.Values;
    using Uml.CommonStructure;

    /// <summary>
    /// A Duration is a ValueSpecification that specifies the temporal distance between two time instants.
    /// </summary>
    internal class Duration : Implementation.CommonStructure.Element, Uml.Values.Duration
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Duration"/>
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="Duration"/>
        /// </param>
        public Duration(string id) : base(id)
        {
            this.NameExpression = new OwnerList<Uml.Values.StringExpression>(this);
            this.Expr = new OwnerList<ValueSpecification>(this);
            this.Observation = new List<Observation>();
            this.NameExpression = new OwnerList<Uml.Values.StringExpression>(this);
        }

        /// <summary>
        /// Indicates the Dependencies that reference this <see cref="NamedElement"/> as a client.
        /// </summary>
        public IEnumerable<Dependency> ClientDependency()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The name of the <see cref="NamedElement"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The <see cref="Uml.Values.StringExpression"/> used to define the name of this <see cref="NamedElement"/>.
        /// </summary>
        public OwnerList<Uml.Values.StringExpression> NameExpression { get; set; }

        /// <summary>
        /// Specifies the <see cref="NamedElement.Namespace"/> that owns the <see cref="NamedElement"/>.
        /// </summary>
        public Namespace Namespace()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// A name that allows the <see cref="NamedElement"/> to be identified within a hierarchy of nested <see cref="NamedElement.Namespace"/>s. It is constructed from the names of the containing <see cref="NamedElement.Namespace"/>s starting at the root of the hierarchy and ending with the name of the <see cref="NamedElement"/> itself.
        /// </summary>
        public string QualifiedName()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Determines whether and how the <see cref="NamedElement"/> is visible outside its owning <see cref="NamedElement.Namespace"/>.
        /// </summary>
        public VisibilityKind Visibility { get; set; }

        /// <summary>
        /// The type of the <see cref="TypedElement"/>.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// The formal <see cref="ParameterableElement.TemplateParameter"/> that owns this <see cref="ParameterableElement"/>.
        /// </summary>
        public TemplateParameter OwningTemplateParameter { get; set; }

        /// <summary>
        /// The <see cref="ParameterableElement.TemplateParameter"/> that exposes this <see cref="ParameterableElement"/> as a formal parameter.
        /// </summary>
        public TemplateParameter TemplateParameter { get; set; }

        /// <summary>
        /// A <see cref="Uml.Values.Duration"/> is a <see cref="ValueSpecification"/> that specifies the temporal distance between two time instants.
        /// </summary>
        public OwnerList<ValueSpecification> Expr { get; set; }

        /// <summary>
        /// Refers to the <see cref="Uml.Values.Duration.Observation"/>s that are involved in the computation of the <see cref="Uml.Values.Duration"/> value
        /// </summary>
        public List<Observation> Observation { get; set; }
    }
}