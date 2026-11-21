// -------------------------------------------------------------------------------------------------
// <copyright file="IElement.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.CommonStructure
{
    using System;

    /// <summary>
    /// An Element is a constituent of a model. As such, it has the capability of owning other Elements.
    /// </summary>
    public partial interface IElement : IXmiElement
    {
        /// <summary>
        /// Gets or sets the container of this <see cref="IElement"/>
        /// </summary>
        public IElement Possessor { get; set; }

        /// <summary>
        /// Gets the most specific uml4net-generated interface (e.g. <c>typeof(IComponent)</c> for a
        /// <c>Component</c> instance) that represents the UML metaclass of this instance.
        /// </summary>
        /// <remarks>
        /// uml4net's generated concrete classes only ever inherit from <c>XmiElement</c> - the UML
        /// generalization hierarchy is expressed exclusively through interface inheritance (e.g.
        /// <c>IComponent : IClass</c>). This property lets callers evaluate OCL's
        /// <c>oclIsKindOf</c>/<c>oclType()</c> against an instance's actual UML metaclass (e.g. for
        /// <c>NamedElement::isDistinguishableFrom</c>) without resorting to reflection: each generated
        /// class implements this by returning a hardcoded <c>typeof(I{ClassName})</c> literal.
        /// </remarks>
        public Type MetaclassInterface { get; }
    }
}
