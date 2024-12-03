// -------------------------------------------------------------------------------------------------
// <copyright file="IExceptionHandler.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.Activities
{
    using System.Collections.Generic;

    using uml4net.Decorators;
    using uml4net.Actions;
    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.CommonBehavior;
    using uml4net.CommonStructure;
    using uml4net.Deployments;
    using uml4net.InformationFlows;
    using uml4net.Interactions;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;
    using uml4net.Values;

    using uml4net.Utils;

    /// <summary>
    /// An ExceptionHandler is an Element that specifies a handlerBody ExecutableNode to execute in case the
    /// specified exception occurs during the execution of the protected ExecutableNode.
    /// </summary>
    [Class(xmiId: "ExceptionHandler", isAbstract: false, isFinalSpecialization: false, isActive: false)]
    public partial interface IExceptionHandler : IElement
    {
        /// <summary>
        /// An ObjectNode within the handlerBody. When the ExceptionHandler catches an exception, the exception
        /// token is placed on this ObjectNode, causing the handlerBody to execute.
        /// </summary>
        [Property(xmiId: "ExceptionHandler-exceptionInput", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IObjectNode ExceptionInput { get; set; }

        /// <summary>
        /// The Classifiers whose instances the ExceptionHandler catches as exceptions. If an exception occurs
        /// whose type is any exceptionType, the ExceptionHandler catches the exception and executes the
        /// handlerBody.
        /// </summary>
        [Property(xmiId: "ExceptionHandler-exceptionType", aggregation: AggregationKind.None, lowerValue: 1, upperValue: int.MaxValue, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public List<IClassifier> ExceptionType { get; set; }

        /// <summary>
        /// An ExecutableNode that is executed if the ExceptionHandler catches an exception.
        /// </summary>
        [Property(xmiId: "ExceptionHandler-handlerBody", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        public IExecutableNode HandlerBody { get; set; }

        /// <summary>
        /// The ExecutableNode protected by the ExceptionHandler. If an exception propagates out of the
        /// protectedNode and has a type matching one of the exceptionTypes, then it is caught by this
        /// ExceptionHandler.
        /// </summary>
        [Property(xmiId: "ExceptionHandler-protectedNode", aggregation: AggregationKind.None, lowerValue: 1, upperValue: 1, isOrdered: false, isReadOnly: false, isDerived: false, isDerivedUnion: false, isUnique: false, defaultValue: null)]
        [SubsettedProperty(propertyName: "Element-owner")]
        public IExecutableNode ProtectedNode { get; set; }

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
