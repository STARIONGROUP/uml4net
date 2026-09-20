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
        /// Has no OCL body in the metamodel - a plain derived union. Confirmed against the raw
        /// <c>resources/UML/UML.xmi</c> that every direct subsetter of
        /// <c>RedefinableElement-redefinitionContext</c> is the opposite end of a composite ownership
        /// relationship (e.g. <c>Operation.Class</c>/<c>DataType</c>/<c>Interface</c>,
        /// <c>Property.OwningAssociation</c>, <c>Connector</c>'s owning <c>StructuredClassifier</c>, a
        /// nested <c>Class</c>/<c>Interface</c>'s nesting classifier, <c>RedefinableTemplateSignature.
        /// Classifier</c>) - EXCEPT <see cref="IBehavior.Context"/>, which is a real traversal
        /// (<see cref="BehaviorExtensions.QueryContext"/>) that can skip past intermediate owners, so
        /// it must be special-cased ahead of the generic <see cref="IElement.Owner"/> fallback (an
        /// <see cref="IBehavior"/> is also an <see cref="StructuredClassifiers.IClass"/>, so without
        /// this the generic fallback would silently apply and return the wrong answer). This method is
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

            if (redefinableElement is IBehavior behavior)
            {
                var context = behavior.QueryContext();

                return context == null ? new List<IClassifier>() : new List<IClassifier> { context };
            }

            if (redefinableElement.Owner is IClassifier owner)
            {
                return new List<IClassifier> { owner };
            }

            return new List<IClassifier>();
        }
    }
}
