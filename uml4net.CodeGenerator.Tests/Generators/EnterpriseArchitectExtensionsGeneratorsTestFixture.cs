// -------------------------------------------------------------------------------------------------
// <copyright file="EnterpriseArchitectExtensionsGeneratorsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.CodeGenerator.Tests.Generators
{
    using System.IO;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.CodeGenerator.Generators;
    using uml4net.CodeGenerator.Tests.Expected;
    using uml4net.CodeGenerator.Transformers;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

    [TestFixture]
    public class EnterpriseArchitectExtensionsGeneratorsTestFixture
    {
        private DirectoryInfo interfaceDirectoryInfo;
        private DirectoryInfo classesDirectoryInfo;
        private DirectoryInfo enumerationDirectoryInfo;
        private ExtensionGenerator extensionGenerator;
        private ILoggerFactory loggerFactory;
        private XmiReaderResult xmiReaderResult;
        private DirectoryInfo xmiReaderDirectoryInfo;
        private const string Extender = "Enterprise Architect";
        private const string ExtenderId = "6.5";

        [SetUp]
        public void SetUp()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            this.xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "EnterpriseArchitectExtensions.xmi"));

            var modelTransformer = new ModelTransformer(this.loggerFactory);
            modelTransformer.TryTransform(this.xmiReaderResult, "", "EA_Model", out var updatedElements);

            var directoryInfo = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);

            this.interfaceDirectoryInfo = directoryInfo.CreateSubdirectory("_uml4net.EnterpriseArchitectExtensions.AutoGenInterfaces");
            this.classesDirectoryInfo = directoryInfo.CreateSubdirectory("_uml4net.EnterpriseArchitectExtensions.AutoGenClasses");
            this.enumerationDirectoryInfo = directoryInfo.CreateSubdirectory("_uml4net.EnterpriseArchitectExtensions.AutoGenEnumeration");
            this.xmiReaderDirectoryInfo = directoryInfo.CreateSubdirectory("_uml4net.EnterpriseArchitectExtensions.AutoGenReaders");

            this.extensionGenerator = new ExtensionGenerator();
        }
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder => { builder.AddSerilog(); });
        }

        [Test]
        public async Task VerifyExtensionClassesGenerated()
        {
            await Assert.ThatAsync(
                () => this.extensionGenerator.GenerateExtensionClassesAsync(this.xmiReaderResult, null, "EA_Model", this.classesDirectoryInfo),
                Throws.Nothing);
        }

        [Test]
        public async Task VerifyEnumerationsGenerated()
        {
            await Assert.ThatAsync(
                () => this.extensionGenerator.GenerateEnumerationsAsync(this.xmiReaderResult, null, "EA_Model", this.enumerationDirectoryInfo),
                Throws.Nothing);
        }

        [Test]
        public void VerifyInterfacesGenerated()
        {
            Assert.That(
                async () => await this.extensionGenerator.GenerateInterfacesAsync(this.xmiReaderResult, null, "EA_Model", this.interfaceDirectoryInfo),
                Throws.Nothing);
        }
        
        [Test]
        public void VerifyReadersAreGenerated()
        {
            Assert.That(async () => await this.extensionGenerator.GenerateExtensionReadersAsync(this.xmiReaderResult, null, "EA_Model",Extender,ExtenderId, this.xmiReaderDirectoryInfo),
                Throws.Nothing);
        }

        [Test]
        public void VerifyFacadeReaderGenerated()
        {
            Assert.That(async () => await this.extensionGenerator.GenerateExtensionContentReaderFacadeAsync(this.xmiReaderResult, null, "EA_Model", Extender,ExtenderId, this.xmiReaderDirectoryInfo),
                Throws.Nothing);
        }
    }
}
