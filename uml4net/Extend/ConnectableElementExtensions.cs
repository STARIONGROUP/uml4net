// -------------------------------------------------------------------------------------------------
// <copyright file="ConnectableElementExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.StructuredClassifiers
{
    using System;
    using System.Collections.Generic;

    using uml4net.CommonStructure;

    /// <summary>
    /// The <see cref="ConnectableElementExtensions"/> class provides extensions methods for <see cref="IConnectableElement"/>
    /// </summary>
    internal static class ConnectableElementExtensions
    {
        /// <summary>
        /// Queries A set of ConnectorEnds that attach to this ConnectableElement. Per the UML 2.5.1 metamodel this
        /// is derived as <c>ConnectorEnd.allInstances()->select(role = self)</c>. uml4net has no model-wide
        /// instance registry, so this is implemented as a bounded search of the containment tree reachable from
        /// this element, rather than a literal whole-metamodel scan: walk up to the root of the containment tree
        /// (via <see cref="IElement.Owner"/>), then recursively search every <see cref="IElement.OwnedElement"/>
        /// for <see cref="IConnectorEnd"/>s whose <see cref="IConnectorEnd.Role"/> is this ConnectableElement.
        /// </summary>
        /// <param name="connectableElement">
        /// The subject <see cref="IConnectableElement"/>
        /// </param>
        /// <returns>
        /// A set of ConnectorEnds that attach to this ConnectableElement.
        /// </returns>
        internal static List<IConnectorEnd> QueryEnd(this IConnectableElement connectableElement)
        {
            if (connectableElement == null)
            {
                throw new ArgumentNullException(nameof(connectableElement));
            }

            IElement root = connectableElement;

            while (root.Owner != null)
            {
                root = root.Owner;
            }

            var end = new List<IConnectorEnd>();
            var visited = new HashSet<IElement>();
            var elementsToProcess = new Stack<IElement>();
            elementsToProcess.Push(root);

            while (elementsToProcess.Count > 0)
            {
                var current = elementsToProcess.Pop();

                if (!visited.Add(current))
                {
                    continue;
                }

                if (current is IConnectorEnd connectorEnd && ReferenceEquals(connectorEnd.Role, connectableElement))
                {
                    end.Add(connectorEnd);
                }

                foreach (var ownedElement in current.OwnedElement)
                {
                    elementsToProcess.Push(ownedElement);
                }
            }

            return end;
        }
    }
}
