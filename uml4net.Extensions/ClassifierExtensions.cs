// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassifierExtensions.cs" company="Starion Group N.V.">
//    Copyright (c) 2024 Starion Group N.V.
// 
//    Author: Seliman Niakate, Sebastien d'Antuono, Nathanael Smiechowski, Amine Nemmaoui, Amir Janati.
// 
//    This file is part of the SafePlace solution.
// 
//    SafePlace is distributed under the terms and conditions of the
//    European Space Agency Public License (ESA-PL) Weak Copyleft (Type 2) – v2.4
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace uml4net.Extensions
{
    using POCO.Classification;
    using System.Collections.Generic;

    using System.Collections.ObjectModel;
    using System.Linq;

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
