// -------------------------------------------------------------------------------------------------
// <copyright file="ActivityFinalNode.cs" company="RHEA System S.A.">
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
    using Uml.CommonStructure;
    using Uml.Values;    

    /// <summary>
    /// An <see cref="ActivityFinalNode"/> is a <see cref="FinalNode"/> that terminates the execution of its owning <see cref="Activity"/> or <see cref="StructuredActivityNode"/>.
    /// </summary>
    internal class ActivityFinalNode : Implementation.CommonStructure.Element, Uml.Activities.ActivityFinalNode
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ActivityFinalNode"/>
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="ActivityFinalNode"/>
        /// </param>        
        public ActivityFinalNode(string id) : base(id)
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
        public bool IsLeaf { get; set; }
        public IEnumerable<RedefinableElement> RedefinedElement()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Classifier> RedefinitionContext()
        {
            throw new System.NotImplementedException();
        }

        public Uml.Activities.Activity Activity { get; set; }
        public IEnumerable<ActivityGroup> InGroup { get; }
        public List<Uml.Activities.InterruptibleActivityRegion> InInterruptibleRegion { get; set; }
        public List<Uml.Activities.ActivityPartition> InPartition { get; set; }
        public StructuredActivityNode InStructuredNode { get; set; }
        public List<ActivityEdge> Incoming { get; set; }
        public List<ActivityEdge> Outgoing { get; set; }
        public List<ActivityNode> RedefinedNode { get; set; }
    }
}
