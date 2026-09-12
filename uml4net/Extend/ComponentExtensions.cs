// -------------------------------------------------------------------------------------------------
// <copyright file="ComponentExtensions.cs" company="Starion Group S.A.">
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
    using System.Linq;

    using uml4net.Classification;
    using uml4net.SimpleClassifiers;

    /// <summary>
    /// The <see cref="ComponentExtensions"/> class provides extensions methods for <see cref="IComponent"/>
    /// </summary>
    internal static class ComponentExtensions
    {
        /// <summary>
        /// Queries The Interfaces that the Component exposes to its environment. These Interfaces may be Realized by
        /// the Component or any of its realizingClassifiers, or they may be the Interfaces that are provided by
        /// its public Ports.
        /// </summary>
        /// <param name="component">
        /// The subject <see cref="IComponent"/>
        /// </param>
        /// <returns>
        /// The Interfaces that the Component exposes to its environment. These Interfaces may be Realized by
        /// the Component or any of its realizingClassifiers, or they may be the Interfaces that are provided by
        /// its public Ports.
        /// </returns>
        internal static List<IInterface> QueryProvided(this IComponent component)
        {
            if (component == null)
            {
                throw new ArgumentNullException(nameof(component));
            }

            var realizedInterfaces = component.QueryAllRealizedInterfaces();

            var realizingClassifierInterfaces = component.QueryAllRealizingClassifiers()
                .SelectMany(realizingClassifier => realizingClassifier.QueryAllRealizedInterfaces());

            var providedByPorts = component.QueryAllPorts()
                .SelectMany(port => port.QueryProvided());

            return realizedInterfaces
                .Concat(realizingClassifierInterfaces)
                .Concat(providedByPorts)
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Queries The Interfaces that the Component requires from other Components in its environment in order to be
        /// able to offer its full set of provided functionality. These Interfaces may be used by the Component
        /// or any of its realizingClassifiers, or they may be the Interfaces that are required by its public
        /// Ports.
        /// </summary>
        /// <param name="component">
        /// The subject <see cref="IComponent"/>
        /// </param>
        /// <returns>
        /// The Interfaces that the Component requires from other Components in its environment in order to be
        /// able to offer its full set of provided functionality. These Interfaces may be used by the Component
        /// or any of its realizingClassifiers, or they may be the Interfaces that are required by its public
        /// Ports.
        /// </returns>
        internal static List<IInterface> QueryRequired(this IComponent component)
        {
            if (component == null)
            {
                throw new ArgumentNullException(nameof(component));
            }

            var usedInterfaces = component.QueryAllUsedInterfaces();

            var realizingClassifierInterfaces = component.QueryAllRealizingClassifiers()
                .SelectMany(realizingClassifier => realizingClassifier.QueryAllUsedInterfaces());

            var requiredByPorts = component.QueryAllPorts()
                .SelectMany(port => port.QueryRequired());

            return usedInterfaces
                .Concat(realizingClassifierInterfaces)
                .Concat(requiredByPorts)
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Queries the Classifiers that realize this Component, directly or via one of its general Classifiers,
        /// together with every general Classifier of those realizing Classifiers.
        /// </summary>
        /// <param name="component">
        /// The subject <see cref="IComponent"/>
        /// </param>
        /// <returns>
        /// the transitive closure of Classifiers realizing this Component.
        /// </returns>
        private static List<IClassifier> QueryAllRealizingClassifiers(this IComponent component)
        {
            var realizingClassifiers = component.Realization
                .SelectMany(realization => realization.RealizingClassifier)
                .Concat(component.QueryAllGeneralClassifiers()
                    .OfType<IComponent>()
                    .SelectMany(generalComponent => generalComponent.Realization)
                    .SelectMany(realization => realization.RealizingClassifier))
                .Distinct()
                .ToList();

            return realizingClassifiers
                .Concat(realizingClassifiers.SelectMany(realizingClassifier => realizingClassifier.QueryAllGeneralClassifiers()))
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Queries the Ports owned by this Component, together with the Ports owned by its general Classifiers.
        /// </summary>
        /// <param name="component">
        /// The subject <see cref="IComponent"/>
        /// </param>
        /// <returns>
        /// every Port owned by this Component or any of its general Classifiers.
        /// </returns>
        private static List<IPort> QueryAllPorts(this IComponent component)
        {
            return component.OwnedPort
                .Concat(component.QueryAllGeneralClassifiers()
                    .OfType<IEncapsulatedClassifier>()
                    .SelectMany(generalClassifier => generalClassifier.OwnedPort))
                .Distinct()
                .ToList();
        }
    }
}
