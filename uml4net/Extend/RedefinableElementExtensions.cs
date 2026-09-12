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
        /// <see cref="IRedefinableTemplateSignature.ExtendedSignature"/>. None of the contributing
        /// interfaces overlap on the same concrete class, so no narrower-first dispatch ordering is
        /// needed (unlike e.g. <see cref="ClassifierExtensions.QueryFeature"/>'s Class/StructuredClassifier
        /// pair).
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

            if (redefinableElement is IOperation operation)
            {
                result.AddRange(operation.RedefinedOperation);
            }

            if (redefinableElement is IProperty property)
            {
                result.AddRange(property.RedefinedProperty);
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
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        internal static List<IClassifier> QueryRedefinitionContext(this IRedefinableElement redefinableElement)
        {
            throw new NotSupportedException("Create a GitHub issue when this method is required");
        }
    }
}
