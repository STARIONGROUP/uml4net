// -------------------------------------------------------------------------------------------------
//  <copyright file="ReferencedPropertyAttribute.cs" company="Starion Group S.A.">
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

namespace uml4net.Decorators
{

    using System;
    using System.Linq;
    using System.Reflection;

    using uml4net.POCO.Classification;

    /// <summary>
    /// Attribute used to decorate properties with using the properties sourced from
    /// the UML meta-model.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ReferencedPropertyAttribute : Attribute
    {

        /// <summary>
        /// Gets or sets the property name that this attribute can decorate
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferencedPropertyAttribute"/> class.
        /// </summary>
        /// <param name="propertyName">The property name</param>
        public ReferencedPropertyAttribute(string propertyName)
        {
            this.PropertyName = propertyName;
        }

        public static string GetName<T>(IReferenceable<T> instance)
        {
            var memberInfo = GetExplicitInterfaceProperty(instance);
            var customAttribute = Attribute.GetCustomAttribute(memberInfo, typeof(ReferencedPropertyAttribute));
            return ((ReferencedPropertyAttribute)customAttribute).PropertyName;
        }
        
        public static PropertyInfo GetExplicitInterfaceProperty<T>(IReferenceable<T> instance)
        {
            var instanceType = instance.GetType();

            var interfaceMap = instanceType.GetInterfaceMap(typeof(IReferenceable<T>));

            var propertyMethod = interfaceMap.TargetMethods
                .FirstOrDefault(m => m.Name.EndsWith(nameof(IReferenceable<T>.Reference), StringComparison.Ordinal));

            if (propertyMethod != null)
            {
                return instanceType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
                    .FirstOrDefault(p => p.GetMethod == propertyMethod || p.SetMethod == propertyMethod);
            }

            throw new InvalidOperationException($"Property Reference not found for the explicit interface implementation.");
        }
    }
}
