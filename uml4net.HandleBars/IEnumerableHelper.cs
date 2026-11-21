// -------------------------------------------------------------------------------------------------
// <copyright file="IEnumerableHelper.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.HandleBars
{
    using System.Collections.Generic;
    using System.Linq;

    using HandlebarsDotNet;

    /// <summary>
    /// A  helper that supports operations on IEnumerable
    /// </summary>
    public static class IEnumerableHelper
    {
        /// <summary>
        /// Registers the <see cref="IEnumerableHelper"/>
        /// </summary>
        /// <param name="handlebars">
        /// The <see cref="IHandlebars"/> context with which the helper needs to be registered
        /// </param>
        public static void RegisterEnumerableHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("IEnumerable.IsEmpty", (_, parameters) =>
            {
                if (parameters[0] is IEnumerable<object> list && !list.Any())
                {
                    return true;
                }
                
                return false;
                
            });
        }
    }
}
