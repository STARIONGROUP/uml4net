// -------------------------------------------------------------------------------------------------
// <copyright file="XmiWriteContext.cs" company="Starion Group S.A.">
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
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The <see cref="XmiWriteContext"/> represents the state of a single write operation that is
    /// shared by all <see cref="XmiElementWriter{TXmiElement}"/> instances while writing an XMI document.
    /// </summary>
    public class XmiWriteContext : IXmiWriteContext
    {
        /// <summary>
        /// The <see cref="IXmiElement.FullyQualifiedIdentifier"/>s of the elements that are serialized
        /// inside the document that is being written.
        /// </summary>
        private readonly HashSet<string> localIdentifiers;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiWriteContext"/> class.
        /// </summary>
        /// <param name="documentName">
        /// The name of the document that is being written
        /// </param>
        /// <param name="localIdentifiers">
        /// The <see cref="IXmiElement.FullyQualifiedIdentifier"/>s of the elements that are serialized
        /// inside the document that is being written
        /// </param>
        public XmiWriteContext(string documentName, HashSet<string> localIdentifiers)
            : this(documentName, localIdentifiers, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiWriteContext"/> class.
        /// </summary>
        /// <param name="documentName">
        /// The name of the document that is being written
        /// </param>
        /// <param name="localIdentifiers">
        /// The <see cref="IXmiElement.FullyQualifiedIdentifier"/>s of the elements that are serialized
        /// inside the document that is being written
        /// </param>
        /// <param name="isCanonical">
        /// A value indicating whether the document is written as Canonical XMI (XMI 2.5.1 Annex B)
        /// </param>
        public XmiWriteContext(string documentName, HashSet<string> localIdentifiers, bool isCanonical)
        {
            this.DocumentName = documentName ?? throw new ArgumentNullException(nameof(documentName));
            this.localIdentifiers = localIdentifiers ?? throw new ArgumentNullException(nameof(localIdentifiers));
            this.IsCanonical = isCanonical;
        }

        /// <summary>
        /// The Canonical XMI identifiers, by object, once they are derived (XMI 2.5.1 Annex B.6)
        /// </summary>
        private readonly Dictionary<object, string> canonicalIdentifiers = new(ObjectReferenceEqualityComparer.Instance);

        /// <summary>
        /// The top-level objects that were recorded, in the order of serialization
        /// </summary>
        private readonly List<CanonicalObjectRecord> recordedRoots = [];

        /// <summary>
        /// The objects whose serialization is in progress, the innermost one on top
        /// </summary>
        private readonly Stack<CanonicalObjectRecord> openRecords = new();

        /// <summary>
        /// Gets the name of the document that is being written.
        /// </summary>
        public string DocumentName { get; }

        /// <summary>
        /// Gets a value indicating whether the document is written as Canonical XMI (XMI 2.5.1 Annex B)
        /// </summary>
        public bool IsCanonical { get; }

        /// <summary>
        /// Gets a value indicating whether the objects that are serialized are recorded, the first pass of a Canonical
        /// XMI write, after which the identifiers are derived with <see cref="DeriveCanonicalIdentifiers"/>
        /// </summary>
        public bool IsRecording { get; private set; }

        /// <summary>
        /// Starts the recording of the objects that are serialized
        /// </summary>
        public void StartRecording()
        {
            this.recordedRoots.Clear();
            this.openRecords.Clear();
            this.canonicalIdentifiers.Clear();
            this.IsRecording = true;
        }

        /// <summary>
        /// Stops the recording and derives the Canonical XMI identifiers of the recorded objects (XMI 2.5.1 Annex B.6),
        /// which <see cref="QueryXmiId"/> returns from then on
        /// </summary>
        public void DeriveCanonicalIdentifiers()
        {
            this.IsRecording = false;

            foreach (var identifier in CanonicalIdentifierCalculator.Calculate(this.recordedRoots))
            {
                this.canonicalIdentifiers[identifier.Key] = identifier.Value;

                if (identifier.Key is IXmiElement xmiElement && !string.IsNullOrEmpty(xmiElement.XmiId))
                {
                    this.canonicalIdentifiersByReadIdentifier[xmiElement.XmiId] = identifier.Value;
                }
            }
        }

        /// <summary>
        /// The Canonical XMI identifiers of the elements of the document, by the <c>xmi:id</c> that was read
        /// </summary>
        private readonly Dictionary<string, string> canonicalIdentifiersByReadIdentifier = new(StringComparer.Ordinal);

        /// <summary>
        /// Queries the <c>xmi:id</c> with which the element of the document that was read with the provided <c>xmi:id</c>
        /// is written, for a reference that is held as an identifier, such as the <c>element</c> of a MOF tag
        /// </summary>
        /// <param name="readXmiId">
        /// The <c>xmi:id</c> that was read
        /// </param>
        /// <returns>
        /// The derived Canonical XMI identifier of the element, once derived, the <paramref name="readXmiId"/> otherwise
        /// </returns>
        public string QueryXmiIdByReadIdentifier(string readXmiId)
        {
            return !string.IsNullOrEmpty(readXmiId) && this.canonicalIdentifiersByReadIdentifier.TryGetValue(readXmiId, out var identifier) ? identifier : readXmiId;
        }

        /// <summary>
        /// Queries the <c>xmi:id</c> with which the provided object is written
        /// </summary>
        /// <param name="element">
        /// The object, an <see cref="IXmiElement"/> or another top-level object such as a tag
        /// </param>
        /// <param name="readXmiId">
        /// The <c>xmi:id</c> that was read
        /// </param>
        /// <returns>
        /// The derived Canonical XMI identifier, once derived, the <paramref name="readXmiId"/> otherwise
        /// </returns>
        public string QueryXmiId(object element, string readXmiId)
        {
            return element != null && this.canonicalIdentifiers.TryGetValue(element, out var identifier) ? identifier : readXmiId;
        }

        /// <summary>
        /// Queries the <c>xmi:uuid</c> with which an object is written in Canonical XMI: the one that was read, or else the
        /// name of the document followed by <c>#</c> and the <c>xmi:id</c> that was read (XMI 2.5.1 Annex B.6)
        /// </summary>
        /// <param name="readXmiUuid">
        /// The <c>xmi:uuid</c> that was read
        /// </param>
        /// <param name="readXmiId">
        /// The <c>xmi:id</c> that was read
        /// </param>
        /// <returns>
        /// The <c>xmi:uuid</c>, null when neither was read
        /// </returns>
        public string QueryCanonicalXmiUuid(string readXmiUuid, string readXmiId)
        {
            if (!string.IsNullOrEmpty(readXmiUuid))
            {
                return readXmiUuid;
            }

            return string.IsNullOrEmpty(readXmiId) ? null : $"{this.DocumentName}#{readXmiId}";
        }

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
        public string QueryXmiId(IXmiElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return this.QueryXmiId(element, element.XmiId);
        }

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
        public string QueryXmiUuid(IXmiElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return this.IsCanonical ? this.QueryCanonicalXmiUuid(element.XmiGuid, element.XmiId) : element.XmiGuid;
        }

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
        public IEnumerable<T> QueryCanonicalOrder<T>(IEnumerable<T> values, bool isContainment) where T : IXmiElement
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            var valueList = values.ToList();
            var localValues = valueList.Where(x => this.IsLocal(x)).ToList();

            var orderedLocalValues = isContainment
                ? localValues.OrderBy(x => this.QueryXmiUuid(x) ?? string.Empty, StringComparer.Ordinal)
                : localValues.OrderBy(x => this.QueryXmiId(x) ?? string.Empty, StringComparer.Ordinal);

            var orderedExternalValues = valueList.Where(x => !this.IsLocal(x)).OrderBy(x => this.QueryHref(x), StringComparer.Ordinal);

            return orderedLocalValues.Concat(orderedExternalValues).ToList();
        }

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
        public void BeginCanonicalObject(object element, string elementName, string name)
        {
            if (!this.IsRecording)
            {
                return;
            }

            var record = new CanonicalObjectRecord(element, elementName, name, this.openRecords.Count == 0);

            if (this.openRecords.Count == 0)
            {
                this.recordedRoots.Add(record);
            }
            else
            {
                this.openRecords.Peek().Children.Add(record);
            }

            this.openRecords.Push(record);
        }

        /// <summary>
        /// Records the end of the Canonical XMI serialization of the object that was begun last
        /// </summary>
        public void EndCanonicalObject()
        {
            if (this.IsRecording && this.openRecords.Count > 0)
            {
                this.openRecords.Pop();
            }
        }

        /// <summary>
        /// Queries whether the provided <see cref="IXmiElement"/> is serialized inside the document that is being written.
        /// </summary>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that is to be checked
        /// </param>
        /// <returns>
        /// true when the <paramref name="element"/> is part of the document that is being written, false otherwise
        /// </returns>
        public bool IsLocal(IXmiElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return this.localIdentifiers.Contains(element.FullyQualifiedIdentifier);
        }

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
        public string QueryHref(IXmiElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return $"{element.DocumentName}#{element.XmiId}";
        }
    }
}
