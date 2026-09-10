// -------------------------------------------------------------------------------------------------
// <copyright file="EncapsulatedClassifierExtensions.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// The <see cref="EncapsulatedClassifierExtensions"/> class provides extensions methods for <see cref="IEncapsulatedClassifier"/>
    /// </summary>
    internal static class EncapsulatedClassifierExtensions
    {
        /// <summary>
        /// Queries The Ports owned by the EncapsulatedClassifier.
        /// </summary>
        /// <param name="encapsulatedClassifier">
        /// The subject <see cref="IEncapsulatedClassifier"/>
        /// </param>
        /// <returns>
        /// The Ports owned by the EncapsulatedClassifier.
        /// </returns>
        internal static List<IPort> QueryOwnedPort(this IEncapsulatedClassifier encapsulatedClassifier)
        {
            if (encapsulatedClassifier == null)
            {
                throw new ArgumentNullException(nameof(encapsulatedClassifier));
            }

            // Class-derived EncapsulatedClassifiers (every currently generated implementer of the
            // interface) redefine IStructuredClassifier.OwnedAttribute through IClass.OwnedAttribute,
            // which throws "Redefined by property" when accessed through the base interface.
            var ownedAttribute = encapsulatedClassifier is IClass @class
                ? @class.OwnedAttribute
                : encapsulatedClassifier.OwnedAttribute;

            return ownedAttribute.OfType<IPort>().ToList();
        }
    }
}
