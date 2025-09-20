// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiReaderCrossReferenceTwoModels.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests
{
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.Classification;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi;

    [TestFixture]
    public class XmiReaderCrossReferenceTwoModels
    {
        private ILoggerFactory loggerFactory;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });
        }

        [Test]
        public void Verify_that_doc1_and_doc2_can_be_read_where_the_contents_references_each_other()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "doc1.xml"));

            Assert.That(xmiReaderResult.XmiRoot, Is.Not.Null);
            Assert.That(xmiReaderResult.XmiRoot.Documentation.ShortDescription.First(), Is.EqualTo("demo for crossreferencing between doc1 and doc2"));

            Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(2));

            var class_2 = xmiReaderResult.QueryRoot("doc1").PackagedElement.OfType<IClass>().Single(x => x.FullyQualifiedIdentifier == "doc1.xml#class02");
            Assert.That(class_2.DocumentName, Is.EqualTo("doc1.xml"));

            var class_1 = xmiReaderResult.Packages[1].PackagedElement.OfType<IClass>().Single(x => x.FullyQualifiedIdentifier == "doc2.xml#class01");
            Assert.That(class_1.DocumentName, Is.EqualTo("doc2.xml"));

            Assert.That(class_2.OwnedAttribute.OfType<IProperty>().Single().Type, Is.EqualTo(class_1) );
        }
    }
}
