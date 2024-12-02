// -------------------------------------------------------------------------------------------------
// <copyright file="ClassExtensions.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
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
        public static List<IExtension> QueryExtension(this IClass @class)
        {
            throw new NotImplementedException();
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
        public static List<IClass> QuerySuperClass(this IClass @class) => 
            @class.Generalization.Select(x => x.General).OfType<IClass>().ToList();
    }
}