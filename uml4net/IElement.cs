// -------------------------------------------------------------------------------------------------
// <copyright file="IElement.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
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
