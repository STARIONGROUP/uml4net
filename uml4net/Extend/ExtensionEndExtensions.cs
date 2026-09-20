// -------------------------------------------------------------------------------------------------
// <copyright file="ExtensionEndExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Packages
{
    using System;
    using System.Linq;

    using uml4net.CommonStructure;
    using uml4net.Values;

    /// <summary>
    /// The <see cref="ExtensionEndExtensions"/> class provides extensions methods for <see cref="IExtensionEnd"/>
    /// </summary>
    internal static class ExtensionEndExtensions
    {
        /// <summary>
        /// Queries the lower bound of the <paramref name="extensionEnd"/>. This is a redefinition of the default
        /// lower bound, which normally, for MultiplicityElements, evaluates to 1 if empty; for an ExtensionEnd it
        /// evaluates to 0 if empty, since model elements are usually extended by 0 or 1 instance of the extension
        /// stereotype.
        /// </summary>
        /// <param name="extensionEnd">
        /// The subject <see cref="IExtensionEnd"/>
        /// </param>
        /// <returns>
        /// The lower bound of the <paramref name="extensionEnd"/>.
        /// </returns>
        internal static int QueryLower(this IExtensionEnd extensionEnd)
        {
            if (extensionEnd == null)
            {
                throw new ArgumentNullException(nameof(extensionEnd));
            }

            // lowerBound(): if lowerValue = null then 0 else lowerValue.integerValue(); integerValue() is null for a
            // lowerValue that is not a literal, in which case the default of an ExtensionEnd, 0, is returned since
            // the lower bound cannot be empty
            return MultiplicityElementExtensions.TryQueryIntegerValue(extensionEnd.LowerValue.SingleOrDefault(), out var lower) ? lower : 0;
        }
    }
}
