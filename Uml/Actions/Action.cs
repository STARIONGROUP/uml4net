// -------------------------------------------------------------------------------------------------
// <copyright file="Action.cs" company="RHEA System S.A.">
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

namespace Uml.Actions
{
    using System.Collections.Generic;
    using Uml.Assembler;
    using Uml.Activities;
    using Uml.Attributes;
    using Uml.Classification;
    using Uml.CommonStructure;

    /// <summary>
    /// An <see cref="Action"/> is the fundamental unit of executable functionality. The execution of an <see cref="Action"/> represents some transformation or processing in the modeled system. <see cref="Action"/>s provide the <see cref="ExecutableNode"/>s within Activities and may also be used within <see cref="Interaction"/>s.
    /// </summary>
    [Class(IsAbstract = true, IsActive = false, Specializations = "ValueSpecificationAction|VariableAction|AcceptEventAction|ClearAssociationAction|CreateObjectAction|DestroyObjectAction|InvocationAction|LinkAction|OpaqueAction|RaiseExceptionAction|ReadExtentAction|ReadIsClassifiedObjectAction|ReadLinkObjectEndAction|ReadLinkObjectEndQualifierAction|ReadSelfAction|ReclassifyObjectAction|ReduceAction|ReplyAction|StartClassifierBehaviorAction|StructuralFeatureAction|StructuredActivityNode|TestIdentityAction|UnmarshallAction")]
    public interface Action : ExecutableNode
    {
        /// <summary>
        /// The context <see cref="Classifier"/> of the <see cref="Behavior"/> that contains this <see cref="Action"/>, or the <see cref="Behavior"/> itself if it has no context.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "1")]
        [Property(IsDerived = true, IsDerivedUnion = false, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        Classifier Content { get; }

        /// <summary>
        /// The ordered set of <see cref="InputPin"/>s representing the inputs to the <see cref="Action"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = true, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = true, IsDerivedUnion = true, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        IEnumerable<InputPin> Input { get; }

        /// <summary>
        /// If true, the <see cref="Action"/> can begin a new, concurrent execution, even if there is already another execution of the <see cref="Action"/> ongoing. If false, the <see cref="Action"/> cannot begin a new execution until any previous execution has completed.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 1, Upper = "1")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.None, SubsettedProperty = "", RedefinedProperty = "")]
        bool IsLocallyReentrant { get; set; }

        /// <summary>
        /// A <see cref="Constraint"/> that must be satisfied when execution of the <see cref="Action"/> is completed.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<Constraint> LocalPostcondition { get; set; }

        /// <summary>
        /// A <see cref="Constraint"/> that must be satisfied when execution of the <see cref="Action"/> is started.
        /// </summary>
        [MultiplicityElement(IsOrdered = false, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = false, IsDerivedUnion = false, IsReadOnly = false, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        OwnerList<Constraint> LocalPrecondition { get; set; }

        /// <summary>
        /// The ordered set of <see cref="OutputPin"/>s representing outputs from the <see cref="Action"/>.
        /// </summary>
        [MultiplicityElement(IsOrdered = true, IsUnique = true, Lower = 0, Upper = "*")]
        [Property(IsDerived = true, IsDerivedUnion = true, IsReadOnly = true, IsStatic = false, Aggregation = AggregationKind.Composite, SubsettedProperty = "Element.OwnedElement", RedefinedProperty = "")]
        IEnumerable<OutputPin> Output { get; }
    }
}