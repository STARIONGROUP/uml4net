// -------------------------------------------------------------------------------------------------
//  <copyright file="ClassExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.POCO.Classification;
    using uml4net.POCO.StructuredClassifiers;

    /// <summary>
    /// Extension methods for <see cref="IClass"/> interface
    /// </summary>
    public static class ClassExtensions
    {
        /// <summary>
        /// Retrieves all properties from the specified class's abstract superclasses and any interfaces 
        /// implemented by those classes, traversing up the inheritance hierarchy to gather properties.
        /// </summary>
        /// <param name="class">
        /// The <see cref="IClass"/> instance for which to query properties from abstract base classes and interfaces.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{IProperty}"/> containing all properties defined in each abstract superclass
        /// and each associated interface. Each property is yielded immediately upon discovery for lazy enumeration.
        /// </returns>
        /// <remarks>
        /// This method first collects properties from the direct abstract superclass of the specified class, including 
        /// properties from any interfaces implemented by that superclass. It then proceeds up the inheritance chain, 
        /// repeating this process for each abstract superclass encountered until no more superclasses are found.
        /// </remarks>
        public static IEnumerable<IProperty> QueryAllAttribute(this IClass @class)
        {
            var baseClass = @class;
            var interfaceProperties = @class.QueryInterfaces().SelectMany(x => x.Attribute);

            while (baseClass is not null)
            {
                foreach (var attribute in baseClass.OwnedAttribute)
                {
                    yield return attribute;
                }

                foreach (var interfaceProperty in interfaceProperties)
                {
                    yield return interfaceProperty;
                }

                interfaceProperties = baseClass.QueryInterfaces().SelectMany(x => x.Attribute).Distinct();
                baseClass = baseClass.SuperClass.FirstOrDefault(x => x.IsAbstract);
            }
        }
    }
}