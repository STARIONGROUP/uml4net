// -------------------------------------------------------------------------------------------------
// <copyright file="InteractionOperatorKind.cs" company="Starion Group S.A.">
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

namespace uml4net.Interactions
{
    /// <summary>
    /// InteractionOperatorKind is an enumeration designating the different kinds of operators of
    /// CombinedFragments. The InteractionOperand defines the type of operator of a CombinedFragment.
    /// </summary>
    public enum InteractionOperatorKind
    {
        /// <summary>
        /// The InteractionOperatorKind seq designates that the CombinedFragment represents a weak sequencing
        /// between the behaviors of the operands.
        /// </summary>
        Seq,

        /// <summary>
        /// The InteractionOperatorKind alt designates that the CombinedFragment represents a choice of
        /// behavior. At most one of the operands will be chosen. The chosen operand must have an explicit or
        /// implicit guard expression that evaluates to true at this point in the interaction. An implicit true
        /// guard is implied if the operand has no guard.
        /// </summary>
        Alt,

        /// <summary>
        /// The InteractionOperatorKind opt designates that the CombinedFragment represents a choice of behavior
        /// where either the (sole) operand happens or nothing happens. An option is semantically equivalent to
        /// an alternative CombinedFragment where there is one operand with non-empty content and the second
        /// operand is empty.
        /// </summary>
        Opt,

        /// <summary>
        /// The InteractionOperatorKind break designates that the CombinedFragment represents a breaking
        /// scenario in the sense that the operand is a scenario that is performed instead of the remainder of
        /// the enclosing InteractionFragment. A break operator with a guard is chosen when the guard is true
        /// and the rest of the enclosing Interaction Fragment is ignored. When the guard of the break operand
        /// is false, the break operand is ignored and the rest of the enclosing InteractionFragment is chosen.
        /// The choice between a break operand without a guard and the rest of the enclosing InteractionFragment
        /// is done non-deterministically.
        /// </summary>
        Break,

        /// <summary>
        /// The InteractionOperatorKind par designates that the CombinedFragment represents a parallel merge
        /// between the behaviors of the operands. The OccurrenceSpecifications of the different operands can be
        /// interleaved in any way as long as the ordering imposed by each operand as such is preserved.
        /// </summary>
        Par,

        /// <summary>
        /// The InteractionOperatorKind strict designates that the CombinedFragment represents a strict
        /// sequencing between the behaviors of the operands. The semantics of strict sequencing defines a
        /// strict ordering of the operands on the first level within the CombinedFragment with
        /// interactionOperator strict. Therefore OccurrenceSpecifications within contained CombinedFragment
        /// will not directly be compared with other OccurrenceSpecifications of the enclosing CombinedFragment.
        /// </summary>
        Strict,

        /// <summary>
        /// The InteractionOperatorKind loop designates that the CombinedFragment represents a loop. The loop
        /// operand will be repeated a number of times.
        /// </summary>
        Loop,

        /// <summary>
        /// The InteractionOperatorKind critical designates that the CombinedFragment represents a critical
        /// region. A critical region means that the traces of the region cannot be interleaved by other
        /// OccurrenceSpecifications (on those Lifelines covered by the region). This means that the region is
        /// treated atomically by the enclosing fragment when determining the set of valid traces. Even though
        /// enclosing CombinedFragments may imply that some OccurrenceSpecifications may interleave into the
        /// region, such as with par-operator, this is prevented by defining a region.
        /// </summary>
        Critical,

        /// <summary>
        /// The InteractionOperatorKind neg designates that the CombinedFragment represents traces that are
        /// defined to be invalid.
        /// </summary>
        Neg,

        /// <summary>
        /// The InteractionOperatorKind assert designates that the CombinedFragment represents an assertion. The
        /// sequences of the operand of the assertion are the only valid continuations. All other continuations
        /// result in an invalid trace.
        /// </summary>
        Assert,

        /// <summary>
        /// The InteractionOperatorKind ignore designates that there are some message types that are not shown
        /// within this combined fragment. These message types can be considered insignificant and are
        /// implicitly ignored if they appear in a corresponding execution. Alternatively, one can understand
        /// ignore to mean that the message types that are ignored can appear anywhere in the traces.
        /// </summary>
        Ignore,

        /// <summary>
        /// The InteractionOperatorKind consider designates which messages should be considered within this
        /// combined fragment. This is equivalent to defining every other message to be ignored.
        /// </summary>
        Consider
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
