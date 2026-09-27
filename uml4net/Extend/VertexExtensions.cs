// -------------------------------------------------------------------------------------------------
// <copyright file="VertexExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.StateMachines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.Classification;

    /// <summary>
    /// The <see cref="VertexExtensions"/> class provides extensions methods for <see cref="IVertex"/>
    /// </summary>
    internal static class VertexExtensions
    {
        /// <summary>
        /// Specifies the Transitions entering this Vertex.
        /// </summary>
        /// <param name="vertex">
        /// The subject <see cref="IVertex"/>
        /// </param>
        /// <returns>
        /// The Transitions entering this Vertex.
        /// </returns>
        internal static List<ITransition> QueryIncoming(this IVertex vertex)
        {
            if (vertex == null)
            {
                throw new ArgumentNullException(nameof(vertex));
            }

            return QueryTransitionsInContainingStateMachine(vertex)
                .Where(transition => ReferenceEquals(transition.Target, vertex))
                .ToList();
        }

        /// <summary>
        /// Specifies the Transitions departing from this Vertex.
        /// </summary>
        /// <param name="vertex">
        /// The subject <see cref="IVertex"/>
        /// </param>
        /// <returns>
        /// The Transitions departing from this Vertex.
        /// </returns>
        internal static List<ITransition> QueryOutgoing(this IVertex vertex)
        {
            if (vertex == null)
            {
                throw new ArgumentNullException(nameof(vertex));
            }

            return QueryTransitionsInContainingStateMachine(vertex)
                .Where(transition => ReferenceEquals(transition.Source, vertex))
                .ToList();
        }

        /// <summary>
        /// Classifier in which context this element may be redefined.
        /// </summary>
        /// <param name="vertex">
        /// The subject <see cref="IVertex"/>
        /// </param>
        /// <returns>
        /// Classifier in which context this element may be redefined.
        /// </returns>
        internal static IClassifier QueryRedefinitionContext(this IVertex vertex)
        {
            if (vertex == null)
            {
                throw new ArgumentNullException(nameof(vertex));
            }

            return vertex.QueryContainingStateMachine();
        }

        /// <summary>
        /// Queries the StateMachine that contains the <paramref name="vertex"/>, as defined by the operation
        /// <c>Vertex::containingStateMachine</c>
        /// </summary>
        /// <param name="vertex">
        /// The subject <see cref="IVertex"/>
        /// </param>
        /// <returns>
        /// The containing <see cref="IStateMachine"/>, or null when none can be determined.
        /// </returns>
        /// <remarks>
        /// Implements the OCL: <c>if container &lt;&gt; null then container.containingStateMachine() else if
        /// (Pseudostate with kind entryPoint or exitPoint) then stateMachine else if (ConnectionPointReference) then
        /// state.containingStateMachine() else null</c>, with one addition. The OCL only considers the entry and exit
        /// points of a StateMachine (<c>StateMachine::connectionPoint</c>) and yields null for those owned by a
        /// composite State (<c>State::connectionPoint</c>), although such a Pseudostate is a Vertex whose
        /// <c>redefinitionContext</c> is <c>[1..1]</c> and whose Transitions live in the Regions of the enclosing
        /// StateMachine: it is contained by the StateMachine of that State.
        /// </remarks>
        internal static IStateMachine QueryContainingStateMachine(this IVertex vertex)
        {
            if (vertex == null)
            {
                throw new ArgumentNullException(nameof(vertex));
            }

            if (vertex.Container != null)
            {
                return vertex.Container.QueryContainingStateMachine();
            }

            if (vertex is IPseudostate { Kind: PseudostateKind.EntryPoint or PseudostateKind.ExitPoint } pseudostate)
            {
                return pseudostate.StateMachine ?? pseudostate.State?.QueryContainingStateMachine();
            }

            if (vertex is IConnectionPointReference connectionPointReference)
            {
                return connectionPointReference.State?.QueryContainingStateMachine();
            }

            return null;
        }

        /// <summary>
        /// Queries the Transitions owned, directly or through nested composite State Regions, by the
        /// <paramref name="vertex"/>'s containing StateMachine.
        /// </summary>
        private static IEnumerable<ITransition> QueryTransitionsInContainingStateMachine(IVertex vertex)
        {
            var stateMachine = vertex.QueryContainingStateMachine();

            return stateMachine == null ? Enumerable.Empty<ITransition>() : QueryTransitions(stateMachine);
        }

        /// <summary>
        /// Queries all the Transitions owned, directly or through nested composite State Regions, by the
        /// <paramref name="stateMachine"/>.
        /// </summary>
        private static IEnumerable<ITransition> QueryTransitions(IStateMachine stateMachine)
        {
            return stateMachine.Region.SelectMany(QueryTransitions);
        }

        /// <summary>
        /// Queries all the Transitions owned, directly or through nested composite State Regions, by the
        /// <paramref name="region"/>.
        /// </summary>
        private static IEnumerable<ITransition> QueryTransitions(IRegion region)
        {
            foreach (var transition in region.Transition)
            {
                yield return transition;
            }

            foreach (var transition in region.Subvertex.OfType<IState>().SelectMany(state => state.Region).SelectMany(QueryTransitions))
            {
                yield return transition;
            }
        }
    }
}
