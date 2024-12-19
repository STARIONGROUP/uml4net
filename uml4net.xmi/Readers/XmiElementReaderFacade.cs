// -------------------------------------------------------------------------------------------------
// <copyright file="XmiElementReaderFacade.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2024 Starion Group S.A.
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
    using System.Collections.Generic;
    using System.Xml;
    using Microsoft.Extensions.Logging;

    using uml4net.xmi.Cache;
    using uml4net.xmi.Readers.Classification;
    using uml4net.xmi.Readers.CommonStructure;
    using uml4net.xmi.Readers.Packages;
    using uml4net.xmi.Readers.SimpleClassifiers;
    using uml4net.xmi.Readers.StructuredClassifiers;
    using uml4net.xmi.Readers.UseCases;
    using uml4net.xmi.Readers.Values;

    /// <summary>
    /// The purpose of the <see cref="XmiElementReaderFacade"/> is to read an <see cref="IXmiElement"/> from an
    /// <see cref="XmlReader"/>
    /// </summary>
    public class XmiElementReaderFacade : IXmiElementReaderFacade
    {
        /// <summary>
        /// A dictionary that contains functions that return <see cref="IXmiElement"/> based a key that represents the xmiType
        /// and a provided <see cref="IXmiReaderCache"/>, <see cref="ILoggerFactory"/> and <see cref="XmlReader"/>
        /// </summary>
        private readonly Dictionary<string, Func<IXmiReaderCache, ILoggerFactory, XmlReader, IXmiElement>> readerCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiElementReaderFacade"/>
        /// </summary>
        public XmiElementReaderFacade()
        {
            readerCache = new Dictionary<string, Func<IXmiReaderCache, ILoggerFactory, XmlReader, IXmiElement>>
            {
                ["uml:Activity"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ActivityFinalNode"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ActivityParameterNode"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ActivityPartition"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:CentralBufferNode"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ControlFlow"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:DataStoreNode"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:DecisionNode"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ExceptionHandler"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:FlowFinalNode"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ForkNode"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:InitialNode"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:InterruptibleActivityRegion"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:JoinNode"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:MergeNode"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ObjectFlow"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Variable"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Duration"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:DurationConstraint"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException(); ;
                },
                ["uml:DurationInterval"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:DurationObservation"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Expression"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Interval"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:IntervalConstraint"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:LiteralBoolean"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var literalBooleanReader = new LiteralBooleanReader(cache, loggerFactory);
                    return literalBooleanReader.Read(subXmlReader);
                },
                ["uml:LiteralInteger"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var literalIntegerReader = new LiteralIntegerReader(cache, loggerFactory);
                    return literalIntegerReader.Read(subXmlReader);
                },
                ["uml:LiteralNull"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:LiteralReal"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:LiteralString"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var literalStringReader = new LiteralStringReader(cache, loggerFactory);
                    return literalStringReader.Read(subXmlReader);
                },
                ["uml:LiteralUnlimitedNatural"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var literalUnlimitedNaturalReader = new LiteralUnlimitedNaturalReader(cache, loggerFactory);
                    return literalUnlimitedNaturalReader.Read(subXmlReader);
                },
                ["uml:OpaqueExpression"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var opaqueExpressionReader = new OpaqueExpressionReader(cache, loggerFactory);
                    return opaqueExpressionReader.Read(subXmlReader);
                },
                ["uml:StringExpression"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var stringExpressionReader = new StringExpressionReader(cache, loggerFactory);
                    return stringExpressionReader.Read(subXmlReader);
                },
                ["uml:TimeConstraint"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:TimeExpression"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:TimeInterval"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:TimeObservation"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Actor"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Extend"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ExtensionPoint"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Include"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:UseCase"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var useCaseReader = new UseCaseReader(cache, loggerFactory);
                    return useCaseReader.Read(subXmlReader);
                },
                ["uml:Association"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var associationReader = new AssociationReader(cache, loggerFactory);
                    return associationReader.Read(subXmlReader);
                },
                ["uml:AssociationClass"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Class"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var classReader = new ClassReader(cache, loggerFactory);
                    return classReader.Read(subXmlReader);
                },
                ["uml:Collaboration"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:CollaborationUse"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var collaborationUseReader = new CollaborationUseReader(cache, loggerFactory);
                    return collaborationUseReader.Read(subXmlReader);
                },
                ["uml:Component"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ComponentRealization"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ConnectableElementTemplateParameter"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Connector"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var connectorReader = new ConnectorReader(cache, loggerFactory);
                    return connectorReader.Read(subXmlReader);
                },
                ["uml:ConnectorEnd"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Port"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ConnectionPointReference"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:FinalState"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ProtocolConformance"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ProtocolStateMachine"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ProtocolTransition"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Pseudostate"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Region"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:State"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:StateMachine"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Transition"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:DataType"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Enumeration"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var enumerationReader = new EnumerationReader(cache, loggerFactory);
                    return enumerationReader.Read(subXmlReader);
                },
                ["uml:EnumerationLiteral"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var enumerationLiteralReader = new EnumerationLiteralReader(cache, loggerFactory);
                    return enumerationLiteralReader.Read(subXmlReader);
                },
                ["uml:Interface"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var interfaceReader = new InterfaceReader(cache, loggerFactory);
                    return interfaceReader.Read(subXmlReader);
                },
                ["uml:InterfaceRealization"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var interfaceRealizationReader = new InterfaceRealizationReader(cache, loggerFactory);
                    return interfaceRealizationReader.Read(subXmlReader);
                },
                ["uml:PrimitiveType"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var primitiveTypeReader = new PrimitiveTypeReader(cache, loggerFactory);
                    return primitiveTypeReader.Read(subXmlReader);
                },
                ["uml:Reception"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var receptionReader = new ReceptionReader(cache, loggerFactory);
                    return receptionReader.Read(subXmlReader);
                },
                ["uml:Signal"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Extension"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ExtensionEnd"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Image"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Model"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var modelReader = new ModelReader(cache, loggerFactory);
                    return modelReader.Read(subXmlReader);
                },
                ["uml:Package"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var packageReader = new PackageReader(cache, loggerFactory);
                    return packageReader.Read(subXmlReader);
                },
                ["uml:PackageMerge"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Profile"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ProfileApplication"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Stereotype"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ActionExecutionSpecification"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:BehaviorExecutionSpecification"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:CombinedFragment"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ConsiderIgnoreFragment"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Continuation"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:DestructionOccurrenceSpecification"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ExecutionOccurrenceSpecification"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Gate"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:GeneralOrdering"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Interaction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:InteractionConstraint"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:InteractionOperand"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:InteractionUse"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Lifeline"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Message"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:MessageOccurrenceSpecification"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:OccurrenceSpecification"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:PartDecomposition"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:StateInvariant"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:InformationFlow"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:InformationItem"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Artifact"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:CommunicationPath"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Deployment"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:DeploymentSpecification"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Device"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ExecutionEnvironment"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Manifestation"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Node"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Abstraction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Comment"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var commentReader = new CommentReader(cache, loggerFactory);
                    return commentReader.Read(subXmlReader);
                },
                ["uml:Constraint"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var constraintReader = new ConstraintReader(cache, loggerFactory);
                    return constraintReader.Read(subXmlReader);
                },
                ["uml:Dependency"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ElementImport"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var elementImportReader = new ElementImportReader(cache, loggerFactory);
                    return elementImportReader.Read(subXmlReader);
                },
                ["uml:PackageImport"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var packageImportReader = new PackageImportReader(cache, loggerFactory);
                    return packageImportReader.Read(subXmlReader);
                },
                ["uml:Realization"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var realizationReader = new RealizationReader(cache, loggerFactory);
                    return realizationReader.Read(subXmlReader);
                },
                ["uml:TemplateBinding"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var templateBindingReader = new TemplateBindingReader(cache, loggerFactory);
                    return templateBindingReader.Read(subXmlReader);
                },
                ["uml:TemplateParameter"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:TemplateParameterSubstitution"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:TemplateSignature"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Usage"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:AnyReceiveEvent"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:CallEvent"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ChangeEvent"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:FunctionBehavior"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:OpaqueBehavior"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:SignalEvent"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:TimeEvent"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Trigger"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Substitution"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var substitutionReader = new SubstitutionReader(cache, loggerFactory);
                    return substitutionReader.Read(subXmlReader);
                },
                ["uml:ClassifierTemplateParameter"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Generalization"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var generalizationReader = new GeneralizationReader(cache, loggerFactory);
                    return generalizationReader.Read(subXmlReader);
                },
                ["uml:GeneralizationSet"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:InstanceSpecification"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:InstanceValue"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var instanceValueReader = new InstanceValueReader(cache, loggerFactory);
                    return instanceValueReader.Read(subXmlReader);
                },
                ["uml:Operation"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var operationReader = new OperationReader(cache, loggerFactory);
                    return operationReader.Read(subXmlReader);
                },
                ["uml:OperationTemplateParameter"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Parameter"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var parameterReader = new ParameterReader(cache, loggerFactory);
                    return parameterReader.Read(subXmlReader);
                },
                ["uml:ParameterSet"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Property"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var propertyReader = new PropertyReader(cache, loggerFactory);
                    return propertyReader.Read(subXmlReader);
                },
                ["uml:RedefinableTemplateSignature"] = (cache, loggerFactory, xmlReader) =>
                {
                    using var subXmlReader = xmlReader.ReadSubtree();
                    var redefinableTemplateSignatureReader = new RedefinableTemplateSignatureReader(cache, loggerFactory);
                    return redefinableTemplateSignatureReader.Read(subXmlReader);
                },
                ["uml:Slot"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ValueSpecificationAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:AcceptCallAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:AcceptEventAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ActionInputPin"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:AddStructuralFeatureValueAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:AddVariableValueAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:BroadcastSignalAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:CallBehaviorAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:CallOperationAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:Clause"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ClearAssociationAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ClearStructuralFeatureAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ClearVariableAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ConditionalNode"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:CreateLinkAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:CreateLinkObjectAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:CreateObjectAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:DestroyLinkAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:DestroyObjectAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ExpansionNode"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ExpansionRegion"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:InputPin"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:LinkEndCreationData"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:LinkEndData"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:LinkEndDestructionData"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:LoopNode"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:OpaqueAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:OutputPin"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:QualifierValue"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:RaiseExceptionAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ReadExtentAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ReadIsClassifiedObjectAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ReadLinkAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ReadLinkObjectEndAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ReadLinkObjectEndQualifierAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ReadSelfAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ReadStructuralFeatureAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ReadVariableAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ReclassifyObjectAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ReduceAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:RemoveStructuralFeatureValueAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:RemoveVariableValueAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ReplyAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:SendObjectAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:SendSignalAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:SequenceNode"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:StartClassifierBehaviorAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:StartObjectBehaviorAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:StructuredActivityNode"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:TestIdentityAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:UnmarshallAction"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
                },
                ["uml:ValuePin"] = (cache, loggerFactory, xmlReader) =>
                {
                    throw new NotSupportedException();
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
        /// <param name="cache">
        /// The <see cref="IXmiReaderCache"/> in which all model instances are registered
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
        public IXmiElement QueryXmiElement(XmlReader xmlReader, IXmiReaderCache cache, ILoggerFactory loggerFactory, string explicitTypeName = null)
        {
            var xmiType= xmlReader.GetAttribute("xmi:type");

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
                return readerFactory(cache, loggerFactory, xmlReader);
            }

            throw new InvalidOperationException($"No reader found for xmi:type - {xmiType}");
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
