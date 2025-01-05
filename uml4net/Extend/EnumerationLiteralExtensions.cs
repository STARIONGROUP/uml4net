// -------------------------------------------------------------------------------------------------
//  <copyright file="EnumerationLiteralExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.SimpleClassifiers
{
    using System;

    /// <summary>
    /// The <see cref="EnumerationLiteralExtensions"/> class provides extensions methods for <see cref="IEnumerationLiteral"/>
    /// </summary>
    public static class EnumerationLiteralExtensions
    {
        /// <summary>
        /// Queries the classifier of this EnumerationLiteral derived to be equal to its Enumeration.
        /// </summary>
        /// <param name="enumerationLiteral">
        /// The subject <see cref="IEnumerationLiteral"/>
        /// </param>
        /// <returns>
        /// The classifier of this EnumerationLiteral derived to be equal to its Enumeration.
        /// </returns>
        public static IEnumeration QueryClassifier(this IEnumerationLiteral enumerationLiteral)
        {
            throw new NotSupportedException();
        }
    }
}
