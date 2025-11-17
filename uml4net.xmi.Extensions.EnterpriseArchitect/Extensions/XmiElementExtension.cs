// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiElementExtension.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2025 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.Packages;
    using uml4net.xmi.Extensions.EnterpriseArchitect.Structure;

    /// <summary>
    /// Extension class for the <see cref="IXmiElement"/> interface
    /// </summary>
    public static class XmiElementExtension
    {
        /// <summary>
        /// Queries all applied <see cref="IStereotype"/> to a provided <see cref="IXmiElement"/>
        /// </summary>
        /// <param name="xmiElement">The <see cref="IXmiElement"/></param>
        /// <param name="cache">The <see cref="IXmiElementCache"/></param>
        /// <returns>A collection of applied <see cref="IStereotype"/> to the provided <see cref="IXmiElement"/></returns>
        public static IReadOnlyCollection<IStereotype> QueryAppliedStereotypes(this IXmiElement xmiElement, IXmiElementCache cache)
        {
            if (!cache.TryGetExtenders(xmiElement, out var extenders))
            {
                return Enumerable.Empty<IStereotype>().ToList();
            }

            var appliedStereotypes = new List<string>();

            foreach (var extender in extenders)
            {
                switch (extender)
                {
                    case IElement element when !string.IsNullOrWhiteSpace(element.Properties.Stereotype):
                        appliedStereotypes.Add(element.Properties.Stereotype);
                        break;
                    
                    case IAttribute attribute when !string.IsNullOrWhiteSpace(attribute.Stereotype.Stereotype) :
                        appliedStereotypes.Add(attribute.Stereotype.Stereotype);
                        break;

                    case IConnector connector when !string.IsNullOrWhiteSpace(connector.Properties.Stereotype):
                        appliedStereotypes.Add(connector.Properties.Stereotype);
                        break;
                    
                    case Operation operation when !string.IsNullOrWhiteSpace(operation.Stereotype.Stereotype):
                        appliedStereotypes.Add(operation.Stereotype.Stereotype);
                        break;
                    
                    case Operation operation when !string.IsNullOrWhiteSpace(operation.Type.Stereotype):
                        appliedStereotypes.Add(operation.Type.Stereotype);
                        break;
                }
            }

            return appliedStereotypes.Count == 0 
                ? Enumerable.Empty<IStereotype>().ToList()
                : cache.Values.OfType<IStereotype>().Where(x => appliedStereotypes.Contains(x.Name)).ToList();
        }
    }
}
