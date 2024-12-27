// -------------------------------------------------------------------------------------------------
//  <copyright file="PortExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
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
    /// The <see cref="PortExtensions"/> class provides extensions methods for <see cref="IPort"/>
    /// </summary>
    public static class PortExtensions
    {
        /// <summary>
        /// Queries  The Interfaces specifying the set of Operations and Receptions that the EncapsulatedCclassifier
        /// offers to its environment via this Port, and which it will handle either directly or by forwarding
        /// it to a part of its internal structure. This association is derived according to the value of
        /// isConjugated. If isConjugated is false, provided is derived as the union of the sets of Interfaces
        /// realized by the type of the port and its supertypes, or directly from the type of the Port if the
        /// Port is typed by an Interface. If isConjugated is true, it is derived as the union of the sets of
        /// Interfaces used by the type of the Port and its supertypes.
        /// </summary>
        /// <param name="port">
        /// The subject <see cref="IPort"/>
        /// </param>
        /// <returns>
        ///  The Interfaces specifying the set of Operations and Receptions that the EncapsulatedCclassifier
        /// offers to its environment via this Port, and which it will handle either directly or by forwarding
        /// it to a part of its internal structure. This association is derived according to the value of
        /// isConjugated. If isConjugated is false, provided is derived as the union of the sets of Interfaces
        /// realized by the type of the port and its supertypes, or directly from the type of the Port if the
        /// Port is typed by an Interface. If isConjugated is true, it is derived as the union of the sets of
        /// Interfaces used by the type of the Port and its supertypes.
        /// </returns>
        public static List<IInterface> QueryProvided(this IPort port)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Queries The Interfaces specifying the set of Operations and Receptions that the EncapsulatedCassifier
        /// expects its environment to handle via this port. This association is derived according to the value
        /// of isConjugated. If isConjugated is false, required is derived as the union of the sets of
        /// Interfaces used by the type of the Port and its supertypes. If isConjugated is true, it is derived
        /// as the union of the sets of Interfaces realized by the type of the Port and its supertypes, or
        /// directly from the type of the Port if the Port is typed by an Interface.
        /// </summary>
        /// <param name="port">
        /// The subject <see cref="IPort"/>
        /// </param>
        /// <returns>
        ///  The Interfaces specifying the set of Operations and Receptions that the EncapsulatedCassifier
        /// expects its environment to handle via this port. This association is derived according to the value
        /// of isConjugated. If isConjugated is false, required is derived as the union of the sets of
        /// Interfaces used by the type of the Port and its supertypes. If isConjugated is true, it is derived
        /// as the union of the sets of Interfaces realized by the type of the Port and its supertypes, or
        /// directly from the type of the Port if the Port is typed by an Interface.
        /// </returns>
        public static List<IInterface> QueryRequired(this IPort port)
        {
            throw new NotSupportedException();
        }

    }
}
