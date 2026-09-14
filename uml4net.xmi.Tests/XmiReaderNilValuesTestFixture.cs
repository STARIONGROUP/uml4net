// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderNilValuesTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.Classification;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Verifies that a null value serialized as <c>xsi:nil="true"</c> (XMI 2.5.1 clause 9.5.2, rule 2b) is read
    /// as no value for value, reference and contained elements, in strict and in non-strict mode
    /// </summary>
    [TestFixture]
    public class XmiReaderNilValuesTestFixture
    {
        private string rootPath;

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Nil");
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
        public void Verify_that_nil_elements_are_read_as_null_values(bool useStrictReading)
        {
            var xmiReaderResult = this.CreateReader(useStrictReading).Read(Path.Combine(this.rootPath, "xsi-nil.xmi"));
            var package = xmiReaderResult.QueryRoot("p");
            var classes = package.PackagedElement.OfType<IClass>().ToList();
            var classC = classes.Single(x => x.XmiId == "c");
            var property = classC.OwnedAttribute.Single();
            var opaqueExpression = package.PackagedElement.OfType<IOpaqueExpression>().Single();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classes.Select(x => x.Name), Is.EqualTo(new[] { "C", "D" }), "the elements after the nil elements are still read");
                Assert.That(classC.IsAbstract, Is.False, "a nil Boolean value element keeps the default");
                Assert.That(classC.OwnedComment.Single().Body, Is.Null, "a nil String value element is null, not empty");
                Assert.That(classC.OwnedAttribute.Select(x => x.XmiId), Is.EqualTo(new[] { "a" }), "a nil contained element contains nothing");
                Assert.That(property.Type, Is.Null, "a nil single-valued reference element is no reference");
                Assert.That(property.RedefinedProperty, Is.Empty, "a nil multi-valued reference element is no reference");
                Assert.That(property.Aggregation, Is.EqualTo(AggregationKind.None), "a nil enumeration value element keeps the default");
                Assert.That(opaqueExpression.Body, Is.EqualTo(new[] { "kept" }), "a nil item of a multi-valued String property is not added");
                Assert.That(opaqueExpression.Language, Is.Empty, "xsi:nil='1' is the other lexical form of true");
            }
        }
    }
}
