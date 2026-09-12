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
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static List<IPackageableElement> QueryImportedMember(this INamespace @namespace)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
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
