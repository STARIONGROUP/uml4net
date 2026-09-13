// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderRootElementsTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright (C) 2019-2026 Starion Group S.A.
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

namespace uml4net.xmi.Tests
{
    using System;
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Readers;

    [TestFixture]
    public class XmiReaderRootElementsTestFixture
    {
        private ILoggerFactory loggerFactory;

        private string rootPath;

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

            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "ProxyReferences");
        }

        private XmiReaderResult Read(string fileName)
        {
            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = this.rootPath)
                .WithLogger(this.loggerFactory)
                .Build();

            return reader.Read(Path.Combine(this.rootPath, fileName));
        }

        [Test]
        public void Verify_that_a_class_as_document_root_is_read()
        {
            var xmiReaderResult = this.Read("bare-class-root.xml");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiReaderResult.Packages, Is.Empty);
                Assert.That(xmiReaderResult.RootElements, Has.Count.EqualTo(1));

                var @class = xmiReaderResult.QueryRootElement<IClass>("class1");

                Assert.That(@class.Name, Is.EqualTo("Class1"));
                Assert.That(@class.OwnedAttribute.Single().Name, Is.EqualTo("prop1"));
                Assert.That(xmiReaderResult.XmiRoot.Content, Is.EquivalentTo(new[] { @class }));
            }
        }

        [Test]
        public void Verify_that_a_flat_list_of_root_elements_is_read_in_document_order()
        {
            var xmiReaderResult = this.Read("flat-roots.xml");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiReaderResult.Packages, Is.Empty);
                Assert.That(xmiReaderResult.RootElements.Select(x => x.XmiId), Is.EqualTo(new[] { "idO1", "idC2" }));

                var operation = xmiReaderResult.QueryRootElement<IOperation>("idO1");
                var constraint = xmiReaderResult.QueryRootElement<IConstraint>("idC2");

                Assert.That(constraint.ConstrainedElement.Single(), Is.SameAs(operation));
                Assert.That(constraint.Specification.Single().XmiId, Is.EqualTo("idS2"));
            }
        }

        [Test]
        public void Verify_that_QueryRootElement_throws_for_unknown_or_missing_identifiers()
        {
            var xmiReaderResult = this.Read("flat-roots.xml");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => xmiReaderResult.QueryRootElement<IOperation>("unknown"), Throws.InstanceOf<InvalidOperationException>());
                Assert.That(() => xmiReaderResult.QueryRootElement<IClass>("idO1"), Throws.InstanceOf<InvalidOperationException>());
                Assert.That(() => xmiReaderResult.QueryRootElement<IOperation>(null), Throws.ArgumentNullException);
                Assert.That(() => xmiReaderResult.QueryRootElement<IOperation>(string.Empty), Throws.ArgumentNullException);
            }
        }
    }
}
