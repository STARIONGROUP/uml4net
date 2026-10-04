// -------------------------------------------------------------------------------------------------
// <copyright file="IXmiWriteContext.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Writers
{
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="IXmiWriteContext"/> interface defines the state of a single write operation that is
    /// shared by all <see cref="XmiElementWriter{TXmiElement}"/> instances while writing an XMI document.
    /// </summary>
    public interface IXmiWriteContext
    {
        /// <summary>
        /// Gets the name of the document that is being written.
        /// </summary>
        string DocumentName { get; }

        /// <summary>
        /// Queries whether the provided <see cref="IXmiElement"/> is serialized inside the document that is being written.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that is to be checked
        /// </param>
        /// <returns>
        /// true when the <paramref name="element"/> is part of the document that is being written, false otherwise
        /// </returns>
        bool IsLocal(IXmiElement element);

        /// <summary>
        /// Queries the href reference to the provided <see cref="IXmiElement"/>, which is the concatenation
        /// of the <see cref="IXmiElement.DocumentName"/> and the <see cref="IXmiElement.XmiId"/> separated by a pound sign #
        /// </summary>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> for which the href reference is queried
        /// </param>
        /// <returns>
        /// the href reference to the <paramref name="element"/>
        /// </returns>
        string QueryHref(IXmiElement element);

        /// <summary>
        /// Gets a value indicating whether the document is written as Canonical XMI (XMI 2.5.1 Annex B)
        /// </summary>
        bool IsCanonical { get; }

        /// <summary>
        /// Queries the <c>xmi:id</c> with which the provided object is written: the identifier that was read, or, for
        /// Canonical XMI, the identifier derived from the model (XMI 2.5.1 Annex B.6)
        /// </summary>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> whose identifier is queried
        /// </param>
        /// <returns>
        /// The <c>xmi:id</c> to write
        /// </returns>
        string QueryXmiId(IXmiElement element);

        /// <summary>
        /// Queries the <c>xmi:uuid</c> with which the provided object is written: the one that was read, if any, or, for
        /// Canonical XMI, which requires one on every object, the name of the document followed by <c>#</c> and the
        /// <c>xmi:id</c> that was read (XMI 2.5.1 Annex B.6)
        /// </summary>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> whose uuid is queried
        /// </param>
        /// <returns>
        /// The <c>xmi:uuid</c> to write, null or empty when none is written
        /// </returns>
        string QueryXmiUuid(IXmiElement element);

        /// <summary>
        /// Orders the values of a property that is not ordered as Canonical XMI prescribes (XMI 2.5.1 Annex B.5.3): the
        /// nested elements first, by <c>xmi:uuid</c>, then the <c>xmi:idref</c> links by identifier, then the <c>href</c>
        /// links by href
        /// </summary>
        /// <typeparam name="T">
        /// The type of the values
        /// </typeparam>
        /// <param name="values">
        /// The values of the property
        /// </param>
        /// <param name="isContainment">
        /// A value indicating whether the property is a containment, whose local values are nested elements rather than
        /// <c>xmi:idref</c> links
        /// </param>
        /// <returns>
        /// The ordered values
        /// </returns>
        IEnumerable<T> QueryCanonicalOrder<T>(IEnumerable<T> values, bool isContainment) where T : IXmiElement;

        /// <summary>
        /// Records the start of the Canonical XMI serialization of an object, so that its <c>xmi:id</c> can be derived from
        /// its position in the document (XMI 2.5.1 Annex B.6)
        /// </summary>
        /// <param name="element">
        /// The object that is serialized: an <see cref="IXmiElement"/> or another top-level object such as a tag
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that serializes the object, the name of the property that contains it for a nested object
        /// </param>
        /// <param name="name">
        /// The name of the object, its identifier in the sense of Annex B.6, null or empty when it has none
        /// </param>
        void BeginCanonicalObject(object element, string elementName, string name);

        /// <summary>
        /// Records the end of the Canonical XMI serialization of the object that was begun last
        /// </summary>
        void EndCanonicalObject();
    }
}
