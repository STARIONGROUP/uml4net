// -------------------------------------------------------------------------------------------------
// <copyright file="Activity.cs" company="RHEA System S.A.">
//   Copyright (c) 2018-2019 RHEA System S.A.
//
//   This file is part of uml-sharp
//
//   uml-sharp is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//   
//   uml-sharp is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//   GNU General Public License for more details.
//
//   You should have received a copy of the GNU General Public License
//   along with uml-sharp. If not, see<http://www.gnu.org/licenses/>.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Implementation.Activities
{
    using System.Collections.Generic;
    using Uml.Actions;
    using Uml.Activities;
    using Uml.Assembler;
    using Uml.Classification;
    using Uml.CommonBehavior;
    using Uml.CommonStructure;
    using Uml.Packages;
    using Uml.SimpleClassifiers;
    using Uml.StructuredClassifiers;
    using Uml.UseCases;
    using Uml.Values;    

    /// <summary>
    /// An <see cref="Activity"/> is the specification of parameterized Behavior as the coordinated sequencing of subordinate units.
    /// </summary>
    internal class Activity : Implementation.CommonStructure.Element, Uml.Activities.Activity
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Activity"/>
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="Activity"/>
        /// </param>
        public Activity(string id) : base(id)
        {
        }

        
        public IEnumerable<Dependency> ClientDependency()
        {
            throw new System.NotImplementedException();
        }

        
        public string Name { get; set; }

        
        public OwnerList<StringExpression> NameExpression { get; set; }

        
        public Namespace Namespace()
        {
            throw new System.NotImplementedException();
        }

        
        public string QualifiedName()
        {
            throw new System.NotImplementedException();
        }

        
        public VisibilityKind Visibility { get; set; }

        
        public OwnerList<ElementImport> ElementImport { get; set; }

        
        public IEnumerable<PackageableElement> ImportedMember { get; set; }

        
        public IEnumerable<NamedElement> Member()
        {
            throw new System.NotImplementedException();
        }

        
        public IEnumerable<NamedElement> OwnedMember()
        {
            throw new System.NotImplementedException();
        }

        
        public OwnerList<Constraint> OwnedRule { get; set; }

        
        public OwnerList<PackageImport> PackageImport { get; set; }

        
        public TemplateParameter OwningTemplateParameter { get; set; }

        
        TemplateParameter ParameterableElement.TemplateParameter { get; set; }

        
        public ClassifierTemplateParameter TemplateParameter { get; set; }

        
        public List<UseCase> UseCase { get; set; }

        
        public OwnerList<Substitution> Substitution { get; set; }

        
        public Package Package { get; set; }

        
        public IEnumerable<Property> Attribute()
        {
            throw new System.NotImplementedException();
        }

        
        public OwnerList<CollaborationUse> CollaborationUse { get; set; }

        
        public IEnumerable<Feature> Feature()
        {
            throw new System.NotImplementedException();
        }

        
        public IEnumerable<Classifier> General()
        {
            throw new System.NotImplementedException();
        }
        
        
        public OwnerList<Generalization> Generalization { get; set; }
        
        
        public IEnumerable<NamedElement> InheritedMember()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Extension> Extension { get; set; }
        
        public bool IsAbstract { get; set; }
        
        public bool IsActive { get; set; }
        
        public OwnerList<Classifier> NestedClassifier { get; set; }
        
        public bool IsFinalSpecialization { get; set; }
        
        OwnerList<RedefinableTemplateSignature> Classifier.OwnedTemplateSignature { get; set; }
        
        public OwnerList<UseCase> OwnedUseCase { get; set; }
        
        public List<GeneralizationSet> PowertypeExtent { get; set; }
        
        public List<Classifier> RedefinedClassifier { get; set; }
        
        public CollaborationUse Representation { get; set; }
        
        OwnerList<TemplateSignature> TemplateableElement.OwnedTemplateSignature { get; set; }
        
        public OwnerList<TemplateBinding> TemplateBinding { get; set; }
        
        public bool IsLeaf { get; set; }
        
        public IEnumerable<RedefinableElement> RedefinedElement()
        {
            throw new System.NotImplementedException();
        }
        
        public IEnumerable<Classifier> RedefinitionContext()
        {
            throw new System.NotImplementedException();
        }
        
        public Behavior ClassifierBehavior { get; set; }
        
        public InterfaceRealization InterfaceRealization { get; set; }
        
        public OwnerList<Behavior> OwnedBehavior { get; set; }
        
        public OwnerList<Property> OwnedAttribute { get; set; }
        
        public OwnerList<Operation> OwnedOperation { get; set; }
        
        public OwnerList<Reception> OwnedReception { get; set; }
        
        public IEnumerable<Class> SuperClass()
        {
            throw new System.NotImplementedException();
        }
        
        public OwnerList<Connector> OwnedConnector { get; set; }
        
        public IEnumerable<Property> Part()
        {
            throw new System.NotImplementedException();
        }
        
        public IEnumerable<ConnectableElement> Role()
        {
            throw new System.NotImplementedException();
        }
        
        public IEnumerable<Port> OwnedPort()
        {
            throw new System.NotImplementedException();
        }
        
        public BehavioredClassifier Context()
        {
            throw new System.NotImplementedException();
        }
        
        public bool IsReentrant { get; set; }
        
        public OwnerList<Parameter> OwnedParameter { get; set; }
        
        public OwnerList<ParameterSet> OwnedParameterSet { get; set; }
        
        public OwnerList<Constraint> PostCondition { get; set; }
        
        public OwnerList<Constraint> PreCondition { get; set; }
        
        public BehavioralFeature Specification { get; set; }
        
        public List<Behavior> RedefinedBehavior { get; set; }
        
        public OwnerList<ActivityEdge> Edge { get; set; }
        
        public OwnerList<ActivityGroup> Group { get; set; }
        
        public bool IsReadOnly { get; set; }
        
        public bool IsSingleExecution { get; set; }
        
        public OwnerList<ActivityNode> Node { get; set; }
        
        public OwnerList<Uml.Activities.ActivityPartition> Partition { get; set; }

        public OwnerList<StructuredActivityNode> StructuredNode { get; set; }

        public OwnerList<Uml.Activities.Variable> Variable { get; set; }
    }
}