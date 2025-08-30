// -------------------------------------------------------------------------------------------------
// <copyright file="BehaviorExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.CommonBehavior
{
    using System;

    using uml4net.SimpleClassifiers;

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
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static IBehavioredClassifier QueryContext(this IBehavior behavior)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }
    }
}
