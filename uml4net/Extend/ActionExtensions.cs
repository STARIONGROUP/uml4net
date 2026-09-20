// -------------------------------------------------------------------------------------------------
// <copyright file="ActionExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Actions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.Classification;

    /// <summary>
    /// The <see cref="ActionExtensions"/> class provides extensions methods for <see cref="IAction"/>
    /// </summary>
    internal static class ActionExtensions
    {
        /// <summary>
        /// Queries the context Classifier of the Behavior that contains this Action, or the Behavior itself if it has
        /// no context.
        /// </summary>
        /// <param name="action">
        /// The subject <see cref="IAction"/>
        /// </param>
        /// <returns>
        /// a <see cref="IClassifier"/>
        /// </returns>
        internal static IClassifier QueryContext(this IAction action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (action.InStructuredNode != null)
            {
                return action.InStructuredNode.Context;
            }

            var activity = action is IStructuredActivityNode structuredActivityNode ? structuredActivityNode.Activity : action.Activity;

            if (activity != null)
            {
                return activity.Context;
            }

            return null;
        }

        /// <summary>
        /// Queries the ordered set of InputPins representing the inputs to the Action.
        /// </summary>
        /// <param name="action">
        /// The subject <see cref="IAction"/>
        /// </param>
        /// <returns>
        /// The ordered set of InputPins representing the inputs to the Action.
        /// </returns>
        /// <remarks>
        /// Has no OCL body in the metamodel - a derived union of the 28 properties that subset <c>Action-input</c>.
        /// Each is read through the interface that declares it, so that a property that redefines a subsetting
        /// property is included as well: <c>SendObjectAction::request</c> redefines <c>InvocationAction::argument</c>
        /// and <c>LoopNode::loopVariableInput</c> redefines <c>StructuredActivityNode::structuredNodeInput</c>, and the
        /// generated classes forward the redefined member to the redefining property.
        /// </remarks>
        internal static List<IInputPin> QueryInput(this IAction action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var result = new List<IInputPin>();

            if (action is IAddStructuralFeatureValueAction addStructuralFeatureValueAction)
            {
                result.AddRange(addStructuralFeatureValueAction.InsertAt);
            }

            if (action is IAddVariableValueAction addVariableValueAction)
            {
                result.AddRange(addVariableValueAction.InsertAt);
            }

            if (action is ICallOperationAction callOperationAction)
            {
                result.AddRange(callOperationAction.Target);
            }

            if (action is IClearAssociationAction clearAssociationAction)
            {
                result.AddRange(clearAssociationAction.Object);
            }

            if (action is IDestroyObjectAction destroyObjectAction)
            {
                result.AddRange(destroyObjectAction.Target);
            }

            if (action is IInvocationAction invocationAction)
            {
                result.AddRange(invocationAction.Argument);
            }

            if (action is ILinkAction linkAction)
            {
                result.AddRange(linkAction.InputValue);
            }

            if (action is IOpaqueAction opaqueAction)
            {
                result.AddRange(opaqueAction.InputValue);
            }

            if (action is IRaiseExceptionAction raiseExceptionAction)
            {
                result.AddRange(raiseExceptionAction.Exception);
            }

            if (action is IReadIsClassifiedObjectAction readIsClassifiedObjectAction)
            {
                result.AddRange(readIsClassifiedObjectAction.Object);
            }

            if (action is IReadLinkObjectEndAction readLinkObjectEndAction)
            {
                result.AddRange(readLinkObjectEndAction.Object);
            }

            if (action is IReadLinkObjectEndQualifierAction readLinkObjectEndQualifierAction)
            {
                result.AddRange(readLinkObjectEndQualifierAction.Object);
            }

            if (action is IReclassifyObjectAction reclassifyObjectAction)
            {
                result.AddRange(reclassifyObjectAction.Object);
            }

            if (action is IReduceAction reduceAction)
            {
                result.AddRange(reduceAction.Collection);
            }

            if (action is IRemoveStructuralFeatureValueAction removeStructuralFeatureValueAction)
            {
                result.AddRange(removeStructuralFeatureValueAction.RemoveAt);
            }

            if (action is IRemoveVariableValueAction removeVariableValueAction)
            {
                result.AddRange(removeVariableValueAction.RemoveAt);
            }

            if (action is IReplyAction replyAction)
            {
                result.AddRange(replyAction.ReturnInformation);
            }

            if (action is ISendObjectAction sendObjectAction)
            {
                result.AddRange(sendObjectAction.Target);
            }

            if (action is ISendSignalAction sendSignalAction)
            {
                result.AddRange(sendSignalAction.Target);
            }

            if (action is IStartClassifierBehaviorAction startClassifierBehaviorAction)
            {
                result.AddRange(startClassifierBehaviorAction.Object);
            }

            if (action is IStartObjectBehaviorAction startObjectBehaviorAction)
            {
                result.AddRange(startObjectBehaviorAction.Object);
            }

            if (action is IStructuralFeatureAction structuralFeatureAction)
            {
                result.AddRange(structuralFeatureAction.Object);
            }

            if (action is IStructuredActivityNode structuredActivityNode)
            {
                result.AddRange(structuredActivityNode.StructuredNodeInput);
            }

            if (action is ITestIdentityAction testIdentityAction)
            {
                result.AddRange(testIdentityAction.First);
                result.AddRange(testIdentityAction.Second);
            }

            if (action is IUnmarshallAction unmarshallAction)
            {
                result.AddRange(unmarshallAction.Object);
            }

            if (action is IWriteStructuralFeatureAction writeStructuralFeatureAction)
            {
                result.AddRange(writeStructuralFeatureAction.Value);
            }

            if (action is IWriteVariableAction writeVariableAction)
            {
                result.AddRange(writeVariableAction.Value);
            }

            return result.Distinct().ToList();
        }

        /// <summary>
        /// Queries the ordered set of OutputPins representing outputs from the Action.
        /// </summary>
        /// <param name="action">
        /// The subject <see cref="IAction"/>
        /// </param>
        /// <returns>
        /// The ordered set of OutputPins representing outputs from the Action.
        /// </returns>
        /// <remarks>
        /// Has no OCL body in the metamodel - a derived union of the 21 properties that subset <c>Action-output</c>.
        /// Each is read through the interface that declares it, so that <c>LoopNode::result</c> and
        /// <c>ConditionalNode::result</c>, which redefine <c>StructuredActivityNode::structuredNodeOutput</c>, are
        /// included: the generated classes forward the redefined member to the redefining property.
        /// </remarks>
        internal static List<IOutputPin> QueryOutput(this IAction action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var result = new List<IOutputPin>();

            if (action is IAcceptCallAction acceptCallAction)
            {
                result.AddRange(acceptCallAction.ReturnInformation);
            }

            if (action is IAcceptEventAction acceptEventAction)
            {
                result.AddRange(acceptEventAction.Result);
            }

            if (action is ICallAction callAction)
            {
                result.AddRange(callAction.Result);
            }

            if (action is IClearStructuralFeatureAction clearStructuralFeatureAction)
            {
                result.AddRange(clearStructuralFeatureAction.Result);
            }

            if (action is ICreateLinkObjectAction createLinkObjectAction)
            {
                result.AddRange(createLinkObjectAction.Result);
            }

            if (action is ICreateObjectAction createObjectAction)
            {
                result.AddRange(createObjectAction.Result);
            }

            if (action is IOpaqueAction opaqueAction)
            {
                result.AddRange(opaqueAction.OutputValue);
            }

            if (action is IReadExtentAction readExtentAction)
            {
                result.AddRange(readExtentAction.Result);
            }

            if (action is IReadIsClassifiedObjectAction readIsClassifiedObjectAction)
            {
                result.AddRange(readIsClassifiedObjectAction.Result);
            }

            if (action is IReadLinkAction readLinkAction)
            {
                result.AddRange(readLinkAction.Result);
            }

            if (action is IReadLinkObjectEndAction readLinkObjectEndAction)
            {
                result.AddRange(readLinkObjectEndAction.Result);
            }

            if (action is IReadLinkObjectEndQualifierAction readLinkObjectEndQualifierAction)
            {
                result.AddRange(readLinkObjectEndQualifierAction.Result);
            }

            if (action is IReadSelfAction readSelfAction)
            {
                result.AddRange(readSelfAction.Result);
            }

            if (action is IReadStructuralFeatureAction readStructuralFeatureAction)
            {
                result.AddRange(readStructuralFeatureAction.Result);
            }

            if (action is IReadVariableAction readVariableAction)
            {
                result.AddRange(readVariableAction.Result);
            }

            if (action is IReduceAction reduceAction)
            {
                result.AddRange(reduceAction.Result);
            }

            if (action is IStructuredActivityNode structuredActivityNode)
            {
                result.AddRange(structuredActivityNode.StructuredNodeOutput);
            }

            if (action is ITestIdentityAction testIdentityAction)
            {
                result.AddRange(testIdentityAction.Result);
            }

            if (action is IUnmarshallAction unmarshallAction)
            {
                result.AddRange(unmarshallAction.Result);
            }

            if (action is IValueSpecificationAction valueSpecificationAction)
            {
                result.AddRange(valueSpecificationAction.Result);
            }

            if (action is IWriteStructuralFeatureAction writeStructuralFeatureAction)
            {
                result.AddRange(writeStructuralFeatureAction.Result);
            }

            return result.Distinct().ToList();
        }
    }
}
