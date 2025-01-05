// -------------------------------------------------------------------------------------------------
// <copyright file="ClassExtensions.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
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
    using uml4net.Packages;

    /// <summary>
    /// The <see cref="ClassExtensions"/> class provides extensions methods for <see cref="IClass"/>
    /// </summary>
    public static class ClassExtensions
    {
        /// <summary>
        /// Queries whether this property is used when the Class is acting as a metaclass. It references the Extensions that
        /// specify additional properties of the metaclass. The property is derived from the Extensions whose
        /// memberEnds are typed by the Class.
        /// </summary>
        /// <param name="@class">
        /// The subject <see cref="IClass"/>
        /// </param>
        /// <returns>
        /// This property is used when the Class is acting as a metaclass. It references the Extensions that
        /// specify additional properties of the metaclass. The property is derived from the Extensions whose
        /// memberEnds are typed by the Class.
        /// </returns>
        public static List<IExtension> QueryExtension(this IClass @class)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Retrieves the list of immediate superclasses for the specified class, based on its generalizations.
        /// </summary>
        /// <param name="class">
        /// The <see cref="IClass"/> instance whose superclasses are being queried.
        /// </param>
        /// <returns>
        /// A list of <see cref="IClass"/> objects representing the immediate superclasses of the specified class. 
        /// If no superclasses are defined, returns an empty list.
        /// </returns>
        public static List<IClass> QuerySuperClass(this IClass @class)
        {
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            return @class.Generalization.Select(x => x.General).OfType<IClass>().ToList();
        }
    }
}
