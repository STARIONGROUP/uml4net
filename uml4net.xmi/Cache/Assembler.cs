// -------------------------------------------------------------------------------------------------
// <copyright file="Assembler.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
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

namespace uml4net.xmi.Cache
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    using Microsoft.Extensions.Logging;
    
    using uml4net;
    using uml4net.Decorators;

    /// <summary>
    /// The purpose of the Assembler is to resolve all the reference properties of the objects
    /// after deserialization to construct a complete object graph
    /// </summary>
    public class Assembler : IAssembler
    {
        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<Assembler> logger;

        /// <summary>
        /// The <see cref="IXmiReaderCache"/>
        /// </summary>
        private readonly IXmiReaderCache cache;

        /// <summary>
        /// Initializes a new <see cref="Assembler"/>
        /// </summary>
        /// <param name="logger">The <see cref="ILogger{T}"/></param>
        /// <param name="cache">The <see cref="IXmiReaderCache"/></param>
        public Assembler(ILogger<Assembler> logger, IXmiReaderCache cache)
        {
            this.logger = logger;
            this.cache = cache;
        }

        /// <summary>
        /// Synchronizes the <see cref="IXmiReaderCache"/> by assigning properties to elements.
        /// </summary>
        public void Synchronize()
        {
            foreach (var contextEntries in this.cache.GlobalCache)
            {
                foreach (var element in contextEntries.Value)
                {
                    this.ResolveReferences(element.Value);
                }
            }
        }

        /// <summary>
        /// Resolves single and multi-value references for the given element using the provided cache.
        /// </summary>
        /// <param name="element">The element whose references are to be resolved.</param>
        public void ResolveReferences(IXmiElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            foreach (var property in element.SingleValueReferencePropertyIdentifiers)
            {
                if (!this.TryGetReferencedElement(property.Value, out var referencedElement))
                {
                    this.logger.LogWarning("The reference to [{Reference}] for property [{Key}] on element type [{Element}] with id [{Id}] was not found in the cache, probably because its type is not supported.", 
                        property.Value, property.Key, element.XmiType, element.XmiId);
                    continue;
                }

                var targetProperty = this.FindPropertyWithAttribute(element, property.Key, referencedElement.GetType());
                
                if (targetProperty is null)
                {
                    throw new InvalidOperationException($"The target property {property.Key} was not found on {element.GetType().Name} or the property type doesn't match the referenced element type");
                }

                targetProperty.SetValue(element, referencedElement);
            }

            foreach (var property in element.MultiValueReferencePropertyIdentifiers)
            {
                var targetProperty = this.FindPropertyWithAttribute(element, property.Key);
                var underlyingType = targetProperty?.PropertyType.GetGenericArguments().FirstOrDefault();

                if (targetProperty is null || underlyingType is null)
                {
                    throw new KeyNotFoundException($"The target property {property.Key} was not found on {element.GetType().Name} or the type is null");
                }

                var resolvedReferences = this.ResolveMultiValueReferences(property.Value, property.Key, underlyingType);

                if (targetProperty.GetValue(element) is not IList list)
                {
                    continue;
                }

                foreach (var resolvedReference in resolvedReferences)
                {
                    list.Add(resolvedReference);
                }
            }
        }

        /// <summary>
        /// Attempts to retrieve the referenced element associated with the specified reference ID key.
        /// </summary>
        /// <param name="referenceIdKey">The key representing the reference ID.</param>
        /// <param name="element">When this method returns, contains the referenced element if found; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if the referenced element was successfully retrieved; otherwise, <c>false</c>.</returns>
        private bool TryGetReferencedElement(string referenceIdKey, out IXmiElement element)
        {
            return this.cache.TryResolveContext(referenceIdKey, out var resolvedContextAndResource, true)
                ? this.cache.TryGetValue(resolvedContextAndResource.Context, resolvedContextAndResource.ResourceId, out element)
                : this.cache.Cache.TryGetValue(referenceIdKey, out element);
        }

        /// <summary>
        /// Finds a property in the given element that has the <see cref="PropertyAttribute"/> and matches the specified property name and type.
        /// </summary>
        /// <param name="element">The element whose properties are to be searched.</param>
        /// <param name="propertyName">The name of the property to find.</param>
        /// <param name="expectedType">The expected type of the property. If null, type checking is skipped.</param>
        /// <returns>The <see cref="PropertyInfo"/> of the found property, or null if no matching property is found.</returns>
        private PropertyInfo FindPropertyWithAttribute(IXmiElement element, string propertyName, Type? expectedType = null)
        {
            return element.GetType().GetProperties()
                .FirstOrDefault(x => Attribute.IsDefined(x, typeof(PropertyAttribute))
                                     && x.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase)
                                     && (expectedType == null || x.PropertyType.IsAssignableFrom(expectedType)));
        }

        /// <summary>
        /// Resolves multiple references from the cache, ensuring that the types match the expected type.
        /// </summary>
        /// <param name="propertyValues">The keys of the references to be resolved.</param>
        /// <param name="key">The name of the property referring to the elements.</param>
        /// <param name="expectedType">The expected type of the referenced elements.</param>
        /// <returns>A list of resolved IXmiElement references.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if a reference is not found in the cache or if the type of a referenced element does not match the expected type.
        /// </exception>
        private List<IXmiElement> ResolveMultiValueReferences(IEnumerable<string> propertyValues, string key, Type expectedType)
        {
            var resolvedReferences = new List<IXmiElement>();

            foreach (var propertyValue in propertyValues)
            {
                if (!this.TryGetReferencedElement(propertyValue, out var referencedElement) || !expectedType.IsAssignableFrom(referencedElement.GetType()))
                {
                    this.logger.LogWarning("The reference with the id [{Key}] to [{PropertyValue}] was not found in the cache, probably because its type is not supported.", key, propertyValue);
                    continue;
                }

                resolvedReferences.Add(referencedElement);
            }

            return resolvedReferences;
        }
    }
}
