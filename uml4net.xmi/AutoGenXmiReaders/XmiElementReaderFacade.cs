// -------------------------------------------------------------------------------------------------
// <copyright file="XmiElementReaderFacade.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
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

namespace uml4net.xmi.Readers
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net.xmi.ReferenceResolver;

    /// <summary>
    /// The purpose of the <see cref="XmiElementReaderFacade"/> is to read an <see cref="IXmiElement"/> from an
    /// <see cref="XmlReader"/>
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class XmiElementReaderFacade : IXmiElementReaderFacade
    {
        /// <summary>
        /// A dictionary that contains functions that return <see cref="IXmiElement"/> based a key that represents the xmiType
        /// and a provided <see cref="IXmiElementCache"/>, <see cref="ILoggerFactory"/> and <see cref="XmlReader"/>
        /// </summary>
        private readonly Dictionary<string, Func<IXmiElementCache, ILoggerFactory, XmlReader, string, string, IXmiElement>> readerCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiElementReaderFacade"/>
        /// </summary>
        public XmiElementReaderFacade()
        {
            readerCache = new Dictionary<string, Func<IXmiElementCache, ILoggerFactory, XmlReader, string, string, IXmiElement>>
            {
                ["uml:Activity"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var activityReader = new ActivityReader(cache, this, loggerFactory);
                    return activityReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ActivityFinalNode"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var activityFinalNodeReader = new ActivityFinalNodeReader(cache, this, loggerFactory);
                    return activityFinalNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ActivityParameterNode"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var activityParameterNodeReader = new ActivityParameterNodeReader(cache, this, loggerFactory);
                    return activityParameterNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ActivityPartition"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var activityPartitionReader = new ActivityPartitionReader(cache, this, loggerFactory);
                    return activityPartitionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CentralBufferNode"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var centralBufferNodeReader = new CentralBufferNodeReader(cache, this, loggerFactory);
                    return centralBufferNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ControlFlow"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var controlFlowReader = new ControlFlowReader(cache, this, loggerFactory);
                    return controlFlowReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DataStoreNode"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var dataStoreNodeReader = new DataStoreNodeReader(cache, this, loggerFactory);
                    return dataStoreNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DecisionNode"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var decisionNodeReader = new DecisionNodeReader(cache, this, loggerFactory);
                    return decisionNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ExceptionHandler"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var exceptionHandlerReader = new ExceptionHandlerReader(cache, this, loggerFactory);
                    return exceptionHandlerReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:FlowFinalNode"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var flowFinalNodeReader = new FlowFinalNodeReader(cache, this, loggerFactory);
                    return flowFinalNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ForkNode"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var forkNodeReader = new ForkNodeReader(cache, this, loggerFactory);
                    return forkNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InitialNode"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var initialNodeReader = new InitialNodeReader(cache, this, loggerFactory);
                    return initialNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InterruptibleActivityRegion"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var interruptibleActivityRegionReader = new InterruptibleActivityRegionReader(cache, this, loggerFactory);
                    return interruptibleActivityRegionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:JoinNode"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var joinNodeReader = new JoinNodeReader(cache, this, loggerFactory);
                    return joinNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:MergeNode"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var mergeNodeReader = new MergeNodeReader(cache, this, loggerFactory);
                    return mergeNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ObjectFlow"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var objectFlowReader = new ObjectFlowReader(cache, this, loggerFactory);
                    return objectFlowReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Variable"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var variableReader = new VariableReader(cache, this, loggerFactory);
                    return variableReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Duration"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var durationReader = new DurationReader(cache, this, loggerFactory);
                    return durationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DurationConstraint"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var durationConstraintReader = new DurationConstraintReader(cache, this, loggerFactory);
                    return durationConstraintReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DurationInterval"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var durationIntervalReader = new DurationIntervalReader(cache, this, loggerFactory);
                    return durationIntervalReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DurationObservation"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var durationObservationReader = new DurationObservationReader(cache, this, loggerFactory);
                    return durationObservationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Expression"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var expressionReader = new ExpressionReader(cache, this, loggerFactory);
                    return expressionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Interval"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var intervalReader = new IntervalReader(cache, this, loggerFactory);
                    return intervalReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:IntervalConstraint"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var intervalConstraintReader = new IntervalConstraintReader(cache, this, loggerFactory);
                    return intervalConstraintReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LiteralBoolean"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var literalBooleanReader = new LiteralBooleanReader(cache, this, loggerFactory);
                    return literalBooleanReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LiteralInteger"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var literalIntegerReader = new LiteralIntegerReader(cache, this, loggerFactory);
                    return literalIntegerReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LiteralNull"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var literalNullReader = new LiteralNullReader(cache, this, loggerFactory);
                    return literalNullReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LiteralReal"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var literalRealReader = new LiteralRealReader(cache, this, loggerFactory);
                    return literalRealReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LiteralString"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var literalStringReader = new LiteralStringReader(cache, this, loggerFactory);
                    return literalStringReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LiteralUnlimitedNatural"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var literalUnlimitedNaturalReader = new LiteralUnlimitedNaturalReader(cache, this, loggerFactory);
                    return literalUnlimitedNaturalReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:OpaqueExpression"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var opaqueExpressionReader = new OpaqueExpressionReader(cache, this, loggerFactory);
                    return opaqueExpressionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:StringExpression"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var stringExpressionReader = new StringExpressionReader(cache, this, loggerFactory);
                    return stringExpressionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TimeConstraint"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var timeConstraintReader = new TimeConstraintReader(cache, this, loggerFactory);
                    return timeConstraintReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TimeExpression"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var timeExpressionReader = new TimeExpressionReader(cache, this, loggerFactory);
                    return timeExpressionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TimeInterval"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var timeIntervalReader = new TimeIntervalReader(cache, this, loggerFactory);
                    return timeIntervalReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TimeObservation"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var timeObservationReader = new TimeObservationReader(cache, this, loggerFactory);
                    return timeObservationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Actor"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var actorReader = new ActorReader(cache, this, loggerFactory);
                    return actorReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Extend"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var extendReader = new ExtendReader(cache, this, loggerFactory);
                    return extendReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ExtensionPoint"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var extensionPointReader = new ExtensionPointReader(cache, this, loggerFactory);
                    return extensionPointReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Include"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var includeReader = new IncludeReader(cache, this, loggerFactory);
                    return includeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:UseCase"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var useCaseReader = new UseCaseReader(cache, this, loggerFactory);
                    return useCaseReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Association"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var associationReader = new AssociationReader(cache, this, loggerFactory);
                    return associationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:AssociationClass"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var associationClassReader = new AssociationClassReader(cache, this, loggerFactory);
                    return associationClassReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Class"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var classReader = new ClassReader(cache, this, loggerFactory);
                    return classReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Collaboration"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var collaborationReader = new CollaborationReader(cache, this, loggerFactory);
                    return collaborationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CollaborationUse"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var collaborationUseReader = new CollaborationUseReader(cache, this, loggerFactory);
                    return collaborationUseReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Component"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var componentReader = new ComponentReader(cache, this, loggerFactory);
                    return componentReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ComponentRealization"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var componentRealizationReader = new ComponentRealizationReader(cache, this, loggerFactory);
                    return componentRealizationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ConnectableElementTemplateParameter"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var connectableElementTemplateParameterReader = new ConnectableElementTemplateParameterReader(cache, this, loggerFactory);
                    return connectableElementTemplateParameterReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Connector"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var connectorReader = new ConnectorReader(cache, this, loggerFactory);
                    return connectorReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ConnectorEnd"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var connectorEndReader = new ConnectorEndReader(cache, this, loggerFactory);
                    return connectorEndReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Port"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var portReader = new PortReader(cache, this, loggerFactory);
                    return portReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ConnectionPointReference"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var connectionPointReferenceReader = new ConnectionPointReferenceReader(cache, this, loggerFactory);
                    return connectionPointReferenceReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:FinalState"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var finalStateReader = new FinalStateReader(cache, this, loggerFactory);
                    return finalStateReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ProtocolConformance"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var protocolConformanceReader = new ProtocolConformanceReader(cache, this, loggerFactory);
                    return protocolConformanceReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ProtocolStateMachine"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var protocolStateMachineReader = new ProtocolStateMachineReader(cache, this, loggerFactory);
                    return protocolStateMachineReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ProtocolTransition"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var protocolTransitionReader = new ProtocolTransitionReader(cache, this, loggerFactory);
                    return protocolTransitionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Pseudostate"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var pseudostateReader = new PseudostateReader(cache, this, loggerFactory);
                    return pseudostateReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Region"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var regionReader = new RegionReader(cache, this, loggerFactory);
                    return regionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:State"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var stateReader = new StateReader(cache, this, loggerFactory);
                    return stateReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:StateMachine"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var stateMachineReader = new StateMachineReader(cache, this, loggerFactory);
                    return stateMachineReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Transition"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var transitionReader = new TransitionReader(cache, this, loggerFactory);
                    return transitionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DataType"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var dataTypeReader = new DataTypeReader(cache, this, loggerFactory);
                    return dataTypeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Enumeration"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var enumerationReader = new EnumerationReader(cache, this, loggerFactory);
                    return enumerationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:EnumerationLiteral"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var enumerationLiteralReader = new EnumerationLiteralReader(cache, this, loggerFactory);
                    return enumerationLiteralReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Interface"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var interfaceReader = new InterfaceReader(cache, this, loggerFactory);
                    return interfaceReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InterfaceRealization"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var interfaceRealizationReader = new InterfaceRealizationReader(cache, this, loggerFactory);
                    return interfaceRealizationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:PrimitiveType"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var primitiveTypeReader = new PrimitiveTypeReader(cache, this, loggerFactory);
                    return primitiveTypeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Reception"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var receptionReader = new ReceptionReader(cache, this, loggerFactory);
                    return receptionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Signal"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var signalReader = new SignalReader(cache, this, loggerFactory);
                    return signalReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Extension"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var extensionReader = new ExtensionReader(cache, this, loggerFactory);
                    return extensionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ExtensionEnd"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var extensionEndReader = new ExtensionEndReader(cache, this, loggerFactory);
                    return extensionEndReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Image"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var imageReader = new ImageReader(cache, this, loggerFactory);
                    return imageReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Model"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var modelReader = new ModelReader(cache, this, loggerFactory);
                    return modelReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Package"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var packageReader = new PackageReader(cache, this, loggerFactory);
                    return packageReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:PackageMerge"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var packageMergeReader = new PackageMergeReader(cache, this, loggerFactory);
                    return packageMergeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Profile"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var profileReader = new ProfileReader(cache, this, loggerFactory);
                    return profileReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ProfileApplication"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var profileApplicationReader = new ProfileApplicationReader(cache, this, loggerFactory);
                    return profileApplicationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Stereotype"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var stereotypeReader = new StereotypeReader(cache, this, loggerFactory);
                    return stereotypeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ActionExecutionSpecification"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var actionExecutionSpecificationReader = new ActionExecutionSpecificationReader(cache, this, loggerFactory);
                    return actionExecutionSpecificationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:BehaviorExecutionSpecification"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var behaviorExecutionSpecificationReader = new BehaviorExecutionSpecificationReader(cache, this, loggerFactory);
                    return behaviorExecutionSpecificationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CombinedFragment"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var combinedFragmentReader = new CombinedFragmentReader(cache, this, loggerFactory);
                    return combinedFragmentReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ConsiderIgnoreFragment"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var considerIgnoreFragmentReader = new ConsiderIgnoreFragmentReader(cache, this, loggerFactory);
                    return considerIgnoreFragmentReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Continuation"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var continuationReader = new ContinuationReader(cache, this, loggerFactory);
                    return continuationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DestructionOccurrenceSpecification"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var destructionOccurrenceSpecificationReader = new DestructionOccurrenceSpecificationReader(cache, this, loggerFactory);
                    return destructionOccurrenceSpecificationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ExecutionOccurrenceSpecification"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var executionOccurrenceSpecificationReader = new ExecutionOccurrenceSpecificationReader(cache, this, loggerFactory);
                    return executionOccurrenceSpecificationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Gate"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var gateReader = new GateReader(cache, this, loggerFactory);
                    return gateReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:GeneralOrdering"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var generalOrderingReader = new GeneralOrderingReader(cache, this, loggerFactory);
                    return generalOrderingReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Interaction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var interactionReader = new InteractionReader(cache, this, loggerFactory);
                    return interactionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InteractionConstraint"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var interactionConstraintReader = new InteractionConstraintReader(cache, this, loggerFactory);
                    return interactionConstraintReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InteractionOperand"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var interactionOperandReader = new InteractionOperandReader(cache, this, loggerFactory);
                    return interactionOperandReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InteractionUse"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var interactionUseReader = new InteractionUseReader(cache, this, loggerFactory);
                    return interactionUseReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Lifeline"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var lifelineReader = new LifelineReader(cache, this, loggerFactory);
                    return lifelineReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Message"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var messageReader = new MessageReader(cache, this, loggerFactory);
                    return messageReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:MessageOccurrenceSpecification"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var messageOccurrenceSpecificationReader = new MessageOccurrenceSpecificationReader(cache, this, loggerFactory);
                    return messageOccurrenceSpecificationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:OccurrenceSpecification"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var occurrenceSpecificationReader = new OccurrenceSpecificationReader(cache, this, loggerFactory);
                    return occurrenceSpecificationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:PartDecomposition"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var partDecompositionReader = new PartDecompositionReader(cache, this, loggerFactory);
                    return partDecompositionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:StateInvariant"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var stateInvariantReader = new StateInvariantReader(cache, this, loggerFactory);
                    return stateInvariantReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InformationFlow"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var informationFlowReader = new InformationFlowReader(cache, this, loggerFactory);
                    return informationFlowReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InformationItem"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var informationItemReader = new InformationItemReader(cache, this, loggerFactory);
                    return informationItemReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Artifact"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var artifactReader = new ArtifactReader(cache, this, loggerFactory);
                    return artifactReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CommunicationPath"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var communicationPathReader = new CommunicationPathReader(cache, this, loggerFactory);
                    return communicationPathReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Deployment"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var deploymentReader = new DeploymentReader(cache, this, loggerFactory);
                    return deploymentReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DeploymentSpecification"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var deploymentSpecificationReader = new DeploymentSpecificationReader(cache, this, loggerFactory);
                    return deploymentSpecificationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Device"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var deviceReader = new DeviceReader(cache, this, loggerFactory);
                    return deviceReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ExecutionEnvironment"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var executionEnvironmentReader = new ExecutionEnvironmentReader(cache, this, loggerFactory);
                    return executionEnvironmentReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Manifestation"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var manifestationReader = new ManifestationReader(cache, this, loggerFactory);
                    return manifestationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Node"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var nodeReader = new NodeReader(cache, this, loggerFactory);
                    return nodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Abstraction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var abstractionReader = new AbstractionReader(cache, this, loggerFactory);
                    return abstractionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Comment"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var commentReader = new CommentReader(cache, this, loggerFactory);
                    return commentReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Constraint"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var constraintReader = new ConstraintReader(cache, this, loggerFactory);
                    return constraintReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Dependency"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var dependencyReader = new DependencyReader(cache, this, loggerFactory);
                    return dependencyReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ElementImport"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var elementImportReader = new ElementImportReader(cache, this, loggerFactory);
                    return elementImportReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:PackageImport"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var packageImportReader = new PackageImportReader(cache, this, loggerFactory);
                    return packageImportReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Realization"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var realizationReader = new RealizationReader(cache, this, loggerFactory);
                    return realizationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TemplateBinding"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var templateBindingReader = new TemplateBindingReader(cache, this, loggerFactory);
                    return templateBindingReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TemplateParameter"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var templateParameterReader = new TemplateParameterReader(cache, this, loggerFactory);
                    return templateParameterReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TemplateParameterSubstitution"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var templateParameterSubstitutionReader = new TemplateParameterSubstitutionReader(cache, this, loggerFactory);
                    return templateParameterSubstitutionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TemplateSignature"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var templateSignatureReader = new TemplateSignatureReader(cache, this, loggerFactory);
                    return templateSignatureReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Usage"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var usageReader = new UsageReader(cache, this, loggerFactory);
                    return usageReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:AnyReceiveEvent"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var anyReceiveEventReader = new AnyReceiveEventReader(cache, this, loggerFactory);
                    return anyReceiveEventReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CallEvent"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var callEventReader = new CallEventReader(cache, this, loggerFactory);
                    return callEventReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ChangeEvent"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var changeEventReader = new ChangeEventReader(cache, this, loggerFactory);
                    return changeEventReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:FunctionBehavior"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var functionBehaviorReader = new FunctionBehaviorReader(cache, this, loggerFactory);
                    return functionBehaviorReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:OpaqueBehavior"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var opaqueBehaviorReader = new OpaqueBehaviorReader(cache, this, loggerFactory);
                    return opaqueBehaviorReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:SignalEvent"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var signalEventReader = new SignalEventReader(cache, this, loggerFactory);
                    return signalEventReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TimeEvent"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var timeEventReader = new TimeEventReader(cache, this, loggerFactory);
                    return timeEventReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Trigger"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var triggerReader = new TriggerReader(cache, this, loggerFactory);
                    return triggerReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Substitution"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var substitutionReader = new SubstitutionReader(cache, this, loggerFactory);
                    return substitutionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ClassifierTemplateParameter"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var classifierTemplateParameterReader = new ClassifierTemplateParameterReader(cache, this, loggerFactory);
                    return classifierTemplateParameterReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Generalization"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var generalizationReader = new GeneralizationReader(cache, this, loggerFactory);
                    return generalizationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:GeneralizationSet"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var generalizationSetReader = new GeneralizationSetReader(cache, this, loggerFactory);
                    return generalizationSetReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InstanceSpecification"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var instanceSpecificationReader = new InstanceSpecificationReader(cache, this, loggerFactory);
                    return instanceSpecificationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InstanceValue"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var instanceValueReader = new InstanceValueReader(cache, this, loggerFactory);
                    return instanceValueReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Operation"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var operationReader = new OperationReader(cache, this, loggerFactory);
                    return operationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:OperationTemplateParameter"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var operationTemplateParameterReader = new OperationTemplateParameterReader(cache, this, loggerFactory);
                    return operationTemplateParameterReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Parameter"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var parameterReader = new ParameterReader(cache, this, loggerFactory);
                    return parameterReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ParameterSet"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var parameterSetReader = new ParameterSetReader(cache, this, loggerFactory);
                    return parameterSetReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Property"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var propertyReader = new PropertyReader(cache, this, loggerFactory);
                    return propertyReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:RedefinableTemplateSignature"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var redefinableTemplateSignatureReader = new RedefinableTemplateSignatureReader(cache, this, loggerFactory);
                    return redefinableTemplateSignatureReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Slot"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var slotReader = new SlotReader(cache, this, loggerFactory);
                    return slotReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ValueSpecificationAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var valueSpecificationActionReader = new ValueSpecificationActionReader(cache, this, loggerFactory);
                    return valueSpecificationActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:AcceptCallAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var acceptCallActionReader = new AcceptCallActionReader(cache, this, loggerFactory);
                    return acceptCallActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:AcceptEventAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var acceptEventActionReader = new AcceptEventActionReader(cache, this, loggerFactory);
                    return acceptEventActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ActionInputPin"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var actionInputPinReader = new ActionInputPinReader(cache, this, loggerFactory);
                    return actionInputPinReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:AddStructuralFeatureValueAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var addStructuralFeatureValueActionReader = new AddStructuralFeatureValueActionReader(cache, this, loggerFactory);
                    return addStructuralFeatureValueActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:AddVariableValueAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var addVariableValueActionReader = new AddVariableValueActionReader(cache, this, loggerFactory);
                    return addVariableValueActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:BroadcastSignalAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var broadcastSignalActionReader = new BroadcastSignalActionReader(cache, this, loggerFactory);
                    return broadcastSignalActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CallBehaviorAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var callBehaviorActionReader = new CallBehaviorActionReader(cache, this, loggerFactory);
                    return callBehaviorActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CallOperationAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var callOperationActionReader = new CallOperationActionReader(cache, this, loggerFactory);
                    return callOperationActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Clause"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var clauseReader = new ClauseReader(cache, this, loggerFactory);
                    return clauseReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ClearAssociationAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var clearAssociationActionReader = new ClearAssociationActionReader(cache, this, loggerFactory);
                    return clearAssociationActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ClearStructuralFeatureAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var clearStructuralFeatureActionReader = new ClearStructuralFeatureActionReader(cache, this, loggerFactory);
                    return clearStructuralFeatureActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ClearVariableAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var clearVariableActionReader = new ClearVariableActionReader(cache, this, loggerFactory);
                    return clearVariableActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ConditionalNode"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var conditionalNodeReader = new ConditionalNodeReader(cache, this, loggerFactory);
                    return conditionalNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CreateLinkAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var createLinkActionReader = new CreateLinkActionReader(cache, this, loggerFactory);
                    return createLinkActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CreateLinkObjectAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var createLinkObjectActionReader = new CreateLinkObjectActionReader(cache, this, loggerFactory);
                    return createLinkObjectActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CreateObjectAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var createObjectActionReader = new CreateObjectActionReader(cache, this, loggerFactory);
                    return createObjectActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DestroyLinkAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var destroyLinkActionReader = new DestroyLinkActionReader(cache, this, loggerFactory);
                    return destroyLinkActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DestroyObjectAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var destroyObjectActionReader = new DestroyObjectActionReader(cache, this, loggerFactory);
                    return destroyObjectActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ExpansionNode"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var expansionNodeReader = new ExpansionNodeReader(cache, this, loggerFactory);
                    return expansionNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ExpansionRegion"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var expansionRegionReader = new ExpansionRegionReader(cache, this, loggerFactory);
                    return expansionRegionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InputPin"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var inputPinReader = new InputPinReader(cache, this, loggerFactory);
                    return inputPinReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LinkEndCreationData"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var linkEndCreationDataReader = new LinkEndCreationDataReader(cache, this, loggerFactory);
                    return linkEndCreationDataReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LinkEndData"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var linkEndDataReader = new LinkEndDataReader(cache, this, loggerFactory);
                    return linkEndDataReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LinkEndDestructionData"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var linkEndDestructionDataReader = new LinkEndDestructionDataReader(cache, this, loggerFactory);
                    return linkEndDestructionDataReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LoopNode"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var loopNodeReader = new LoopNodeReader(cache, this, loggerFactory);
                    return loopNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:OpaqueAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var opaqueActionReader = new OpaqueActionReader(cache, this, loggerFactory);
                    return opaqueActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:OutputPin"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var outputPinReader = new OutputPinReader(cache, this, loggerFactory);
                    return outputPinReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:QualifierValue"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var qualifierValueReader = new QualifierValueReader(cache, this, loggerFactory);
                    return qualifierValueReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:RaiseExceptionAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var raiseExceptionActionReader = new RaiseExceptionActionReader(cache, this, loggerFactory);
                    return raiseExceptionActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReadExtentAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var readExtentActionReader = new ReadExtentActionReader(cache, this, loggerFactory);
                    return readExtentActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReadIsClassifiedObjectAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var readIsClassifiedObjectActionReader = new ReadIsClassifiedObjectActionReader(cache, this, loggerFactory);
                    return readIsClassifiedObjectActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReadLinkAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var readLinkActionReader = new ReadLinkActionReader(cache, this, loggerFactory);
                    return readLinkActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReadLinkObjectEndAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var readLinkObjectEndActionReader = new ReadLinkObjectEndActionReader(cache, this, loggerFactory);
                    return readLinkObjectEndActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReadLinkObjectEndQualifierAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var readLinkObjectEndQualifierActionReader = new ReadLinkObjectEndQualifierActionReader(cache, this, loggerFactory);
                    return readLinkObjectEndQualifierActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReadSelfAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var readSelfActionReader = new ReadSelfActionReader(cache, this, loggerFactory);
                    return readSelfActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReadStructuralFeatureAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var readStructuralFeatureActionReader = new ReadStructuralFeatureActionReader(cache, this, loggerFactory);
                    return readStructuralFeatureActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReadVariableAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var readVariableActionReader = new ReadVariableActionReader(cache, this, loggerFactory);
                    return readVariableActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReclassifyObjectAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var reclassifyObjectActionReader = new ReclassifyObjectActionReader(cache, this, loggerFactory);
                    return reclassifyObjectActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReduceAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var reduceActionReader = new ReduceActionReader(cache, this, loggerFactory);
                    return reduceActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:RemoveStructuralFeatureValueAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var removeStructuralFeatureValueActionReader = new RemoveStructuralFeatureValueActionReader(cache, this, loggerFactory);
                    return removeStructuralFeatureValueActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:RemoveVariableValueAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var removeVariableValueActionReader = new RemoveVariableValueActionReader(cache, this, loggerFactory);
                    return removeVariableValueActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReplyAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var replyActionReader = new ReplyActionReader(cache, this, loggerFactory);
                    return replyActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:SendObjectAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var sendObjectActionReader = new SendObjectActionReader(cache, this, loggerFactory);
                    return sendObjectActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:SendSignalAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var sendSignalActionReader = new SendSignalActionReader(cache, this, loggerFactory);
                    return sendSignalActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:SequenceNode"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var sequenceNodeReader = new SequenceNodeReader(cache, this, loggerFactory);
                    return sequenceNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:StartClassifierBehaviorAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var startClassifierBehaviorActionReader = new StartClassifierBehaviorActionReader(cache, this, loggerFactory);
                    return startClassifierBehaviorActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:StartObjectBehaviorAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var startObjectBehaviorActionReader = new StartObjectBehaviorActionReader(cache, this, loggerFactory);
                    return startObjectBehaviorActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:StructuredActivityNode"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var structuredActivityNodeReader = new StructuredActivityNodeReader(cache, this, loggerFactory);
                    return structuredActivityNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TestIdentityAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var testIdentityActionReader = new TestIdentityActionReader(cache, this, loggerFactory);
                    return testIdentityActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:UnmarshallAction"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var unmarshallActionReader = new UnmarshallActionReader(cache, this, loggerFactory);
                    return unmarshallActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ValuePin"] = (cache, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var valuePinReader = new ValuePinReader(cache, this, loggerFactory);
                    return valuePinReader.Read(subXmlReader, documentName, namespaceUri);
                },
            };
        }

        /// <summary>
        /// Queries an instance of an <see cref="IXmiElement"/> based on the position of the <see cref="XmlReader"/>. When the reader
        /// is at an XML Element and has an attribute of xmi:type, the value of that attribute is used to select the appropriate
        /// XmiElementReader from which the <see cref="IXmiElement"/> is returned.
        /// </summary>
        /// <param name="xmlReader">
        /// An instance of <see cref="XmlReader"/>
        /// </param>
        /// <param name="documentName">
        /// The name of the document that contains the <see cref="IXmiElement"/>
        /// </param>
        /// <param name="namespaceUri">
        /// the namespace that the <see cref="IXmiElement"/> belongs to
        /// </param>
        /// <param name="cache">
        /// The <see cref="IXmiElementCache"/> in which all model instances are registered
        /// </param>
        /// <param name="loggerFactory">
        /// The <see cref="ILoggerFactory"/> to set up logging
        /// </param>
        /// <param name="explicitTypeName">
        /// the name of the type using the convention of the XMI file. This must be specified in case the XMI document does not include the
        /// xmi:type attribute since the type can be inferred from the property itself.
        /// </param>
        /// <returns>
        /// an instance of <see cref="IXmiElement"/>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// thrown when the xmi:type is not supported and noXmiElementReader was found
        /// </exception>
        public IXmiElement QueryXmiElement(XmlReader xmlReader, string documentName, string namespaceUri, IXmiElementCache cache, ILoggerFactory loggerFactory, string explicitTypeName = null)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }

            if (string.IsNullOrEmpty(documentName))
            {
                throw new ArgumentNullException(nameof(documentName));
            }

            if (string.IsNullOrEmpty(namespaceUri))
            {
                throw new ArgumentNullException(nameof(namespaceUri));
            }

            var xmiType = xmlReader.GetAttribute("xmi:type");

            if (xmiType == null && explicitTypeName != null)
            {
                xmiType = explicitTypeName;
            }

            if (xmiType == null)
            {
                throw new InvalidOperationException($"The xmi:type is not specified");
            }

            if (readerCache.TryGetValue(xmiType, out var readerFactory))
            {
                return readerFactory(cache, loggerFactory, xmlReader, documentName, namespaceUri);
            }

            throw new InvalidOperationException($"No reader found for xmi:type - {xmiType}");
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
