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
    using uml4net.xmi.Settings;

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
        protected readonly Dictionary<string, Func<IXmiElementCache, IXmiReaderSettings, INameSpaceResolver, ILoggerFactory, XmlReader, string, string, IXmiElement>> ReaderCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiElementReaderFacade"/>
        /// </summary>
        public XmiElementReaderFacade()
        {
            this.ReaderCache = new Dictionary<string, Func<IXmiElementCache, IXmiReaderSettings, INameSpaceResolver, ILoggerFactory, XmlReader, string, string, IXmiElement>>
            {
                ["uml:Activity"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var activityReader = new ActivityReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return activityReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ActivityFinalNode"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var activityFinalNodeReader = new ActivityFinalNodeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return activityFinalNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ActivityParameterNode"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var activityParameterNodeReader = new ActivityParameterNodeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return activityParameterNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ActivityPartition"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var activityPartitionReader = new ActivityPartitionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return activityPartitionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CentralBufferNode"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var centralBufferNodeReader = new CentralBufferNodeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return centralBufferNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ControlFlow"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var controlFlowReader = new ControlFlowReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return controlFlowReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DataStoreNode"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var dataStoreNodeReader = new DataStoreNodeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return dataStoreNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DecisionNode"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var decisionNodeReader = new DecisionNodeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return decisionNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ExceptionHandler"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var exceptionHandlerReader = new ExceptionHandlerReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return exceptionHandlerReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:FlowFinalNode"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var flowFinalNodeReader = new FlowFinalNodeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return flowFinalNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ForkNode"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var forkNodeReader = new ForkNodeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return forkNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InitialNode"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var initialNodeReader = new InitialNodeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return initialNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InterruptibleActivityRegion"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var interruptibleActivityRegionReader = new InterruptibleActivityRegionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return interruptibleActivityRegionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:JoinNode"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var joinNodeReader = new JoinNodeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return joinNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:MergeNode"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var mergeNodeReader = new MergeNodeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return mergeNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ObjectFlow"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var objectFlowReader = new ObjectFlowReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return objectFlowReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Variable"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var variableReader = new VariableReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return variableReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Duration"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var durationReader = new DurationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return durationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DurationConstraint"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var durationConstraintReader = new DurationConstraintReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return durationConstraintReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DurationInterval"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var durationIntervalReader = new DurationIntervalReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return durationIntervalReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DurationObservation"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var durationObservationReader = new DurationObservationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return durationObservationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Expression"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var expressionReader = new ExpressionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return expressionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Interval"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var intervalReader = new IntervalReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return intervalReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:IntervalConstraint"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var intervalConstraintReader = new IntervalConstraintReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return intervalConstraintReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LiteralBoolean"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var literalBooleanReader = new LiteralBooleanReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return literalBooleanReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LiteralInteger"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var literalIntegerReader = new LiteralIntegerReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return literalIntegerReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LiteralNull"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var literalNullReader = new LiteralNullReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return literalNullReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LiteralReal"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var literalRealReader = new LiteralRealReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return literalRealReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LiteralString"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var literalStringReader = new LiteralStringReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return literalStringReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LiteralUnlimitedNatural"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var literalUnlimitedNaturalReader = new LiteralUnlimitedNaturalReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return literalUnlimitedNaturalReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:OpaqueExpression"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var opaqueExpressionReader = new OpaqueExpressionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return opaqueExpressionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:StringExpression"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var stringExpressionReader = new StringExpressionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return stringExpressionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TimeConstraint"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var timeConstraintReader = new TimeConstraintReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return timeConstraintReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TimeExpression"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var timeExpressionReader = new TimeExpressionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return timeExpressionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TimeInterval"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var timeIntervalReader = new TimeIntervalReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return timeIntervalReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TimeObservation"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var timeObservationReader = new TimeObservationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return timeObservationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Actor"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var actorReader = new ActorReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return actorReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Extend"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var extendReader = new ExtendReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return extendReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ExtensionPoint"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var extensionPointReader = new ExtensionPointReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return extensionPointReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Include"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var includeReader = new IncludeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return includeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:UseCase"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var useCaseReader = new UseCaseReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return useCaseReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Association"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var associationReader = new AssociationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return associationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:AssociationClass"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var associationClassReader = new AssociationClassReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return associationClassReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Class"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var classReader = new ClassReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return classReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Collaboration"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var collaborationReader = new CollaborationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return collaborationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CollaborationUse"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var collaborationUseReader = new CollaborationUseReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return collaborationUseReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Component"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var componentReader = new ComponentReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return componentReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ComponentRealization"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var componentRealizationReader = new ComponentRealizationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return componentRealizationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ConnectableElementTemplateParameter"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var connectableElementTemplateParameterReader = new ConnectableElementTemplateParameterReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return connectableElementTemplateParameterReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Connector"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var connectorReader = new ConnectorReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return connectorReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ConnectorEnd"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var connectorEndReader = new ConnectorEndReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return connectorEndReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Port"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var portReader = new PortReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return portReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ConnectionPointReference"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var connectionPointReferenceReader = new ConnectionPointReferenceReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return connectionPointReferenceReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:FinalState"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var finalStateReader = new FinalStateReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return finalStateReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ProtocolConformance"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var protocolConformanceReader = new ProtocolConformanceReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return protocolConformanceReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ProtocolStateMachine"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var protocolStateMachineReader = new ProtocolStateMachineReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return protocolStateMachineReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ProtocolTransition"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var protocolTransitionReader = new ProtocolTransitionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return protocolTransitionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Pseudostate"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var pseudostateReader = new PseudostateReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return pseudostateReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Region"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var regionReader = new RegionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return regionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:State"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var stateReader = new StateReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return stateReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:StateMachine"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var stateMachineReader = new StateMachineReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return stateMachineReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Transition"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var transitionReader = new TransitionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return transitionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DataType"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var dataTypeReader = new DataTypeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return dataTypeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Enumeration"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var enumerationReader = new EnumerationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return enumerationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:EnumerationLiteral"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var enumerationLiteralReader = new EnumerationLiteralReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return enumerationLiteralReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Interface"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var interfaceReader = new InterfaceReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return interfaceReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InterfaceRealization"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var interfaceRealizationReader = new InterfaceRealizationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return interfaceRealizationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:PrimitiveType"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var primitiveTypeReader = new PrimitiveTypeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return primitiveTypeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Reception"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var receptionReader = new ReceptionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return receptionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Signal"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var signalReader = new SignalReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return signalReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Extension"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var extensionReader = new ExtensionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return extensionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ExtensionEnd"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var extensionEndReader = new ExtensionEndReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return extensionEndReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Image"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var imageReader = new ImageReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return imageReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Model"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var modelReader = new ModelReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return modelReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Package"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var packageReader = new PackageReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return packageReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:PackageMerge"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var packageMergeReader = new PackageMergeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return packageMergeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Profile"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var profileReader = new ProfileReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return profileReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ProfileApplication"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var profileApplicationReader = new ProfileApplicationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return profileApplicationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Stereotype"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var stereotypeReader = new StereotypeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return stereotypeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ActionExecutionSpecification"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var actionExecutionSpecificationReader = new ActionExecutionSpecificationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return actionExecutionSpecificationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:BehaviorExecutionSpecification"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var behaviorExecutionSpecificationReader = new BehaviorExecutionSpecificationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return behaviorExecutionSpecificationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CombinedFragment"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var combinedFragmentReader = new CombinedFragmentReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return combinedFragmentReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ConsiderIgnoreFragment"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var considerIgnoreFragmentReader = new ConsiderIgnoreFragmentReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return considerIgnoreFragmentReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Continuation"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var continuationReader = new ContinuationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return continuationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DestructionOccurrenceSpecification"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var destructionOccurrenceSpecificationReader = new DestructionOccurrenceSpecificationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return destructionOccurrenceSpecificationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ExecutionOccurrenceSpecification"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var executionOccurrenceSpecificationReader = new ExecutionOccurrenceSpecificationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return executionOccurrenceSpecificationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Gate"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var gateReader = new GateReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return gateReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:GeneralOrdering"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var generalOrderingReader = new GeneralOrderingReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return generalOrderingReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Interaction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var interactionReader = new InteractionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return interactionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InteractionConstraint"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var interactionConstraintReader = new InteractionConstraintReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return interactionConstraintReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InteractionOperand"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var interactionOperandReader = new InteractionOperandReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return interactionOperandReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InteractionUse"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var interactionUseReader = new InteractionUseReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return interactionUseReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Lifeline"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var lifelineReader = new LifelineReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return lifelineReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Message"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var messageReader = new MessageReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return messageReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:MessageOccurrenceSpecification"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var messageOccurrenceSpecificationReader = new MessageOccurrenceSpecificationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return messageOccurrenceSpecificationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:OccurrenceSpecification"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var occurrenceSpecificationReader = new OccurrenceSpecificationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return occurrenceSpecificationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:PartDecomposition"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var partDecompositionReader = new PartDecompositionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return partDecompositionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:StateInvariant"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var stateInvariantReader = new StateInvariantReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return stateInvariantReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InformationFlow"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var informationFlowReader = new InformationFlowReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return informationFlowReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InformationItem"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var informationItemReader = new InformationItemReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return informationItemReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Artifact"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var artifactReader = new ArtifactReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return artifactReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CommunicationPath"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var communicationPathReader = new CommunicationPathReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return communicationPathReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Deployment"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var deploymentReader = new DeploymentReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return deploymentReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DeploymentSpecification"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var deploymentSpecificationReader = new DeploymentSpecificationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return deploymentSpecificationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Device"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var deviceReader = new DeviceReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return deviceReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ExecutionEnvironment"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var executionEnvironmentReader = new ExecutionEnvironmentReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return executionEnvironmentReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Manifestation"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var manifestationReader = new ManifestationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return manifestationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Node"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var nodeReader = new NodeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return nodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Abstraction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var abstractionReader = new AbstractionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return abstractionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Comment"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var commentReader = new CommentReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return commentReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Constraint"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var constraintReader = new ConstraintReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return constraintReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Dependency"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var dependencyReader = new DependencyReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return dependencyReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ElementImport"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var elementImportReader = new ElementImportReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return elementImportReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:PackageImport"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var packageImportReader = new PackageImportReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return packageImportReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Realization"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var realizationReader = new RealizationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return realizationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TemplateBinding"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var templateBindingReader = new TemplateBindingReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return templateBindingReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TemplateParameter"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var templateParameterReader = new TemplateParameterReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return templateParameterReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TemplateParameterSubstitution"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var templateParameterSubstitutionReader = new TemplateParameterSubstitutionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return templateParameterSubstitutionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TemplateSignature"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var templateSignatureReader = new TemplateSignatureReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return templateSignatureReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Usage"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var usageReader = new UsageReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return usageReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:AnyReceiveEvent"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var anyReceiveEventReader = new AnyReceiveEventReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return anyReceiveEventReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CallEvent"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var callEventReader = new CallEventReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return callEventReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ChangeEvent"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var changeEventReader = new ChangeEventReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return changeEventReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:FunctionBehavior"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var functionBehaviorReader = new FunctionBehaviorReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return functionBehaviorReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:OpaqueBehavior"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var opaqueBehaviorReader = new OpaqueBehaviorReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return opaqueBehaviorReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:SignalEvent"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var signalEventReader = new SignalEventReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return signalEventReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TimeEvent"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var timeEventReader = new TimeEventReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return timeEventReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Trigger"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var triggerReader = new TriggerReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return triggerReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Substitution"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var substitutionReader = new SubstitutionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return substitutionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ClassifierTemplateParameter"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var classifierTemplateParameterReader = new ClassifierTemplateParameterReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return classifierTemplateParameterReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Generalization"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var generalizationReader = new GeneralizationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return generalizationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:GeneralizationSet"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var generalizationSetReader = new GeneralizationSetReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return generalizationSetReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InstanceSpecification"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var instanceSpecificationReader = new InstanceSpecificationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return instanceSpecificationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InstanceValue"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var instanceValueReader = new InstanceValueReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return instanceValueReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Operation"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var operationReader = new OperationReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return operationReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:OperationTemplateParameter"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var operationTemplateParameterReader = new OperationTemplateParameterReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return operationTemplateParameterReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Parameter"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var parameterReader = new ParameterReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return parameterReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ParameterSet"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var parameterSetReader = new ParameterSetReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return parameterSetReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Property"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var propertyReader = new PropertyReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return propertyReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:RedefinableTemplateSignature"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var redefinableTemplateSignatureReader = new RedefinableTemplateSignatureReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return redefinableTemplateSignatureReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Slot"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var slotReader = new SlotReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return slotReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ValueSpecificationAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var valueSpecificationActionReader = new ValueSpecificationActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return valueSpecificationActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:AcceptCallAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var acceptCallActionReader = new AcceptCallActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return acceptCallActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:AcceptEventAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var acceptEventActionReader = new AcceptEventActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return acceptEventActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ActionInputPin"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var actionInputPinReader = new ActionInputPinReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return actionInputPinReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:AddStructuralFeatureValueAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var addStructuralFeatureValueActionReader = new AddStructuralFeatureValueActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return addStructuralFeatureValueActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:AddVariableValueAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var addVariableValueActionReader = new AddVariableValueActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return addVariableValueActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:BroadcastSignalAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var broadcastSignalActionReader = new BroadcastSignalActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return broadcastSignalActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CallBehaviorAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var callBehaviorActionReader = new CallBehaviorActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return callBehaviorActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CallOperationAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var callOperationActionReader = new CallOperationActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return callOperationActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:Clause"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var clauseReader = new ClauseReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return clauseReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ClearAssociationAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var clearAssociationActionReader = new ClearAssociationActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return clearAssociationActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ClearStructuralFeatureAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var clearStructuralFeatureActionReader = new ClearStructuralFeatureActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return clearStructuralFeatureActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ClearVariableAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var clearVariableActionReader = new ClearVariableActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return clearVariableActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ConditionalNode"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var conditionalNodeReader = new ConditionalNodeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return conditionalNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CreateLinkAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var createLinkActionReader = new CreateLinkActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return createLinkActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CreateLinkObjectAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var createLinkObjectActionReader = new CreateLinkObjectActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return createLinkObjectActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:CreateObjectAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var createObjectActionReader = new CreateObjectActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return createObjectActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DestroyLinkAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var destroyLinkActionReader = new DestroyLinkActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return destroyLinkActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:DestroyObjectAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var destroyObjectActionReader = new DestroyObjectActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return destroyObjectActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ExpansionNode"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var expansionNodeReader = new ExpansionNodeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return expansionNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ExpansionRegion"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var expansionRegionReader = new ExpansionRegionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return expansionRegionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:InputPin"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var inputPinReader = new InputPinReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return inputPinReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LinkEndCreationData"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var linkEndCreationDataReader = new LinkEndCreationDataReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return linkEndCreationDataReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LinkEndData"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var linkEndDataReader = new LinkEndDataReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return linkEndDataReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LinkEndDestructionData"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var linkEndDestructionDataReader = new LinkEndDestructionDataReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return linkEndDestructionDataReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:LoopNode"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var loopNodeReader = new LoopNodeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return loopNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:OpaqueAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var opaqueActionReader = new OpaqueActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return opaqueActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:OutputPin"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var outputPinReader = new OutputPinReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return outputPinReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:QualifierValue"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var qualifierValueReader = new QualifierValueReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return qualifierValueReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:RaiseExceptionAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var raiseExceptionActionReader = new RaiseExceptionActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return raiseExceptionActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReadExtentAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var readExtentActionReader = new ReadExtentActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return readExtentActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReadIsClassifiedObjectAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var readIsClassifiedObjectActionReader = new ReadIsClassifiedObjectActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return readIsClassifiedObjectActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReadLinkAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var readLinkActionReader = new ReadLinkActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return readLinkActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReadLinkObjectEndAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var readLinkObjectEndActionReader = new ReadLinkObjectEndActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return readLinkObjectEndActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReadLinkObjectEndQualifierAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var readLinkObjectEndQualifierActionReader = new ReadLinkObjectEndQualifierActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return readLinkObjectEndQualifierActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReadSelfAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var readSelfActionReader = new ReadSelfActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return readSelfActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReadStructuralFeatureAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var readStructuralFeatureActionReader = new ReadStructuralFeatureActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return readStructuralFeatureActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReadVariableAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var readVariableActionReader = new ReadVariableActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return readVariableActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReclassifyObjectAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var reclassifyObjectActionReader = new ReclassifyObjectActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return reclassifyObjectActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReduceAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var reduceActionReader = new ReduceActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return reduceActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:RemoveStructuralFeatureValueAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var removeStructuralFeatureValueActionReader = new RemoveStructuralFeatureValueActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return removeStructuralFeatureValueActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:RemoveVariableValueAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var removeVariableValueActionReader = new RemoveVariableValueActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return removeVariableValueActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ReplyAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var replyActionReader = new ReplyActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return replyActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:SendObjectAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var sendObjectActionReader = new SendObjectActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return sendObjectActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:SendSignalAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var sendSignalActionReader = new SendSignalActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return sendSignalActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:SequenceNode"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var sequenceNodeReader = new SequenceNodeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return sequenceNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:StartClassifierBehaviorAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var startClassifierBehaviorActionReader = new StartClassifierBehaviorActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return startClassifierBehaviorActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:StartObjectBehaviorAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var startObjectBehaviorActionReader = new StartObjectBehaviorActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return startObjectBehaviorActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:StructuredActivityNode"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var structuredActivityNodeReader = new StructuredActivityNodeReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return structuredActivityNodeReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:TestIdentityAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var testIdentityActionReader = new TestIdentityActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return testIdentityActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:UnmarshallAction"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var unmarshallActionReader = new UnmarshallActionReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
                    return unmarshallActionReader.Read(subXmlReader, documentName, namespaceUri);
                },
                ["uml:ValuePin"] = (cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var valuePinReader = new ValuePinReader(cache, this, xmiReaderSettings, nameSpaceResolver, loggerFactory);
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
        /// <param name = "xmiReaderSettings" >
        /// The <see cref="IXmiReaderSettings"/> used to configure reading
        /// </param>
        /// <param>
        /// The (injected) <see cref="INameSpaceResolver"/> used to resolve a namespace to one of the
        /// <see cref="SupportedNamespaces"/>
        /// </param>
        /// <param name="loggerFactory">
        /// The <see cref="ILoggerFactory"/> to set up logging
        /// </param>
        /// <param name="explicitTypeName">
        /// the name of the type using the convention of the XMI file. This must be specified in case the XMI document does not include the
        /// xmi:type attribute since the type can be inferred from the property itself.
        /// </param>
        /// <param name="ignoreXmiType">
        /// Asserts that the xmi:type value should be ignored even if the attribute is present inside the XMI element.
        /// Should be use in case of extension part reading.
        /// </param>
        /// <returns>
        /// an instance of <see cref="IXmiElement"/>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// thrown when the xmi:type is not supported and noXmiElementReader was found
        /// </exception>
        public IXmiElement QueryXmiElement(XmlReader xmlReader, string documentName, string namespaceUri, IXmiElementCache cache, IXmiReaderSettings xmiReaderSettings, INameSpaceResolver nameSpaceResolver, ILoggerFactory loggerFactory, string explicitTypeName = null, bool ignoreXmiType = false)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }

            if (xmiReaderSettings == null)
            {
                throw new ArgumentNullException(nameof(xmiReaderSettings));
            }

            if (nameSpaceResolver == null)
            {
                throw new ArgumentNullException(nameof(xmiReaderSettings));
            }

            if (string.IsNullOrEmpty(documentName))
            {
                throw new ArgumentNullException(nameof(documentName));
            }

            if (string.IsNullOrEmpty(namespaceUri))
            {
                throw new ArgumentNullException(nameof(namespaceUri));
            }

            if (string.IsNullOrEmpty(explicitTypeName) && ignoreXmiType)
            {
                throw new InvalidOperationException($"While ignoring the xmi:type, the {nameof(explicitTypeName)} should be provided");
            }

            var xmiType = xmlReader.GetAttribute("xmi:type");

            if ((xmiType == null && explicitTypeName != null) || ignoreXmiType)
            {
                xmiType = explicitTypeName;
            }

            if (xmiType == null)
            {
                throw new InvalidOperationException($"The xmi:type is not specified");
            }

            if (this.ReaderCache.TryGetValue(xmiType, out var readerFactory))
            {
                return readerFactory(cache, xmiReaderSettings, nameSpaceResolver, loggerFactory, xmlReader, documentName, namespaceUri);
            }

            throw new InvalidOperationException($"No reader found for xmi:type - {xmiType}");
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
