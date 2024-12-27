// -------------------------------------------------------------------------------------------------
//  <copyright file="ClassifierExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using uml4net.Classification;

    /// <summary>
    /// The <see cref="ClassifierExtensions"/> class provides extensions methods for the <see cref="IClassifier"/>
    /// </summary>
    public static class ClassifierExtensions
    {
        /// <summary>
        /// Queries all the general <see cref="IClassifier"/>s of the subject <see cref="IClassifier"/>
        /// </summary>
        /// <param name="classifier">
        /// the subject <see cref="IClassifier"/>
        /// </param>
        /// <returns>
        /// a readonly collection of <see cref="IClassifier"/>s, including the subject <see cref="IClassifier"/>, of
        /// all the super classifiers 
        /// </returns>
        public static ReadOnlyCollection<IClassifier> QueryAllGeneralClassifiers(this IClassifier classifier)
        {
            if (classifier == null)
            {
                throw new ArgumentNullException(nameof(classifier));
            }

            var result = new List<IClassifier> { classifier };

            if (classifier.Generalization != null)
            {
                foreach (var generalization in classifier.Generalization)
                {
                    result.AddRange(generalization.General.QueryAllGeneralClassifiers());
                }
            }

            return result.Distinct().ToList().AsReadOnly();
        }
    }
}
