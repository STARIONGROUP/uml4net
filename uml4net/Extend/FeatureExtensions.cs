﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="FeatureExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.Classification
{
    using System;

    /// <summary>
    /// The <see cref="FeatureExtensions"/> class provides extensions methods for <see cref="IFeature"/>
    /// </summary>
    internal static class FeatureExtensions
    {
        /// <summary>
        /// Queries The Classifiers that have this Feature as a feature.
        /// </summary>
        /// <param name="feature">
        /// The subject <see cref="IFeature"/>
        /// </param>
        /// <returns>
        /// The Classifiers that have this Feature as a feature.
        /// </returns>
        internal static IClassifier QueryFeaturingClassifier(this IFeature feature)
        {
            throw new NotSupportedException();
        }
    }
}
