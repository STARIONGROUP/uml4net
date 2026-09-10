// -------------------------------------------------------------------------------------------------
// <copyright file="RedefinableTemplateSignatureExtensions.cs" company="Starion Group S.A.">
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
