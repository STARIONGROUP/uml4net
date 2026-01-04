// -------------------------------------------------------------------------------------------------
// <copyright file="ActionExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Actions
{
    using System;
    
    using uml4net.Classification;

    /// <summary>
    /// The <see cref="ActionExtensions"/> class provides extensions methods for <see cref="IAction"/>
    /// </summary>
    internal static class ActionExtensions
    {
        /// <summary>
        /// Queries the context Classifier of the Behavior that contains this Action, or the Behavior itself if it has
        /// no context.
        /// </summary>
        /// <param name="action">
        /// The subject <see cref="IAction"/>
        /// </param>
        /// <returns>
        /// a <see cref="IClassifier"/>
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static IClassifier QueryContext(this IAction action)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }

        /// <summary>
        /// Queries the ordered set of InputPins representing the inputs to the Action.
        /// </summary>
        /// <param name="action">
        /// The subject <see cref="IAction"/>
        /// </param>
        /// <returns>
        /// The ordered set of InputPins representing the inputs to the Action.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static IContainerList<IInputPin> QueryInput(this IAction action)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }

        /// <summary>
        /// Queries the ordered set of OutputPins representing outputs from the Action.
        /// </summary>
        /// <param name="action">
        /// The subject <see cref="IAction"/>
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static IContainerList<IOutputPin> QueryOutput(this IAction action)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }
    }
}
