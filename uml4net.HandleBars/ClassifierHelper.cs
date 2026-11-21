// -------------------------------------------------------------------------------------------------
// <copyright file="ClassifierHelper.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.HandleBars
{
    using System;
    using System.Linq;
    using Classification;
    using HandlebarsDotNet;

    using uml4net.CommonStructure;
    using uml4net.Extensions;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// A block helper that supports codegen for <see cref="IClassifier"/>
    /// </summary>
    public static class ClassifierHelper
    {
        /// <summary>
        /// Registers the <see cref="ClassHelper"/>
        /// </summary>
        /// <param name="handlebars">
        /// The <see cref="IHandlebars"/> context with which the helper needs to be registered
        /// </param>
        public static void RegisterClassifierHelper(this IHandlebars handlebars)
        {
            handlebars.RegisterHelper("Classifier.QueryContainers", (context, _) =>
            {
                if (!(context.Value is IClassifier classifier))
                {
                    throw new ArgumentException("The object is supposed to be an IClassifier");
                }

                var containers = classifier.QueryContainers()
                    .ToList();

                return containers;
            });

            // Queries whether the classifier conforms to the type that is provided as second argument: whether that
            // type is the classifier itself or one of its direct or indirect general classifiers
            handlebars.RegisterHelper("Classifier.QueryConformsTo", (_, arguments) =>
            {
                if (arguments.Length != 2)
                {
                    throw new HandlebarsException("{{#Classifier.QueryConformsTo}} helper must have exactly two arguments");
                }

                if (!(arguments[0] is IClassifier classifier))
                {
                    throw new ArgumentException("{{#Classifier.QueryConformsTo}} - the first argument is supposed to be an IClassifier");
                }

                if (!(arguments[1] is IType other))
                {
                    throw new ArgumentException("{{#Classifier.QueryConformsTo}} - the second argument is supposed to be an IType");
                }

                return classifier.QueryConformsTo(other);
            });
        }
    }
}
