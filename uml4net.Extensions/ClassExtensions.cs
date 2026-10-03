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
        /// Queries all the properties of the <see cref="IClass"/>, including the inherited ones, superclass first: grouped
        /// by the classifier that declares them, a general classifier before its specializations, each one in declaration order
        /// </summary>
        /// <param name="class">
        /// The subject <see cref="IClass"/>
        /// </param>
        /// <returns>
        /// The same properties as <see cref="QueryAllProperties"/>, in the order in which the OMG normative XMI documents
        /// serialize them (the MOF tag <c>org.omg.xmi.superClassFirst</c>)
        /// </returns>
        /// <remarks>
        /// The classifiers are ordered by a depth-first traversal of the generalizations, in the order in which they are
        /// declared, a classifier following all of its generals
        /// </remarks>
        public static ReadOnlyCollection<IProperty> QueryAllPropertiesSuperClassFirst(this IClass @class)
        {
            if (@class == null)
            {
                throw new ArgumentNullException(nameof(@class));
            }

            var orderedClassifiers = new List<IClassifier>();
            QuerySuperClassFirst(@class, orderedClassifiers, []);

            var result = new List<IProperty>();

            foreach (var classifier in orderedClassifiers)
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
        /// Adds the general classifiers of the provided classifier, and then the classifier itself, to the ordered list
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
        private static void QuerySuperClassFirst(IClassifier classifier, List<IClassifier> orderedClassifiers, HashSet<IClassifier> visitedClassifiers)
        {
            if (!visitedClassifiers.Add(classifier))
            {
                return;
            }

            foreach (var general in classifier.Generalization.Select(x => x.General).Where(x => x != null))
            {
                QuerySuperClassFirst(general, orderedClassifiers, visitedClassifiers);
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
    }
}
