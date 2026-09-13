// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderIdLessElementsTestFixture.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// Verifies that elements without xmi:id (optional per XMI 2.5.1 clause 7.6.1) are assembled like any other
    /// element: their references are resolved, their hrefs load external documents and their extensions are kept
    /// </summary>
    [TestFixture]
    public class XmiReaderIdLessElementsTestFixture
    {
        [Test]
        public void Verify_that_references_of_elements_without_xmi_id_are_resolved()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "IdLess");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.LocalReferenceBasePath = rootPath;
                    x.UseStrictReading = true;
                })
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(rootPath, "idless-elements.xmi"));
            var package = xmiReaderResult.QueryRoot("p");
            var classes = package.PackagedElement.OfType<IClass>().ToList();
            var classBase = classes.Single(x => x.Name == "Base");
            var classA = classes.Single(x => x.Name == "A");
            var classB = classes.Single(x => x.Name == "B");
            var classC = classes.Single(x => x.Name == "C");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classes.Where(x => string.IsNullOrEmpty(x.XmiId)).Select(x => x.Name), Is.EquivalentTo(new[] { "A", "B", "C" }));

                Assert.That(classA.Generalization.Single().General, Is.SameAs(classBase), "attribute reference of the first element without xmi:id");
                Assert.That(classB.Generalization.Single().General, Is.SameAs(classBase), "attribute reference of the second element without xmi:id");
                Assert.That(classC.Generalization.Single().General, Is.SameAs(classBase), "element reference (xmi:idref) of the third element without xmi:id");

                Assert.That(classA.OwnedAttribute.Single().Type?.Name, Is.EqualTo("T"), "the href of an element without xmi:id loads the external document and is resolved");
                Assert.That(classA.OwnedAttribute.Single().UnresolvedReferences, Is.Empty);

                Assert.That(classB.Extensions.Single().Extender, Is.EqualTo("tests"), "the extension of an element without xmi:id is kept");
                Assert.That(xmiReaderResult.Packages.Select(x => x.Name), Is.EquivalentTo(new[] { "P", "Types" }));
            }
        }
    }
}
