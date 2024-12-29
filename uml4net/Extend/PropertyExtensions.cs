// -------------------------------------------------------------------------------------------------
//  <copyright file="PropertyExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Classification
{
    using System;
    using System.Linq;

    /// <summary>
    /// The <see cref="PropertyExtensions"/> class provides extensions methods for <see cref="IProperty"/>
    /// </summary>
    public static class PropertyExtensions
    {
        /// <summary>
        /// Asserts whether the aggregation of the <see cref="IProperty"/> is composite or not.
        /// </summary>
        /// <param name="property">
        /// the subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// true if the aggregation is composite, false if not
        /// </returns>
        public static bool QueryIsComposite(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (property.Aggregation == AggregationKind.Composite)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// In the case where the Property is one end of a binary association this gives the other end.
        /// </summary>
        /// <param name="property">
        /// The subject <see cref="IProperty"/>
        /// </param>
        /// <returns>
        /// In the case where the Property is one end of a binary association this gives the other end.
        /// </returns>
        public static IProperty QueryOpposite(this IProperty property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (property.Association == null)
            {
                return null;
            }

            return property.Association.MemberEnd.Except([property]).Single();
        }
    }
}
