// -------------------------------------------------------------------------------------------------
//  <copyright file="StateExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.StateMachines
{
    using System;

    /// <summary>
    /// The <see cref="StateExtensions"/> class provides extensions methods for <see cref="IState"/>
    /// </summary>
    internal static class StateExtensions
    {
        /// <summary>
        /// Queries a state with isComposite=true is said to be a composite State. A composite State is a State that
        /// contains at least one Region.
        /// </summary>
        /// <param name="state">
        /// The subject <see cref="IState"/>
        /// </param>
        /// <returns>
        /// A state with isComposite=true is said to be a composite State. A composite State is a State that
        /// contains at least one Region.
        /// </returns>
        internal static bool QueryIsComposite(this IState state)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Queries a State with isSimple=true is said to be a simple State A simple State does not have any Regions and
        /// it does not refer to any submachine StateMachine.
        /// </summary>
        /// <param name="state">
        /// The subject <see cref="IState"/>
        /// </param>
        /// <returns>
        /// A State with isSimple=true is said to be a simple State A simple State does not have any Regions and
        /// it does not refer to any submachine StateMachine.
        /// </returns>
        internal static bool QueryIsSimple(this IState state)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Queries A State with isSubmachineState=true is said to be a submachine State Such a State refers to another
        /// StateMachine(submachine).
        /// </summary>
        /// <param name="state">
        /// The subject <see cref="IState"/>
        /// </param>
        /// <returns>
        /// A State with isSubmachineState=true is said to be a submachine State Such a State refers to another
        /// StateMachine(submachine).
        /// </returns>
        internal static bool QueryIsSubmachineState(this IState state)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Queries A State with isOrthogonal=true is said to be an orthogonal composite State An orthogonal composite
        /// State contains two or more Regions.
        /// </summary>
        /// <param name="state">
        /// The subject <see cref="IState"/>
        /// </param>
        /// <returns>
        /// A State with isOrthogonal=true is said to be an orthogonal composite State An orthogonal composite
        /// State contains two or more Regions.
        /// </returns>
        internal static bool QueryIsOrthogonal(this IState state)
        {
            throw new NotSupportedException();
        }
    }
}
