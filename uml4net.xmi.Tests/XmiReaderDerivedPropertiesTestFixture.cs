// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderDerivedPropertiesTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.CommonStructure;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Verifies that derived properties that are present in a document (XMI 2.5.1 clause 7.8.10, org.omg.xmi.serialize)
    /// are ignored in strict and in non-strict mode, whether they are serialized as XML attributes or as XML elements
    /// </summary>
    [TestFixture]
    public class XmiReaderDerivedPropertiesTestFixture
    {
        private string rootPath;

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "DerivedProperties");
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

        [TestCase(true)]
        [TestCase(false)]
        public void Verify_that_serialized_derived_properties_are_ignored(bool useStrictReading)
        {
            var xmiReaderResult = this.CreateReader(useStrictReading).Read(Path.Combine(this.rootPath, "derived-properties.xmi"));
            var package = xmiReaderResult.QueryRoot("p");
            var classes = package.PackagedElement.OfType<IClass>().ToList();
            var classC = classes.Single(x => x.XmiId == "c");
            var property = classC.OwnedAttribute.Single();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classes.Select(x => x.Name), Is.EqualTo(new[] { "C", "D" }), "the elements after the derived properties are still read");
                Assert.That(classC.QualifiedName, Is.EqualTo("P::C"), "the serialized qualifiedName attribute and element are ignored, the value is derived");
                Assert.That(classC.SuperClass, Is.Empty, "the serialized superClass element is ignored, the value is derived from the generalizations");
                Assert.That(classC.OwnedComment.Select(x => x.Body), Is.EqualTo(new[] { "kept" }), "the comment inside the serialized derived union ownedElement is not read, the sibling after it is");
                Assert.That(classC.OwnedElement, Is.EquivalentTo(new IElement[] { classC.OwnedComment.Single(), property }), "the derived union is computed from the owned comment and attribute");
                Assert.That(property.IsComposite, Is.False, "the serialized isComposite attribute is ignored, the value is derived from the aggregation");
                Assert.That(property.Opposite, Is.Null, "the serialized opposite element is ignored, the value is derived from the association");
            }
        }
    }
}
