﻿// -------------------------------------------------------------------------------------------------
//  <copyright file="ModelTransformer.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
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

namespace uml4net.CodeGenerator.Transformers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using uml4net.POCO.CommonStructure;
    using uml4net.POCO.StructuredClassifiers;
    using uml4net.Extensions;
    using uml4net.xmi.Readers;
    using Microsoft.Extensions.Logging.Abstractions;

    /// <summary>
    /// The purpose of the <see cref="ModelTransformer"/> is to transform the model prior
    /// it being used for code-generation
    /// </summary>
    public class ModelTransformer
    {
        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<ModelTransformer> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelTransformer"/> class
        /// </summary>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </param>
        public ModelTransformer(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory == null ? NullLogger<ModelTransformer>.Instance : loggerFactory.CreateLogger<ModelTransformer>();
        }

        /// <summary>
        /// Transform the model to be compatible with C#
        /// </summary>
        /// <param name="xmiReaderResult">
        /// The <see cref="XmiReaderResult"/> that contains the UML model that may be transformed
        /// </param>
        public bool Transform(XmiReaderResult xmiReaderResult, out List<IElement> updatedElements)
        {
            updatedElements = new List<IElement>();

            var packages = xmiReaderResult.Root.QueryPackages();

            foreach (var package in packages)
            {
                var classes = package.PackagedElement.OfType<IClass>().Where(x => !x.IsAbstract);

                foreach (var @class in classes)
                {
                    var property = @class.QueryAllProperties().SingleOrDefault(x => x.Name.ToLowerInvariant()  == @class.Name.ToLowerInvariant());
                    if (property != null)
                    {
                        var owner = property.Owner as INamedElement;

                        if (property.QueryIsEnumerable())
                        {
                            this.logger.LogWarning("The {owner} class has a property {property} that is renamed", owner.Name, property.Name);

                            property.Name = $"{property.Name}s";

                            updatedElements.Add(property);
                        }
                        else
                        {
                            throw new NotSupportedException("implement other cases");
                        }
                    }
                }
            }

            return updatedElements.Any();
        }
    }
}