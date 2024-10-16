﻿// -------------------------------------------------------------------------------------------------
// <copyright file="IInformationFlow.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.POCO.InformationFlows
{
    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// InformationFlows describe circulation of information through a system in a general manner.
    /// They do not specify the nature of the information, mechanisms by which it is conveyed, sequences
    /// of exchange or any control conditions. During more detailed modeling, representation and realization
    /// links may be added to specify which model elements implement an InformationFlow and to show how
    /// information is conveyed.  InformationFlows require some kind of “information channel” for
    /// unidirectional transmission of information items from sources to targets.  They specify the
    /// information channel’s realizations, if any, and identify the information that flows along them.
    /// Information moving along the information channel may be represented by abstract InformationItems
    /// and by concrete Classifiers.
    /// </summary>
    public interface IInformationFlow : IDirectedRelationship, IPackageableElement
    {
    }
}
