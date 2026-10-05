// -------------------------------------------------------------------------------------------------
// <copyright file="ContainerListMembership.cs" company="Starion Group S.A.">
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

namespace uml4net
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using uml4net.CommonStructure;

    /// <summary>
    /// The <see cref="IContainerListMembership"/> interface is the non-generic view of a <see cref="ContainerList{T}"/>
    /// that is used to keep an element in the composite lists of a single container
    /// </summary>
    internal interface IContainerListMembership
    {
        /// <summary>
        /// Gets the <see cref="IElement"/> that owns the list
        /// </summary>
        IElement Container { get; }

        /// <summary>
        /// Removes an element that moves to another container from the list and clears its owner end, without
        /// changing its <see cref="IElement.Possessor"/>
        /// </summary>
        /// <param name="element">The <see cref="IElement"/> that moves to another container</param>
        void DetachMovingElement(IElement element);

        /// <summary>
        /// Sets the owner end of an element that the list still holds to the container
        /// </summary>
        /// <param name="element">The <see cref="IElement"/> held by the list</param>
        void ReattachOwnerEnd(IElement element);
    }

    /// <summary>
    /// The <see cref="ContainerListMembership"/> class records which <see cref="ContainerList{T}"/>s hold an element.
    /// An element can be held by more than one composite list of the same container, when a composite property subsets
    /// another one (for example <c>Operation::precondition</c> subsets <c>Namespace::ownedRule</c>), but by the lists of
    /// one container only.
    /// </summary>
    /// <remarks>
    /// A <see cref="ConditionalWeakTable{TKey,TValue}"/> is used so that the record does not keep an element alive
    /// </remarks>
    internal static class ContainerListMembership
    {
        /// <summary>
        /// The lists that hold an element
        /// </summary>
        private static readonly ConditionalWeakTable<IElement, List<IContainerListMembership>> Memberships = new();

        /// <summary>
        /// Records that the <paramref name="list"/> holds the <paramref name="element"/>
        /// </summary>
        /// <param name="element">The held <see cref="IElement"/></param>
        /// <param name="list">The list that holds it</param>
        internal static void Register(IElement element, IContainerListMembership list)
        {
            var lists = Memberships.GetOrCreateValue(element);

            if (!lists.Any(x => ReferenceEquals(x, list)))
            {
                lists.Add(list);
            }
        }

        /// <summary>
        /// Records that the <paramref name="list"/> no longer holds the <paramref name="element"/>
        /// </summary>
        /// <param name="element">The <see cref="IElement"/> that is no longer held</param>
        /// <param name="list">The list that held it</param>
        internal static void Unregister(IElement element, IContainerListMembership list)
        {
            if (Memberships.TryGetValue(element, out var lists))
            {
                lists.RemoveAll(x => ReferenceEquals(x, list));
            }
        }

        /// <summary>
        /// Queries the lists that hold the <paramref name="element"/>
        /// </summary>
        /// <param name="element">The <see cref="IElement"/></param>
        /// <returns>The lists that hold the <paramref name="element"/>, a copy that can be changed while iterating</returns>
        internal static List<IContainerListMembership> QueryLists(IElement element)
        {
            return Memberships.TryGetValue(element, out var lists) ? lists.ToList() : new List<IContainerListMembership>();
        }
    }
}
