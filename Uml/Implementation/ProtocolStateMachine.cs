// -------------------------------------------------------------------------------------------------
// <copyright file="ProtocolStateMachine.cs" company="RHEA System S.A.">
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

namespace Implementation.StateMachines
{
    using Uml.CommonStructure;

    /// <summary>
    /// A ProtocolStateMachine is always defined in the context of a Classifier. It specifies which BehavioralFeatures of the Classifier can be called in which State and under which conditions, thus specifying the allowed invocation sequences on the Classifier's BehavioralFeatures. A ProtocolStateMachine specifies the possible and permitted Transitions on the instances of its context Classifier, together with the BehavioralFeatures that carry the Transitions. In this manner, an instance lifecycle can be specified for a Classifier, by defining the order in which the BehavioralFeatures can be activated and the States through which an instance progresses during its existence.
    /// </summary>
    internal class ProtocolStateMachine : Implementation.CommonStructure.Element //, Uml.StateMachines.ProtocolStateMachine
    {
        public ProtocolStateMachine(string id) : base(id)
        {
        }
    }
}