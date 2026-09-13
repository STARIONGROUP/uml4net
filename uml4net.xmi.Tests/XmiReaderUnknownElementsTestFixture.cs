// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderUnknownElementsTestFixture.cs" company="Starion Group S.A.">
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

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Verifies that an unknown element is skipped as a whole when strict reading is off: its children are not
    /// read as properties of the enclosing element, and the sibling that follows it is still read
    /// </summary>
    [TestFixture]
    public class XmiReaderUnknownElementsTestFixture
    {
        private string rootPath;

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UnknownElements");
        }

        private IXmiReader CreateReader(bool useStrictReading)
        {
            return XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.LocalReferenceBasePath = this.rootPath;
                    x.UseStrictReading = useStrictReading;
                })
                .WithLogger(NullLoggerFactory.Instance)
                .Build();
        }

        [Test]
        public void Verify_that_unknown_elements_are_skipped_as_a_whole_when_strict_reading_is_off()
        {
            var xmiReaderResult = this.CreateReader(useStrictReading: false).Read(Path.Combine(this.rootPath, "unknown-elements.xmi"));
            var package = xmiReaderResult.QueryRoot("p");
            var classes = package.PackagedElement.OfType<IClass>().ToList();
            var classC = classes.Single(x => x.XmiId == "c");
            var documentation = xmiReaderResult.XmiRoot.Documentation;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classC.Name, Is.EqualTo("C"), "the name inside the unknown element is not read as the class name");
                Assert.That(classC.OwnedComment.Select(x => x.Body), Is.EqualTo(new[] { "kept" }), "the comment inside the unknown element is not read, the sibling after it is");
                Assert.That(classes.Select(x => x.Name), Is.EqualTo(new[] { "C", "D" }));

                Assert.That(documentation.Exporter, Is.EqualTo("uml4net tests"), "the exporter inside the unknown documentation element is not read");
                Assert.That(documentation.ExporterVersion, Is.EqualTo("1.0"), "the sibling after the unknown documentation element is read");
            }
        }

        [Test]
        public void Verify_that_unknown_elements_still_throw_when_strict_reading_is_on()
        {
            Assert.That(() => this.CreateReader(useStrictReading: true).Read(Path.Combine(this.rootPath, "unknown-elements.xmi")), Throws.InstanceOf<NotSupportedException>());
        }
    }
}
