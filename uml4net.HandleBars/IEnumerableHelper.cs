// -------------------------------------------------------------------------------------------------
//  <copyright file="IEnumerableHelper.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

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
            handlebars.RegisterHelper("IEnumerable.IsEmpty", (context, parameters) =>
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