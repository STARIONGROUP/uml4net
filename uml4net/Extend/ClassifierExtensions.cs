// -------------------------------------------------------------------------------------------------
// <copyright file="ClassifierExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Extend
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.POCO.Classification;
    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// The <see cref="ClassifierExtensions"/> class provides extensions methods for the <see cref="IClassifier"/>
    /// </summary>
    public static class ClassifierExtensions
    {
        public static List<IProperty> QueryAttribute(this IClassifier element)
        {
            throw new NotImplementedException();
        }

        public static List<IFeature> QueryFeature(this IClassifier element)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the collection of <see cref="IClassifier"/>s that represent the generalizations of the specified <paramref name="element"/>.
        /// </summary>
        /// <param name="element">The <see cref="IClassifier"/> for which to retrieve the generalizations.</param>
        /// <returns>
        /// A list of <see cref="IClassifier"/> objects that represent the generalizations of the specified <paramref name="element"/>. 
        /// If the element does not have any generalizations, an empty list will be returned.
        /// </returns>
        public static List<IClassifier> QueryGeneral(this IClassifier element)
            => element.Generalization.Select(x => x.General).ToList();

        public static List<INamedElement> QueryInheritedMember(this IClassifier element)
        {
            throw new NotImplementedException();
        }
    }
}