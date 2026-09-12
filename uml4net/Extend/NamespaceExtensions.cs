// -------------------------------------------------------------------------------------------------
// <copyright file="NamespaceExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.CommonStructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.Activities;
    using uml4net.Actions;
    using uml4net.Classification;
    using uml4net.CommonBehavior;
    using uml4net.Deployments;
    using uml4net.Interactions;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;

    /// <summary>
    /// The <see cref="NamespaceExtensions"/> class provides extensions methods for <see cref="INamespace"/>
    /// </summary>
    internal static class NamespaceExtensions
    {
        /// <summary>
        /// Queries the PackageableElements that are members of this Namespace as a result of either
        /// PackageImports or ElementImports.
        /// </summary>
        /// <param name="namespace">
        /// The subject <see cref="INamespace"/>
        /// </param>
        /// <returns>
        /// the PackageableElements that are members of this Namespace as a result of either
        /// PackageImports or ElementImports.
        /// </returns>
        internal static List<IPackageableElement> QueryImportedMember(this INamespace @namespace)
        {
            if (@namespace == null)
            {
                throw new ArgumentNullException(nameof(@namespace));
            }

            var candidates = @namespace.ElementImport
                .Select(elementImport => elementImport.ImportedElement)
                .Concat(@namespace.PackageImport.SelectMany(packageImport => packageImport.ImportedPackage.QueryVisibleMembers()))
                .Distinct()
                .ToList();

            return @namespace.QueryImportMembers(candidates);
        }

        /// <summary>
        /// Queries the names that a NamedElement would have in this Namespace, whether it is an
        /// owned member, a member imported via an <see cref="IElementImport"/>, or a member imported
        /// via a public <see cref="IPackageImport"/>.
        /// </summary>
        /// <param name="namespace">
        /// The subject <see cref="INamespace"/>
        /// </param>
        /// <param name="element">
        /// the <see cref="INamedElement"/> whose names are queried
        /// </param>
        /// <returns>
        /// the names, if any, under which <paramref name="element"/> is known in this Namespace.
        /// </returns>
        internal static List<string> QueryGetNamesOfMember(this INamespace @namespace, INamedElement element)
        {
            if (@namespace == null)
            {
                throw new ArgumentNullException(nameof(@namespace));
            }

            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (@namespace.OwnedMember.Contains(element))
            {
                return new List<string> { element.Name };
            }

            var elementImports = @namespace.ElementImport.Where(elementImport => Equals(elementImport.ImportedElement, element)).ToList();

            if (elementImports.Count > 0)
            {
                return elementImports.Select(elementImport => elementImport.QueryGetName()).Distinct().ToList();
            }

            return @namespace.PackageImport
                .Where(packageImport => packageImport.ImportedPackage.QueryVisibleMembers().Any(member => Equals(member, element)))
                .SelectMany(packageImport => packageImport.ImportedPackage.QueryGetNamesOfMember(element))
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Queries which of the provided PackageableElements would not be distinguishable from each
        /// other if all were imported into this Namespace, excluding them from the result.
        /// </summary>
        /// <param name="namespace">
        /// The subject <see cref="INamespace"/>
        /// </param>
        /// <param name="imps">
        /// the candidate <see cref="IPackageableElement"/>s to check for collisions
        /// </param>
        /// <returns>
        /// the subset of <paramref name="imps"/> that are pairwise distinguishable from every other
        /// element of <paramref name="imps"/> within this Namespace.
        /// </returns>
        /// <remarks>
        /// The metamodel's own OCL for this operation (verified against the raw
        /// <c>resources/UML/UML.xmi</c>) is missing a guard against comparing a candidate to itself:
        /// <c>imps->reject(imp1 | imps->exists(imp2 | not imp1.isDistinguishableFrom(imp2, self)))</c>.
        /// For any candidate already registered in this Namespace (e.g. as the <c>ImportedElement</c>
        /// of one of its own <see cref="IElementImport"/>s - the normal case, since real callers such
        /// as <c>Namespace.ImportedMember</c> always pass candidates drawn from
        /// <c>elementImport.importedElement</c>), <c>isDistinguishableFrom(x, x, self)</c> evaluates
        /// to <c>false</c> (its own non-empty name set trivially intersects itself), so the literal
        /// OCL would reject every such candidate outright, even a single one with no real collision.
        /// This implementation adds the evidently-intended <c>imp2 &lt;&gt; imp1</c> guard implied by
        /// the operation's own documentation ("excludes ... any that would not be distinguishable
        /// from <i>each other</i>").
        /// </remarks>
        internal static List<IPackageableElement> QueryExcludeCollisions(this INamespace @namespace, IEnumerable<IPackageableElement> imps)
        {
            if (@namespace == null)
            {
                throw new ArgumentNullException(nameof(@namespace));
            }

            if (imps == null)
            {
                throw new ArgumentNullException(nameof(imps));
            }

            var candidates = imps.ToList();

            return candidates
                .Where(imp1 => !candidates.Any(imp2 => !ReferenceEquals(imp1, imp2) && !imp1.QueryIsDistinguishableFrom(imp2, @namespace)))
                .ToList();
        }

        /// <summary>
        /// Queries which of the provided PackageableElements are actually imported into this
        /// Namespace: those that do not collide with each other (<see cref="QueryExcludeCollisions"/>)
        /// and that are distinguishable from every one of this Namespace's own owned members.
        /// </summary>
        /// <param name="namespace">
        /// The subject <see cref="INamespace"/>
        /// </param>
        /// <param name="imps">
        /// the candidate <see cref="IPackageableElement"/>s to import
        /// </param>
        /// <returns>
        /// the subset of <paramref name="imps"/> that would actually be imported into this Namespace.
        /// </returns>
        internal static List<IPackageableElement> QueryImportMembers(this INamespace @namespace, IEnumerable<IPackageableElement> imps)
        {
            if (@namespace == null)
            {
                throw new ArgumentNullException(nameof(@namespace));
            }

            if (imps == null)
            {
                throw new ArgumentNullException(nameof(imps));
            }

            return @namespace.QueryExcludeCollisions(imps)
                .Where(imp => @namespace.OwnedMember.All(member => imp.QueryIsDistinguishableFrom(member, @namespace)))
                .ToList();
        }

        /// <summary>
        /// Queries a collection of NamedElements owned by the Namespace.
        /// </summary>
        /// <param name="namespace">
        /// The subject <see cref="INamespace"/>
        /// </param>
        /// <returns>
        /// a collection of NamedElements owned by the Namespace.
        /// </returns>
        /// <remarks>
        /// Has no OCL body in the metamodel - like <see cref="ElementExtensions.QueryAllInstancesInModel"/>'s
        /// sibling case <c>Element::/ownedElement</c>, it is defined purely by the UML derived union
        /// mechanism: its value is the union of every property, anywhere in the metamodel, that
        /// subsets <c>Namespace-ownedMember</c>. Two pairs of these subsetting properties are
        /// themselves in a redefinition relationship (<see cref="IClass.OwnedAttribute"/> redefines
        /// <see cref="IStructuredClassifier.OwnedAttribute"/>, <see cref="IOperation.OwnedParameter"/>
        /// redefines <see cref="IBehavioralFeature.OwnedParameter"/>, and
        /// <see cref="IExtension.OwnedEnd"/> redefines <see cref="IAssociation.OwnedEnd"/>) - those are
        /// dispatched narrowest-first to avoid the "Redefined by property" guard the redefined
        /// (wider) property throws when accessed directly.
        /// </remarks>
        internal static List<INamedElement> QueryOwnedMember(this INamespace @namespace)
        {
            if (@namespace == null)
            {
                throw new ArgumentNullException(nameof(@namespace));
            }

            var result = new List<INamedElement>();

            result.AddRange(@namespace.OwnedRule);

            if (@namespace is IActivity activity)
            {
                result.AddRange(activity.Variable);
            }

            if (@namespace is IArtifact artifact)
            {
                result.AddRange(artifact.NestedArtifact);
                result.AddRange(artifact.OwnedAttribute);
                result.AddRange(artifact.OwnedOperation);
            }

            if (@namespace is IExtension extension)
            {
                result.AddRange(extension.OwnedEnd);
            }
            else if (@namespace is IAssociation association)
            {
                result.AddRange(association.OwnedEnd);
            }

            if (@namespace is IBehavior behavior)
            {
                result.AddRange(behavior.OwnedParameter);
                result.AddRange(behavior.OwnedParameterSet);
            }

            if (@namespace is IOperation operation)
            {
                result.AddRange(operation.OwnedParameter);
            }
            else if (@namespace is IBehavioralFeature behavioralFeature)
            {
                result.AddRange(behavioralFeature.OwnedParameter);
            }

            if (@namespace is IBehavioralFeature behavioralFeatureForParameterSet)
            {
                result.AddRange(behavioralFeatureForParameterSet.OwnedParameterSet);
            }

            if (@namespace is IBehavioredClassifier behavioredClassifier)
            {
                result.AddRange(behavioredClassifier.OwnedBehavior);
            }

            if (@namespace is IClass @class)
            {
                result.AddRange(@class.NestedClassifier);
                result.AddRange(@class.OwnedAttribute);
                result.AddRange(@class.OwnedOperation);
                result.AddRange(@class.OwnedReception);
            }
            else if (@namespace is IStructuredClassifier structuredClassifier)
            {
                result.AddRange(structuredClassifier.OwnedAttribute);
            }

            if (@namespace is IStructuredClassifier structuredClassifierForConnector)
            {
                result.AddRange(structuredClassifierForConnector.OwnedConnector);
            }

            if (@namespace is IClassifier classifier)
            {
                result.AddRange(classifier.OwnedUseCase);
            }

            if (@namespace is IComponent component)
            {
                result.AddRange(component.PackagedElement);
            }

            if (@namespace is IDataType dataType)
            {
                result.AddRange(dataType.OwnedAttribute);
                result.AddRange(dataType.OwnedOperation);
            }

            if (@namespace is IEnumeration enumeration)
            {
                result.AddRange(enumeration.OwnedLiteral);
            }

            if (@namespace is IInteraction interaction)
            {
                result.AddRange(interaction.FormalGate);
                result.AddRange(interaction.Fragment);
                result.AddRange(interaction.Lifeline);
                result.AddRange(interaction.Message);
            }

            if (@namespace is IInteractionOperand interactionOperand)
            {
                result.AddRange(interactionOperand.Fragment);
            }

            if (@namespace is IInterface @interface)
            {
                result.AddRange(@interface.NestedClassifier);
                result.AddRange(@interface.OwnedAttribute);
                result.AddRange(@interface.OwnedOperation);
                result.AddRange(@interface.OwnedReception);
                result.AddRange(@interface.Protocol);
            }

            if (@namespace is INode node)
            {
                result.AddRange(node.NestedNode);
            }

            if (@namespace is IPackage package)
            {
                result.AddRange(package.PackagedElement);
            }

            if (@namespace is IRegion region)
            {
                result.AddRange(region.Subvertex);
                result.AddRange(region.Transition);
            }

            if (@namespace is ISignal signal)
            {
                result.AddRange(signal.OwnedAttribute);
            }

            if (@namespace is IState state)
            {
                result.AddRange(state.Connection);
                result.AddRange(state.ConnectionPoint);
                result.AddRange(state.Region);
            }

            if (@namespace is IStateMachine stateMachine)
            {
                result.AddRange(stateMachine.ConnectionPoint);
                result.AddRange(stateMachine.Region);
            }

            if (@namespace is IStructuredActivityNode structuredActivityNode)
            {
                result.AddRange(structuredActivityNode.Variable);
            }

            if (@namespace is IUseCase useCase)
            {
                result.AddRange(useCase.Extend);
                result.AddRange(useCase.ExtensionPoint);
                result.AddRange(useCase.Include);
            }

            return result.Distinct().ToList();
        }
    }
}
