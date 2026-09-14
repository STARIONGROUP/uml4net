// -------------------------------------------------------------------------------------------------
// <copyright file="NamedElementExtensions.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The <see cref="NamedElementExtensions"/> class provides extensions methods for <see cref="INamedElement"/>
    /// </summary>
    internal static class NamedElementExtensions
    {
        /// <summary>
        /// Queries the Dependencies that reference this NamedElement as a client.
        /// </summary>
        /// <param name="namedElement">
        /// The subject <see cref="INamedElement"/>
        /// </param>
        /// <returns>
        /// the Dependencies that reference this NamedElement as a client.
        /// </returns>
        internal static List<IDependency> QueryClientDependency(this INamedElement namedElement)
        {
            if (namedElement == null)
            {
                throw new ArgumentNullException(nameof(namedElement));
            }

            return namedElement.QueryAllInstancesInModel()
                .OfType<IDependency>()
                .Where(dependency => dependency.Client.Contains(namedElement))
                .ToList();
        }

        /// <summary>
        /// Queries the Dependencies that reference this NamedElement as a supplier.
        /// </summary>
        /// <param name="namedElement">
        /// The subject <see cref="INamedElement"/>
        /// </param>
        /// <returns>
        /// the Dependencies that reference this NamedElement as a supplier.
        /// </returns>
        /// <remarks>
        /// Backs the reverse navigation of <see cref="IDependency.Supplier"/>, exposed in the OMG UML
        /// 2.5.1 metamodel as the implicit association end <c>A_supplier_supplierDependency-supplierDependency</c>,
        /// used by e.g. <c>Classifier::directlyUsedInterfaces()</c>.
        /// </remarks>
        internal static List<IDependency> QuerySupplierDependency(this INamedElement namedElement)
        {
            if (namedElement == null)
            {
                throw new ArgumentNullException(nameof(namedElement));
            }

            return namedElement.QueryAllInstancesInModel()
                .OfType<IDependency>()
                .Where(dependency => dependency.Supplier.Contains(namedElement))
                .ToList();
        }

        /// <summary>
        /// Queries whether the two NamedElements may exist in the same Namespace without conflict.
        /// </summary>
        /// <param name="namedElement">
        /// The subject <see cref="INamedElement"/>
        /// </param>
        /// <param name="other">
        /// the <see cref="INamedElement"/> to compare against
        /// </param>
        /// <param name="namespace">
        /// the <see cref="INamespace"/> within which the two elements are compared
        /// </param>
        /// <returns>
        /// <c>true</c> when the two elements are distinguishable, <c>false</c> otherwise.
        /// </returns>
        /// <remarks>
        /// Two elements are only required to be distinguishable when one is a kind of the other's
        /// type; in that case, they must not share any name visible within <paramref name="namespace"/>
        /// (<see cref="NamespaceExtensions.QueryGetNamesOfMember"/>). "Kind of" is evaluated via
        /// <see cref="IElement.MetaclassInterface"/> rather than the concrete .NET type, since
        /// uml4net's generated concrete classes only ever inherit from <c>XmiElement</c> - the UML
        /// generalization hierarchy is expressed exclusively through interface inheritance (e.g.
        /// <c>IComponent : IClass</c>).
        /// </remarks>
        internal static bool QueryIsDistinguishableFrom(this INamedElement namedElement, INamedElement other, INamespace @namespace)
        {
            if (namedElement == null)
            {
                throw new ArgumentNullException(nameof(namedElement));
            }

            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (@namespace == null)
            {
                throw new ArgumentNullException(nameof(@namespace));
            }

            var oneIsAKindOfTheOther = namedElement.MetaclassInterface.IsInstanceOfType(other)
                || other.MetaclassInterface.IsInstanceOfType(namedElement);

            if (!oneIsAKindOfTheOther)
            {
                return true;
            }

            return !@namespace.QueryGetNamesOfMember(namedElement).Intersect(@namespace.QueryGetNamesOfMember(other)).Any();
        }

        /// <summary>
        /// Queries the fully qualified name of the <see cref="INamedElement"/>
        /// </summary>
        /// <param name="namedElement">
        /// The subject <see cref="INamedElement"/>
        /// </param>
        /// <returns>
        /// a string that represents the fully qualified name following the pattern N1::N2::x where N1 and N2 are the
        /// <see cref="QueryAllNamespaces"/> of the subject <see cref="INamedElement"/> x; null when the element or
        /// any of those Namespaces has no name (UML 2.5.1 clause 7.8.9, constraint <c>has_no_qualified_name</c>)
        /// </returns>
        /// <remarks>
        /// Implements the OCL of <c>NamedElement::qualifiedName</c>:
        /// <c>if self.name &lt;&gt; null and self.allNamespaces()-&gt;select(ns | ns.name = null)-&gt;isEmpty() then
        /// self.allNamespaces()-&gt;iterate(ns; agg = self.name | ns.name.concat(self.separator()).concat(agg)) else null</c>
        /// </remarks>
        internal static string QueryQualifiedName(this INamedElement namedElement)
        {
            if (namedElement == null)
            {
                throw new ArgumentNullException(nameof(namedElement));
            }

            if (namedElement.Name == null)
            {
                return null;
            }

            var allNamespaces = namedElement.QueryAllNamespaces();

            if (allNamespaces.Any(ns => ns.Name == null))
            {
                return null;
            }

            var result = namedElement.Name;

            foreach (var @namespace in allNamespaces)
            {
                result = $"{@namespace.Name}{Separator}{result}";
            }

            return result;
        }

        /// <summary>
        /// The <c>NamedElement::separator</c> used between the names in a qualified name (UML 2.5.1 clause 7.8.9)
        /// </summary>
        internal const string Separator = "::";

        /// <summary>
        /// Queries the sequence of Namespaces of the <see cref="INamedElement"/>, from the innermost to the outermost,
        /// as defined by the operation <c>NamedElement::allNamespaces</c> (UML 2.5.1 clause 7.8.9)
        /// </summary>
        /// <param name="namedElement">
        /// The subject <see cref="INamedElement"/>
        /// </param>
        /// <returns>
        /// the <see cref="INamedElement.Namespace"/> of the element followed by the namespaces of that namespace, and
        /// so on; an element owned by a <see cref="ITemplateParameter"/> whose signature's template is a Namespace
        /// takes that template as its enclosing namespace; empty when the element has no namespace
        /// </returns>
        /// <remarks>
        /// Implements the OCL: <c>if owner.oclIsKindOf(TemplateParameter) and
        /// owner.oclAsType(TemplateParameter).signature.template.oclIsKindOf(Namespace) then let enclosingNamespace =
        /// owner.oclAsType(TemplateParameter).signature.template.oclAsType(Namespace) in
        /// enclosingNamespace.allNamespaces()-&gt;prepend(enclosingNamespace) else if namespace-&gt;isEmpty() then
        /// OrderedSet{} else namespace.allNamespaces()-&gt;prepend(namespace)</c>
        /// </remarks>
        internal static List<INamespace> QueryAllNamespaces(this INamedElement namedElement)
        {
            if (namedElement == null)
            {
                throw new ArgumentNullException(nameof(namedElement));
            }

            INamespace enclosingNamespace;

            // TemplateParameter::signature and TemplateSignature::template subset owner and are not populated by the
            // reader, hence the fallback to the owner (see the DirectedRelationship extensions for the same pattern)
            if (namedElement.Owner is ITemplateParameter templateParameter
                && (templateParameter.Signature ?? templateParameter.Owner as ITemplateSignature) is { } signature
                && (signature.Template ?? signature.Owner as ITemplateableElement) is INamespace template)
            {
                enclosingNamespace = template;
            }
            else
            {
                enclosingNamespace = namedElement.Namespace;
            }

            if (enclosingNamespace == null)
            {
                return [];
            }

            var result = new List<INamespace> { enclosingNamespace };

            result.AddRange(enclosingNamespace.QueryAllNamespaces());

            return result;
        }

        /// <summary>
        /// Queries the <see cref="INamespace"/> that owns the <see cref="INamedElement"/> as one of its
        /// <see cref="INamespace.OwnedMember"/>s (UML 2.5.1 clause 7.8.9: <c>NamedElement::namespace</c> is a derived
        /// union that subsets <c>Element::owner</c> and is the opposite of <c>Namespace::ownedMember</c>)
        /// </summary>
        /// <param name="namedElement">
        /// The subject <see cref="INamedElement"/>
        /// </param>
        /// <returns>
        /// The owner when it is a <see cref="INamespace"/> that has the <see cref="INamedElement"/> among its
        /// <see cref="INamespace.OwnedMember"/>s; null otherwise, for example for a <c>ValueSpecification</c> owned
        /// as a <c>lowerValue</c> or a <c>Pin</c> owned by an <c>Action</c> - more distant ancestors are never returned
        /// </returns>
        internal static INamespace QueryNamespace(this INamedElement namedElement)
        {
            if (namedElement == null)
            {
                throw new ArgumentNullException(nameof(namedElement));
            }

            if (namedElement.Owner is INamespace owner && owner.OwnedMember.Contains(namedElement))
            {
                return owner;
            }

            return null;
        }

    }
}
