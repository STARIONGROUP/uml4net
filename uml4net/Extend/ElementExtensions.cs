// -------------------------------------------------------------------------------------------------
// <copyright file="ElementExtensions.cs" company="Starion Group S.A.">
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
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using uml4net.Classification;
    using uml4net.Decorators;

    /// <summary>
    /// The <see cref="ElementExtensions"/> class provides extensions methods for <see cref="IElement"/>
    /// </summary>
    internal static class ElementExtensions
    {
        /// <summary>
        /// The cache of the owning <see cref="PropertyInfo"/>s per concrete <see cref="IElement"/> type.
        /// </summary>
        private static readonly ConcurrentDictionary<Type, List<PropertyInfo>> OwningPropertiesCache = new();

        /// <summary>
        /// Gets the owning <see cref="IElement"/> that contains the specified <paramref name="element"/>.
        /// </summary>
        /// <param name="element">The <see cref="IElement"/> for which to retrieve the owner.</param>
        /// <returns>
        /// The <see cref="IElement"/> that acts as the container for the specified <paramref name="element"/>,
        /// or <c>null</c> if the element does not have a container.
        /// </returns>
        internal static IElement QueryOwner(this IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return element.Possessor;
        }

        /// <summary>
        /// Queries the Elements owned by this Element. Per the UML 2.5.1 metamodel this is a derived union of every
        /// composite property that the concrete type genuinely backs (i.e. is not itself derived, and is not
        /// shadowed by a more general composite property that already accounts for the same content - mirroring
        /// the containment classification used by the XMI writer to walk the containment tree).
        /// </summary>
        /// <param name="element">
        /// The subject <see cref="IElement"/>
        /// </param>
        /// <returns>
        /// The Elements owned by this Element.
        /// </returns>
        internal static List<IElement> QueryOwnedElement(this IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            var ownedElement = new List<IElement>();

            foreach (var propertyInfo in QueryOwningProperties(element.GetType()))
            {
                switch (propertyInfo.GetValue(element))
                {
                    case null:
                        break;
                    case IElement singleElement:
                        ownedElement.Add(singleElement);
                        break;
                    case IEnumerable elements:
                        foreach (var item in elements)
                        {
                            if (item is IElement itemElement)
                            {
                                ownedElement.Add(itemElement);
                            }
                        }
                        break;
                }
            }

            return ownedElement.Distinct().ToList();
        }

        /// <summary>
        /// Queries the <see cref="PropertyInfo"/>s of the provided type from the cache, classifying the properties
        /// of the type when the type has not been classified before.
        /// </summary>
        /// <param name="type">
        /// The concrete <see cref="IElement"/> type whose properties are classified
        /// </param>
        /// <returns>
        /// The <see cref="PropertyInfo"/>s that genuinely back owned content on the provided type
        /// </returns>
        private static List<PropertyInfo> QueryOwningProperties(Type type)
        {
            return OwningPropertiesCache.GetOrAdd(type, ClassifyOwningProperties);
        }

        /// <summary>
        /// Classifies the properties of the provided type, selecting the composite properties that genuinely back
        /// owned content, as opposed to being themselves derived or shadowed by a more general composite property.
        /// </summary>
        /// <param name="type">
        /// The concrete <see cref="IElement"/> type whose properties are classified
        /// </param>
        /// <returns>
        /// The <see cref="PropertyInfo"/>s that genuinely back owned content on the provided type
        /// </returns>
        private static List<PropertyInfo> ClassifyOwningProperties(Type type)
        {
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var owningProperties = new List<PropertyInfo>();

            foreach (var propertyInfo in properties)
            {
                var propertyAttribute = propertyInfo.GetCustomAttribute<PropertyAttribute>();

                if (propertyAttribute == null || propertyAttribute.IsDerived || propertyAttribute.IsDerivedUnion || propertyAttribute.IsReadOnly)
                {
                    continue;
                }

                if (propertyAttribute.Aggregation != AggregationKind.Composite)
                {
                    continue;
                }

                if (!QueryIsElementProperty(propertyInfo))
                {
                    continue;
                }

                if (QueryIsShadowedByMoreGeneralProperty(propertyInfo, properties))
                {
                    continue;
                }

                owningProperties.Add(propertyInfo);
            }

            return owningProperties;
        }

        /// <summary>
        /// Queries whether the provided property holds one or more <see cref="IElement"/> values.
        /// </summary>
        /// <param name="propertyInfo">
        /// The <see cref="PropertyInfo"/> of the property that is checked
        /// </param>
        /// <returns>
        /// true when the property holds <see cref="IElement"/> values, false otherwise
        /// </returns>
        private static bool QueryIsElementProperty(PropertyInfo propertyInfo)
        {
            var propertyType = propertyInfo.PropertyType;

            if (propertyType.IsGenericType && propertyType.GenericTypeArguments.Length == 1)
            {
                propertyType = propertyType.GenericTypeArguments[0];
            }

            return typeof(IElement).IsAssignableFrom(propertyType);
        }

        /// <summary>
        /// Queries whether the provided composite property is shadowed by a more general property that it
        /// subsets, which is the case when the property has subsetted properties that are all themselves
        /// genuinely backed (non-derived, non-read-only) - in that case the more general property already
        /// accounts for the same owned content, so counting this one too would double the result.
        /// </summary>
        /// <param name="propertyInfo">
        /// The <see cref="PropertyInfo"/> of the composite property that is checked
        /// </param>
        /// <param name="properties">
        /// All public instance properties of the type that declares the <paramref name="propertyInfo"/>
        /// </param>
        /// <returns>
        /// true when the composite property is shadowed by a more general property, false when it is itself
        /// the property that backs the owned content
        /// </returns>
        private static bool QueryIsShadowedByMoreGeneralProperty(PropertyInfo propertyInfo, PropertyInfo[] properties)
        {
            var subsettedPropertyAttributes = propertyInfo.GetCustomAttributes<SubsettedPropertyAttribute>().ToList();

            if (subsettedPropertyAttributes.Count == 0)
            {
                return false;
            }

            foreach (var subsettedPropertyAttribute in subsettedPropertyAttributes)
            {
                var subsettedProperty = properties
                    .Select(x => x.GetCustomAttribute<PropertyAttribute>())
                    .FirstOrDefault(x => x != null && x.XmiId == subsettedPropertyAttribute.PropertyName);

                if (subsettedProperty == null || subsettedProperty.IsDerived || subsettedProperty.IsDerivedUnion || subsettedProperty.IsReadOnly)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
