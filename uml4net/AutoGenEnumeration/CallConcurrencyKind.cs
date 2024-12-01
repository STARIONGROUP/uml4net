// -------------------------------------------------------------------------------------------------
// <copyright file="CallConcurrencyKind.cs" company="Starion Group S.A.">
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

namespace uml4net.Classification
{
    /// <summary>
    /// CallConcurrencyKind is an Enumeration used to specify the semantics of concurrent calls to a
    /// BehavioralFeature.
    /// </summary>
    public enum CallConcurrencyKind
    {
        /// <summary>
        /// No concurrency management mechanism is associated with the BehavioralFeature and, therefore,
        /// concurrency conflicts may occur. Instances that invoke a BehavioralFeature need to coordinate so
        /// that only one invocation to a target on any BehavioralFeature occurs at once.
        /// </summary>
        Sequential,

        /// <summary>
        /// Multiple invocations of a BehavioralFeature that overlap in time may occur to one instance, but only
        /// one is allowed to commence. The others are blocked until the performance of the currently executing
        /// BehavioralFeature is complete. It is the responsibility of the system designer to ensure that
        /// deadlocks do not occur due to simultaneous blocking.
        /// </summary>
        Guarded,

        /// <summary>
        /// Multiple invocations of a BehavioralFeature that overlap in time may occur to one instance and all
        /// of them may proceed concurrently.
        /// </summary>
        Concurrent,

    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------