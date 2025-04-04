﻿// -------------------------------------------------------------------------------------------------
// <copyright file="IModelInspector.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2025 Starion Group S.A.
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

namespace uml4net.Reporting.Generators
{
    using System.Collections.Generic;

    using uml4net.Classification;
    using uml4net.Packages;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// The purpose of the <see cref="IModelInspector"/> is to iterate through the model and report on the various kinds of
    /// patters that exist in the UML model that need to be taken into account for code-generation
    /// </summary>
    public interface IModelInspector : IReportGenerator
    {
        /// <summary>
        /// Inspect the content of the provided <see cref="IPackage"/> and returns the variation 
        /// of data-types, enums and multiplicity as an Analysis report
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that needs to be inspected
        /// </param>
        /// <returns>
        /// Returns a report of the classes of interest in the provided package 
        /// </returns>
        public string Inspect(IPackage package);

        /// <summary>
        /// Inspect the content of the provided <see cref="IPackage"/> and returns a
        /// read-only collection of interesting <see cref="IClass"/>
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that needs to be inspected
        /// </param>
        /// <returns>
        /// A read-only collection of interesting <see cref="IClass"/> that cover the variations
        /// of <see cref="IProperty"/>> and <see cref="IOperation"/> variations
        /// </returns>
        public IReadOnlyCollection<IClass> QueryInterestingClasses(IPackage package);

        /// <summary>
        /// Inspect the provided <see cref="IClass"/> (by name) that is contained in the <see cref="IPackage"/>
        /// and returns the variation of data-types, enums and multiplicity as an Analysis report
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that contains the <see cref="IClass"/> that
        /// is to be inspected
        /// </param>
        /// <param name="className">
        /// the name of the class that is to be inspected
        /// </param>
        /// <returns>
        /// returns a report detailing the various combinations of properties of the provided class
        /// </returns>
        public string Inspect(IPackage package, string className);

        /// <summary>
        /// Recursively analyzes the documentation of the model and prints the names of all classes 
        /// and features that do not have any documentation in an analysis report
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> which needs to be inspected
        /// </param>
        /// <returns>
        /// returns a report of the classes and properties that do not contain any documentation
        /// </returns>
        public string AnalyzeDocumentation(IPackage package);
    }
}
