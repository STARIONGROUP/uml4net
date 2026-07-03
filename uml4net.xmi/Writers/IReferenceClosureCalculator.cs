// -------------------------------------------------------------------------------------------------
// <copyright file="IReferenceClosureCalculator.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Writers
{
    using uml4net.Packages;
    using uml4net.xmi.Settings;

    /// <summary>
    /// The <see cref="IReferenceClosureCalculator"/> interface defines the calculation of an <see cref="XmiWritePlan"/>
    /// for a selected <see cref="IPackage"/>, which determines the elements that are serialized inside an
    /// XMI document and the root packages that the document contains.
    /// </summary>
    public interface IReferenceClosureCalculator
    {
        /// <summary>
        /// Calculates the <see cref="XmiWritePlan"/> for the provided <see cref="IPackage"/>.
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that is selected to be written
        /// </param>
        /// <param name="externalReferenceResolution">
        /// The <see cref="ExternalReferenceResolutionKind"/> that specifies how references to elements that are
        /// not contained by the <paramref name="package"/> are treated
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written
        /// </param>
        /// <returns>
        /// The calculated <see cref="XmiWritePlan"/>
        /// </returns>
        XmiWritePlan CalculateWritePlan(IPackage package, ExternalReferenceResolutionKind externalReferenceResolution, string documentName);
    }
}
