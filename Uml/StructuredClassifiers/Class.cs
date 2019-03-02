// -------------------------------------------------------------------------------------------------
// <copyright file="Class.cs" company="RHEA System S.A.">
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

namespace Uml.StructuredClassifiers
{
    using System.Collections.Generic;
    using Uml.Assembler;
    using Uml.Classification;
    using Uml.Packages;
    using Uml.SimpleClassifiers;

    /// <summary>
    /// A Class classifies a set of objects and specifies the features that characterize the structure and behavior of those objects.  A Class may have an internal structure and Ports.
    /// </summary>
    public interface Class : BehavioredClassifier, EncapsulatedClassifier
    {
        /// <summary>
        /// This property is used when the <see cref="Class"/> is acting as a metaclass. It references the <see cref="Extension"/>s that specify additional properties of the metaclass. The property is derived from the Extensions whose memberEnds are typed by the <see cref="Class"/>.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        IEnumerable<Extension> Extension { get; set; }

        /// <summary>
        /// If true, the <see cref="Class"/> does not provide a complete declaration and cannot be instantiated. An abstract <see cref="Class"/> is typically used as a target of <see cref="Association"/>s or <see cref="Generalization"/>s.
        /// </summary>
        bool IsAbstract { get; set; }

        /// <summary>
        /// Determines whether an object specified by this <see cref="Class"/> is active or not. If true, then the owning <see cref="Class"/> is referred to as an active <see cref="Class"/>. If false, then such a <see cref="Class"/> is referred to as a passive <see cref="Class"/>.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// The <see cref="Classifier"/>s owned by the <see cref="Class"/> that are not ownedBehaviors.
        /// </summary>
        OwnerList<Classifier> NestedClassifier { get; set; }

        /// <summary>
        /// The attributes (i.e., the Properties) owned by the <see cref="Class"/>.
        /// </summary>
        OwnerList<Property> OwnedAttribute { get; set; }

        /// <summary>
        /// The <see cref="Operation"/>s owned by the <see cref="Class"/>.
        /// </summary>
        OwnerList<Operation> OwnedOperation { get; set; }

        /// <summary>
        /// The <see cref="Reception"/>s owned by the <see cref="Class"/>.
        /// </summary>
        OwnerList<Reception> OwnedReception { get; set; }

        /// <summary>
        /// The superclasses of a <see cref="Class"/>, derived from its <see cref="Generalization"/>s.
        /// </summary>
        /// <remarks>
        /// Derived property.
        /// </remarks>
        IEnumerable<Class> SuperClass { get; }
    }
}