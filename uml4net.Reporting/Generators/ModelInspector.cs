﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="ModelInspector.cs" company="Starion Group S.A.">
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

namespace uml4net.Reporting.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Extensions;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using uml4net.POCO.Packages;
    using uml4net.POCO.StructuredClassifiers;

    /// <summary>
    /// The purpose of the <see cref="ModelInspector"/> is to iterate through the model and report on the various kinds of
    /// patters that exist in the ECore model that need to be taken into account for code-generation
    /// </summary>
    public class ModelInspector : ReportGenerator, IModelInspector
    {
        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<ModelInspector> logger;

        private readonly HashSet<IClass> interestingClasses = new();

        private readonly List<string> referenceTypes = new();

        private readonly List<string> valueTypes = new();

        private readonly List<string> enums = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelInspector"/> class.
        /// </summary>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to set up logging
        /// </param>
        public ModelInspector(ILoggerFactory loggerFactory = null) : base(loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ModelInspector>.Instance : loggerFactory.CreateLogger<ModelInspector>();
        }

        /// <summary>
        /// Queries the name of the report type that is generated by the current <see cref="IReportGenerator"/>
        /// </summary>
        /// <returns>
        /// human-readable name of the report type
        /// </returns>
        public string QueryReportType()
        {
            return "inspection";
        }

        /// <summary>
        /// Inspect the content of the provided <see cref="IPackage"/> and returns the variation 
        /// of data-types, enums and multiplicity as an Analysis report
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> that needs to be inspected
        /// </param>
        /// <param name="recursive">
        /// Assertion whether the sub packages should be inspected or not
        /// </param>
        /// <returns>
        /// Returns a report of the classes of interest in the provided package 
        /// </returns>
        public string Inspect(IPackage package, bool recursive = false)
        {
            this.logger.LogInformation("Start UML Model Inspection at IPackage {0}:{1}", package.XmiId, package.Name);

            var sw = Stopwatch.StartNew();

            var sb = new StringBuilder();

            sb.AppendLine($"----- PACKAGE {package.Name} ANALYSIS ------");
            sb.AppendLine("");

            this.Inspect(package, sb, recursive);

            sb.AppendLine("");
            sb.AppendLine("----- MULTIPLICITY RESULTS ------");
            sb.AppendLine("");

            this.logger.LogInformation("MULTIPLICITY RESULTS - Inspecting the Reference Types");

            var orderedReferenceTypes = this.referenceTypes.OrderBy(x => x);

            foreach (var referenceType in orderedReferenceTypes)
            {
                sb.AppendLine($"reference type: {referenceType}");
            }

            this.logger.LogInformation("MULTIPLICITY RESULTS - Inspecting the Enums");

            var orderedEnums = this.enums.OrderBy(x => x);

            foreach (var @enum in orderedEnums)
            {
                sb.AppendLine($"enum type: {@enum}");
            }

            this.logger.LogInformation("MULTIPLICITY RESULTS - Inspecting the Value Types");

            var orderedValueTypes = this.valueTypes.OrderBy(x => x);

            foreach (var valueType in orderedValueTypes)
            {
                sb.AppendLine($"value type: {valueType}");
            }

            sb.AppendLine("");
            sb.AppendLine("----- INTERESTING CLASSES ------");
            sb.AppendLine("");

            this.logger.LogInformation("INTERESTING CLASSES - Listing interesting Classes");

            foreach (var @class in this.interestingClasses.OrderBy(x => x.Name))
            {
                sb.AppendLine($"class: {package.Name}:{@class.Name}");
            }

            sb.AppendLine("");

            this.logger.LogInformation("ECore Model Inspection of EPackage {0}:{1} finished in {2} [ms]", package.XmiId, package.Name, sw.ElapsedMilliseconds);

            return sb.ToString();
        }

        /// <summary>
        /// Recursively inspects the content of the provided <see cref="EPackage"/>
        /// and adds the reported results to the provided <see cref="StringBuilder"/>
        /// </summary>
        /// <param name="package">
        /// The <see cref="EPackage"/> which needs to be inspected
        /// </param>
        /// <param name="sb">
        /// The <see cref="StringBuilder"/> to which the results of hte inspection are reported
        /// </param>
        /// <param name="recursive">
        /// A value indicating whether the sub <see cref="EPackage"/>s need to be inspected as well
        /// </param>
        private void Inspect(IPackage package, StringBuilder sb, bool recursive)
        {
            this.logger.LogInformation("Inspecting the contents of EPackage {0}:{1}", package.XmiId, package.Name);

            foreach (var eClass in package.OwnedType.OfType<IClass>().OrderBy(x => x.Name))
            {
                //this.logger.LogTrace("Inspecting EClass {0}:{1}", eClass.Identifier, eClass.Name);

                foreach (var property in eClass.OwnedAttribute)
                {
                    if (property.IsDerived)
                    {
                        continue;
                    }

                    //if (property is EReference reference)
                    //{
                    //    var referenceType = reference.IsContainment ? $"{reference.LowerBound}:{reference.UpperBound}:containment" : $"{reference.LowerBound}:{reference.UpperBound}";

                    //    if (!this.referenceTypes.Contains(referenceType))
                    //    {
                    //        this.logger.LogTrace("Inspecting reference type {0}", referenceType);

                    //        this.referenceTypes.Add(referenceType);
                    //        this.interestingClasses.Add(eClass);

                    //        sb.AppendLine($"{package.Name}.{eClass.Name} -- REF {referenceType}");
                    //    }
                    //}

                    //if (structuralFeature is EAttribute attribute)
                    //{
                    //    if (structuralFeature.QueryIsEnum())
                    //    {
                    //        var @enum = $"{attribute.LowerBound}:{attribute.UpperBound}";

                    //        this.logger.LogTrace("Inspecting enum attribute {0}", @enum);

                    //        if (!this.enums.Contains(@enum))
                    //        {
                    //            this.enums.Add(@enum);
                    //            this.interestingClasses.Add(eClass);

                    //            sb.AppendLine($"{eClass.Name} -- ENUM {@enum}");
                    //        }

                    //    }
                    //    else
                    //    {
                    //        var valueType = $"{attribute.EType.Name}:{attribute.LowerBound}:{attribute.UpperBound}";

                    //        if (!this.valueTypes.Contains(valueType))
                    //        {
                    //            this.logger.LogTrace("Inspecting value attribute {0}", valueType);

                    //            this.valueTypes.Add(valueType);
                    //            this.interestingClasses.Add(eClass);

                    //            sb.AppendLine($"{eClass.Name} -- VAL {valueType}");
                    //        }
                    //    }
                    //}
                }
            }

            if (recursive)
            {
                foreach (var subPackage in package.NestedPackage)
                {
                    this.Inspect(subPackage, sb, true);
                }
            }
        }

        /// <summary>
        /// Inspect the provided <see cref="EClass"/> (by name) that is contained in the <see cref="EPackage"/>
        /// and returns the variation of data-types, enums and multiplicity as an Analysis report
        /// </summary>
        /// <param name="package">
        /// The <see cref="EPackage"/> that contains the <see cref="EClass"/> that
        /// is to be inspected
        /// </param>
        /// <param name="className">
        /// the name of the class that is to be inspected
        /// </param>
        /// <returns>
        /// returns a report detailing the various combinations of properties of the provided class
        /// </returns>
        public string Inspect(IPackage package, string className)
        {
            this.logger.LogInformation("Start ECore named Class '{2}' Inspection at EPackage {0}:{1}", package.XmiId, package.Name, className);

            var sw = Stopwatch.StartNew();

            var sb = new StringBuilder();

            var eClass = package.OwnedType.OfType<IClass>().Single(x => x.Name == className);

            sb.AppendLine($"{package.Name}.{eClass.Name}:");
            sb.AppendLine("----------------------------------");

            //foreach (var structuralFeature in eClass.AllEStructuralFeaturesOrderByName)
            //{
            //    if (structuralFeature.Derived || structuralFeature.Transient)
            //    {
            //        continue;
            //    }

            //    //if (structuralFeature is EReference reference)
            //    //{
            //    //    string referenceType;
            //    //    if (reference.IsContainment)
            //    //    {
            //    //        referenceType = $"{reference.Name}:{reference.EType.Name} [{reference.LowerBound}..{reference.UpperBound}] - CONTAINED REFERENCE TYPE";
            //    //    }
            //    //    else
            //    //    {
            //    //        referenceType = $"{reference.Name}:{reference.EType.Name} [{reference.LowerBound}..{reference.UpperBound}] - REFERENCE TYPE";
            //    //    }

            //    //    sb.AppendLine(referenceType);
            //    //}

            //    //if (structuralFeature is EAttribute attribute)
            //    //{
            //    //    if (structuralFeature.QueryIsEnum())
            //    //    {
            //    //        var @enum = $"{attribute.Name}:{attribute.EType.Name} [{attribute.LowerBound}..{attribute.UpperBound}] - ENUM TYPE";
            //    //        sb.AppendLine(@enum);
            //    //    }
            //    //    else
            //    //    {
            //    //        var valueType = $"{attribute.Name}:{attribute.EType.Name} [{attribute.LowerBound}..{attribute.UpperBound}] - VALUETYPE";
            //    //        sb.AppendLine(valueType);
            //    //    }
            //    //}
            //}

            sb.AppendLine("-DERIVED--------------------------");
            //foreach (var structuralFeature in eClass.AllEStructuralFeaturesOrderByName)
            //{
            //    if (structuralFeature.Derived)
            //    {
            //        //if (structuralFeature is EReference reference)
            //        //{
            //        //    var referenceType = $"{reference.Name}:{reference.EType.Name} [{reference.LowerBound}..{reference.UpperBound}] - REFERENCE TYPE";
            //        //    sb.AppendLine(referenceType);
            //        //}

            //        //if (structuralFeature is EAttribute attribute)
            //        //{
            //        //    if (structuralFeature.QueryIsEnum())
            //        //    {
            //        //        var @enum = $"{attribute.Name}:{attribute.EType.Name} [{attribute.LowerBound}..{attribute.UpperBound}] - ENUM TYPE";
            //        //        sb.AppendLine(@enum);
            //        //    }
            //        //    else
            //        //    {
            //        //        var valueType = $"{attribute.Name}:{attribute.EType.Name} [{attribute.LowerBound}..{attribute.UpperBound}] - VALUETYPE";
            //        //        sb.AppendLine(valueType);
            //        //    }
            //        //}
            //    }
            //}

            this.logger.LogInformation("ECore named Class '{2}' Inspection at EPackage {0}:{1} finished in {3} [ms]", package.XmiId, package.Name, className, sw.ElapsedMilliseconds);

            return sb.ToString();
        }

        /// <summary>
        /// Recursively analyzes the documentation of the model and prints the names of all classes 
        /// and features that do not have any documentation in an analysis report
        /// </summary>
        /// <param name="package">
        /// The <see cref="IPackage"/> which needs to be inspected
        /// </param>
        /// <param name="recursive">
        /// A value indicating whether the sub <see cref="IPackage"/>s need to be Analyzed as well
        /// </param>
        /// <returns>
        /// returns a report of the classes and properties that do not contain any documentation
        /// </returns>
        public string AnalyzeDocumentation(IPackage package, bool recursive = false)
        {
            this.logger.LogInformation("Start inspection of EPackage documentation {0}:{1}", package.XmiId, package.Name);

            var sw = Stopwatch.StartNew();

            var sb = new StringBuilder();

            sb.AppendLine("----- MISSING DOCUMENTATION ANALYSIS ------");
            sb.AppendLine("");

            this.AnalyzeDocumentation(package, sb, recursive);

            sb.AppendLine("");

            this.logger.LogInformation("Inspection of EPackage documentation {0}:{1} finished in {3} [ms]", package.XmiId, package.Name, sw.ElapsedMilliseconds);

            return sb.ToString();
        }

        /// <summary>
        /// Recursively analyzes the documentation of the model and adds the result to the provided
        /// <see cref="StringBuilder"/>
        /// </summary>
        /// <param name="package">
        /// The <see cref="EPackage"/> which needs to be inspected
        /// </param>
        /// <param name="recursive">
        /// A value indicating whether the sub <see cref="EPackage"/>s need to be Analyzed as well
        /// </param>
        private void AnalyzeDocumentation(IPackage package, StringBuilder sb, bool recursive = false)
        {
            sb.AppendLine($"Package.Class:Feature");
            sb.AppendLine();

            //foreach (var eClass in package.EClassifiers.OfType<EClass>().OrderBy(x => x.Name))
            //{
            //    if (string.IsNullOrEmpty(eClass.QueryRawDocumentation()))
            //    {
            //        sb.AppendLine($"{package.Name}.{eClass.Name}");
            //    }

            //    foreach (var eStructuralFeature in eClass.EStructuralFeaturesOrderByName)
            //    {
            //        if (string.IsNullOrEmpty(eStructuralFeature.QueryRawDocumentation()))
            //        {
            //            sb.AppendLine($"{package.Name}.{eClass.Name}:{eStructuralFeature.Name}");
            //        }
            //    }
            //}

            if (recursive)
            {
                foreach (var subPackage in package.NestedPackage)
                {
                    this.AnalyzeDocumentation(subPackage, sb, true);
                }
            }
        }

        /// <summary>
        /// Verifies whether the extension of the <paramref name="outputPath"/> is valid or not
        /// </summary>
        /// <param name="outputPath">
        /// The subject <see cref="FileInfo"/> to check
        /// </param>
        /// <returns>
        /// A Tuple of bool and string, where the string contains a description of the verification.
        /// Either stating that the extension is valid or not.
        /// </returns>
        public override Tuple<bool, string> IsValidReportExtension(FileInfo outputPath)
        {
            if (outputPath.Extension == ".txt")
            {
                return new Tuple<bool, string>(true, ".txt is a supported report extension");
            }

            return new Tuple<bool, string>(false,
                $"The Extension of the output file '{outputPath.Extension}' is not supported. Supported extensions is '.txt'");
        }

        /// <summary>
        /// Generates a table that contains all classes, attributes and their documentation
        /// </summary>
        /// <param name="modelPath">
        /// the path to the Ecore model of which the report is to be generated.
        /// </param>
        /// <param name="outputPath">
        /// the path, including filename, where the output is to be generated.
        /// </param>
        public void GenerateReport(FileInfo modelPath, FileInfo outputPath)
        {
            if (modelPath == null)
            {
                throw new ArgumentNullException(nameof(modelPath));
            }

            if (outputPath == null)
            {
                throw new ArgumentNullException(nameof(outputPath));
            }

            var sw = Stopwatch.StartNew();

            this.logger.LogInformation("Start Generating Inspection Report");

            //var rootPackage = this.LoadRootPackage(modelPath);
            IPackage rootPackage = null;

            var result = new StringBuilder();

            result.Append(this.ReportHeader());
            result.Append(this.Inspect(rootPackage, true));
            result.Append(this.AnalyzeDocumentation(rootPackage, true));

            if (outputPath.Exists)
            {
                outputPath.Delete();
            }

            using var writer = outputPath.CreateText();
            writer.Write(result);

            this.logger.LogInformation("Generated inspection report in {0} [ms]", sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Generates the report header that is the first part of the text report
        /// </summary>
        /// <returns>
        /// a string containing the header information
        /// </returns>
        private string ReportHeader()
        {
            this.logger.LogDebug("Generate report header");

            var header = new StringBuilder();

            header.AppendLine("The purpose of this report is to provide an overview of the");
            header.AppendLine("contents of an ECore model.");
            header.AppendLine("");
            header.AppendLine("1. This report shows the variation of value-types reference-types");
            header.AppendLine("   and enumerations");
            header.AppendLine("2. The report provides an overview of the variation of");
            header.AppendLine("   used multiplicities. ");
            header.AppendLine("3. The report shows an overview of interesting classes.");
            header.AppendLine("   Interesting classes are those classes that should be used");
            header.AppendLine("   when writing unit tests for code generation. By writing");
            header.AppendLine("   tests for these classes all variations of types and multiplicities");
            header.AppendLine("   are covered.");
            header.AppendLine("4. The report lists each class and feature that does contain");
            header.AppendLine("   any documentation.");
            header.AppendLine("");
            header.AppendLine($"Inspection Report generated on {DateTime.Now:f}");
            header.AppendLine("");

            return header.ToString();
        }
    }
}