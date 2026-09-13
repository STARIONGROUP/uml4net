// -------------------------------------------------------------------------------------------------
// <copyright file="UnresolvedReferencesException.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.xmi.Settings;

    /// <summary>
    /// The exception that is thrown by the <see cref="XmiReader"/> when references could not be resolved and
    /// <see cref="IXmiReaderSettings.ThrowOnUnresolvedReferences"/> is set
    /// </summary>
    public class UnresolvedReferencesException : Exception
    {
        /// <summary>
        /// The maximum number of <see cref="XmiReferenceResolutionFailure"/>s that are listed in the <see cref="Exception.Message"/>
        /// </summary>
        public const int MaximumListedFailures = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnresolvedReferencesException"/> class.
        /// </summary>
        /// <param name="failures">
        /// The <see cref="XmiReferenceResolutionFailure"/>s that describe the references that could not be resolved
        /// </param>
        public UnresolvedReferencesException(IReadOnlyList<XmiReferenceResolutionFailure> failures)
            : base(CreateMessage(failures ?? throw new ArgumentNullException(nameof(failures))))
        {
            this.Failures = failures;
        }

        /// <summary>
        /// Gets the <see cref="XmiReferenceResolutionFailure"/>s that describe the references that could not be resolved
        /// </summary>
        public IReadOnlyList<XmiReferenceResolutionFailure> Failures { get; }

        /// <summary>
        /// Creates the message that lists the first <see cref="MaximumListedFailures"/> failures
        /// </summary>
        /// <param name="failures">
        /// The <see cref="XmiReferenceResolutionFailure"/>s that describe the references that could not be resolved
        /// </param>
        /// <returns>
        /// the message of the exception
        /// </returns>
        private static string CreateMessage(IReadOnlyList<XmiReferenceResolutionFailure> failures)
        {
            var listedFailures = string.Join(Environment.NewLine, failures.Take(MaximumListedFailures).Select(x => $"  {x}"));

            var message = $"{failures.Count} reference(s) could not be resolved:{Environment.NewLine}{listedFailures}";

            return failures.Count > MaximumListedFailures
                ? $"{message}{Environment.NewLine}  ... and {failures.Count - MaximumListedFailures} more"
                : message;
        }
    }
}
