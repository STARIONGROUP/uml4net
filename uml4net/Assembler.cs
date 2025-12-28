// -------------------------------------------------------------------------------------------------
// <copyright file="Assembler.cs" company="Starion Group S.A.">
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

namespace uml4net
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    using Microsoft.Extensions.Logging;
    
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
        /// The <see cref="IXmiElementCache"/>
        /// </summary>
        private readonly IXmiElementCache cache;

        /// <summary>
        /// Initializes a new <see cref="Assembler"/>
        /// </summary>
        /// <param name="logger">The <see cref="ILogger{T}"/></param>
        /// <param name="cache">The <see cref="IXmiElementCache"/></param>
        public Assembler(ILogger<Assembler> logger, IXmiElementCache cache)
        {
            this.logger = logger;
            this.cache = cache;
        }

        /// <summary>
        /// Synchronizes the <see cref="IXmiElement"/>s in the <see cref="IXmiElementCache"/> by assigning
        /// the reference properties that are encoded by <see cref="IXmiElement.SingleValueReferencePropertyIdentifiers"/>
        /// and by <see cref="IXmiElement.MultiValueReferencePropertyIdentifiers"/>
        /// </summary>
        public void Synchronize()
        {
            foreach (var kvp in this.cache)
            {
                this.ResolveReferences(kvp.Value);
            }
        }

        /// <summary>
        /// Resolves single and multi-value references for the given element using the provided cache.
        /// </summary>
        /// <param name="element">The element whose references are to be resolved.</param>
        private void ResolveReferences(IXmiElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            foreach (var property in element.SingleValueReferencePropertyIdentifiers)
            {
                if (!this.TryGetReferencedElement(element.DocumentName,property.Value, out var referencedElement))
                {
                    this.logger.LogWarning("The reference to [{Reference}] for property [{Key}] on element type [{Element}] with id [{Id}] was not found in the cache, probably because its type is not supported.",
                        property.Value, property.Key, element.XmiType, element.XmiId);
                    continue;
                }

                var targetProperty = FindPropertyWithAttribute(element, property.Key, referencedElement.GetType());

                if (targetProperty is null)
                {
                    throw new InvalidOperationException($"The target property {property.Key} was not found on {element.GetType().Name} or the property type doesn't match the referenced {nameof(element)} type");
                }

                targetProperty.SetValue(element, referencedElement);
            }

            foreach (var property in element.MultiValueReferencePropertyIdentifiers)
            {
                var targetProperty = FindPropertyWithAttribute(element, property.Key);
                var underlyingType = targetProperty?.PropertyType.GetGenericArguments().FirstOrDefault();

                if (targetProperty is null || underlyingType is null)
                {
                    throw new KeyNotFoundException($"The target property {property.Key} was not found on {element.GetType().Name} or the type is null");
                }

                var resolvedReferences = this.ResolveMultiValueReferences(element.DocumentName,property.Value, property.Key, underlyingType);

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
        /// Try to get an <see cref="IXmiElement"/> from th cache based on the provided
        /// <paramref name="documentName"/> and <paramref name="referenceIdKey"/>
        /// </summary>
        /// <param name="documentName">
        /// The name of the document or resource from where the <see cref="IXmiElement"/> was parsed/read
        /// </param>
        /// <param name="referenceIdKey">
        /// The unique identifier of the <see cref="IXmiElement"/> that is to be retrieved
        /// </param>
        /// <param name="element">
        /// The found <see cref="IXmiElement"/>, null if not found
        /// </param>
        /// <returns>
        /// true if found, false if not
        /// </returns>
        private bool TryGetReferencedElement(string documentName, string referenceIdKey, out IXmiElement element)
        {
            var key = referenceIdKey.Contains("#") ? referenceIdKey : $"{documentName}#{referenceIdKey}";

            return this.cache.TryGetValue(key, out element);
        }

        /// <summary>
        /// resolves multi-valued reference properties
        /// </summary>
        /// <param name="documentName">
        /// The name of the document or resource from where the <see cref="IXmiElement"/> was parsed/read
        /// </param>
        /// <param name="propertyValues">
        /// The values of the property, which are references by unique identifier to other <see cref="IXmiElement"/>s
        /// </param>
        /// <param name="key">
        /// The name of the property for which the references to other <see cref="IXmiElement"/>s are being resolved
        /// </param>
        /// <param name="expectedType"></param>
        /// <returns></returns>
        private List<IXmiElement> ResolveMultiValueReferences(string documentName, IEnumerable<string> propertyValues, string key, Type expectedType)
        {
            var resolvedReferences = new List<IXmiElement>();

            foreach (var propertyValue in propertyValues)
            {
                if (!this.TryGetReferencedElement(documentName,propertyValue, out var referencedElement) || !expectedType.IsAssignableFrom(referencedElement.GetType()))
                {
                    this.logger.LogWarning("The reference with the id [{Key}] to [{PropertyValue}] was not found in the cache, probably because its type is not supported.", key, propertyValue);
                    continue;
                }

                resolvedReferences.Add(referencedElement);
            }

            return resolvedReferences;
        }

        /// <summary>
        /// Finds a property in the given element that has the <see cref="PropertyAttribute"/> and matches the specified property name and type.
        /// </summary>
        /// <param name="element">The element whose properties are to be searched.</param>
        /// <param name="propertyName">The name of the property to find.</param>
        /// <param name="expectedType">The expected type of the property. If null, type checking is skipped.</param>
        /// <returns>The <see cref="PropertyInfo"/> of the found property, or null if no matching property is found.</returns>
        private static PropertyInfo FindPropertyWithAttribute(IXmiElement element, string propertyName, Type? expectedType = null)
        {
            return element.GetType().GetProperties()
                .FirstOrDefault(x => Attribute.IsDefined(x, typeof(PropertyAttribute))
                                     && x.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase)
                                     && (expectedType == null || x.PropertyType.IsAssignableFrom(expectedType)));
        }
    }
}
