// -------------------------------------------------------------------------------------------------
// <copyright file="StructuredClassifierExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.StructuredClassifiers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.Classification;

    /// <summary>
    /// The <see cref="StructuredClassifierExtensions"/> class provides extensions methods for <see cref="IStructuredClassifier"/>
    /// </summary>
    internal static class StructuredClassifierExtensions
    {
        /// <summary>
        /// Queries the Properties specifying instances that the StructuredClassifier owns by composition. This
        /// collection is derived, selecting those owned Properties where isComposite is true.
        /// </summary>
        /// <param name="structuredClassifier">
        /// The subject <see cref="IStructuredClassifier"/>
        /// </param>
        /// <returns>
        /// The Properties specifying instances that the StructuredClassifier owns by composition. This
        /// collection is derived, selecting those owned Properties where isComposite is true.
        /// </returns>
        /// <remarks>
        /// Confirmed against the raw <c>resources/UML/UML.xmi</c>: OCL is
        /// <c>ownedAttribute->select(isComposite)</c>, with no dependency on any other unimplemented
        /// stub.
        /// </remarks>
        internal static List<IProperty> QueryPart(this IStructuredClassifier structuredClassifier)
        {
            if (structuredClassifier == null)
            {
                throw new ArgumentNullException(nameof(structuredClassifier));
            }

            return structuredClassifier.OwnedAttribute.Where(attribute => attribute.IsComposite).ToList();
        }

        /// <summary>
        /// Queries the roles that instances may play in this StructuredClassifier.
        /// </summary>
        /// <param name="structuredClassifier">
        /// The subject <see cref="IStructuredClassifier"/>
        /// </param>
        /// <returns>
        /// The roles that instances may play in this StructuredClassifier.
        /// </returns>
        /// <remarks>
        /// Has no OCL body in the metamodel - a plain derived union. Confirmed against the raw
        /// <c>resources/UML/UML.xmi</c>: exactly 2 properties subset <c>StructuredClassifier-role</c> -
        /// <see cref="IStructuredClassifier.OwnedAttribute"/> itself (every StructuredClassifier's own
        /// attributes qualify, since <see cref="IProperty"/> is a <see cref="IConnectableElement"/>),
        /// and <see cref="ICollaboration.CollaborationRole"/> (Collaboration-specific participants).
        /// </remarks>
        internal static List<IConnectableElement> QueryRole(this IStructuredClassifier structuredClassifier)
        {
            if (structuredClassifier == null)
            {
                throw new ArgumentNullException(nameof(structuredClassifier));
            }

            var result = new List<IConnectableElement>(structuredClassifier.OwnedAttribute);

            if (structuredClassifier is ICollaboration collaboration)
            {
                result.AddRange(collaboration.CollaborationRole);
            }

            return result.Distinct().ToList();
        }
    }
}
