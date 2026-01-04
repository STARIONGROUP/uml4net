// -------------------------------------------------------------------------------------------------
//  <copyright file="EAPropertyExtensionsTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2026 Starion Group S.A.
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

namespace uml4net.Extensions.Tests
{
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    
    using xmi.Readers;

    [TestFixture]
    public class EAPropertyExtensionsTestFixture
    {
        private ILoggerFactory loggerFactory;

        private XmiReaderResult xmiReaderResult;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });
        }

        [SetUp]
        public void SetUp()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.UseStrictReading = false;
                    x.LocalReferenceBasePath = rootPath;
                })
                .WithLogger(this.loggerFactory)
                .Build();

            this.xmiReaderResult = reader.Read(Path.Combine(rootPath, "EnterpriseArchitectAggregation.xmi"));
        }

        [Test]
        public void Verify_that_QueryIsContainment_returns_expected_Result()
        {
            var root = this.xmiReaderResult.QueryRoot(xmiId: null, name: "EA_Model");

            var package1 = root.NestedPackage.Single(x => x.Name == "Package1");
            
            var class2 = package1.PackagedElement.OfType<IClass>().Single(x => x.Name == "Class2");

            var prop = class2.OwnedAttribute.Single();

            Assert.That(prop.IsComposite, Is.True);

            var class4 = package1.PackagedElement.OfType<IClass>().Single(x => x.Name == "Class4");
            prop = class4.OwnedAttribute.Single();

            Assert.That(prop.IsComposite, Is.False);
        }
    }
}
