// -------------------------------------------------------------------------------------------------
// <copyright file="ClassifierExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Classification
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.CommonStructure;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;

    /// <summary>
    /// The <see cref="ClassifierExtensions"/> class provides extensions methods for <see cref="IClassifier"/>
    /// </summary>
    internal static class ClassifierExtensions
    {
        /// <summary>
        /// Queries All of the Properties that are direct (i.e., not inherited or imported) attributes of the
        /// Classifier.
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IClassifier"/>
        /// </param>
        /// <returns>
        /// All of the Properties that are direct (i.e., not inherited or imported) attributes of the
        /// Classifier.
        /// </returns>
        internal static List<IProperty> QueryAttribute(this IClassifier element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (element is IInterface @interface)
            {
                return @interface.OwnedAttribute.ToList();
            }

            if (element is IClass @class)
            {
                return @class.OwnedAttribute.ToList();
            }

            if (element is IEnumeration enumeration)
            {
                return enumeration.OwnedAttribute.ToList();
            }

            if (element is IAssociation association)
            {
                return association.OwnedEnd.ToList();
            }

            if (element is IDataType dataType)
            {
                return dataType.OwnedAttribute.ToList();
            }

            throw new NotSupportedException($"The Type is not yet supported {element.GetType()}");
        }

        /// <summary>
        /// Queries each Feature directly defined in the classifier. Note that there may be members of the
        /// Classifier that are of the type Feature but are not included, e.g., inherited features.
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IClassifier"/>
        /// </param>
        /// <returns>
        /// each Feature directly defined in the classifier. Note that there may be members of the
        /// Classifier that are of the type Feature but are not included, e.g., inherited features.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static List<IFeature> QueryFeature(this IClassifier element)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }

        /// <summary>
        /// Gets the collection of <see cref="IClassifier"/>s that represent the generalizations of the specified <paramref name="element"/>.
        /// </summary>
        /// <param name="element">The <see cref="IClassifier"/> for which to retrieve the generalizations.</param>
        /// <returns>
        /// A list of <see cref="IClassifier"/> objects that represent the generalizations of the specified <paramref name="element"/>. 
        /// If the element does not have any generalizations, an empty list will be returned.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static List<IClassifier> QueryGeneral(this IClassifier element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return element.Generalization.Select(x => x.General).ToList();
        }

        /// <summary>
        /// Queries All elements inherited by this Classifier from its general Classifiers
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IClassifier"/>
        /// </param>
        /// <returns>
        /// All elements inherited by this Classifier from its general Classifiers.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static List<INamedElement> QueryInheritedMember(this IClassifier element)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }
    }
}
