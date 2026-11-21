// -------------------------------------------------------------------------------------------------
// <copyright file="BehaviorExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.CommonBehavior
{
    using System;

    using uml4net.CommonStructure;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// The <see cref="BehaviorExtensions"/> class provides extensions methods for <see cref="IBehavior"/>
    /// </summary>
    internal static class BehaviorExtensions
    {
        /// <summary>
        /// Queries the BehavioredClassifier that is the context for the execution of the Behavior. A Behavior that is
        /// directly owned as a nestedClassifier does not have a context. Otherwise, to determine the context of
        /// a Behavior, find the first BehavioredClassifier reached by following the chain of owner
        /// relationships from the Behavior, if any. If there is such a BehavioredClassifier, then it is the
        /// context, unless it is itself a Behavior with a non-empty context, in which case that is also the
        /// context for the original Behavior. For example, following this algorithm, the context of an entry
        /// Behavior in a StateMachine is the BehavioredClassifier that owns the StateMachine. The features of
        /// the context BehavioredClassifier as well as the Elements visible to the context Classifier are
        /// visible to the Behavior.
        /// </summary>
        /// <param name="behavior">
        /// The subject <see cref="IBehavior"/>
        /// </param>
        /// <returns>
        /// The BehavioredClassifier that is the context for the execution of the Behavior. A Behavior that is
        /// directly owned as a nestedClassifier does not have a context. Otherwise, to determine the context of
        /// a Behavior, find the first BehavioredClassifier reached by following the chain of owner
        /// relationships from the Behavior, if any. If there is such a BehavioredClassifier, then it is the
        /// context, unless it is itself a Behavior with a non-empty context, in which case that is also the
        /// context for the original Behavior. For example, following this algorithm, the context of an entry
        /// Behavior in a StateMachine is the BehavioredClassifier that owns the StateMachine. The features of
        /// the context BehavioredClassifier as well as the Elements visible to the context Classifier are
        /// visible to the Behavior.
        /// </returns>
        internal static IBehavioredClassifier QueryContext(this IBehavior behavior)
        {
            if (behavior == null)
            {
                throw new ArgumentNullException(nameof(behavior));
            }

            if (behavior.Owner is IClass owningClass && owningClass.NestedClassifier.Contains(behavior))
            {
                return null;
            }

            IElement current = behavior.Owner;

            while (current != null)
            {
                if (current is IBehavioredClassifier behavioredClassifier)
                {
                    if (behavioredClassifier is IBehavior ancestorBehavior)
                    {
                        return ancestorBehavior.Context ?? behavioredClassifier;
                    }

                    return behavioredClassifier;
                }

                current = current.Owner;
            }

            return null;
        }
    }
}
