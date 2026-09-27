// -------------------------------------------------------------------------------------------------
// <copyright file="RedefinableElementExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Classification
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.Activities;
    using uml4net.CommonBehavior;
    using uml4net.Deployments;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// The <see cref="RedefinableElementExtensions"/> class provides extensions methods for <see cref="IRedefinableElement"/>
    /// </summary>
    internal static class RedefinableElementExtensions
    {
        /// <summary>
        /// Queries The RedefinableElement that is being redefined by this element.
        /// </summary>
        /// <param name="redefinableElement">
        /// The subject <see cref="IRedefinableElement"/>
        /// </param>
        /// <returns>
        /// The RedefinableElement that is being redefined by this element.
        /// </returns>
        /// <remarks>
        /// Has no OCL body in the metamodel - like <see cref="ClassifierExtensions.QueryFeature"/> and
        /// <see cref="NamespaceExtensions.QueryOwnedMember"/>, it is defined purely by the UML
        /// derived union mechanism. Confirmed against the raw <c>resources/UML/UML.xmi</c>: exactly
        /// 10 properties across 10 interfaces directly subset <c>RedefinableElement-redefinedElement</c>
        /// - <see cref="IActivityEdge.RedefinedEdge"/>, <see cref="IActivityNode.RedefinedNode"/>,
        /// <see cref="IConnector.RedefinedConnector"/>, <see cref="IRegion.ExtendedRegion"/>,
        /// <see cref="ITransition.RedefinedTransition"/>, <see cref="IVertex.RedefinedVertex"/>,
        /// <see cref="IClassifier.RedefinedClassifier"/>, <see cref="IOperation.RedefinedOperation"/>,
        /// <see cref="IProperty.RedefinedProperty"/>, and
        /// <see cref="IRedefinableTemplateSignature.ExtendedSignature"/>. Three more properties contribute
        /// transitively, since a subsetted property is a plain stored list that does not receive the values of
        /// its subsets: <see cref="IInterface.RedefinedInterface"/> and <see cref="IBehavior.RedefinedBehavior"/>
        /// subset <c>Classifier-redefinedClassifier</c>, and <see cref="IPort.RedefinedPort"/> subsets
        /// <c>Property-redefinedProperty</c>. <see cref="IStateMachine.ExtendedStateMachine"/> redefines
        /// <c>Behavior-redefinedBehavior</c>, so a StateMachine is dispatched before a Behavior: reading the
        /// redefined property throws.
        /// </remarks>
        internal static List<IRedefinableElement> QueryRedefinedElement(this IRedefinableElement redefinableElement)
        {
            if (redefinableElement == null)
            {
                throw new ArgumentNullException(nameof(redefinableElement));
            }

            var result = new List<IRedefinableElement>();

            if (redefinableElement is IActivityEdge activityEdge)
            {
                result.AddRange(activityEdge.RedefinedEdge);
            }

            if (redefinableElement is IActivityNode activityNode)
            {
                result.AddRange(activityNode.RedefinedNode);
            }

            if (redefinableElement is IConnector connector)
            {
                result.AddRange(connector.RedefinedConnector);
            }

            if (redefinableElement is IRegion region && region.ExtendedRegion != null)
            {
                result.Add(region.ExtendedRegion);
            }

            if (redefinableElement is ITransition transition && transition.RedefinedTransition != null)
            {
                result.Add(transition.RedefinedTransition);
            }

            if (redefinableElement is IVertex vertex && vertex.RedefinedVertex != null)
            {
                result.Add(vertex.RedefinedVertex);
            }

            if (redefinableElement is IClassifier classifier)
            {
                result.AddRange(classifier.RedefinedClassifier);
            }

            // Interface::redefinedInterface and Behavior::redefinedBehavior subset Classifier::redefinedClassifier, which
            // is a plain stored list that does not receive the values of its subsets
            if (redefinableElement is IInterface @interface)
            {
                result.AddRange(@interface.RedefinedInterface);
            }

            // StateMachine::extendedStateMachine redefines Behavior::redefinedBehavior; reading the redefined property throws
            if (redefinableElement is IStateMachine stateMachine)
            {
                result.AddRange(stateMachine.ExtendedStateMachine);
            }
            else if (redefinableElement is IBehavior behavior)
            {
                result.AddRange(behavior.RedefinedBehavior);
            }

            if (redefinableElement is IOperation operation)
            {
                result.AddRange(operation.RedefinedOperation);
            }

            if (redefinableElement is IProperty property)
            {
                result.AddRange(property.RedefinedProperty);
            }

            // Port::redefinedPort subsets Property::redefinedProperty
            if (redefinableElement is IPort port)
            {
                result.AddRange(port.RedefinedPort);
            }

            if (redefinableElement is IRedefinableTemplateSignature signature)
            {
                result.AddRange(signature.ExtendedSignature);
            }

            return result.Distinct().ToList();
        }

        /// <summary>
        /// Queries The contexts that this element may be redefined from.
        /// </summary>
        /// <param name="redefinableElement">
        /// The subject <see cref="IRedefinableElement"/>
        /// </param>
        /// <returns>
        /// The contexts that this element may be redefined from.
        /// </returns>
        /// <remarks>
        /// Has no OCL body in the metamodel - a plain derived union. Its value is <see cref="IBehavior.Context"/> for a
        /// Behavior (a real traversal, <see cref="BehaviorExtensions.QueryContext"/>, that can skip past intermediate
        /// owners), together with the owning Classifier when the element is held in one of the ten properties that
        /// subset the opposite end <c>A_redefinitionContext_redefinableElement::redefinableElement</c> (see
        /// <see cref="IsRedefinableElementOf"/>). The owner is not a redefinition context for elements owned through
        /// any other property, such as a Reception or an ActivityNode. A Behavior nested through
        /// <c>Class::nestedClassifier</c> has no <c>context</c> (its OCL yields null when <c>nestingClass</c> is set)
        /// but has its nesting Class as redefinition context. This method is
        /// NOT called at all for <c>Vertex</c>/<c>Region</c>/<c>Transition</c> instances - those three
        /// interfaces REDEFINE (not subset) <c>redefinitionContext</c> as a narrower scalar
        /// (<c>IVertex</c>/<c>IRegion</c>/<c>ITransition.RedefinitionContext</c>, from #254/#255/#256),
        /// and every one of their generated concrete classes implements
        /// <c>IRedefinableElement.RedefinitionContext</c> by directly wrapping that narrower scalar in
        /// a list, bypassing this generic dispatch entirely.
        /// </remarks>
        internal static List<IClassifier> QueryRedefinitionContext(this IRedefinableElement redefinableElement)
        {
            if (redefinableElement == null)
            {
                throw new ArgumentNullException(nameof(redefinableElement));
            }

            var result = new List<IClassifier>();

            // Behavior::context subsets redefinitionContext; it is null for a Behavior nested through
            // Class::nestedClassifier, whose nesting Class is contributed below
            if (redefinableElement is IBehavior behavior && behavior.QueryContext() is { } context)
            {
                result.Add(context);
            }

            if (redefinableElement.Owner is IClassifier owner && IsRedefinableElementOf(owner, redefinableElement))
            {
                result.Add(owner);
            }

            return result.Distinct().ToList();
        }

        /// <summary>
        /// Queries whether the <paramref name="redefinableElement"/> is held by the <paramref name="classifier"/> in one of
        /// the properties that subset <c>A_redefinitionContext_redefinableElement::redefinableElement</c>, the opposite of
        /// <c>RedefinableElement::redefinitionContext</c>
        /// </summary>
        /// <param name="classifier">
        /// The <see cref="IClassifier"/> that owns the <paramref name="redefinableElement"/>
        /// </param>
        /// <param name="redefinableElement">
        /// The subject <see cref="IRedefinableElement"/>
        /// </param>
        /// <returns>
        /// true when the <paramref name="classifier"/> is a redefinition context of the <paramref name="redefinableElement"/>
        /// </returns>
        /// <remarks>
        /// The ten subsetting properties, taken from the generated metadata and the uml4net-sage metamodel:
        /// <c>Classifier::attribute</c> (the derived union of the owned attributes of Class, DataType, Interface, Artifact
        /// and Signal), <c>Association::ownedEnd</c> (which does not subset <c>Classifier::attribute</c>), <c>Class::ownedOperation</c>,
        /// <c>DataType::ownedOperation</c>, <c>Interface::ownedOperation</c>, <c>Artifact::ownedOperation</c>,
        /// <c>Class::nestedClassifier</c>, <c>Interface::nestedClassifier</c>, <c>Classifier::ownedTemplateSignature</c>
        /// and <c>StructuredClassifier::ownedConnector</c>. Elements owned through any other property - a Reception, an
        /// ActivityNode or ActivityEdge of an Activity, an ExtensionPoint of a UseCase - have no redefinition context
        /// from their owner.
        /// </remarks>
        private static bool IsRedefinableElementOf(IClassifier classifier, IRedefinableElement redefinableElement)
        {
            switch (redefinableElement)
            {
                case IProperty property:
                    return classifier.Attribute.Contains(property)
                           || (classifier is IExtension extension ? extension.OwnedEnd.Contains(property) : classifier is IAssociation association && association.OwnedEnd.Contains(property));

                case IOperation operation:
                    return (classifier is IClass @class && @class.OwnedOperation.Contains(operation))
                           || (classifier is IDataType dataType && dataType.OwnedOperation.Contains(operation))
                           || (classifier is IInterface @interface && @interface.OwnedOperation.Contains(operation))
                           || (classifier is IArtifact artifact && artifact.OwnedOperation.Contains(operation));

                case IRedefinableTemplateSignature signature:
                    return classifier.OwnedTemplateSignature.Contains(signature);

                case IConnector connector:
                    return classifier is IStructuredClassifier structuredClassifier && structuredClassifier.OwnedConnector.Contains(connector);

                case IClassifier nestedClassifier:
                    return (classifier is IClass nestingClass && nestingClass.NestedClassifier.Contains(nestedClassifier))
                           || (classifier is IInterface nestingInterface && nestingInterface.NestedClassifier.Contains(nestedClassifier));

                default:
                    return false;
            }
        }
    }
}
