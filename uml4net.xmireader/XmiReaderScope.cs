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
    using Autofac;
    using Cache;
    using Microsoft.Extensions.Logging;
    using POCO.Classification;
    using POCO.CommonStructure;
    using POCO.Packages;
    using POCO.SimpleClassifiers;
    using POCO.StructuredClassifiers;
    using POCO.Values;
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
        /// Gets the Autofac container builder for configuring services.
        /// </summary>
        internal ContainerBuilder ContainerBuilder { get; } = new();

        /// <summary>
        /// Gets the Autofac container for resolving services.
        /// </summary>
        internal IContainer Container { get; private set; }

        /// <summary>
        /// Gets the service scope which provides a scoped lifetime for services.
        /// </summary>
        internal ILifetimeScope Scope { get; private set; }

        /// <summary>
        /// Builds the service provider and service scope from the configured service collection.
        /// </summary>
        internal void CreateScope()
        {
            this.Container = this.ContainerBuilder.Build();
            this.Scope = this.Container.BeginLifetimeScope();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReaderScope"/> class and configures default services.
        /// </summary>
        internal XmiReaderScope()
        {
            // Overridable services
            this.ContainerBuilder.RegisterType<HttpClient>().AsSelf();
            this.ContainerBuilder.RegisterType<DefaultSettings>().As<IXmiReaderSettings>();

            // Required services
            this.ContainerBuilder.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>));
            this.ContainerBuilder.RegisterInstance(this).As<IXmiReaderScope>().SingleInstance();
            this.ContainerBuilder.RegisterType<Assembler>().As<IAssembler>();
            this.ContainerBuilder.RegisterType<XmiReaderCache>().As<IXmiReaderCache>().SingleInstance();
            this.ContainerBuilder.RegisterType<ExternalReferenceResolver>().As<IExternalReferenceResolver>().SingleInstance();

            // Readers
            this.ContainerBuilder.RegisterType<XmiReader>().As<IXmiReader>().PropertiesAutowired();
            this.ContainerBuilder.RegisterType<GeneralizationReader>().As<IXmiElementReader<IGeneralization>>().PropertiesAutowired();
            this.ContainerBuilder.RegisterType<PropertyReader>().As<IXmiElementReader<IProperty>>().PropertiesAutowired();
            this.ContainerBuilder.RegisterType<CommentReader>().As<IXmiElementReader<IComment>>().PropertiesAutowired();
            this.ContainerBuilder.RegisterType<ConstraintReader>().As<IXmiElementReader<IConstraint>>().PropertiesAutowired();
            this.ContainerBuilder.RegisterType<PackageImportReader>().As<IXmiElementReader<IPackageImport>>().PropertiesAutowired();
            this.ContainerBuilder.RegisterType<ModelReader>().As<IXmiElementReader<IModel>>().PropertiesAutowired();
            this.ContainerBuilder.RegisterType<PackageReader>().As<IXmiElementReader<IPackage>>().PropertiesAutowired();
            this.ContainerBuilder.RegisterType<EnumerationLiteralReader>().As<IXmiElementReader<IEnumerationLiteral>>().PropertiesAutowired();
            this.ContainerBuilder.RegisterType<EnumerationReader>().As<IXmiElementReader<IEnumeration>>().PropertiesAutowired();
            this.ContainerBuilder.RegisterType<ClassReader>().As<IXmiElementReader<IClass>>().PropertiesAutowired();
            this.ContainerBuilder.RegisterType<LiteralIntegerReader>().As<IXmiElementReader<ILiteralInteger>>().PropertiesAutowired();
            this.ContainerBuilder.RegisterType<LiteralUnlimitedNaturalReader>().As<IXmiElementReader<ILiteralUnlimitedNatural>>().PropertiesAutowired();
            this.ContainerBuilder.RegisterType<OpaqueExpressionReader>().As<IXmiElementReader<IOpaqueExpression>>().PropertiesAutowired();
            this.ContainerBuilder.RegisterType<PrimitiveTypeReader>().As<IXmiElementReader<IPrimitiveType>>().PropertiesAutowired();
            this.ContainerBuilder.RegisterType<InterfaceReader>().As<IXmiElementReader<IInterface>>().PropertiesAutowired();
            this.ContainerBuilder.RegisterType<RealizationReader>().As<IXmiElementReader<IRealization>>().PropertiesAutowired();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Container?.Dispose();
        }
    }
}
