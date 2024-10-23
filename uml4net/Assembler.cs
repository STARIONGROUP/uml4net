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
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;

    using POCO.CommonStructure;
    using System;
    using System.Collections;
    using System.Linq;
    using POCO.Classification;
    using POCO;
    using POCO.Values;
    using System.Reflection;
    using Microsoft.Extensions.Logging.Abstractions;
    using System.Xml;

    /// <summary>
    /// The purpose of the Assembler is to convert a list of DTO's into an object graph
    /// </summary>
    public class Assembler
    {
        /// <summary>
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </summary>
        private readonly ILoggerFactory loggerFactory;

        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<Assembler> logger;

        /// <summary>
        /// Gets
        /// </summary>
        /// <param name="loggerFactory"></param>
        public Assembler(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
            this.logger = this.loggerFactory == null ? NullLogger<Assembler>.Instance : this.loggerFactory.CreateLogger<Assembler>();
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
                this.ResolveReferences(element, cache);
            }
        }

        /// <summary>
        /// Resolves single and multi-value references for the given element using the provided cache.
        /// </summary>
        /// <param name="element">The element whose references are to be resolved.</param>
        /// <param name="cache">The cache containing the referenced elements.</param>
        public void ResolveReferences(IXmiElement element, IDictionary<string, IXmiElement> cache)
        {
            foreach (var property in element.SingleValueReferencePropertyIdentifiers)
            {
                var referencedElement = this.GetReferencedElement(cache, property.Value, property.Key);

                if (referencedElement is null)
                {
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
                    throw new NullReferenceException($"The target property {property.Key} was not found on {element.GetType().Name} or the type is null");
                }

                var resolvedReferences = this.ResolveMultiValueReferences(cache, property.Value, property.Key, underlyingType);

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
        /// Retrieves a referenced element from the cache based on the reference key.
        /// </summary>
        /// <param name="cache">The cache containing the referenced elements.</param>
        /// <param name="reference">The key to the reference in the cache.</param>
        /// <param name="key">The name of the property referring to the element.</param>
        /// <returns>The resolved IXmiElement from the cache.</returns>
        private IXmiElement GetReferencedElement(IDictionary<string, IXmiElement> cache, string reference, string key)
        {
            if (reference.Contains('#'))
            {
                this.logger.LogWarning("Referencing external type is not yet supported");
                return null;
            }

            if (cache.TryGetValue(reference, out var referencedElement))
            {
                return referencedElement;
            }

            this.logger.LogWarning("The reference with the id [{reference}] to [{key}] was not found in the cache, probably because its type is not supported.", reference, key);
            return null;
        }

        /// <summary>
        /// Finds a property in the given element that has the <see cref="PropertyAttribute"/> and matches the specified property name and type.
        /// </summary>
        /// <param name="element">The element whose properties are to be searched.</param>
        /// <param name="propertyName">The name of the property to find.</param>
        /// <param name="expectedType">The expected type of the property. If null, type checking is skipped.</param>
        /// <returns>The <see cref="PropertyInfo"/> of the found property, or null if no matching property is found.</returns>
        private PropertyInfo? FindPropertyWithAttribute(IXmiElement element, string propertyName, Type? expectedType = null)
        {
            return element.GetType().GetProperties()
                .FirstOrDefault(x => Attribute.IsDefined(x, typeof(PropertyAttribute))
                                     && x.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase)
                                     && (expectedType == null || x.PropertyType.IsAssignableFrom(expectedType)));
        }

        /// <summary>
        /// Resolves multiple references from the cache, ensuring that the types match the expected type.
        /// </summary>
        /// <param name="cache">The cache containing the referenced elements.</param>
        /// <param name="propertyValues">The keys of the references to be resolved.</param>
        /// <param name="key">The name of the property referring to the elements.</param>
        /// <param name="expectedType">The expected type of the referenced elements.</param>
        /// <returns>A list of resolved IXmiElement references.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if a reference is not found in the cache or if the type of a referenced element does not match the expected type.
        /// </exception>
        private List<IXmiElement> ResolveMultiValueReferences(IDictionary<string, IXmiElement> cache, IEnumerable<string> propertyValues, string key, Type expectedType)
        {
            var resolvedReferences = new List<IXmiElement>();

            foreach (var propertyValue in propertyValues)
            {
                if (!cache.TryGetValue(propertyValue, out var referencedElement) || !expectedType.IsAssignableFrom(referencedElement.GetType()))
                {
                    this.logger.LogWarning("The reference with the id [{key}] to [{propertyValue}] was not found in the cache, probably because its type is not supported.", key, propertyValue);
                    continue;
                }

                resolvedReferences.Add(referencedElement);
            }

            return resolvedReferences;
        }
    }
}
