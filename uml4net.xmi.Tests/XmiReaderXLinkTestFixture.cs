// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderXLinkTestFixture.cs" company="Starion Group S.A.">
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
    using uml4net.xmi.Readers;

    /// <summary>
    /// Verifies the link forms of XMI 2.5.1 clause 7.10.2 beyond the plain href: XLink simple links
    /// (<c>xlink:href</c> with <c>xlink:type="simple"</c>) with an XPointer bare name, and the XPointer uuid form
    /// <c>xpointer((//*[@xmi:uuid='value'])[1])</c>, across documents and within the same document
    /// </summary>
    [TestFixture]
    public class XmiReaderXLinkTestFixture
    {
        private string rootPath;

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Links");
        }

        [Test]
        public void Verify_that_xlink_and_uuid_based_links_are_resolved()
        {
            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = this.rootPath)
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(this.rootPath, "xlinks.xmi"));

            var package = xmiReaderResult.QueryRoot("p");
            var classC = package.PackagedElement.OfType<IClass>().Single(x => x.XmiId == "C");
            var local = package.PackagedElement.OfType<IClass>().Single(x => x.XmiId == "Local");

            IClass TypeOf(string propertyName) => classC.OwnedAttribute.Single(x => x.Name == propertyName).Type as IClass;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(TypeOf("byId")?.Name, Is.EqualTo("Employee"), "xlink:href with an XPointer bare name, Co.xmi#emp_2");
                Assert.That(TypeOf("byUuid")?.Name, Is.EqualTo("Manager"), "xlink:href with the XPointer uuid form locates the FIRST element with that xmi:uuid");
                Assert.That(TypeOf("byUuid")?.XmiId, Is.EqualTo("emp_3"), "not the twin that carries the same uuid");
                Assert.That(TypeOf("byLocalUuid"), Is.SameAs(local), "href=\"#xpointer(...)\" locates an element of the same document by uuid");
                Assert.That(TypeOf("byUuidNoId")?.Name, Is.EqualTo("NoId"), "an element without xmi:id is still reachable by its xmi:uuid (double-quoted form)");
                Assert.That(classC.OwnedAttribute.Single(x => x.Name == "many").RedefinedProperty.Select(x => x.XmiId), Is.EqualTo(new[] { "emp_2-p" }), "xlink:href on a multi-valued reference");
                Assert.That(classC.OwnedComment.Select(x => x.Body.Trim()), Is.EqualTo(new[] { "a comment of Co" }), "xlink:href on a composite proxy");
                Assert.That(classC.UnresolvedReferences, Is.Empty);
                Assert.That(classC.OwnedAttribute.SelectMany(x => x.UnresolvedReferences), Is.Empty);
            }
        }
    }
}
