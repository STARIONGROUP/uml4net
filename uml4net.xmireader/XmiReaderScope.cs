// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiReaderBuilder.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi
{
    using Cache;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using POCO.Classification;
    using POCO.CommonStructure;
    using POCO.Packages;
    using POCO.SimpleClassifiers;
    using POCO.StructuredClassifiers;
    using POCO.Values;
    using System;
    using System.Net.Http;
    using Readers;
    using Readers.Classification;
    using Readers.CommonStructure;
    using Readers.Packages;
    using Readers.SimpleClassifiers;
    using Readers.StructuredClassifiers;
    using Readers.Values;
    using Settings;

    /// <summary>
    /// Represents the scope for configuring and managing services used by the XMI reader.
    /// </summary>
    public class XmiReaderScope : IXmiReaderScope
    {
        /// <summary>
        /// Gets the service collection where all service registrations are stored.
        /// </summary>
        internal IServiceCollection ServiceCollection { get; } = new ServiceCollection();

        /// <summary>
        /// Gets the service provider responsible for resolving services.
        /// </summary>
        internal IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// Gets the service scope which provides a scoped lifetime for services.
        /// </summary>
        internal IServiceScope Scope { get; private set; }

        /// <summary>
        /// Builds the service provider and service scope from the configured service collection.
        /// </summary>
        internal void CreateScope()
        {
            this.ServiceProvider = this.ServiceCollection.BuildServiceProvider();
            this.Scope = this.ServiceProvider.CreateScope();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReaderScope"/> class and configures default services.
        /// </summary>
        internal XmiReaderScope()
        {
            //Overridable services
            this.ServiceCollection.AddScoped(_ => new HttpClient());
            this.ServiceCollection.AddScoped<IXmiReaderSettings, DefaultSettings>();
            this.ServiceCollection.AddSingleton(LoggerFactory.Create(builder => builder.AddConsole()));

            //Required services
            this.ServiceCollection.AddScoped(typeof(ILogger<>), typeof(Logger<>));
            this.ServiceCollection.AddScoped<IXmiReaderScope>(x => this);
            this.ServiceCollection.AddScoped<IXmiReader, XmiReader>();
            this.ServiceCollection.AddScoped<IAssembler, Assembler>();
            this.ServiceCollection.AddScoped<IXmiReaderCache, XmiReaderCache>();
            this.ServiceCollection.AddScoped<IExternalReferenceResolver, ExternalReferenceResolver>();

            //Readers
            this.ServiceCollection.AddScoped<IXmiElementReader<IGeneralization>, GeneralizationReader>();
            this.ServiceCollection.AddScoped<IXmiElementReader<IProperty>, PropertyReader>();
            this.ServiceCollection.AddScoped<IXmiElementReader<IComment>, CommentReader>();
            this.ServiceCollection.AddScoped<IXmiElementReader<IConstraint>, ConstraintReader>();
            this.ServiceCollection.AddScoped<IXmiElementReader<IPackageImport>, PackageImportReader>();
            this.ServiceCollection.AddScoped<IXmiElementReader<IModel>, ModelReader>();
            this.ServiceCollection.AddScoped<IXmiElementReader<IPackage>, PackageReader>();
            this.ServiceCollection.AddScoped<IXmiElementReader<IEnumerationLiteral>, EnumerationLiteralReader>();
            this.ServiceCollection.AddScoped<IXmiElementReader<IEnumeration>, EnumerationReader>();
            this.ServiceCollection.AddScoped<IXmiElementReader<IClass>, ClassReader>();
            this.ServiceCollection.AddScoped<IXmiElementReader<ILiteralInteger>, LiteralIntegerReader>();
            this.ServiceCollection.AddScoped<IXmiElementReader<ILiteralUnlimitedNatural>, LiteralUnlimitedNaturalReader>();
            this.ServiceCollection.AddScoped<IXmiElementReader<IOpaqueExpression>, OpaqueExpressionReader>();
            this.ServiceCollection.AddScoped<IXmiElementReader<IPrimitiveType>, PrimitiveTypeReader>();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Scope.Dispose();
            this.ServiceCollection.Clear();
        }
    }
}
