// -------------------------------------------------------------------------------------------------
// <copyright file="XmiElementExtension.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

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
        /// <returns>A collection of applied <see cref="IStereotype"/> to the provided <see cref="IXmiElement"/></returns>
        public static IReadOnlyCollection<IStereotype> QueryAppliedStereotypes(this IXmiElement xmiElement)
        {
            if (!xmiElement.Cache.TryGetExtenders(xmiElement, out var extenders))
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
                    
                    case Operation operation :
                        if (!string.IsNullOrWhiteSpace(operation.Stereotype.Stereotype))
                        {
                            appliedStereotypes.Add(operation.Stereotype.Stereotype);
                        }

                        if (!string.IsNullOrWhiteSpace(operation.Type.Stereotype))
                        {
                            appliedStereotypes.Add(operation.Type.Stereotype);
                        }

                        break;
                }
            }

            appliedStereotypes = [..appliedStereotypes.Distinct()];

            return appliedStereotypes.Count == 0 
                ? Enumerable.Empty<IStereotype>().ToList()
                : xmiElement.Cache.Values.OfType<IStereotype>().Where(x => appliedStereotypes.Contains(x.Name)).ToList();
        }
    }
}
