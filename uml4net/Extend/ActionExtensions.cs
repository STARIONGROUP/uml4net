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
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using uml4net.Classification;
    using uml4net.Decorators;

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
        internal static IClassifier QueryContext(this IAction action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (action.InStructuredNode != null)
            {
                return action.InStructuredNode.Context;
            }

            var activity = action is IStructuredActivityNode structuredActivityNode ? structuredActivityNode.Activity : action.Activity;

            if (activity != null)
            {
                return activity.Context;
            }

            return null;
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
        internal static IContainerList<IInputPin> QueryInput(this IAction action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var containerList = new ContainerList<IInputPin>(action);

            foreach (var inputPin in action.QuerySubsettedPins<IInputPin>("Action-input"))
            {
                containerList.Add(inputPin);
            }

            return containerList;
        }

        /// <summary>
        /// Queries the ordered set of OutputPins representing outputs from the Action.
        /// </summary>
        /// <param name="action">
        /// The subject <see cref="IAction"/>
        /// </param>
        /// <returns>
        /// The ordered set of OutputPins representing outputs from the Action.
        /// </returns>
        internal static IContainerList<IOutputPin> QueryOutput(this IAction action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var containerList = new ContainerList<IOutputPin>(action);

            foreach (var outputPin in action.QuerySubsettedPins<IOutputPin>("Action-output"))
            {
                containerList.Add(outputPin);
            }

            return containerList;
        }

        /// <summary>
        /// Queries, in declaration order, the values of the properties on the runtime type of the
        /// <paramref name="action"/> that are decorated with a <see cref="SubsettedPropertyAttribute"/>
        /// referencing <paramref name="subsettedPropertyName"/> (e.g. "Action-input" or "Action-output").
        /// Every concrete Action subclass declares its own specifically-named pins (e.g.
        /// <c>CallAction.Argument</c>, <c>SendSignalAction.Target</c>) that subset the derived union
        /// <see cref="IAction.Input"/>/<see cref="IAction.Output"/>; this reflects over those declarations
        /// instead of enumerating every concrete subclass by hand.
        /// </summary>
        /// <typeparam name="TPin">
        /// The pin type, <see cref="IInputPin"/> or <see cref="IOutputPin"/>.
        /// </typeparam>
        /// <param name="action">
        /// The subject <see cref="IAction"/>
        /// </param>
        /// <param name="subsettedPropertyName">
        /// The <see cref="PropertyAttribute.XmiId"/> of the subsetted union property, "Action-input" or "Action-output".
        /// </param>
        /// <returns>
        /// The pins declared by the properties that subset <paramref name="subsettedPropertyName"/>.
        /// </returns>
        private static IEnumerable<TPin> QuerySubsettedPins<TPin>(this IAction action, string subsettedPropertyName)
        {
            var subsettingProperties = action.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(property => property.GetCustomAttributes<SubsettedPropertyAttribute>().Any(attribute => attribute.PropertyName == subsettedPropertyName));

            foreach (var subsettingProperty in subsettingProperties)
            {
                if (subsettingProperty.GetValue(action) is IEnumerable<TPin> pins)
                {
                    foreach (var pin in pins)
                    {
                        yield return pin;
                    }
                }
            }
        }
    }
}
