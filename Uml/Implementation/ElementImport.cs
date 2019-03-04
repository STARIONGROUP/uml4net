// -------------------------------------------------------------------------------------------------
// <copyright file="ElementImport.cs" company="RHEA System S.A.">
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
    using Uml.CommonStructure;

    /// <summary>
    /// An <see cref="ElementImport"/> identifies a <see cref="NamedElement"/> in a <see cref="Namespace"/> other than the one that owns that <see cref="NamedElement"/> and allows the <see cref="NamedElement"/> to be referenced using an unqualified name in the Namespace owning the <see cref="ElementImport"/>.
    /// </summary>
    internal class ElementImport : Implementation.CommonStructure.Element, Uml.CommonStructure.ElementImport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElementImport"/> class.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="ElementImport"/>
        /// </param>
        public ElementImport(string id) : base(id)
        {
        }

        /// <summary>
        /// Specifies the elements related by the <see cref="ElementImport"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public IEnumerable<Uml.CommonStructure.Element> RelatedElement()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Specifies the source Element(s) of the <see cref="ElementImport"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public IEnumerable<Uml.CommonStructure.Element> Source()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Specifies the target Element(s) of the <see cref="ElementImport"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        public IEnumerable<Uml.CommonStructure.Element> Target()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Specifies the name that should be added to the importing Namespace in lieu of the name of the imported PackagableElement. The alias must not clash with any other member in the importing Namespace. By default, no alias is used.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Specifies the <see cref="PackageableElement"/> whose name is to be added to a <see cref="Namespace"/>.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="DirectedRelationship.Target"/>
        /// </remarks>
        public Uml.CommonStructure.PackageableElement ImportedElement 
        { 
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        
        /// <summary>
        /// Specifies the <see cref="Namespace"/> that imports a <see cref="PackageableElement"/> from another <see cref="Namespace"/>.
        /// </summary>
        /// <remarks>
        /// Subsets <see cref="DirectedRelationship.Source"/>
        /// </remarks>
        public Uml.CommonStructure.Namespace ImportingNamespace
        { 
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// Specifies the visibility of the imported <see cref="PackageableElement"/> within the importingNamespace, i.e., whether the  importedElement will in turn be visible to other <see cref="Namespaces"/>. If the <see cref="ElementImport"/> is public, the importedElement will be visible outside the importingNamespace while, if the <see cref="ElementImport"/> is private, it will not.
        /// </summary>
        public VisibilityKind Visibility { get; set; }
    }
}