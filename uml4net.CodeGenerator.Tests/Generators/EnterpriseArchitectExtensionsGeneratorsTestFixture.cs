// -------------------------------------------------------------------------------------------------
//  <copyright file="EnterpriseArchitectExtensionsGeneratorsTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2025 Starion Group S.A.
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
            Assert.That(async () => await this.extensionGenerator.GenerateXmiReadersAsync(this.xmiReaderResult, null, "EA_Model", this.xmiReaderDirectoryInfo),
                Throws.Nothing);
        }

        [Test]
        public void VerifyFacadeReaderGenerated()
        {
            Assert.That(async () => await this.extensionGenerator.GenerateXmiElementReaderFacadeAsync(this.xmiReaderResult, null, "EA_Model", this.xmiReaderDirectoryInfo),
                Throws.Nothing);
        }
    }
}
