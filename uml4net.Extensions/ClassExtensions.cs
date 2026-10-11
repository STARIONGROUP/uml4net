// -------------------------------------------------------------------------------------------------
// <copyright file="ClassExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using uml4net.Classification;
    using uml4net.CommonStructure;
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
        /// <remarks>
        /// The interface implementations are the interfaces realized by the class or its general classes (see
        /// <see cref="ElementExtensions.QueryInterfaces"/>); <see cref="QueryAllOperations"/> includes them as well.
        /// </remarks>
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
        /// Queries all the properties of the <see cref="IClass"/>, including the inherited ones, in the order that Canonical
        /// XMI prescribes (XMI 2.5.1 Annex B.5.2)
        /// </summary>
        /// <param name="class">
        /// The subject <see cref="IClass"/>
        /// </param>
        /// <returns>
        /// The properties ordered by the class in which they are defined: the properties of a superclass before those of
        /// its subclasses, those of the alphabetically earlier direct superclass first when a class has several, each class
        /// in declaration order. A redefining property takes the position of the property that it redefines
        /// </returns>
        public static ReadOnlyCollection<IProperty> QueryAllPropertiesInCanonicalOrder(this IClass @class)
        {
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            var orderedClassifiers = new List<IClassifier>();
            QueryCanonicalClassifierOrder(@class, orderedClassifiers, []);

            var result = new List<IProperty>();

            foreach (var classifier in orderedClassifiers)
            {
                if (!(classifier is IClass c))
                {
                    continue;
                }

                foreach (var property in c.OwnedAttribute.Concat(c.QueryInterfaces().SelectMany(x => x.Attribute)))
                {
                    if (result.Contains(property))
                    {
                        continue;
                    }

                    // B.5.2: "if a property is redefined in a subclass, its position in the order remains the position of
                    // the original redefined property within the parent class"
                    var redefinedIndex = result.FindIndex(x => property.RedefinedProperty.Contains(x));

                    if (redefinedIndex >= 0)
                    {
                        result.Insert(redefinedIndex + 1, property);
                    }
                    else
                    {
                        result.Add(property);
                    }
                }
            }

            return result.AsReadOnly();
        }

        /// <summary>
        /// Adds the general classifiers of the provided classifier, alphabetically by name, and then the classifier itself,
        /// to the ordered list
        /// </summary>
        /// <param name="classifier">
        /// The <see cref="IClassifier"/> that is visited
        /// </param>
        /// <param name="orderedClassifiers">
        /// The classifiers, superclass first
        /// </param>
        /// <param name="visitedClassifiers">
        /// The classifiers that have been visited, to visit each one once
        /// </param>
        private static void QueryCanonicalClassifierOrder(IClassifier classifier, List<IClassifier> orderedClassifiers, HashSet<IClassifier> visitedClassifiers)
        {
            if (!visitedClassifiers.Add(classifier))
            {
                return;
            }

            foreach (var general in classifier.Generalization.Select(x => x.General).Where(x => x != null).OrderBy(x => x.Name, StringComparer.Ordinal))
            {
                QueryCanonicalClassifierOrder(general, orderedClassifiers, visitedClassifiers);
            }

            orderedClassifiers.Add(classifier);
        }

        /// <summary>
        /// Queries all the specializations (immediate subclasses) of the <paramref name="class"/>
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

            if (root == null)
            {
                return result.AsReadOnly();
            }

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

            // every class owned by the packages, also those nested in a Class or an Interface, packaged in a
            // Component or owned as a Behavior, as the cache path above sees every Generalization
            foreach (var c in packages.QueryOwnedClassifiers().OfType<IClass>())
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

            return result.Distinct().ToList().AsReadOnly();
        }

        /// <summary>
        /// Queries all descendant specializations (subclasses at all levels) of the <paramref name="class"/>
        /// </summary>
        /// <param name="class">
        /// The <see cref="IClass"/> for which all descendant specializations are to be queried
        /// </param>
        /// <returns>
        /// a readonly collection of <see cref="IClass"/> containing all descendants at all levels
        /// </returns>
        public static ReadOnlyCollection<IClass> QueryAllDescendantSpecializations(this IClass @class)
        {
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            var result = new List<IClass>();

            QueryAllDescendantSpecializationsRecursive(@class, result);

            return result.Distinct().ToList().AsReadOnly();
        }

        /// <summary>
        /// Recursively collects all descendant specializations
        /// </summary>
        /// <param name="class">
        /// The <see cref="IClass"/> for which to collect descendants
        /// </param>
        /// <param name="result">
        /// The accumulator list of <see cref="IClass"/>
        /// </param>
        private static void QueryAllDescendantSpecializationsRecursive(IClass @class, List<IClass> result)
        {
            var immediateSpecializations = @class.QueryAllSpecializations();

            foreach (var specialization in immediateSpecializations)
            {
                if (!result.Contains(specialization))
                {
                    result.Add(specialization);
                    QueryAllDescendantSpecializationsRecursive(specialization, result);
                }
            }
        }

        /// <summary>
        /// Returns the complete set of <see cref="IConstraint"/>>s that apply to the specified
        /// <see cref="IClass"/>, including constraints owned by the class itself
        /// and all constraints inherited from its general classifiers.
        /// </summary>
        /// <param name="class">
        /// The <see cref="IClass"/> for which all applicable constraints are queried.
        /// </param>
        /// <returns>
        /// A read-only collection of <see cref="IConstraint"/> instances representing
        /// the effective constraint set of the class. The returned collection contains
        /// constraints owned by the class and all constraints inherited through the
        /// generalization hierarchy, with duplicates removed.
        /// </returns>
        /// <remarks>
        /// The returned <see cref="IConstraint"/> instances are ordered by name. The constraints of a classifier are its
        /// <c>Namespace::ownedRule</c> and the constraints held in the properties that subset it, such as the
        /// <c>precondition</c> and <c>postcondition</c> of a Behavior, which is a Class; they are the Constraints among
        /// its <c>Namespace::ownedMember</c>.
        /// </remarks>
        public static ReadOnlyCollection<IConstraint> QueryAllConstraints(this IClass @class)
        {
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            var superClassifiers = @class.QueryAllGeneralClassifiers();

            // ownedRule is a plain stored list that does not receive the values of its subsets; ownedMember includes them
            var result = superClassifiers.SelectMany(x => x.OwnedMember.OfType<IConstraint>());

            return result.Distinct().OrderBy(x => x.Name) .ToList().AsReadOnly();
        }

        /// <summary>
        /// Returns the complete set of operations that apply to the specified
        /// <see cref="IClass"/>, including operations owned by the class itself,
        /// all operations inherited from its general classifiers and the operations of the
        /// interfaces that the class or its general classes realize.
        /// </summary>
        /// <param name="class">
        /// The <see cref="IClass"/> for which all applicable operations are queried.
        /// </param>
        /// <returns>
        /// A read-only collection of <see cref="IOperation"/> instances representing
        /// the effective operation set of the class. The returned collection contains
        /// operations owned by the class, all operations inherited through the
        /// generalization hierarchy and the operations of the realized interfaces
        /// (see <see cref="ElementExtensions.QueryInterfaces"/>), with duplicates removed.
        /// </returns>
        /// <remarks>
        /// The returned <see cref="IOperation"/> instances are ordered by name. The realized interfaces are
        /// included as they are by <see cref="QueryAllProperties"/>, so that both describe the same set of classifiers.
        /// </remarks>
        public static ReadOnlyCollection<IOperation> QueryAllOperations(this IClass @class)
        {
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            var result = new List<IOperation>();

            foreach (var c in @class.QueryAllGeneralClassifiers().OfType<IClass>())
            {
                result.AddRange(c.OwnedOperation);
                result.AddRange(c.QueryInterfaces().SelectMany(x => x.OwnedOperation));
            }

            return result.Distinct().OrderBy(x => x.Name).ToList().AsReadOnly();
        }

        /// <summary>
        /// Queries all the properties of the <see cref="IClass"/>, including the inherited ones, that are not derived
        /// </summary>
        /// <param name="class">
        /// The <see cref="IClass"/> from which to query the properties
        /// </param>
        /// <returns>
        /// The properties of <see cref="QueryAllProperties"/> for which <c>Property::isDerived</c> is false, in the
        /// same order
        /// </returns>
        public static ReadOnlyCollection<IProperty> QueryAllNonDerivedProperties(this IClass @class)
        {
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            return @class.QueryAllProperties()
                .Where(x => !x.IsDerived)
                .ToList()
                .AsReadOnly();
        }

        /// <summary>
        /// Queries all the properties of the <see cref="IClass"/>, including the inherited ones, that are not derived
        /// and that are not redefined in the context of the <see cref="IClass"/>
        /// </summary>
        /// <param name="class">
        /// The <see cref="IClass"/> from which to query the properties
        /// </param>
        /// <returns>
        /// The properties of <see cref="QueryAllNonDerivedProperties"/> for which
        /// <see cref="PropertyExtensions.TryQueryRedefinedByProperty"/> finds no redefining property in the
        /// <paramref name="class"/>, in the same order
        /// </returns>
        public static ReadOnlyCollection<IProperty> QueryAllNonDerivedNonRedefinedProperties(this IClass @class)
        {
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            return @class.QueryAllNonDerivedProperties()
                .Where(x => !x.TryQueryRedefinedByProperty(@class, out _))
                .ToList()
                .AsReadOnly();
        }

        /// <summary>
        /// Queries whether the <see cref="IClass"/> is a direct or indirect subclass of the <paramref name="superClass"/>
        /// </summary>
        /// <param name="class">
        /// The subject <see cref="IClass"/>
        /// </param>
        /// <param name="superClass">
        /// The <see cref="IClass"/> that is expected to be a direct or indirect general class
        /// </param>
        /// <returns>
        /// true when the <paramref name="superClass"/> is one of the direct or indirect general classifiers of the
        /// <paramref name="class"/>, false otherwise. A class is not a subclass of itself; use
        /// <see cref="ClassifierExtensions.QueryConformsTo"/> for the test that includes the class itself.
        /// </returns>
        public static bool QueryIsSubclassOf(this IClass @class, IClass superClass)
        {
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            if (superClass == null)
            {
                throw new ArgumentNullException(nameof(superClass));
            }

            return !ReferenceEquals(@class, superClass) && @class.QueryAllGeneralClassifiers().Contains(superClass);
        }

        /// <summary>
        /// Queries whether the <see cref="IClass"/> is a direct or indirect subclass of a class with the specified name
        /// </summary>
        /// <param name="class">
        /// The subject <see cref="IClass"/>
        /// </param>
        /// <param name="superClassName">
        /// The name of the <see cref="IClass"/> that is expected to be a direct or indirect general class
        /// </param>
        /// <returns>
        /// true when one of the direct or indirect general classes of the <paramref name="class"/> has the
        /// <paramref name="superClassName"/> as name, false otherwise. The <paramref name="class"/> itself is not
        /// taken into account.
        /// </returns>
        /// <remarks>
        /// The comparison is on the name only, it is case-sensitive and does not take the package into account. Two
        /// classes that have the same name in different packages are not told apart; use the overload that takes an
        /// <see cref="IClass"/> when that matters.
        /// </remarks>
        public static bool QueryIsSubclassOf(this IClass @class, string superClassName)
        {
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            if (string.IsNullOrWhiteSpace(superClassName))
            {
                throw new ArgumentException("The name of the super class may not be null or empty", nameof(superClassName));
            }

            return @class.QueryAllGeneralClassifiers()
                .OfType<IClass>()
                .Any(x => !ReferenceEquals(x, @class) && x.Name == superClassName);
        }

        /// <summary>
        /// Queries the properties in the model that refer to the <see cref="IClass"/>: the properties that have the
        /// <see cref="IClass"/> as type
        /// </summary>
        /// <param name="class">
        /// The subject <see cref="IClass"/>
        /// </param>
        /// <returns>
        /// The owned attributes that are typed by the <paramref name="class"/>, of the classes that are packaged
        /// elements of the root package of the <paramref name="class"/>, of its nested packages and of the packages
        /// that these import (see <see cref="PackageExtensions.QueryAllNestedAndImportedPackages"/>). An empty
        /// collection when the <paramref name="class"/> has no root package.
        /// </returns>
        /// <remarks>
        /// Only the owned attributes of classes that are directly contained by a package are searched. An association
        /// end that is owned by the association, and an attribute of a nested class, an interface or a data type, are
        /// not returned.
        /// </remarks>
        public static ReadOnlyCollection<IProperty> QueryReferencingProperties(this IClass @class)
        {
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            var rootPackage = @class.QueryRootPackage();

            if (rootPackage == null)
            {
                return new List<IProperty>().AsReadOnly();
            }

            return rootPackage.QueryAllNestedAndImportedPackages()
                .SelectMany(x => x.PackagedElement.OfType<IClass>())
                .SelectMany(x => x.OwnedAttribute)
                .Where(x => ReferenceEquals(x.Type, @class))
                .Distinct()
                .ToList()
                .AsReadOnly();
        }

        /// <summary>
        /// Queries the owned attributes of the <see cref="IClass"/> that take part in a many-to-many relationship
        /// </summary>
        /// <param name="class">
        /// The subject <see cref="IClass"/>
        /// </param>
        /// <returns>
        /// The owned attributes for which <see cref="PropertyExtensions.QueryIsMemberOfManyToMany"/> is true, ordered
        /// by name
        /// </returns>
        public static ReadOnlyCollection<IProperty> QueryOwnedManyToManyProperties(this IClass @class)
        {
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            return @class.OwnedAttribute
                .Where(x => x.QueryIsMemberOfManyToMany())
                .OrderBy(x => x.Name, StringComparer.Ordinal)
                .Distinct()
                .ToList()
                .AsReadOnly();
        }
    }
}
