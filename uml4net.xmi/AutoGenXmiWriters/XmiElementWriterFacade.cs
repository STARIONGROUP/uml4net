// -------------------------------------------------------------------------------------------------
// <copyright file="XmiElementWriterFacade.cs" company="Starion Group S.A.">
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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Writers
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Xml;

    using Microsoft.Extensions.Logging;

    using uml4net;
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
    using uml4net.xmi.Settings;

    /// <summary>
    /// The purpose of the <see cref="XmiElementWriterFacade"/> is to write an <see cref="IXmiElement"/> to an
    /// <see cref="XmlWriter"/> using the appropriate <see cref="IXmiElementWriter{TXmiElement}"/> based on the
    /// concrete type of the <see cref="IXmiElement"/>
    /// </summary>
    [GeneratedCode("uml4net", "latest")]
    public class XmiElementWriterFacade : IXmiElementWriterFacade
    {
        /// <summary>
        /// The injected <see cref="IXmiWriterSettings" /> that provides XMI writer settings
        /// </summary>
        private readonly IXmiWriterSettings xmiWriterSettings;

        /// <summary>
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </summary>
        private readonly ILoggerFactory loggerFactory;

        /// <summary>
        /// A dictionary that contains delegates to write an <see cref="IXmiElement"/> based on the name of
        /// the concrete type of the <see cref="IXmiElement"/>
        /// </summary>
        private readonly Dictionary<string, Action<XmlWriter, IXmiElement, string, IXmiWriteContext>> writerCache;

        /// <summary>
        /// A dictionary that contains delegates to asynchronously write an <see cref="IXmiElement"/> based on the name of
        /// the concrete type of the <see cref="IXmiElement"/>
        /// </summary>
        private readonly Dictionary<string, Func<XmlWriter, IXmiElement, string, IXmiWriteContext, Task>> writerAsyncCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiElementWriterFacade"/> class.
        /// </summary>
        /// <param name="xmiWriterSettings">
        /// The injected <see cref="IXmiWriterSettings" /> that provides XMI writer settings
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public XmiElementWriterFacade(IXmiWriterSettings xmiWriterSettings, ILoggerFactory loggerFactory)
        {
            this.xmiWriterSettings = xmiWriterSettings;
            this.loggerFactory = loggerFactory;

            this.writerCache = new Dictionary<string, Action<XmlWriter, IXmiElement, string, IXmiWriteContext>>
            {
                ["Activity"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var activityWriter = new ActivityWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    activityWriter.Write(xmlWriter, (IActivity)element, elementName, writeContext);
                },
                ["ActivityFinalNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var activityFinalNodeWriter = new ActivityFinalNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    activityFinalNodeWriter.Write(xmlWriter, (IActivityFinalNode)element, elementName, writeContext);
                },
                ["ActivityParameterNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var activityParameterNodeWriter = new ActivityParameterNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    activityParameterNodeWriter.Write(xmlWriter, (IActivityParameterNode)element, elementName, writeContext);
                },
                ["ActivityPartition"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var activityPartitionWriter = new ActivityPartitionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    activityPartitionWriter.Write(xmlWriter, (IActivityPartition)element, elementName, writeContext);
                },
                ["CentralBufferNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var centralBufferNodeWriter = new CentralBufferNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    centralBufferNodeWriter.Write(xmlWriter, (ICentralBufferNode)element, elementName, writeContext);
                },
                ["ControlFlow"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var controlFlowWriter = new ControlFlowWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    controlFlowWriter.Write(xmlWriter, (IControlFlow)element, elementName, writeContext);
                },
                ["DataStoreNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var dataStoreNodeWriter = new DataStoreNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    dataStoreNodeWriter.Write(xmlWriter, (IDataStoreNode)element, elementName, writeContext);
                },
                ["DecisionNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var decisionNodeWriter = new DecisionNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    decisionNodeWriter.Write(xmlWriter, (IDecisionNode)element, elementName, writeContext);
                },
                ["ExceptionHandler"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var exceptionHandlerWriter = new ExceptionHandlerWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    exceptionHandlerWriter.Write(xmlWriter, (IExceptionHandler)element, elementName, writeContext);
                },
                ["FlowFinalNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var flowFinalNodeWriter = new FlowFinalNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    flowFinalNodeWriter.Write(xmlWriter, (IFlowFinalNode)element, elementName, writeContext);
                },
                ["ForkNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var forkNodeWriter = new ForkNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    forkNodeWriter.Write(xmlWriter, (IForkNode)element, elementName, writeContext);
                },
                ["InitialNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var initialNodeWriter = new InitialNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    initialNodeWriter.Write(xmlWriter, (IInitialNode)element, elementName, writeContext);
                },
                ["InterruptibleActivityRegion"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var interruptibleActivityRegionWriter = new InterruptibleActivityRegionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    interruptibleActivityRegionWriter.Write(xmlWriter, (IInterruptibleActivityRegion)element, elementName, writeContext);
                },
                ["JoinNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var joinNodeWriter = new JoinNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    joinNodeWriter.Write(xmlWriter, (IJoinNode)element, elementName, writeContext);
                },
                ["MergeNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var mergeNodeWriter = new MergeNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    mergeNodeWriter.Write(xmlWriter, (IMergeNode)element, elementName, writeContext);
                },
                ["ObjectFlow"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var objectFlowWriter = new ObjectFlowWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    objectFlowWriter.Write(xmlWriter, (IObjectFlow)element, elementName, writeContext);
                },
                ["Variable"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var variableWriter = new VariableWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    variableWriter.Write(xmlWriter, (IVariable)element, elementName, writeContext);
                },
                ["Duration"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var durationWriter = new DurationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    durationWriter.Write(xmlWriter, (IDuration)element, elementName, writeContext);
                },
                ["DurationConstraint"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var durationConstraintWriter = new DurationConstraintWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    durationConstraintWriter.Write(xmlWriter, (IDurationConstraint)element, elementName, writeContext);
                },
                ["DurationInterval"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var durationIntervalWriter = new DurationIntervalWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    durationIntervalWriter.Write(xmlWriter, (IDurationInterval)element, elementName, writeContext);
                },
                ["DurationObservation"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var durationObservationWriter = new DurationObservationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    durationObservationWriter.Write(xmlWriter, (IDurationObservation)element, elementName, writeContext);
                },
                ["Expression"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var expressionWriter = new ExpressionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    expressionWriter.Write(xmlWriter, (IExpression)element, elementName, writeContext);
                },
                ["Interval"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var intervalWriter = new IntervalWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    intervalWriter.Write(xmlWriter, (IInterval)element, elementName, writeContext);
                },
                ["IntervalConstraint"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var intervalConstraintWriter = new IntervalConstraintWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    intervalConstraintWriter.Write(xmlWriter, (IIntervalConstraint)element, elementName, writeContext);
                },
                ["LiteralBoolean"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var literalBooleanWriter = new LiteralBooleanWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    literalBooleanWriter.Write(xmlWriter, (ILiteralBoolean)element, elementName, writeContext);
                },
                ["LiteralInteger"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var literalIntegerWriter = new LiteralIntegerWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    literalIntegerWriter.Write(xmlWriter, (ILiteralInteger)element, elementName, writeContext);
                },
                ["LiteralNull"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var literalNullWriter = new LiteralNullWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    literalNullWriter.Write(xmlWriter, (ILiteralNull)element, elementName, writeContext);
                },
                ["LiteralReal"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var literalRealWriter = new LiteralRealWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    literalRealWriter.Write(xmlWriter, (ILiteralReal)element, elementName, writeContext);
                },
                ["LiteralString"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var literalStringWriter = new LiteralStringWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    literalStringWriter.Write(xmlWriter, (ILiteralString)element, elementName, writeContext);
                },
                ["LiteralUnlimitedNatural"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var literalUnlimitedNaturalWriter = new LiteralUnlimitedNaturalWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    literalUnlimitedNaturalWriter.Write(xmlWriter, (ILiteralUnlimitedNatural)element, elementName, writeContext);
                },
                ["OpaqueExpression"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var opaqueExpressionWriter = new OpaqueExpressionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    opaqueExpressionWriter.Write(xmlWriter, (IOpaqueExpression)element, elementName, writeContext);
                },
                ["StringExpression"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var stringExpressionWriter = new StringExpressionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    stringExpressionWriter.Write(xmlWriter, (IStringExpression)element, elementName, writeContext);
                },
                ["TimeConstraint"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var timeConstraintWriter = new TimeConstraintWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    timeConstraintWriter.Write(xmlWriter, (ITimeConstraint)element, elementName, writeContext);
                },
                ["TimeExpression"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var timeExpressionWriter = new TimeExpressionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    timeExpressionWriter.Write(xmlWriter, (ITimeExpression)element, elementName, writeContext);
                },
                ["TimeInterval"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var timeIntervalWriter = new TimeIntervalWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    timeIntervalWriter.Write(xmlWriter, (ITimeInterval)element, elementName, writeContext);
                },
                ["TimeObservation"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var timeObservationWriter = new TimeObservationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    timeObservationWriter.Write(xmlWriter, (ITimeObservation)element, elementName, writeContext);
                },
                ["Actor"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var actorWriter = new ActorWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    actorWriter.Write(xmlWriter, (IActor)element, elementName, writeContext);
                },
                ["Extend"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var extendWriter = new ExtendWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    extendWriter.Write(xmlWriter, (IExtend)element, elementName, writeContext);
                },
                ["ExtensionPoint"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var extensionPointWriter = new ExtensionPointWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    extensionPointWriter.Write(xmlWriter, (IExtensionPoint)element, elementName, writeContext);
                },
                ["Include"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var includeWriter = new IncludeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    includeWriter.Write(xmlWriter, (IInclude)element, elementName, writeContext);
                },
                ["UseCase"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var useCaseWriter = new UseCaseWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    useCaseWriter.Write(xmlWriter, (IUseCase)element, elementName, writeContext);
                },
                ["Association"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var associationWriter = new AssociationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    associationWriter.Write(xmlWriter, (IAssociation)element, elementName, writeContext);
                },
                ["AssociationClass"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var associationClassWriter = new AssociationClassWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    associationClassWriter.Write(xmlWriter, (IAssociationClass)element, elementName, writeContext);
                },
                ["Class"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var classWriter = new ClassWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    classWriter.Write(xmlWriter, (IClass)element, elementName, writeContext);
                },
                ["Collaboration"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var collaborationWriter = new CollaborationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    collaborationWriter.Write(xmlWriter, (ICollaboration)element, elementName, writeContext);
                },
                ["CollaborationUse"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var collaborationUseWriter = new CollaborationUseWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    collaborationUseWriter.Write(xmlWriter, (ICollaborationUse)element, elementName, writeContext);
                },
                ["Component"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var componentWriter = new ComponentWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    componentWriter.Write(xmlWriter, (IComponent)element, elementName, writeContext);
                },
                ["ComponentRealization"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var componentRealizationWriter = new ComponentRealizationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    componentRealizationWriter.Write(xmlWriter, (IComponentRealization)element, elementName, writeContext);
                },
                ["ConnectableElementTemplateParameter"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var connectableElementTemplateParameterWriter = new ConnectableElementTemplateParameterWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    connectableElementTemplateParameterWriter.Write(xmlWriter, (IConnectableElementTemplateParameter)element, elementName, writeContext);
                },
                ["Connector"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var connectorWriter = new ConnectorWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    connectorWriter.Write(xmlWriter, (IConnector)element, elementName, writeContext);
                },
                ["ConnectorEnd"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var connectorEndWriter = new ConnectorEndWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    connectorEndWriter.Write(xmlWriter, (IConnectorEnd)element, elementName, writeContext);
                },
                ["Port"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var portWriter = new PortWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    portWriter.Write(xmlWriter, (IPort)element, elementName, writeContext);
                },
                ["ConnectionPointReference"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var connectionPointReferenceWriter = new ConnectionPointReferenceWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    connectionPointReferenceWriter.Write(xmlWriter, (IConnectionPointReference)element, elementName, writeContext);
                },
                ["FinalState"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var finalStateWriter = new FinalStateWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    finalStateWriter.Write(xmlWriter, (IFinalState)element, elementName, writeContext);
                },
                ["ProtocolConformance"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var protocolConformanceWriter = new ProtocolConformanceWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    protocolConformanceWriter.Write(xmlWriter, (IProtocolConformance)element, elementName, writeContext);
                },
                ["ProtocolStateMachine"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var protocolStateMachineWriter = new ProtocolStateMachineWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    protocolStateMachineWriter.Write(xmlWriter, (IProtocolStateMachine)element, elementName, writeContext);
                },
                ["ProtocolTransition"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var protocolTransitionWriter = new ProtocolTransitionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    protocolTransitionWriter.Write(xmlWriter, (IProtocolTransition)element, elementName, writeContext);
                },
                ["Pseudostate"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var pseudostateWriter = new PseudostateWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    pseudostateWriter.Write(xmlWriter, (IPseudostate)element, elementName, writeContext);
                },
                ["Region"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var regionWriter = new RegionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    regionWriter.Write(xmlWriter, (IRegion)element, elementName, writeContext);
                },
                ["State"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var stateWriter = new StateWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    stateWriter.Write(xmlWriter, (IState)element, elementName, writeContext);
                },
                ["StateMachine"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var stateMachineWriter = new StateMachineWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    stateMachineWriter.Write(xmlWriter, (IStateMachine)element, elementName, writeContext);
                },
                ["Transition"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var transitionWriter = new TransitionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    transitionWriter.Write(xmlWriter, (ITransition)element, elementName, writeContext);
                },
                ["DataType"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var dataTypeWriter = new DataTypeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    dataTypeWriter.Write(xmlWriter, (IDataType)element, elementName, writeContext);
                },
                ["Enumeration"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var enumerationWriter = new EnumerationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    enumerationWriter.Write(xmlWriter, (IEnumeration)element, elementName, writeContext);
                },
                ["EnumerationLiteral"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var enumerationLiteralWriter = new EnumerationLiteralWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    enumerationLiteralWriter.Write(xmlWriter, (IEnumerationLiteral)element, elementName, writeContext);
                },
                ["Interface"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var interfaceWriter = new InterfaceWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    interfaceWriter.Write(xmlWriter, (IInterface)element, elementName, writeContext);
                },
                ["InterfaceRealization"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var interfaceRealizationWriter = new InterfaceRealizationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    interfaceRealizationWriter.Write(xmlWriter, (IInterfaceRealization)element, elementName, writeContext);
                },
                ["PrimitiveType"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var primitiveTypeWriter = new PrimitiveTypeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    primitiveTypeWriter.Write(xmlWriter, (IPrimitiveType)element, elementName, writeContext);
                },
                ["Reception"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var receptionWriter = new ReceptionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    receptionWriter.Write(xmlWriter, (IReception)element, elementName, writeContext);
                },
                ["Signal"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var signalWriter = new SignalWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    signalWriter.Write(xmlWriter, (ISignal)element, elementName, writeContext);
                },
                ["Extension"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var extensionWriter = new ExtensionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    extensionWriter.Write(xmlWriter, (IExtension)element, elementName, writeContext);
                },
                ["ExtensionEnd"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var extensionEndWriter = new ExtensionEndWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    extensionEndWriter.Write(xmlWriter, (IExtensionEnd)element, elementName, writeContext);
                },
                ["Image"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var imageWriter = new ImageWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    imageWriter.Write(xmlWriter, (IImage)element, elementName, writeContext);
                },
                ["Model"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var modelWriter = new ModelWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    modelWriter.Write(xmlWriter, (IModel)element, elementName, writeContext);
                },
                ["Package"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var packageWriter = new PackageWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    packageWriter.Write(xmlWriter, (IPackage)element, elementName, writeContext);
                },
                ["PackageMerge"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var packageMergeWriter = new PackageMergeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    packageMergeWriter.Write(xmlWriter, (IPackageMerge)element, elementName, writeContext);
                },
                ["Profile"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var profileWriter = new ProfileWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    profileWriter.Write(xmlWriter, (IProfile)element, elementName, writeContext);
                },
                ["ProfileApplication"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var profileApplicationWriter = new ProfileApplicationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    profileApplicationWriter.Write(xmlWriter, (IProfileApplication)element, elementName, writeContext);
                },
                ["Stereotype"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var stereotypeWriter = new StereotypeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    stereotypeWriter.Write(xmlWriter, (IStereotype)element, elementName, writeContext);
                },
                ["ActionExecutionSpecification"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var actionExecutionSpecificationWriter = new ActionExecutionSpecificationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    actionExecutionSpecificationWriter.Write(xmlWriter, (IActionExecutionSpecification)element, elementName, writeContext);
                },
                ["BehaviorExecutionSpecification"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var behaviorExecutionSpecificationWriter = new BehaviorExecutionSpecificationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    behaviorExecutionSpecificationWriter.Write(xmlWriter, (IBehaviorExecutionSpecification)element, elementName, writeContext);
                },
                ["CombinedFragment"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var combinedFragmentWriter = new CombinedFragmentWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    combinedFragmentWriter.Write(xmlWriter, (ICombinedFragment)element, elementName, writeContext);
                },
                ["ConsiderIgnoreFragment"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var considerIgnoreFragmentWriter = new ConsiderIgnoreFragmentWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    considerIgnoreFragmentWriter.Write(xmlWriter, (IConsiderIgnoreFragment)element, elementName, writeContext);
                },
                ["Continuation"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var continuationWriter = new ContinuationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    continuationWriter.Write(xmlWriter, (IContinuation)element, elementName, writeContext);
                },
                ["DestructionOccurrenceSpecification"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var destructionOccurrenceSpecificationWriter = new DestructionOccurrenceSpecificationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    destructionOccurrenceSpecificationWriter.Write(xmlWriter, (IDestructionOccurrenceSpecification)element, elementName, writeContext);
                },
                ["ExecutionOccurrenceSpecification"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var executionOccurrenceSpecificationWriter = new ExecutionOccurrenceSpecificationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    executionOccurrenceSpecificationWriter.Write(xmlWriter, (IExecutionOccurrenceSpecification)element, elementName, writeContext);
                },
                ["Gate"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var gateWriter = new GateWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    gateWriter.Write(xmlWriter, (IGate)element, elementName, writeContext);
                },
                ["GeneralOrdering"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var generalOrderingWriter = new GeneralOrderingWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    generalOrderingWriter.Write(xmlWriter, (IGeneralOrdering)element, elementName, writeContext);
                },
                ["Interaction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var interactionWriter = new InteractionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    interactionWriter.Write(xmlWriter, (IInteraction)element, elementName, writeContext);
                },
                ["InteractionConstraint"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var interactionConstraintWriter = new InteractionConstraintWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    interactionConstraintWriter.Write(xmlWriter, (IInteractionConstraint)element, elementName, writeContext);
                },
                ["InteractionOperand"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var interactionOperandWriter = new InteractionOperandWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    interactionOperandWriter.Write(xmlWriter, (IInteractionOperand)element, elementName, writeContext);
                },
                ["InteractionUse"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var interactionUseWriter = new InteractionUseWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    interactionUseWriter.Write(xmlWriter, (IInteractionUse)element, elementName, writeContext);
                },
                ["Lifeline"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var lifelineWriter = new LifelineWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    lifelineWriter.Write(xmlWriter, (ILifeline)element, elementName, writeContext);
                },
                ["Message"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var messageWriter = new MessageWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    messageWriter.Write(xmlWriter, (IMessage)element, elementName, writeContext);
                },
                ["MessageOccurrenceSpecification"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var messageOccurrenceSpecificationWriter = new MessageOccurrenceSpecificationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    messageOccurrenceSpecificationWriter.Write(xmlWriter, (IMessageOccurrenceSpecification)element, elementName, writeContext);
                },
                ["OccurrenceSpecification"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var occurrenceSpecificationWriter = new OccurrenceSpecificationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    occurrenceSpecificationWriter.Write(xmlWriter, (IOccurrenceSpecification)element, elementName, writeContext);
                },
                ["PartDecomposition"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var partDecompositionWriter = new PartDecompositionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    partDecompositionWriter.Write(xmlWriter, (IPartDecomposition)element, elementName, writeContext);
                },
                ["StateInvariant"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var stateInvariantWriter = new StateInvariantWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    stateInvariantWriter.Write(xmlWriter, (IStateInvariant)element, elementName, writeContext);
                },
                ["InformationFlow"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var informationFlowWriter = new InformationFlowWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    informationFlowWriter.Write(xmlWriter, (IInformationFlow)element, elementName, writeContext);
                },
                ["InformationItem"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var informationItemWriter = new InformationItemWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    informationItemWriter.Write(xmlWriter, (IInformationItem)element, elementName, writeContext);
                },
                ["Artifact"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var artifactWriter = new ArtifactWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    artifactWriter.Write(xmlWriter, (IArtifact)element, elementName, writeContext);
                },
                ["CommunicationPath"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var communicationPathWriter = new CommunicationPathWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    communicationPathWriter.Write(xmlWriter, (ICommunicationPath)element, elementName, writeContext);
                },
                ["Deployment"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var deploymentWriter = new DeploymentWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    deploymentWriter.Write(xmlWriter, (IDeployment)element, elementName, writeContext);
                },
                ["DeploymentSpecification"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var deploymentSpecificationWriter = new DeploymentSpecificationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    deploymentSpecificationWriter.Write(xmlWriter, (IDeploymentSpecification)element, elementName, writeContext);
                },
                ["Device"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var deviceWriter = new DeviceWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    deviceWriter.Write(xmlWriter, (IDevice)element, elementName, writeContext);
                },
                ["ExecutionEnvironment"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var executionEnvironmentWriter = new ExecutionEnvironmentWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    executionEnvironmentWriter.Write(xmlWriter, (IExecutionEnvironment)element, elementName, writeContext);
                },
                ["Manifestation"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var manifestationWriter = new ManifestationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    manifestationWriter.Write(xmlWriter, (IManifestation)element, elementName, writeContext);
                },
                ["Node"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var nodeWriter = new NodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    nodeWriter.Write(xmlWriter, (INode)element, elementName, writeContext);
                },
                ["Abstraction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var abstractionWriter = new AbstractionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    abstractionWriter.Write(xmlWriter, (IAbstraction)element, elementName, writeContext);
                },
                ["Comment"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var commentWriter = new CommentWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    commentWriter.Write(xmlWriter, (IComment)element, elementName, writeContext);
                },
                ["Constraint"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var constraintWriter = new ConstraintWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    constraintWriter.Write(xmlWriter, (IConstraint)element, elementName, writeContext);
                },
                ["Dependency"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var dependencyWriter = new DependencyWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    dependencyWriter.Write(xmlWriter, (IDependency)element, elementName, writeContext);
                },
                ["ElementImport"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var elementImportWriter = new ElementImportWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    elementImportWriter.Write(xmlWriter, (IElementImport)element, elementName, writeContext);
                },
                ["PackageImport"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var packageImportWriter = new PackageImportWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    packageImportWriter.Write(xmlWriter, (IPackageImport)element, elementName, writeContext);
                },
                ["Realization"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var realizationWriter = new RealizationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    realizationWriter.Write(xmlWriter, (IRealization)element, elementName, writeContext);
                },
                ["TemplateBinding"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var templateBindingWriter = new TemplateBindingWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    templateBindingWriter.Write(xmlWriter, (ITemplateBinding)element, elementName, writeContext);
                },
                ["TemplateParameter"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var templateParameterWriter = new TemplateParameterWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    templateParameterWriter.Write(xmlWriter, (ITemplateParameter)element, elementName, writeContext);
                },
                ["TemplateParameterSubstitution"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var templateParameterSubstitutionWriter = new TemplateParameterSubstitutionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    templateParameterSubstitutionWriter.Write(xmlWriter, (ITemplateParameterSubstitution)element, elementName, writeContext);
                },
                ["TemplateSignature"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var templateSignatureWriter = new TemplateSignatureWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    templateSignatureWriter.Write(xmlWriter, (ITemplateSignature)element, elementName, writeContext);
                },
                ["Usage"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var usageWriter = new UsageWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    usageWriter.Write(xmlWriter, (IUsage)element, elementName, writeContext);
                },
                ["AnyReceiveEvent"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var anyReceiveEventWriter = new AnyReceiveEventWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    anyReceiveEventWriter.Write(xmlWriter, (IAnyReceiveEvent)element, elementName, writeContext);
                },
                ["CallEvent"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var callEventWriter = new CallEventWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    callEventWriter.Write(xmlWriter, (ICallEvent)element, elementName, writeContext);
                },
                ["ChangeEvent"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var changeEventWriter = new ChangeEventWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    changeEventWriter.Write(xmlWriter, (IChangeEvent)element, elementName, writeContext);
                },
                ["FunctionBehavior"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var functionBehaviorWriter = new FunctionBehaviorWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    functionBehaviorWriter.Write(xmlWriter, (IFunctionBehavior)element, elementName, writeContext);
                },
                ["OpaqueBehavior"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var opaqueBehaviorWriter = new OpaqueBehaviorWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    opaqueBehaviorWriter.Write(xmlWriter, (IOpaqueBehavior)element, elementName, writeContext);
                },
                ["SignalEvent"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var signalEventWriter = new SignalEventWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    signalEventWriter.Write(xmlWriter, (ISignalEvent)element, elementName, writeContext);
                },
                ["TimeEvent"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var timeEventWriter = new TimeEventWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    timeEventWriter.Write(xmlWriter, (ITimeEvent)element, elementName, writeContext);
                },
                ["Trigger"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var triggerWriter = new TriggerWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    triggerWriter.Write(xmlWriter, (ITrigger)element, elementName, writeContext);
                },
                ["Substitution"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var substitutionWriter = new SubstitutionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    substitutionWriter.Write(xmlWriter, (ISubstitution)element, elementName, writeContext);
                },
                ["ClassifierTemplateParameter"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var classifierTemplateParameterWriter = new ClassifierTemplateParameterWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    classifierTemplateParameterWriter.Write(xmlWriter, (IClassifierTemplateParameter)element, elementName, writeContext);
                },
                ["Generalization"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var generalizationWriter = new GeneralizationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    generalizationWriter.Write(xmlWriter, (IGeneralization)element, elementName, writeContext);
                },
                ["GeneralizationSet"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var generalizationSetWriter = new GeneralizationSetWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    generalizationSetWriter.Write(xmlWriter, (IGeneralizationSet)element, elementName, writeContext);
                },
                ["InstanceSpecification"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var instanceSpecificationWriter = new InstanceSpecificationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    instanceSpecificationWriter.Write(xmlWriter, (IInstanceSpecification)element, elementName, writeContext);
                },
                ["InstanceValue"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var instanceValueWriter = new InstanceValueWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    instanceValueWriter.Write(xmlWriter, (IInstanceValue)element, elementName, writeContext);
                },
                ["Operation"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var operationWriter = new OperationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    operationWriter.Write(xmlWriter, (IOperation)element, elementName, writeContext);
                },
                ["OperationTemplateParameter"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var operationTemplateParameterWriter = new OperationTemplateParameterWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    operationTemplateParameterWriter.Write(xmlWriter, (IOperationTemplateParameter)element, elementName, writeContext);
                },
                ["Parameter"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var parameterWriter = new ParameterWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    parameterWriter.Write(xmlWriter, (IParameter)element, elementName, writeContext);
                },
                ["ParameterSet"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var parameterSetWriter = new ParameterSetWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    parameterSetWriter.Write(xmlWriter, (IParameterSet)element, elementName, writeContext);
                },
                ["Property"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var propertyWriter = new PropertyWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    propertyWriter.Write(xmlWriter, (IProperty)element, elementName, writeContext);
                },
                ["RedefinableTemplateSignature"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var redefinableTemplateSignatureWriter = new RedefinableTemplateSignatureWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    redefinableTemplateSignatureWriter.Write(xmlWriter, (IRedefinableTemplateSignature)element, elementName, writeContext);
                },
                ["Slot"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var slotWriter = new SlotWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    slotWriter.Write(xmlWriter, (ISlot)element, elementName, writeContext);
                },
                ["ValueSpecificationAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var valueSpecificationActionWriter = new ValueSpecificationActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    valueSpecificationActionWriter.Write(xmlWriter, (IValueSpecificationAction)element, elementName, writeContext);
                },
                ["AcceptCallAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var acceptCallActionWriter = new AcceptCallActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    acceptCallActionWriter.Write(xmlWriter, (IAcceptCallAction)element, elementName, writeContext);
                },
                ["AcceptEventAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var acceptEventActionWriter = new AcceptEventActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    acceptEventActionWriter.Write(xmlWriter, (IAcceptEventAction)element, elementName, writeContext);
                },
                ["ActionInputPin"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var actionInputPinWriter = new ActionInputPinWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    actionInputPinWriter.Write(xmlWriter, (IActionInputPin)element, elementName, writeContext);
                },
                ["AddStructuralFeatureValueAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var addStructuralFeatureValueActionWriter = new AddStructuralFeatureValueActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    addStructuralFeatureValueActionWriter.Write(xmlWriter, (IAddStructuralFeatureValueAction)element, elementName, writeContext);
                },
                ["AddVariableValueAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var addVariableValueActionWriter = new AddVariableValueActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    addVariableValueActionWriter.Write(xmlWriter, (IAddVariableValueAction)element, elementName, writeContext);
                },
                ["BroadcastSignalAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var broadcastSignalActionWriter = new BroadcastSignalActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    broadcastSignalActionWriter.Write(xmlWriter, (IBroadcastSignalAction)element, elementName, writeContext);
                },
                ["CallBehaviorAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var callBehaviorActionWriter = new CallBehaviorActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    callBehaviorActionWriter.Write(xmlWriter, (ICallBehaviorAction)element, elementName, writeContext);
                },
                ["CallOperationAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var callOperationActionWriter = new CallOperationActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    callOperationActionWriter.Write(xmlWriter, (ICallOperationAction)element, elementName, writeContext);
                },
                ["Clause"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var clauseWriter = new ClauseWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    clauseWriter.Write(xmlWriter, (IClause)element, elementName, writeContext);
                },
                ["ClearAssociationAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var clearAssociationActionWriter = new ClearAssociationActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    clearAssociationActionWriter.Write(xmlWriter, (IClearAssociationAction)element, elementName, writeContext);
                },
                ["ClearStructuralFeatureAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var clearStructuralFeatureActionWriter = new ClearStructuralFeatureActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    clearStructuralFeatureActionWriter.Write(xmlWriter, (IClearStructuralFeatureAction)element, elementName, writeContext);
                },
                ["ClearVariableAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var clearVariableActionWriter = new ClearVariableActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    clearVariableActionWriter.Write(xmlWriter, (IClearVariableAction)element, elementName, writeContext);
                },
                ["ConditionalNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var conditionalNodeWriter = new ConditionalNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    conditionalNodeWriter.Write(xmlWriter, (IConditionalNode)element, elementName, writeContext);
                },
                ["CreateLinkAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var createLinkActionWriter = new CreateLinkActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    createLinkActionWriter.Write(xmlWriter, (ICreateLinkAction)element, elementName, writeContext);
                },
                ["CreateLinkObjectAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var createLinkObjectActionWriter = new CreateLinkObjectActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    createLinkObjectActionWriter.Write(xmlWriter, (ICreateLinkObjectAction)element, elementName, writeContext);
                },
                ["CreateObjectAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var createObjectActionWriter = new CreateObjectActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    createObjectActionWriter.Write(xmlWriter, (ICreateObjectAction)element, elementName, writeContext);
                },
                ["DestroyLinkAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var destroyLinkActionWriter = new DestroyLinkActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    destroyLinkActionWriter.Write(xmlWriter, (IDestroyLinkAction)element, elementName, writeContext);
                },
                ["DestroyObjectAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var destroyObjectActionWriter = new DestroyObjectActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    destroyObjectActionWriter.Write(xmlWriter, (IDestroyObjectAction)element, elementName, writeContext);
                },
                ["ExpansionNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var expansionNodeWriter = new ExpansionNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    expansionNodeWriter.Write(xmlWriter, (IExpansionNode)element, elementName, writeContext);
                },
                ["ExpansionRegion"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var expansionRegionWriter = new ExpansionRegionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    expansionRegionWriter.Write(xmlWriter, (IExpansionRegion)element, elementName, writeContext);
                },
                ["InputPin"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var inputPinWriter = new InputPinWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    inputPinWriter.Write(xmlWriter, (IInputPin)element, elementName, writeContext);
                },
                ["LinkEndCreationData"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var linkEndCreationDataWriter = new LinkEndCreationDataWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    linkEndCreationDataWriter.Write(xmlWriter, (ILinkEndCreationData)element, elementName, writeContext);
                },
                ["LinkEndData"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var linkEndDataWriter = new LinkEndDataWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    linkEndDataWriter.Write(xmlWriter, (ILinkEndData)element, elementName, writeContext);
                },
                ["LinkEndDestructionData"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var linkEndDestructionDataWriter = new LinkEndDestructionDataWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    linkEndDestructionDataWriter.Write(xmlWriter, (ILinkEndDestructionData)element, elementName, writeContext);
                },
                ["LoopNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var loopNodeWriter = new LoopNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    loopNodeWriter.Write(xmlWriter, (ILoopNode)element, elementName, writeContext);
                },
                ["OpaqueAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var opaqueActionWriter = new OpaqueActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    opaqueActionWriter.Write(xmlWriter, (IOpaqueAction)element, elementName, writeContext);
                },
                ["OutputPin"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var outputPinWriter = new OutputPinWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    outputPinWriter.Write(xmlWriter, (IOutputPin)element, elementName, writeContext);
                },
                ["QualifierValue"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var qualifierValueWriter = new QualifierValueWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    qualifierValueWriter.Write(xmlWriter, (IQualifierValue)element, elementName, writeContext);
                },
                ["RaiseExceptionAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var raiseExceptionActionWriter = new RaiseExceptionActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    raiseExceptionActionWriter.Write(xmlWriter, (IRaiseExceptionAction)element, elementName, writeContext);
                },
                ["ReadExtentAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var readExtentActionWriter = new ReadExtentActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    readExtentActionWriter.Write(xmlWriter, (IReadExtentAction)element, elementName, writeContext);
                },
                ["ReadIsClassifiedObjectAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var readIsClassifiedObjectActionWriter = new ReadIsClassifiedObjectActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    readIsClassifiedObjectActionWriter.Write(xmlWriter, (IReadIsClassifiedObjectAction)element, elementName, writeContext);
                },
                ["ReadLinkAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var readLinkActionWriter = new ReadLinkActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    readLinkActionWriter.Write(xmlWriter, (IReadLinkAction)element, elementName, writeContext);
                },
                ["ReadLinkObjectEndAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var readLinkObjectEndActionWriter = new ReadLinkObjectEndActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    readLinkObjectEndActionWriter.Write(xmlWriter, (IReadLinkObjectEndAction)element, elementName, writeContext);
                },
                ["ReadLinkObjectEndQualifierAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var readLinkObjectEndQualifierActionWriter = new ReadLinkObjectEndQualifierActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    readLinkObjectEndQualifierActionWriter.Write(xmlWriter, (IReadLinkObjectEndQualifierAction)element, elementName, writeContext);
                },
                ["ReadSelfAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var readSelfActionWriter = new ReadSelfActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    readSelfActionWriter.Write(xmlWriter, (IReadSelfAction)element, elementName, writeContext);
                },
                ["ReadStructuralFeatureAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var readStructuralFeatureActionWriter = new ReadStructuralFeatureActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    readStructuralFeatureActionWriter.Write(xmlWriter, (IReadStructuralFeatureAction)element, elementName, writeContext);
                },
                ["ReadVariableAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var readVariableActionWriter = new ReadVariableActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    readVariableActionWriter.Write(xmlWriter, (IReadVariableAction)element, elementName, writeContext);
                },
                ["ReclassifyObjectAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var reclassifyObjectActionWriter = new ReclassifyObjectActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    reclassifyObjectActionWriter.Write(xmlWriter, (IReclassifyObjectAction)element, elementName, writeContext);
                },
                ["ReduceAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var reduceActionWriter = new ReduceActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    reduceActionWriter.Write(xmlWriter, (IReduceAction)element, elementName, writeContext);
                },
                ["RemoveStructuralFeatureValueAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var removeStructuralFeatureValueActionWriter = new RemoveStructuralFeatureValueActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    removeStructuralFeatureValueActionWriter.Write(xmlWriter, (IRemoveStructuralFeatureValueAction)element, elementName, writeContext);
                },
                ["RemoveVariableValueAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var removeVariableValueActionWriter = new RemoveVariableValueActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    removeVariableValueActionWriter.Write(xmlWriter, (IRemoveVariableValueAction)element, elementName, writeContext);
                },
                ["ReplyAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var replyActionWriter = new ReplyActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    replyActionWriter.Write(xmlWriter, (IReplyAction)element, elementName, writeContext);
                },
                ["SendObjectAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var sendObjectActionWriter = new SendObjectActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    sendObjectActionWriter.Write(xmlWriter, (ISendObjectAction)element, elementName, writeContext);
                },
                ["SendSignalAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var sendSignalActionWriter = new SendSignalActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    sendSignalActionWriter.Write(xmlWriter, (ISendSignalAction)element, elementName, writeContext);
                },
                ["SequenceNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var sequenceNodeWriter = new SequenceNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    sequenceNodeWriter.Write(xmlWriter, (ISequenceNode)element, elementName, writeContext);
                },
                ["StartClassifierBehaviorAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var startClassifierBehaviorActionWriter = new StartClassifierBehaviorActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    startClassifierBehaviorActionWriter.Write(xmlWriter, (IStartClassifierBehaviorAction)element, elementName, writeContext);
                },
                ["StartObjectBehaviorAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var startObjectBehaviorActionWriter = new StartObjectBehaviorActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    startObjectBehaviorActionWriter.Write(xmlWriter, (IStartObjectBehaviorAction)element, elementName, writeContext);
                },
                ["StructuredActivityNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var structuredActivityNodeWriter = new StructuredActivityNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    structuredActivityNodeWriter.Write(xmlWriter, (IStructuredActivityNode)element, elementName, writeContext);
                },
                ["TestIdentityAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var testIdentityActionWriter = new TestIdentityActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    testIdentityActionWriter.Write(xmlWriter, (ITestIdentityAction)element, elementName, writeContext);
                },
                ["UnmarshallAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var unmarshallActionWriter = new UnmarshallActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    unmarshallActionWriter.Write(xmlWriter, (IUnmarshallAction)element, elementName, writeContext);
                },
                ["ValuePin"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var valuePinWriter = new ValuePinWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    valuePinWriter.Write(xmlWriter, (IValuePin)element, elementName, writeContext);
                },
            };

            this.writerAsyncCache = new Dictionary<string, Func<XmlWriter, IXmiElement, string, IXmiWriteContext, Task>>
            {
                ["Activity"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var activityWriter = new ActivityWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return activityWriter.WriteAsync(xmlWriter, (IActivity)element, elementName, writeContext);
                },
                ["ActivityFinalNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var activityFinalNodeWriter = new ActivityFinalNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return activityFinalNodeWriter.WriteAsync(xmlWriter, (IActivityFinalNode)element, elementName, writeContext);
                },
                ["ActivityParameterNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var activityParameterNodeWriter = new ActivityParameterNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return activityParameterNodeWriter.WriteAsync(xmlWriter, (IActivityParameterNode)element, elementName, writeContext);
                },
                ["ActivityPartition"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var activityPartitionWriter = new ActivityPartitionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return activityPartitionWriter.WriteAsync(xmlWriter, (IActivityPartition)element, elementName, writeContext);
                },
                ["CentralBufferNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var centralBufferNodeWriter = new CentralBufferNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return centralBufferNodeWriter.WriteAsync(xmlWriter, (ICentralBufferNode)element, elementName, writeContext);
                },
                ["ControlFlow"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var controlFlowWriter = new ControlFlowWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return controlFlowWriter.WriteAsync(xmlWriter, (IControlFlow)element, elementName, writeContext);
                },
                ["DataStoreNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var dataStoreNodeWriter = new DataStoreNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return dataStoreNodeWriter.WriteAsync(xmlWriter, (IDataStoreNode)element, elementName, writeContext);
                },
                ["DecisionNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var decisionNodeWriter = new DecisionNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return decisionNodeWriter.WriteAsync(xmlWriter, (IDecisionNode)element, elementName, writeContext);
                },
                ["ExceptionHandler"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var exceptionHandlerWriter = new ExceptionHandlerWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return exceptionHandlerWriter.WriteAsync(xmlWriter, (IExceptionHandler)element, elementName, writeContext);
                },
                ["FlowFinalNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var flowFinalNodeWriter = new FlowFinalNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return flowFinalNodeWriter.WriteAsync(xmlWriter, (IFlowFinalNode)element, elementName, writeContext);
                },
                ["ForkNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var forkNodeWriter = new ForkNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return forkNodeWriter.WriteAsync(xmlWriter, (IForkNode)element, elementName, writeContext);
                },
                ["InitialNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var initialNodeWriter = new InitialNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return initialNodeWriter.WriteAsync(xmlWriter, (IInitialNode)element, elementName, writeContext);
                },
                ["InterruptibleActivityRegion"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var interruptibleActivityRegionWriter = new InterruptibleActivityRegionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return interruptibleActivityRegionWriter.WriteAsync(xmlWriter, (IInterruptibleActivityRegion)element, elementName, writeContext);
                },
                ["JoinNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var joinNodeWriter = new JoinNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return joinNodeWriter.WriteAsync(xmlWriter, (IJoinNode)element, elementName, writeContext);
                },
                ["MergeNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var mergeNodeWriter = new MergeNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return mergeNodeWriter.WriteAsync(xmlWriter, (IMergeNode)element, elementName, writeContext);
                },
                ["ObjectFlow"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var objectFlowWriter = new ObjectFlowWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return objectFlowWriter.WriteAsync(xmlWriter, (IObjectFlow)element, elementName, writeContext);
                },
                ["Variable"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var variableWriter = new VariableWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return variableWriter.WriteAsync(xmlWriter, (IVariable)element, elementName, writeContext);
                },
                ["Duration"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var durationWriter = new DurationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return durationWriter.WriteAsync(xmlWriter, (IDuration)element, elementName, writeContext);
                },
                ["DurationConstraint"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var durationConstraintWriter = new DurationConstraintWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return durationConstraintWriter.WriteAsync(xmlWriter, (IDurationConstraint)element, elementName, writeContext);
                },
                ["DurationInterval"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var durationIntervalWriter = new DurationIntervalWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return durationIntervalWriter.WriteAsync(xmlWriter, (IDurationInterval)element, elementName, writeContext);
                },
                ["DurationObservation"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var durationObservationWriter = new DurationObservationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return durationObservationWriter.WriteAsync(xmlWriter, (IDurationObservation)element, elementName, writeContext);
                },
                ["Expression"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var expressionWriter = new ExpressionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return expressionWriter.WriteAsync(xmlWriter, (IExpression)element, elementName, writeContext);
                },
                ["Interval"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var intervalWriter = new IntervalWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return intervalWriter.WriteAsync(xmlWriter, (IInterval)element, elementName, writeContext);
                },
                ["IntervalConstraint"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var intervalConstraintWriter = new IntervalConstraintWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return intervalConstraintWriter.WriteAsync(xmlWriter, (IIntervalConstraint)element, elementName, writeContext);
                },
                ["LiteralBoolean"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var literalBooleanWriter = new LiteralBooleanWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return literalBooleanWriter.WriteAsync(xmlWriter, (ILiteralBoolean)element, elementName, writeContext);
                },
                ["LiteralInteger"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var literalIntegerWriter = new LiteralIntegerWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return literalIntegerWriter.WriteAsync(xmlWriter, (ILiteralInteger)element, elementName, writeContext);
                },
                ["LiteralNull"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var literalNullWriter = new LiteralNullWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return literalNullWriter.WriteAsync(xmlWriter, (ILiteralNull)element, elementName, writeContext);
                },
                ["LiteralReal"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var literalRealWriter = new LiteralRealWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return literalRealWriter.WriteAsync(xmlWriter, (ILiteralReal)element, elementName, writeContext);
                },
                ["LiteralString"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var literalStringWriter = new LiteralStringWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return literalStringWriter.WriteAsync(xmlWriter, (ILiteralString)element, elementName, writeContext);
                },
                ["LiteralUnlimitedNatural"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var literalUnlimitedNaturalWriter = new LiteralUnlimitedNaturalWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return literalUnlimitedNaturalWriter.WriteAsync(xmlWriter, (ILiteralUnlimitedNatural)element, elementName, writeContext);
                },
                ["OpaqueExpression"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var opaqueExpressionWriter = new OpaqueExpressionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return opaqueExpressionWriter.WriteAsync(xmlWriter, (IOpaqueExpression)element, elementName, writeContext);
                },
                ["StringExpression"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var stringExpressionWriter = new StringExpressionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return stringExpressionWriter.WriteAsync(xmlWriter, (IStringExpression)element, elementName, writeContext);
                },
                ["TimeConstraint"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var timeConstraintWriter = new TimeConstraintWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return timeConstraintWriter.WriteAsync(xmlWriter, (ITimeConstraint)element, elementName, writeContext);
                },
                ["TimeExpression"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var timeExpressionWriter = new TimeExpressionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return timeExpressionWriter.WriteAsync(xmlWriter, (ITimeExpression)element, elementName, writeContext);
                },
                ["TimeInterval"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var timeIntervalWriter = new TimeIntervalWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return timeIntervalWriter.WriteAsync(xmlWriter, (ITimeInterval)element, elementName, writeContext);
                },
                ["TimeObservation"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var timeObservationWriter = new TimeObservationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return timeObservationWriter.WriteAsync(xmlWriter, (ITimeObservation)element, elementName, writeContext);
                },
                ["Actor"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var actorWriter = new ActorWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return actorWriter.WriteAsync(xmlWriter, (IActor)element, elementName, writeContext);
                },
                ["Extend"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var extendWriter = new ExtendWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return extendWriter.WriteAsync(xmlWriter, (IExtend)element, elementName, writeContext);
                },
                ["ExtensionPoint"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var extensionPointWriter = new ExtensionPointWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return extensionPointWriter.WriteAsync(xmlWriter, (IExtensionPoint)element, elementName, writeContext);
                },
                ["Include"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var includeWriter = new IncludeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return includeWriter.WriteAsync(xmlWriter, (IInclude)element, elementName, writeContext);
                },
                ["UseCase"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var useCaseWriter = new UseCaseWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return useCaseWriter.WriteAsync(xmlWriter, (IUseCase)element, elementName, writeContext);
                },
                ["Association"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var associationWriter = new AssociationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return associationWriter.WriteAsync(xmlWriter, (IAssociation)element, elementName, writeContext);
                },
                ["AssociationClass"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var associationClassWriter = new AssociationClassWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return associationClassWriter.WriteAsync(xmlWriter, (IAssociationClass)element, elementName, writeContext);
                },
                ["Class"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var classWriter = new ClassWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return classWriter.WriteAsync(xmlWriter, (IClass)element, elementName, writeContext);
                },
                ["Collaboration"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var collaborationWriter = new CollaborationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return collaborationWriter.WriteAsync(xmlWriter, (ICollaboration)element, elementName, writeContext);
                },
                ["CollaborationUse"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var collaborationUseWriter = new CollaborationUseWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return collaborationUseWriter.WriteAsync(xmlWriter, (ICollaborationUse)element, elementName, writeContext);
                },
                ["Component"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var componentWriter = new ComponentWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return componentWriter.WriteAsync(xmlWriter, (IComponent)element, elementName, writeContext);
                },
                ["ComponentRealization"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var componentRealizationWriter = new ComponentRealizationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return componentRealizationWriter.WriteAsync(xmlWriter, (IComponentRealization)element, elementName, writeContext);
                },
                ["ConnectableElementTemplateParameter"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var connectableElementTemplateParameterWriter = new ConnectableElementTemplateParameterWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return connectableElementTemplateParameterWriter.WriteAsync(xmlWriter, (IConnectableElementTemplateParameter)element, elementName, writeContext);
                },
                ["Connector"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var connectorWriter = new ConnectorWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return connectorWriter.WriteAsync(xmlWriter, (IConnector)element, elementName, writeContext);
                },
                ["ConnectorEnd"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var connectorEndWriter = new ConnectorEndWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return connectorEndWriter.WriteAsync(xmlWriter, (IConnectorEnd)element, elementName, writeContext);
                },
                ["Port"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var portWriter = new PortWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return portWriter.WriteAsync(xmlWriter, (IPort)element, elementName, writeContext);
                },
                ["ConnectionPointReference"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var connectionPointReferenceWriter = new ConnectionPointReferenceWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return connectionPointReferenceWriter.WriteAsync(xmlWriter, (IConnectionPointReference)element, elementName, writeContext);
                },
                ["FinalState"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var finalStateWriter = new FinalStateWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return finalStateWriter.WriteAsync(xmlWriter, (IFinalState)element, elementName, writeContext);
                },
                ["ProtocolConformance"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var protocolConformanceWriter = new ProtocolConformanceWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return protocolConformanceWriter.WriteAsync(xmlWriter, (IProtocolConformance)element, elementName, writeContext);
                },
                ["ProtocolStateMachine"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var protocolStateMachineWriter = new ProtocolStateMachineWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return protocolStateMachineWriter.WriteAsync(xmlWriter, (IProtocolStateMachine)element, elementName, writeContext);
                },
                ["ProtocolTransition"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var protocolTransitionWriter = new ProtocolTransitionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return protocolTransitionWriter.WriteAsync(xmlWriter, (IProtocolTransition)element, elementName, writeContext);
                },
                ["Pseudostate"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var pseudostateWriter = new PseudostateWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return pseudostateWriter.WriteAsync(xmlWriter, (IPseudostate)element, elementName, writeContext);
                },
                ["Region"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var regionWriter = new RegionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return regionWriter.WriteAsync(xmlWriter, (IRegion)element, elementName, writeContext);
                },
                ["State"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var stateWriter = new StateWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return stateWriter.WriteAsync(xmlWriter, (IState)element, elementName, writeContext);
                },
                ["StateMachine"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var stateMachineWriter = new StateMachineWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return stateMachineWriter.WriteAsync(xmlWriter, (IStateMachine)element, elementName, writeContext);
                },
                ["Transition"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var transitionWriter = new TransitionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return transitionWriter.WriteAsync(xmlWriter, (ITransition)element, elementName, writeContext);
                },
                ["DataType"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var dataTypeWriter = new DataTypeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return dataTypeWriter.WriteAsync(xmlWriter, (IDataType)element, elementName, writeContext);
                },
                ["Enumeration"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var enumerationWriter = new EnumerationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return enumerationWriter.WriteAsync(xmlWriter, (IEnumeration)element, elementName, writeContext);
                },
                ["EnumerationLiteral"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var enumerationLiteralWriter = new EnumerationLiteralWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return enumerationLiteralWriter.WriteAsync(xmlWriter, (IEnumerationLiteral)element, elementName, writeContext);
                },
                ["Interface"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var interfaceWriter = new InterfaceWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return interfaceWriter.WriteAsync(xmlWriter, (IInterface)element, elementName, writeContext);
                },
                ["InterfaceRealization"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var interfaceRealizationWriter = new InterfaceRealizationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return interfaceRealizationWriter.WriteAsync(xmlWriter, (IInterfaceRealization)element, elementName, writeContext);
                },
                ["PrimitiveType"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var primitiveTypeWriter = new PrimitiveTypeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return primitiveTypeWriter.WriteAsync(xmlWriter, (IPrimitiveType)element, elementName, writeContext);
                },
                ["Reception"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var receptionWriter = new ReceptionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return receptionWriter.WriteAsync(xmlWriter, (IReception)element, elementName, writeContext);
                },
                ["Signal"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var signalWriter = new SignalWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return signalWriter.WriteAsync(xmlWriter, (ISignal)element, elementName, writeContext);
                },
                ["Extension"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var extensionWriter = new ExtensionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return extensionWriter.WriteAsync(xmlWriter, (IExtension)element, elementName, writeContext);
                },
                ["ExtensionEnd"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var extensionEndWriter = new ExtensionEndWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return extensionEndWriter.WriteAsync(xmlWriter, (IExtensionEnd)element, elementName, writeContext);
                },
                ["Image"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var imageWriter = new ImageWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return imageWriter.WriteAsync(xmlWriter, (IImage)element, elementName, writeContext);
                },
                ["Model"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var modelWriter = new ModelWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return modelWriter.WriteAsync(xmlWriter, (IModel)element, elementName, writeContext);
                },
                ["Package"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var packageWriter = new PackageWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return packageWriter.WriteAsync(xmlWriter, (IPackage)element, elementName, writeContext);
                },
                ["PackageMerge"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var packageMergeWriter = new PackageMergeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return packageMergeWriter.WriteAsync(xmlWriter, (IPackageMerge)element, elementName, writeContext);
                },
                ["Profile"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var profileWriter = new ProfileWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return profileWriter.WriteAsync(xmlWriter, (IProfile)element, elementName, writeContext);
                },
                ["ProfileApplication"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var profileApplicationWriter = new ProfileApplicationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return profileApplicationWriter.WriteAsync(xmlWriter, (IProfileApplication)element, elementName, writeContext);
                },
                ["Stereotype"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var stereotypeWriter = new StereotypeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return stereotypeWriter.WriteAsync(xmlWriter, (IStereotype)element, elementName, writeContext);
                },
                ["ActionExecutionSpecification"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var actionExecutionSpecificationWriter = new ActionExecutionSpecificationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return actionExecutionSpecificationWriter.WriteAsync(xmlWriter, (IActionExecutionSpecification)element, elementName, writeContext);
                },
                ["BehaviorExecutionSpecification"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var behaviorExecutionSpecificationWriter = new BehaviorExecutionSpecificationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return behaviorExecutionSpecificationWriter.WriteAsync(xmlWriter, (IBehaviorExecutionSpecification)element, elementName, writeContext);
                },
                ["CombinedFragment"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var combinedFragmentWriter = new CombinedFragmentWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return combinedFragmentWriter.WriteAsync(xmlWriter, (ICombinedFragment)element, elementName, writeContext);
                },
                ["ConsiderIgnoreFragment"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var considerIgnoreFragmentWriter = new ConsiderIgnoreFragmentWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return considerIgnoreFragmentWriter.WriteAsync(xmlWriter, (IConsiderIgnoreFragment)element, elementName, writeContext);
                },
                ["Continuation"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var continuationWriter = new ContinuationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return continuationWriter.WriteAsync(xmlWriter, (IContinuation)element, elementName, writeContext);
                },
                ["DestructionOccurrenceSpecification"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var destructionOccurrenceSpecificationWriter = new DestructionOccurrenceSpecificationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return destructionOccurrenceSpecificationWriter.WriteAsync(xmlWriter, (IDestructionOccurrenceSpecification)element, elementName, writeContext);
                },
                ["ExecutionOccurrenceSpecification"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var executionOccurrenceSpecificationWriter = new ExecutionOccurrenceSpecificationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return executionOccurrenceSpecificationWriter.WriteAsync(xmlWriter, (IExecutionOccurrenceSpecification)element, elementName, writeContext);
                },
                ["Gate"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var gateWriter = new GateWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return gateWriter.WriteAsync(xmlWriter, (IGate)element, elementName, writeContext);
                },
                ["GeneralOrdering"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var generalOrderingWriter = new GeneralOrderingWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return generalOrderingWriter.WriteAsync(xmlWriter, (IGeneralOrdering)element, elementName, writeContext);
                },
                ["Interaction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var interactionWriter = new InteractionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return interactionWriter.WriteAsync(xmlWriter, (IInteraction)element, elementName, writeContext);
                },
                ["InteractionConstraint"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var interactionConstraintWriter = new InteractionConstraintWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return interactionConstraintWriter.WriteAsync(xmlWriter, (IInteractionConstraint)element, elementName, writeContext);
                },
                ["InteractionOperand"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var interactionOperandWriter = new InteractionOperandWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return interactionOperandWriter.WriteAsync(xmlWriter, (IInteractionOperand)element, elementName, writeContext);
                },
                ["InteractionUse"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var interactionUseWriter = new InteractionUseWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return interactionUseWriter.WriteAsync(xmlWriter, (IInteractionUse)element, elementName, writeContext);
                },
                ["Lifeline"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var lifelineWriter = new LifelineWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return lifelineWriter.WriteAsync(xmlWriter, (ILifeline)element, elementName, writeContext);
                },
                ["Message"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var messageWriter = new MessageWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return messageWriter.WriteAsync(xmlWriter, (IMessage)element, elementName, writeContext);
                },
                ["MessageOccurrenceSpecification"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var messageOccurrenceSpecificationWriter = new MessageOccurrenceSpecificationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return messageOccurrenceSpecificationWriter.WriteAsync(xmlWriter, (IMessageOccurrenceSpecification)element, elementName, writeContext);
                },
                ["OccurrenceSpecification"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var occurrenceSpecificationWriter = new OccurrenceSpecificationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return occurrenceSpecificationWriter.WriteAsync(xmlWriter, (IOccurrenceSpecification)element, elementName, writeContext);
                },
                ["PartDecomposition"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var partDecompositionWriter = new PartDecompositionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return partDecompositionWriter.WriteAsync(xmlWriter, (IPartDecomposition)element, elementName, writeContext);
                },
                ["StateInvariant"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var stateInvariantWriter = new StateInvariantWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return stateInvariantWriter.WriteAsync(xmlWriter, (IStateInvariant)element, elementName, writeContext);
                },
                ["InformationFlow"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var informationFlowWriter = new InformationFlowWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return informationFlowWriter.WriteAsync(xmlWriter, (IInformationFlow)element, elementName, writeContext);
                },
                ["InformationItem"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var informationItemWriter = new InformationItemWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return informationItemWriter.WriteAsync(xmlWriter, (IInformationItem)element, elementName, writeContext);
                },
                ["Artifact"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var artifactWriter = new ArtifactWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return artifactWriter.WriteAsync(xmlWriter, (IArtifact)element, elementName, writeContext);
                },
                ["CommunicationPath"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var communicationPathWriter = new CommunicationPathWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return communicationPathWriter.WriteAsync(xmlWriter, (ICommunicationPath)element, elementName, writeContext);
                },
                ["Deployment"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var deploymentWriter = new DeploymentWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return deploymentWriter.WriteAsync(xmlWriter, (IDeployment)element, elementName, writeContext);
                },
                ["DeploymentSpecification"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var deploymentSpecificationWriter = new DeploymentSpecificationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return deploymentSpecificationWriter.WriteAsync(xmlWriter, (IDeploymentSpecification)element, elementName, writeContext);
                },
                ["Device"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var deviceWriter = new DeviceWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return deviceWriter.WriteAsync(xmlWriter, (IDevice)element, elementName, writeContext);
                },
                ["ExecutionEnvironment"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var executionEnvironmentWriter = new ExecutionEnvironmentWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return executionEnvironmentWriter.WriteAsync(xmlWriter, (IExecutionEnvironment)element, elementName, writeContext);
                },
                ["Manifestation"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var manifestationWriter = new ManifestationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return manifestationWriter.WriteAsync(xmlWriter, (IManifestation)element, elementName, writeContext);
                },
                ["Node"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var nodeWriter = new NodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return nodeWriter.WriteAsync(xmlWriter, (INode)element, elementName, writeContext);
                },
                ["Abstraction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var abstractionWriter = new AbstractionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return abstractionWriter.WriteAsync(xmlWriter, (IAbstraction)element, elementName, writeContext);
                },
                ["Comment"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var commentWriter = new CommentWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return commentWriter.WriteAsync(xmlWriter, (IComment)element, elementName, writeContext);
                },
                ["Constraint"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var constraintWriter = new ConstraintWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return constraintWriter.WriteAsync(xmlWriter, (IConstraint)element, elementName, writeContext);
                },
                ["Dependency"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var dependencyWriter = new DependencyWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return dependencyWriter.WriteAsync(xmlWriter, (IDependency)element, elementName, writeContext);
                },
                ["ElementImport"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var elementImportWriter = new ElementImportWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return elementImportWriter.WriteAsync(xmlWriter, (IElementImport)element, elementName, writeContext);
                },
                ["PackageImport"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var packageImportWriter = new PackageImportWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return packageImportWriter.WriteAsync(xmlWriter, (IPackageImport)element, elementName, writeContext);
                },
                ["Realization"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var realizationWriter = new RealizationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return realizationWriter.WriteAsync(xmlWriter, (IRealization)element, elementName, writeContext);
                },
                ["TemplateBinding"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var templateBindingWriter = new TemplateBindingWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return templateBindingWriter.WriteAsync(xmlWriter, (ITemplateBinding)element, elementName, writeContext);
                },
                ["TemplateParameter"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var templateParameterWriter = new TemplateParameterWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return templateParameterWriter.WriteAsync(xmlWriter, (ITemplateParameter)element, elementName, writeContext);
                },
                ["TemplateParameterSubstitution"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var templateParameterSubstitutionWriter = new TemplateParameterSubstitutionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return templateParameterSubstitutionWriter.WriteAsync(xmlWriter, (ITemplateParameterSubstitution)element, elementName, writeContext);
                },
                ["TemplateSignature"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var templateSignatureWriter = new TemplateSignatureWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return templateSignatureWriter.WriteAsync(xmlWriter, (ITemplateSignature)element, elementName, writeContext);
                },
                ["Usage"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var usageWriter = new UsageWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return usageWriter.WriteAsync(xmlWriter, (IUsage)element, elementName, writeContext);
                },
                ["AnyReceiveEvent"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var anyReceiveEventWriter = new AnyReceiveEventWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return anyReceiveEventWriter.WriteAsync(xmlWriter, (IAnyReceiveEvent)element, elementName, writeContext);
                },
                ["CallEvent"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var callEventWriter = new CallEventWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return callEventWriter.WriteAsync(xmlWriter, (ICallEvent)element, elementName, writeContext);
                },
                ["ChangeEvent"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var changeEventWriter = new ChangeEventWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return changeEventWriter.WriteAsync(xmlWriter, (IChangeEvent)element, elementName, writeContext);
                },
                ["FunctionBehavior"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var functionBehaviorWriter = new FunctionBehaviorWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return functionBehaviorWriter.WriteAsync(xmlWriter, (IFunctionBehavior)element, elementName, writeContext);
                },
                ["OpaqueBehavior"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var opaqueBehaviorWriter = new OpaqueBehaviorWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return opaqueBehaviorWriter.WriteAsync(xmlWriter, (IOpaqueBehavior)element, elementName, writeContext);
                },
                ["SignalEvent"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var signalEventWriter = new SignalEventWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return signalEventWriter.WriteAsync(xmlWriter, (ISignalEvent)element, elementName, writeContext);
                },
                ["TimeEvent"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var timeEventWriter = new TimeEventWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return timeEventWriter.WriteAsync(xmlWriter, (ITimeEvent)element, elementName, writeContext);
                },
                ["Trigger"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var triggerWriter = new TriggerWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return triggerWriter.WriteAsync(xmlWriter, (ITrigger)element, elementName, writeContext);
                },
                ["Substitution"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var substitutionWriter = new SubstitutionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return substitutionWriter.WriteAsync(xmlWriter, (ISubstitution)element, elementName, writeContext);
                },
                ["ClassifierTemplateParameter"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var classifierTemplateParameterWriter = new ClassifierTemplateParameterWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return classifierTemplateParameterWriter.WriteAsync(xmlWriter, (IClassifierTemplateParameter)element, elementName, writeContext);
                },
                ["Generalization"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var generalizationWriter = new GeneralizationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return generalizationWriter.WriteAsync(xmlWriter, (IGeneralization)element, elementName, writeContext);
                },
                ["GeneralizationSet"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var generalizationSetWriter = new GeneralizationSetWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return generalizationSetWriter.WriteAsync(xmlWriter, (IGeneralizationSet)element, elementName, writeContext);
                },
                ["InstanceSpecification"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var instanceSpecificationWriter = new InstanceSpecificationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return instanceSpecificationWriter.WriteAsync(xmlWriter, (IInstanceSpecification)element, elementName, writeContext);
                },
                ["InstanceValue"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var instanceValueWriter = new InstanceValueWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return instanceValueWriter.WriteAsync(xmlWriter, (IInstanceValue)element, elementName, writeContext);
                },
                ["Operation"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var operationWriter = new OperationWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return operationWriter.WriteAsync(xmlWriter, (IOperation)element, elementName, writeContext);
                },
                ["OperationTemplateParameter"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var operationTemplateParameterWriter = new OperationTemplateParameterWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return operationTemplateParameterWriter.WriteAsync(xmlWriter, (IOperationTemplateParameter)element, elementName, writeContext);
                },
                ["Parameter"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var parameterWriter = new ParameterWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return parameterWriter.WriteAsync(xmlWriter, (IParameter)element, elementName, writeContext);
                },
                ["ParameterSet"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var parameterSetWriter = new ParameterSetWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return parameterSetWriter.WriteAsync(xmlWriter, (IParameterSet)element, elementName, writeContext);
                },
                ["Property"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var propertyWriter = new PropertyWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return propertyWriter.WriteAsync(xmlWriter, (IProperty)element, elementName, writeContext);
                },
                ["RedefinableTemplateSignature"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var redefinableTemplateSignatureWriter = new RedefinableTemplateSignatureWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return redefinableTemplateSignatureWriter.WriteAsync(xmlWriter, (IRedefinableTemplateSignature)element, elementName, writeContext);
                },
                ["Slot"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var slotWriter = new SlotWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return slotWriter.WriteAsync(xmlWriter, (ISlot)element, elementName, writeContext);
                },
                ["ValueSpecificationAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var valueSpecificationActionWriter = new ValueSpecificationActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return valueSpecificationActionWriter.WriteAsync(xmlWriter, (IValueSpecificationAction)element, elementName, writeContext);
                },
                ["AcceptCallAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var acceptCallActionWriter = new AcceptCallActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return acceptCallActionWriter.WriteAsync(xmlWriter, (IAcceptCallAction)element, elementName, writeContext);
                },
                ["AcceptEventAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var acceptEventActionWriter = new AcceptEventActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return acceptEventActionWriter.WriteAsync(xmlWriter, (IAcceptEventAction)element, elementName, writeContext);
                },
                ["ActionInputPin"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var actionInputPinWriter = new ActionInputPinWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return actionInputPinWriter.WriteAsync(xmlWriter, (IActionInputPin)element, elementName, writeContext);
                },
                ["AddStructuralFeatureValueAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var addStructuralFeatureValueActionWriter = new AddStructuralFeatureValueActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return addStructuralFeatureValueActionWriter.WriteAsync(xmlWriter, (IAddStructuralFeatureValueAction)element, elementName, writeContext);
                },
                ["AddVariableValueAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var addVariableValueActionWriter = new AddVariableValueActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return addVariableValueActionWriter.WriteAsync(xmlWriter, (IAddVariableValueAction)element, elementName, writeContext);
                },
                ["BroadcastSignalAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var broadcastSignalActionWriter = new BroadcastSignalActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return broadcastSignalActionWriter.WriteAsync(xmlWriter, (IBroadcastSignalAction)element, elementName, writeContext);
                },
                ["CallBehaviorAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var callBehaviorActionWriter = new CallBehaviorActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return callBehaviorActionWriter.WriteAsync(xmlWriter, (ICallBehaviorAction)element, elementName, writeContext);
                },
                ["CallOperationAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var callOperationActionWriter = new CallOperationActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return callOperationActionWriter.WriteAsync(xmlWriter, (ICallOperationAction)element, elementName, writeContext);
                },
                ["Clause"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var clauseWriter = new ClauseWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return clauseWriter.WriteAsync(xmlWriter, (IClause)element, elementName, writeContext);
                },
                ["ClearAssociationAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var clearAssociationActionWriter = new ClearAssociationActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return clearAssociationActionWriter.WriteAsync(xmlWriter, (IClearAssociationAction)element, elementName, writeContext);
                },
                ["ClearStructuralFeatureAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var clearStructuralFeatureActionWriter = new ClearStructuralFeatureActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return clearStructuralFeatureActionWriter.WriteAsync(xmlWriter, (IClearStructuralFeatureAction)element, elementName, writeContext);
                },
                ["ClearVariableAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var clearVariableActionWriter = new ClearVariableActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return clearVariableActionWriter.WriteAsync(xmlWriter, (IClearVariableAction)element, elementName, writeContext);
                },
                ["ConditionalNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var conditionalNodeWriter = new ConditionalNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return conditionalNodeWriter.WriteAsync(xmlWriter, (IConditionalNode)element, elementName, writeContext);
                },
                ["CreateLinkAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var createLinkActionWriter = new CreateLinkActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return createLinkActionWriter.WriteAsync(xmlWriter, (ICreateLinkAction)element, elementName, writeContext);
                },
                ["CreateLinkObjectAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var createLinkObjectActionWriter = new CreateLinkObjectActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return createLinkObjectActionWriter.WriteAsync(xmlWriter, (ICreateLinkObjectAction)element, elementName, writeContext);
                },
                ["CreateObjectAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var createObjectActionWriter = new CreateObjectActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return createObjectActionWriter.WriteAsync(xmlWriter, (ICreateObjectAction)element, elementName, writeContext);
                },
                ["DestroyLinkAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var destroyLinkActionWriter = new DestroyLinkActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return destroyLinkActionWriter.WriteAsync(xmlWriter, (IDestroyLinkAction)element, elementName, writeContext);
                },
                ["DestroyObjectAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var destroyObjectActionWriter = new DestroyObjectActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return destroyObjectActionWriter.WriteAsync(xmlWriter, (IDestroyObjectAction)element, elementName, writeContext);
                },
                ["ExpansionNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var expansionNodeWriter = new ExpansionNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return expansionNodeWriter.WriteAsync(xmlWriter, (IExpansionNode)element, elementName, writeContext);
                },
                ["ExpansionRegion"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var expansionRegionWriter = new ExpansionRegionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return expansionRegionWriter.WriteAsync(xmlWriter, (IExpansionRegion)element, elementName, writeContext);
                },
                ["InputPin"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var inputPinWriter = new InputPinWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return inputPinWriter.WriteAsync(xmlWriter, (IInputPin)element, elementName, writeContext);
                },
                ["LinkEndCreationData"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var linkEndCreationDataWriter = new LinkEndCreationDataWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return linkEndCreationDataWriter.WriteAsync(xmlWriter, (ILinkEndCreationData)element, elementName, writeContext);
                },
                ["LinkEndData"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var linkEndDataWriter = new LinkEndDataWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return linkEndDataWriter.WriteAsync(xmlWriter, (ILinkEndData)element, elementName, writeContext);
                },
                ["LinkEndDestructionData"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var linkEndDestructionDataWriter = new LinkEndDestructionDataWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return linkEndDestructionDataWriter.WriteAsync(xmlWriter, (ILinkEndDestructionData)element, elementName, writeContext);
                },
                ["LoopNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var loopNodeWriter = new LoopNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return loopNodeWriter.WriteAsync(xmlWriter, (ILoopNode)element, elementName, writeContext);
                },
                ["OpaqueAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var opaqueActionWriter = new OpaqueActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return opaqueActionWriter.WriteAsync(xmlWriter, (IOpaqueAction)element, elementName, writeContext);
                },
                ["OutputPin"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var outputPinWriter = new OutputPinWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return outputPinWriter.WriteAsync(xmlWriter, (IOutputPin)element, elementName, writeContext);
                },
                ["QualifierValue"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var qualifierValueWriter = new QualifierValueWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return qualifierValueWriter.WriteAsync(xmlWriter, (IQualifierValue)element, elementName, writeContext);
                },
                ["RaiseExceptionAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var raiseExceptionActionWriter = new RaiseExceptionActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return raiseExceptionActionWriter.WriteAsync(xmlWriter, (IRaiseExceptionAction)element, elementName, writeContext);
                },
                ["ReadExtentAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var readExtentActionWriter = new ReadExtentActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return readExtentActionWriter.WriteAsync(xmlWriter, (IReadExtentAction)element, elementName, writeContext);
                },
                ["ReadIsClassifiedObjectAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var readIsClassifiedObjectActionWriter = new ReadIsClassifiedObjectActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return readIsClassifiedObjectActionWriter.WriteAsync(xmlWriter, (IReadIsClassifiedObjectAction)element, elementName, writeContext);
                },
                ["ReadLinkAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var readLinkActionWriter = new ReadLinkActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return readLinkActionWriter.WriteAsync(xmlWriter, (IReadLinkAction)element, elementName, writeContext);
                },
                ["ReadLinkObjectEndAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var readLinkObjectEndActionWriter = new ReadLinkObjectEndActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return readLinkObjectEndActionWriter.WriteAsync(xmlWriter, (IReadLinkObjectEndAction)element, elementName, writeContext);
                },
                ["ReadLinkObjectEndQualifierAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var readLinkObjectEndQualifierActionWriter = new ReadLinkObjectEndQualifierActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return readLinkObjectEndQualifierActionWriter.WriteAsync(xmlWriter, (IReadLinkObjectEndQualifierAction)element, elementName, writeContext);
                },
                ["ReadSelfAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var readSelfActionWriter = new ReadSelfActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return readSelfActionWriter.WriteAsync(xmlWriter, (IReadSelfAction)element, elementName, writeContext);
                },
                ["ReadStructuralFeatureAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var readStructuralFeatureActionWriter = new ReadStructuralFeatureActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return readStructuralFeatureActionWriter.WriteAsync(xmlWriter, (IReadStructuralFeatureAction)element, elementName, writeContext);
                },
                ["ReadVariableAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var readVariableActionWriter = new ReadVariableActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return readVariableActionWriter.WriteAsync(xmlWriter, (IReadVariableAction)element, elementName, writeContext);
                },
                ["ReclassifyObjectAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var reclassifyObjectActionWriter = new ReclassifyObjectActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return reclassifyObjectActionWriter.WriteAsync(xmlWriter, (IReclassifyObjectAction)element, elementName, writeContext);
                },
                ["ReduceAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var reduceActionWriter = new ReduceActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return reduceActionWriter.WriteAsync(xmlWriter, (IReduceAction)element, elementName, writeContext);
                },
                ["RemoveStructuralFeatureValueAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var removeStructuralFeatureValueActionWriter = new RemoveStructuralFeatureValueActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return removeStructuralFeatureValueActionWriter.WriteAsync(xmlWriter, (IRemoveStructuralFeatureValueAction)element, elementName, writeContext);
                },
                ["RemoveVariableValueAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var removeVariableValueActionWriter = new RemoveVariableValueActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return removeVariableValueActionWriter.WriteAsync(xmlWriter, (IRemoveVariableValueAction)element, elementName, writeContext);
                },
                ["ReplyAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var replyActionWriter = new ReplyActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return replyActionWriter.WriteAsync(xmlWriter, (IReplyAction)element, elementName, writeContext);
                },
                ["SendObjectAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var sendObjectActionWriter = new SendObjectActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return sendObjectActionWriter.WriteAsync(xmlWriter, (ISendObjectAction)element, elementName, writeContext);
                },
                ["SendSignalAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var sendSignalActionWriter = new SendSignalActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return sendSignalActionWriter.WriteAsync(xmlWriter, (ISendSignalAction)element, elementName, writeContext);
                },
                ["SequenceNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var sequenceNodeWriter = new SequenceNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return sequenceNodeWriter.WriteAsync(xmlWriter, (ISequenceNode)element, elementName, writeContext);
                },
                ["StartClassifierBehaviorAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var startClassifierBehaviorActionWriter = new StartClassifierBehaviorActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return startClassifierBehaviorActionWriter.WriteAsync(xmlWriter, (IStartClassifierBehaviorAction)element, elementName, writeContext);
                },
                ["StartObjectBehaviorAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var startObjectBehaviorActionWriter = new StartObjectBehaviorActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return startObjectBehaviorActionWriter.WriteAsync(xmlWriter, (IStartObjectBehaviorAction)element, elementName, writeContext);
                },
                ["StructuredActivityNode"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var structuredActivityNodeWriter = new StructuredActivityNodeWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return structuredActivityNodeWriter.WriteAsync(xmlWriter, (IStructuredActivityNode)element, elementName, writeContext);
                },
                ["TestIdentityAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var testIdentityActionWriter = new TestIdentityActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return testIdentityActionWriter.WriteAsync(xmlWriter, (ITestIdentityAction)element, elementName, writeContext);
                },
                ["UnmarshallAction"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var unmarshallActionWriter = new UnmarshallActionWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return unmarshallActionWriter.WriteAsync(xmlWriter, (IUnmarshallAction)element, elementName, writeContext);
                },
                ["ValuePin"] = (xmlWriter, element, elementName, writeContext) =>
                {
                    var valuePinWriter = new ValuePinWriter(this, this.xmiWriterSettings, this.loggerFactory);
                    return valuePinWriter.WriteAsync(xmlWriter, (IValuePin)element, elementName, writeContext);
                },
            };
        }

        /// <summary>
        /// Writes the provided <see cref="IXmiElement"/> to the <see cref="XmlWriter"/> using the appropriate
        /// <see cref="IXmiElementWriter{TXmiElement}"/> based on the concrete type of the <see cref="IXmiElement"/>.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// thrown when the concrete type of the <see cref="IXmiElement"/> is not supported and no
        /// <see cref="IXmiElementWriter{TXmiElement}"/> was found
        /// </exception>
        public void Write(XmlWriter xmlWriter, IXmiElement element, string elementName, IXmiWriteContext writeContext)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            var typeName = element.GetType().Name;

            if (!this.writerCache.TryGetValue(typeName, out var writer))
            {
                throw new InvalidOperationException($"No writer found for type {typeName}");
            }

            writer(xmlWriter, element, elementName, writeContext);
        }

        /// <summary>
        /// Writes the provided <see cref="IXmiElement"/> to the <see cref="XmlWriter"/> as a contained element. When
        /// the <see cref="IXmiElement"/> is not part of the document that is being written, an href reference element
        /// is written instead.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        public void WriteContainedElement(XmlWriter xmlWriter, IXmiElement element, string elementName, IXmiWriteContext writeContext)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (writeContext.IsLocal(element))
            {
                this.Write(xmlWriter, element, elementName, writeContext);
            }
            else
            {
                this.WriteHrefElement(xmlWriter, element, elementName, writeContext);
            }
        }

        /// <summary>
        /// Writes the provided <see cref="IXmiElement"/> to the <see cref="XmlWriter"/> as a reference element. When the
        /// <see cref="IXmiElement"/> is part of the document that is being written an xmi:idref element is written,
        /// otherwise an href reference element is written.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that is referenced
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        public void WriteReferenceElement(XmlWriter xmlWriter, IXmiElement element, string elementName, IXmiWriteContext writeContext)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (writeContext.IsLocal(element))
            {
                xmlWriter.WriteStartElement(elementName);
                xmlWriter.WriteAttributeString("xmi", "idref", this.xmiWriterSettings.XmiNamespaceUri, element.XmiId);
                xmlWriter.WriteEndElement();
            }
            else
            {
                this.WriteHrefElement(xmlWriter, element, elementName, writeContext);
            }
        }

        /// <summary>
        /// Asynchronously writes the provided <see cref="IXmiElement"/> to the <see cref="XmlWriter"/> using the appropriate
        /// <see cref="IXmiElementWriter{TXmiElement}"/> based on the concrete type of the <see cref="IXmiElement"/>.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// thrown when the concrete type of the <see cref="IXmiElement"/> is not supported and no
        /// <see cref="IXmiElementWriter{TXmiElement}"/> was found
        /// </exception>
        public Task WriteAsync(XmlWriter xmlWriter, IXmiElement element, string elementName, IXmiWriteContext writeContext)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            var typeName = element.GetType().Name;

            if (!this.writerAsyncCache.TryGetValue(typeName, out var writer))
            {
                throw new InvalidOperationException($"No writer found for type {typeName}");
            }

            return writer(xmlWriter, element, elementName, writeContext);
        }

        /// <summary>
        /// Asynchronously writes the provided <see cref="IXmiElement"/> to the <see cref="XmlWriter"/> as a contained element. When
        /// the <see cref="IXmiElement"/> is not part of the document that is being written, an href reference element
        /// is written instead.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that is to be written
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public Task WriteContainedElementAsync(XmlWriter xmlWriter, IXmiElement element, string elementName, IXmiWriteContext writeContext)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (writeContext.IsLocal(element))
            {
                return this.WriteAsync(xmlWriter, element, elementName, writeContext);
            }

            return this.WriteHrefElementAsync(xmlWriter, element, elementName, writeContext);
        }

        /// <summary>
        /// Asynchronously writes the provided <see cref="IXmiElement"/> to the <see cref="XmlWriter"/> as a reference element. When the
        /// <see cref="IXmiElement"/> is part of the document that is being written an xmi:idref element is written,
        /// otherwise an href reference element is written.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that is referenced
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        public async Task WriteReferenceElementAsync(XmlWriter xmlWriter, IXmiElement element, string elementName, IXmiWriteContext writeContext)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (writeContext.IsLocal(element))
            {
                await xmlWriter.WriteStartElementAsync(null, elementName, null);
                await xmlWriter.WriteAttributeStringAsync("xmi", "idref", this.xmiWriterSettings.XmiNamespaceUri, element.XmiId);
                await xmlWriter.WriteEndElementAsync();
            }
            else
            {
                await this.WriteHrefElementAsync(xmlWriter, element, elementName, writeContext);
            }
        }

        /// <summary>
        /// Writes an href reference element for the provided <see cref="IXmiElement"/> to the <see cref="XmlWriter"/>.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that is referenced
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        private void WriteHrefElement(XmlWriter xmlWriter, IXmiElement element, string elementName, IXmiWriteContext writeContext)
        {
            xmlWriter.WriteStartElement(elementName);
            xmlWriter.WriteAttributeString("xmi", "type", this.xmiWriterSettings.XmiNamespaceUri, $"uml:{element.GetType().Name}");
            xmlWriter.WriteAttributeString("href", writeContext.QueryHref(element));
            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Asynchronously writes an href reference element for the provided <see cref="IXmiElement"/> to the <see cref="XmlWriter"/>.
        /// </summary>
        /// <param name="xmlWriter">
        /// The <see cref="XmlWriter"/> to write to
        /// </param>
        /// <param name="element">
        /// The <see cref="IXmiElement"/> that is referenced
        /// </param>
        /// <param name="elementName">
        /// The name of the XML element that is written
        /// </param>
        /// <param name="writeContext">
        /// The <see cref="IXmiWriteContext"/> that captures the state of the write operation
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        private async Task WriteHrefElementAsync(XmlWriter xmlWriter, IXmiElement element, string elementName, IXmiWriteContext writeContext)
        {
            await xmlWriter.WriteStartElementAsync(null, elementName, null);
            await xmlWriter.WriteAttributeStringAsync("xmi", "type", this.xmiWriterSettings.XmiNamespaceUri, $"uml:{element.GetType().Name}");
            await xmlWriter.WriteAttributeStringAsync(null, "href", null, writeContext.QueryHref(element));
            await xmlWriter.WriteEndElementAsync();
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
