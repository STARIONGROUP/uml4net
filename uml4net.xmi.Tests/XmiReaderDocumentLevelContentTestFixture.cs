// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderDocumentLevelContentTestFixture.cs" company="Starion Group S.A.">
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
    using System.Xml.Linq;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.Packages;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Verifies that the document-level content next to the model (XMI 2.5.1 clause 9.5.1) is read: the applications of
    /// the stereotypes of the UML StandardProfile and of other profiles, and the UML Diagram Interchange content
    /// </summary>
    [TestFixture]
    public class XmiReaderDocumentLevelContentTestFixture
    {
        private XmiReaderResult Read()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "DocumentLevelContent");

            using var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            return reader.Read(Path.Combine(rootPath, "document-level-content.xmi"));
        }

        [Test]
        public void Verify_that_the_applications_of_the_stereotypes_of_the_StandardProfile_and_of_other_profiles_are_read()
        {
            var xmiReaderResult = this.Read();

            var applications = xmiReaderResult.XmiRoot.StereoTypeApplications.ToDictionary(x => x.XmiId);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(applications.Keys, Is.EquivalentTo(new[] { "traceApplication", "libraryApplication", "markedApplication" }),
                    "an element without a base_ reference is not a stereotype application");

                var trace = applications["traceApplication"];
                Assert.That(trace.ProfileName, Is.EqualTo("StandardProfile"));
                Assert.That(trace.StereoTypeName, Is.EqualTo("Trace"));
                Assert.That(trace.MetaClass, Is.EqualTo("Abstraction"));
                Assert.That(trace.ElementIdentifier, Is.EqualTo("trace"), "the base_ reference as an attribute");

                var library = applications["libraryApplication"];
                Assert.That(library.ProfileName, Is.EqualTo("StandardProfile"));
                Assert.That(library.StereoTypeName, Is.EqualTo("ModelLibrary"));
                Assert.That(library.MetaClass, Is.EqualTo("Package"));
                Assert.That(library.ElementIdentifier, Is.EqualTo("lib"), "the base_ reference as a child element with xmi:idref");

                var marked = applications["markedApplication"];
                Assert.That(marked.ProfileName, Is.EqualTo("Custom"));
                Assert.That(marked.StereoTypeName, Is.EqualTo("Marked"));
                Assert.That(marked.MetaClass, Is.EqualTo("Class"));
                Assert.That(marked.ElementIdentifier, Is.EqualTo("other.xmi#c"), "the base_ reference as a child element with href");
                Assert.That(marked.Attributes["note"], Is.EqualTo("marked"));

                Assert.That(xmiReaderResult.QueryRoot("p").PackagedElement, Has.Count.EqualTo(4), "the model is read as before");
            }
        }

        [Test]
        public void Verify_that_the_UML_Diagram_Interchange_content_is_preserved()
        {
            var xmiReaderResult = this.Read();

            var umlDi = XNamespace.Get("http://www.omg.org/spec/UML/20161101/UMLDI");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiReaderResult.XmiRoot.DiagramInterchange, Has.Count.EqualTo(1));

                var diagram = XElement.Parse(xmiReaderResult.XmiRoot.DiagramInterchange.Single());

                Assert.That(diagram.Name, Is.EqualTo(umlDi + "UMLClassDiagram"), "the raw XML declares the namespaces of its element names");
                Assert.That(diagram.Attribute(XNamespace.Get("http://www.omg.org/spec/XMI/20131001") + "id")?.Value, Is.EqualTo("diagram"));
                Assert.That(diagram.Descendants("bounds").Single().Attribute("width")?.Value, Is.EqualTo("90"), "the content is preserved");
            }
        }
    }
}
