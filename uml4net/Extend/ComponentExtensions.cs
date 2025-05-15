// -------------------------------------------------------------------------------------------------
//  <copyright file="ComponentExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.StructuredClassifiers
{
    using System;
    using System.Collections.Generic;
    
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
            throw new NotSupportedException();
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
            throw new NotSupportedException();
        }
    }
}
