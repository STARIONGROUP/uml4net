// -------------------------------------------------------------------------------------------------
// <copyright file="IReferenceClosureCalculator.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Writers
{
    using System.Collections.Generic;

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

        /// <summary>
        /// Calculates the <see cref="XmiWritePlan"/> for the provided root elements, which are written as the
        /// top-level elements of the XMI document in the provided order.
        /// </summary>
        /// <param name="rootElements">
        /// The <see cref="IXmiElement"/>s that are selected to be written as top-level elements
        /// </param>
        /// <param name="externalReferenceResolution">
        /// The <see cref="ExternalReferenceResolutionKind"/> that specifies how references to elements that are
        /// not contained by the <paramref name="rootElements"/> are treated
        /// </param>
        /// <param name="documentName">
        /// The name of the document that is being written
        /// </param>
        /// <returns>
        /// The calculated <see cref="XmiWritePlan"/>
        /// </returns>
        XmiWritePlan CalculateWritePlan(IEnumerable<IXmiElement> rootElements, ExternalReferenceResolutionKind externalReferenceResolution, string documentName);
    }
}
