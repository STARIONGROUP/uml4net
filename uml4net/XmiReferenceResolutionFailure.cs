// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReferenceResolutionFailure.cs" company="Starion Group S.A.">
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

namespace uml4net
{
    /// <summary>
    /// Represents a reference that the <see cref="IAssembler"/> could not resolve while assembling the object graph
    /// </summary>
    public class XmiReferenceResolutionFailure
    {
        /// <summary>
        /// Gets or sets the name of the document that contains the element that declares the reference
        /// </summary>
        public string DocumentName { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IXmiElement.XmiId"/> of the element that declares the reference
        /// </summary>
        public string ElementXmiId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IXmiElement.XmiType"/> of the element that declares the reference
        /// </summary>
        public string ElementXmiType { get; set; }

        /// <summary>
        /// Gets or sets the name of the property that holds the reference, such as <c>type</c> or <c>ownedRule</c>
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the referenced element, the value of the <c>xmi:idref</c> or <c>href</c>
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="XmiReferenceResolutionFailureKind"/> that specifies why the reference could not be resolved
        /// </summary>
        public XmiReferenceResolutionFailureKind Kind { get; set; }

        /// <summary>
        /// Returns a human-readable representation of the failure
        /// </summary>
        /// <returns>
        /// a string such as <c>doc1.xml#idO1 (uml:Operation).ownedRule -> doc2.xml#idC4 [NotFound]</c>
        /// </returns>
        public override string ToString()
        {
            return $"{this.DocumentName}#{this.ElementXmiId} ({this.ElementXmiType}).{this.PropertyName} -> {this.Identifier} [{this.Kind}]";
        }
    }
}
