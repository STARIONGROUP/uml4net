// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderNamespacePrefixTestFixture.cs" company="Starion Group S.A.">
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
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.StructuredClassifiers;
    using uml4net.Values;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Verifies that documents that bind the UML or XMI namespace to a prefix other than uml/xmi, or to the
    /// default namespace, are read (XMI 2.5.1 clause 9.5.1 rule 1h and clause 9.5.2 rule 2g)
    /// </summary>
    [TestFixture]
    public class XmiReaderNamespacePrefixTestFixture
    {
        private string rootPath;

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Namespaces");
        }

        private XmiReaderResult Read(string fileName)
        {
            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.LocalReferenceBasePath = this.rootPath;
                    x.UseStrictReading = true;
                })
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            return reader.Read(Path.Combine(this.rootPath, fileName));
        }

        [Test]
        public void Verify_that_a_document_binding_the_UML_namespace_to_another_prefix_is_read()
        {
            var package = this.Read("uml-prefix-UML.xmi").QueryRoot("p");
            var classes = package.PackagedElement.OfType<IClass>().ToList();
            var classC = classes.Single(x => x.Name == "C");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classes.Select(x => x.Name), Is.EquivalentTo(new[] { "Base", "C" }));
                Assert.That(classC.Generalization.Single().General, Is.SameAs(classes.Single(x => x.Name == "Base")));
                Assert.That(((ILiteralInteger)classC.OwnedAttribute.Single().DefaultValue.Single()).Value, Is.EqualTo(7));
            }
        }

        [Test]
        public void Verify_that_a_document_binding_the_XMI_namespace_to_another_prefix_is_read()
        {
            var xmiReaderResult = this.Read("xmi-prefix-x.xmi");
            var package = xmiReaderResult.QueryRoot("p");
            var classes = package.PackagedElement.OfType<IClass>().ToList();
            var classBase = classes.Single(x => x.Name == "Base");
            var classC = classes.Single(x => x.Name == "C");
            var property = classC.OwnedAttribute.Single();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(package.XmiId, Is.EqualTo("p"));
                Assert.That(classC.Generalization.Single().General, Is.SameAs(classBase), "a single-valued reference element with x:idref is resolved");
                Assert.That(property.Type, Is.SameAs(classBase));
                Assert.That(property.RedefinedProperty, Is.EqualTo(new[] { property }), "a multi-valued reference element with x:idref is resolved");
                Assert.That(classC.Extensions.Single().Extender, Is.EqualTo("tests"), "an x:Extension is read");
                Assert.That(xmiReaderResult.XmiRoot.Documentation.Exporter, Is.EqualTo("uml4net tests"));
                Assert.That(xmiReaderResult.XmiRoot.StereoTypeApplications.Single().XmiId, Is.EqualTo("s"), "the x:id of a stereotype application is read");
            }
        }

        [Test]
        public void Verify_that_a_document_using_the_UML_namespace_as_default_namespace_is_read()
        {
            var package = this.Read("default-namespace.xmi").QueryRoot("p");
            var classes = package.PackagedElement.OfType<IClass>().ToList();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classes.Select(x => x.Name), Is.EquivalentTo(new[] { "Base", "C" }));
                Assert.That(classes.Single(x => x.Name == "C").Generalization.Single().General, Is.SameAs(classes.Single(x => x.Name == "Base")));
            }
        }
    }
}
