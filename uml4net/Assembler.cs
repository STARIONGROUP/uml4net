// -------------------------------------------------------------------------------------------------
// <copyright file="Assembler.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net
{
    using Decorators;
    using System.Collections.Generic;

    using POCO.CommonStructure;
    using System;
    using System.Collections;
    using System.Linq;
    using uml4net.POCO.Classification;
    using uml4net.POCO;
    using uml4net.POCO.Values;

    /// <summary>
    /// The purpose of the Assembler is to convert a list of DTO's into an object graph
    /// </summary>
    public class Assembler
    {
        /// <summary>
        /// Synchronizes the specified cache by assigning properties to elements.
        /// </summary>
        /// <param name="cache">
        /// A dictionary containing the elements where the keys are their identifiers and the values are the corresponding <see cref="IXmiElement"/> instances.
        /// </param>
        public void SynchronizeUsingFullReflection(Dictionary<string, IXmiElement> cache)
        {
            foreach (var element in cache.Values)
            {
                foreach (var property in element.SingleValueReferencePropertyIdentifiers)
                {
                    if (!cache.TryGetValue(property.Value, out var referencedElement))
                    {
                        throw new NullReferenceException($"The reference {property.Key} to {property.Value} could not be found in the cache");
                    }

                    var propertiesWithAttribute = element.GetType().GetProperties()
                        .FirstOrDefault(x => Attribute.IsDefined(x, typeof(PropertyAttribute))
                                             && x.Name.Equals(property.Key)
                                             && x.PropertyType.IsAssignableFrom(referencedElement.GetType()));

                    if (propertiesWithAttribute is null)
                    {
                        throw new InvalidOperationException($"The target property {property.Key} was not found on {element.GetType().Name}");
                    }

                    propertiesWithAttribute.SetValue(element, referencedElement);
                }

                foreach (var property in element.MultiValueReferencePropertyIdentifiers)
                {
                    var propertiesWithAttribute = element.GetType().GetProperties()
                        .FirstOrDefault(x => Attribute.IsDefined(x, typeof(PropertyAttribute))
                                             && x.Name.Equals(property.Key));

                    var underlyingType = propertiesWithAttribute?.PropertyType.GetGenericArguments().FirstOrDefault();

                    if (propertiesWithAttribute is null || underlyingType is null)
                    {
                        throw new NullReferenceException($"The target property {property.Key} was not found on {element.GetType().Name} or the type is null");
                    }

                    var resolvedReferences = new List<IXmiElement>();

                    foreach (var propertyValue in property.Value)
                    {
                        if (!cache.TryGetValue(propertyValue, out var referencedElement) || !underlyingType.IsAssignableFrom(referencedElement.GetType()))
                        {
                            throw new InvalidOperationException($"The reference {property.Key} to {propertyValue} could not be found in the cache, Or the type does not match");
                        }

                        resolvedReferences.Add(referencedElement);
                    }

                    if (propertiesWithAttribute.GetValue(element) is not IList list)
                    {
                        continue;
                    }

                    foreach (var resolvedReference in resolvedReferences)
                    {
                        list.Add(resolvedReference);
                    }
                }
            }
        }

        /// <summary>
        /// Synchronizes the specified cache by assigning properties to elements.
        /// </summary>
        /// <param name="cache">
        /// A dictionary containing the elements where the keys are their identifiers and the values are the corresponding <see cref="IXmiElement"/> instances.
        /// </param>
        public void Synchronize(Dictionary<string, IXmiElement> cache)
        {
            foreach (var element in cache.Values)
            {
                foreach (var property in element.SingleValueReferencePropertyIdentifiers)
                {
                    this.AssignProperty(cache, property.Key, [ property.Value ], element);
                }

                foreach (var property in element.MultiValueReferencePropertyIdentifiers)
                {
                    this.AssignProperty(cache, property.Key, property.Value, element);
                }
            }
        }

        /// <summary>
        /// Assigns the specified property values to the given element.
        /// </summary>
        /// <param name="cache">
        /// A dictionary containing the elements where the keys are their identifiers and the values are the corresponding <see cref="IXmiElement"/> instances.
        /// </param>
        /// <param name="propertyKey">
        /// The key of the property being assigned.
        /// </param>
        /// <param name="propertyValues">
        /// A list of values corresponding to the property to be assigned.
        /// </param>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> instance to which the property values are being assigned.
        /// </param>
        /// <exception cref="NullReferenceException">
        /// Thrown when a reference cannot be found in the cache.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the element does not implement a known <see cref="IReferenceable{T}"/> interface.
        /// </exception>
        private void AssignProperty(Dictionary<string, IXmiElement> cache, string propertyKey, List<string> propertyValues, IXmiElement element)
        {
            var resolvedReferences = new List<IXmiElement>();

            foreach (var propertyValue in propertyValues)
            {
                if (!cache.TryGetValue(propertyValue, out var referencedElement))
                {
                    throw new NullReferenceException($"The reference {propertyKey} to {propertyValue} could not be found in the cache");
                }

                resolvedReferences.Add(referencedElement);
            }
            
            switch (element)
            {
                case IReferenceable<IStringExpression> referenceableStringExpr when resolvedReferences.FirstOrDefault() is IStringExpression stringExpression
                    && ReferencedPropertyAttribute.GetName(referenceableStringExpr) == propertyKey:
                    referenceableStringExpr.Reference = stringExpression;
                    break;
                case IReferenceable<List<IComment>> referenceableComments when AnyResolvedReferenceMatch<IComment>(resolvedReferences, out var references)
                                                                               && ReferencedPropertyAttribute.GetName(referenceableComments) == propertyKey:
                    referenceableComments.Reference = references;
                    break;
                case IReferenceable<List<IElementImport>> referenceableElements when AnyResolvedReferenceMatch<IElementImport>(resolvedReferences, out var references)
                                                                                     && ReferencedPropertyAttribute.GetName(referenceableElements) == propertyKey:
                    referenceableElements.Reference = references;
                    break;
                default:
                    throw new InvalidOperationException($"Element {element.GetType().Name} does not implement a known IReferenceable interface.");
            }
        }

        /// <summary>
        /// Determines if there are any resolved references that match the specified type.
        /// </summary>
        /// <typeparam name="T">
        /// The type of references to match.
        /// </typeparam>
        /// <param name="resolvedReferences">
        /// A list of resolved references.
        /// </param>
        /// <param name="references">
        /// The matching references that were found.
        /// </param>
        /// <returns>
        /// <c>true</c> if there are matching references; otherwise, <c>false</c>.
        /// </returns>
        private static bool AnyResolvedReferenceMatch<T>(List<IXmiElement> resolvedReferences, out List<T> references)
        {
            references = resolvedReferences.OfType<T>().ToList();
            return references.Count > 0;
        }
    }
}
