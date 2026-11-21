// -------------------------------------------------------------------------------------------------
// <copyright file="RedefinableTemplateSignatureExtensions.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Classification
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.CommonStructure;

    /// <summary>
    /// The <see cref="RedefinableTemplateSignatureExtensions"/> class provides extensions methods for <see cref="IRedefinableTemplateSignature"/>
    /// </summary>
    internal static class RedefinableTemplateSignatureExtensions
    {
        /// <summary>
        /// Queries The formal template parameters of the extended signatures. Per the UML 2.5.1 metamodel this is
        /// derived as: <c>if extendedSignature->isEmpty() then Set{} else extendedSignature.parameter->asSet()
        /// endif</c>.
        /// </summary>
        /// <param name="redefinableTemplateSignature">
        /// The subject <see cref="IRedefinableTemplateSignature"/>
        /// </param>
        /// <returns>
        /// The formal template parameters of the extended signatures
        /// </returns>
        internal static List<ITemplateParameter> QueryInheritedParameter(this IRedefinableTemplateSignature redefinableTemplateSignature)
        {
            if (redefinableTemplateSignature == null)
            {
                throw new ArgumentNullException(nameof(redefinableTemplateSignature));
            }

            return redefinableTemplateSignature.ExtendedSignature
                .SelectMany(extendedSignature => extendedSignature.Parameter)
                .Distinct()
                .ToList();
        }
    }
}
