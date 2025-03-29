// -------------------------------------------------------------------------------------------------
//  <copyright file="ClassHelper.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
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
    using System;
    using System.Linq;
    using HandlebarsDotNet;

    using uml4net.Extensions;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// A block helper that supports codegen for <see cref="IClass"/>
    /// </summary>
    public static class ClassHelper
    {
        /// <summary>
        /// Registers the <see cref="ClassHelper"/>
        /// </summary>
        /// <param name="handlebars">
        /// The <see cref="IHandlebars"/> context with which the helper needs to be registered
        /// </param>
        public static void RegisterClassHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("Class.QueryOwnedAttributeOrdered", (context, _) =>
            {
                if (!(context.Value is IClass @class))
                {
                    throw new ArgumentException("supposed to be IClass");
                }

                var properties = @class.OwnedAttribute.OrderBy(x => x.Name);

                return properties;
            });

            handlebars.RegisterHelper("Class.QueryAllProperties", (context, _) =>
            {
                if (!(context.Value is IClass @class))
                {
                    throw new ArgumentException("supposed to be IClass");
                }

                var properties = @class.QueryAllProperties().OrderBy(x => x.Name);

                return properties;
            });

            handlebars.RegisterHelper("Class.QueryAllContainedProperties", (context, _) =>
            {
                if (!(context.Value is IClass @class))
                {
                    throw new ArgumentException("supposed to be IClass");
                }

                var properties = @class.QueryAllProperties()
                    .Where(x => x.IsComposite)
                    . OrderBy(x => x.Name);

                return properties;
            });

            handlebars.RegisterHelper("Class.QueryAllContainedNonDerivedProperties", (context, _) =>
            {
                if (!(context.Value is IClass @class))
                {
                    throw new ArgumentException("supposed to be IClass");
                }

                var properties = @class.QueryAllProperties()
                    .Where(x => x.IsComposite)
                    .Where(x => !x.IsDerived)
                    .OrderBy(x => x.Name);

                return properties;
            });

            handlebars.RegisterHelper("Class.QueryAllContainedNonDerivedNonRedefinedProperties", (context, _) =>
            {
                if (!(context.Value is IClass @class))
                {
                    throw new ArgumentException("supposed to be IClass");
                }

                var properties = @class.QueryAllProperties()
                    .Where(x => x.IsComposite)
                    .Where(x => !x.IsDerived)
                    .OrderBy(x => x.Name)
                    .ToList();

                var nonRedefinedProperties = properties.ToList();

                foreach (var property in properties)
                {
                    foreach (var redefinedProperty in property.RedefinedProperty)        
                    {
                        if (nonRedefinedProperties.Contains(redefinedProperty))
                        {
                            nonRedefinedProperties.Remove(redefinedProperty);
                        }
                    }
                }

                return nonRedefinedProperties;
            });

            handlebars.RegisterHelper("Class.QueryAllNonDerivedProperties", (context, _) =>
            {
                if (!(context.Value is IClass @class))
                {
                    throw new ArgumentException("supposed to be IClass");
                }

                var properties = @class.QueryAllProperties()
                    .Where(x => !x.IsDerived)
                    .OrderBy(x => x.Name);

                return properties;
            });

            handlebars.RegisterHelper("Class.QueryAllNonDerivedNonReadOnlyProperties", (context, _) =>
            {
                if (!(context.Value is IClass @class))
                {
                    throw new ArgumentException("supposed to be IClass");
                }

                var properties = @class.QueryAllProperties()
                    .Where(x => !x.IsDerived)
                    .Where(x => !x.IsDerivedUnion)
                    .Where(x => !x.IsReadOnly)
                    .OrderBy(x => x.Name);

                return properties;
            });

            handlebars.RegisterHelper("Class.QueryAllNonDerivedNonReadOnlyNonContainedReferenceEnumerableProperties", (context, _) =>
            {
                if (!(context.Value is IClass @class))
                {
                    throw new ArgumentException("supposed to be IClass");
                }

                var properties = @class.QueryAllProperties()
                    .Where(x => !x.IsDerived)
                    .Where(x => !x.IsDerivedUnion)
                    .Where(x => !x.IsReadOnly)
                    .Where(x => !x.IsComposite)
                    .Where(x => x.QueryIsReferenceProperty())
                    .Where(x => x.QueryIsEnumerable())
                    .OrderBy(x => x.Name);

                return properties;
            });

            handlebars.RegisterHelper("Class.QueryAllNonDerivedNonReadOnlyNonContainedNonRedefinedReferenceEnumerableProperties", (context, _) =>
            {
                if (!(context.Value is IClass @class))
                {
                    throw new ArgumentException("supposed to be IClass");
                }

                var properties = @class.QueryAllProperties()
                    .Where(x => !x.IsDerived)
                    .Where(x => !x.IsDerivedUnion)
                    .Where(x => !x.IsReadOnly)
                    .Where(x => !x.IsComposite)
                    .Where(x => x.QueryIsReferenceProperty())
                    .Where(x => x.QueryIsEnumerable())
                    .OrderBy(x => x.Name);

                var nonRedefinedProperties = properties.ToList();

                foreach (var property in properties)
                {
                    foreach (var redefinedProperty in property.RedefinedProperty)
                    {
                        if (nonRedefinedProperties.Contains(redefinedProperty))
                        {
                            nonRedefinedProperties.Remove(redefinedProperty);
                        }
                    }
                }

                return nonRedefinedProperties;
            });

            handlebars.RegisterHelper("Class.QueryAllSpecializations", (context, _) =>
            {
                if (!(context.Value is IClass @class))
                {
                    throw new ArgumentException("The object is supposed to be an IClass");
                }

                var specializations = @class.QueryAllSpecializations()
                    .OrderBy(x => x.Name)
                    .ToList();

                return specializations;
            });
        }
    }
}
