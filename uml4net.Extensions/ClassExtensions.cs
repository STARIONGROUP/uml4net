// -------------------------------------------------------------------------------------------------
//  <copyright file="ClassExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    
    using uml4net.Classification;
    using uml4net.Packages;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// Extension methods for <see cref="IClass"/> interface
    /// </summary>
    public static class ClassExtensions
    {
        /// <summary>
        /// Queries all the properties that are implemented by the class directly or through superclasses
        /// or interface implementations
        /// </summary>
        /// <param name="class">The <see cref="IClass"/> from which to query the properties</param>
        /// <returns>A <see cref="ReadOnlyCollection{T}"/> of <see cref="IProperty"/></returns>
        public static ReadOnlyCollection<IProperty> QueryAllProperties(this IClass @class)
        {
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            var result = new List<IProperty>();

            var superClassifiers = @class.QueryAllGeneralClassifiers();

            foreach (var classifier in superClassifiers)
            {
                if (classifier is IClass c)
                {
                    result.AddRange(c.OwnedAttribute);
                    result.AddRange(c.QueryInterfaces().SelectMany(x => x.Attribute).Distinct());
                }
            }

            return result.Distinct().ToList().AsReadOnly();
        }

        /// <summary>
        /// Queries all the specializations (immediate subclasses) of the <paramref name="@class"/>
        /// </summary>
        /// <param name="class">
        /// The <see cref="IClass"/> for which all the immediate specializations are to be queried
        /// </param>
        /// <returns>
        /// a readonly collection of <see cref="IClass"/>
        /// </returns>
        public static ReadOnlyCollection<IClass> QueryAllSpecializations(this IClass @class)
        {
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            var result = new List<IClass>();

            // first try to get all generalizations from the cache if the cache exists
            // and iterate through these to find the appropriate classes

            if (@class.Cache != null && @class.Cache.Values.Count > 0)
            {
                var allGeneralizations = @class.Cache.Values.OfType<IGeneralization>();

                foreach (var generalization in allGeneralizations)
                {
                    if (generalization.General == @class)
                    {
                        if (generalization.Specific == null && generalization.Owner is IClass owner)
                        {
                            result.Add(owner);

                            continue;
                        }

                        if (generalization.Specific is IClass specific)
                        {
                            result.Add(specific);
                        }
                    }
                }

                return result.Distinct().ToList().AsReadOnly();
            }

            // if the cache does not exist, iterate through all classes in the model,
            // starting at the root package, all nested packages, and import packages

            var root = @class.QueryRootPackage();

            var packages = new List<IPackage>();

            foreach (var package in root.QueryPackages())
            {
                packages.Add(package);

                foreach (var packageImport in package.PackageImport)
                {
                    packages.Add(packageImport.ImportedPackage);
                }
            }

            packages = packages.Distinct().ToList();

            foreach (var package in packages)
            {
                var classes = package.PackagedElement.OfType<IClass>();
                foreach (var c in classes)
                {
                    foreach (var generalization in c.Generalization)
                    {
                        if (generalization.General == @class)
                        {
                            if (generalization.Specific == null && generalization.Owner is IClass owner)
                            {
                                result.Add(owner);

                                continue;
                            }

                            if (generalization.Specific is IClass specific)
                            {
                                result.Add(specific);
                            }
                        }
                    }
                }
            }

            return result.Distinct().ToList().AsReadOnly();
        }
    }
}
