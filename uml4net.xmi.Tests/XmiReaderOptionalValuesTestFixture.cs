// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderOptionalValuesTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Verifies that optional [0..1] value-typed properties - NamedElement::visibility, Parameter::effect,
    /// Generalization::isSubstitutable - distinguish "no value" from a value that happens to be the first literal or the C#
    /// default, and that a read - write cycle neither drops an explicit value nor invents one
    /// </summary>
    [TestFixture]
    public class XmiReaderOptionalValuesTestFixture
    {
        private string rootPath;

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "OptionalValues");
        }

        private IXmiReader CreateReader()
        {
            return XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = this.rootPath)
                .WithLogger(NullLoggerFactory.Instance)
                .Build();
        }

        [Test]
        public void Verify_that_an_absent_optional_value_is_null_and_a_present_one_is_read()
        {
            var package = this.CreateReader().Read(Path.Combine(this.rootPath, "optional-values.xmi")).QueryRoot("p");
            var classC = package.PackagedElement.OfType<IClass>().Single(x => x.XmiId == "c");
            var classD = package.PackagedElement.OfType<IClass>().Single(x => x.XmiId == "d");
            var operation = classC.OwnedOperation.Single();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classC.Visibility, Is.EqualTo(VisibilityKind.Private));
                Assert.That(classD.Visibility, Is.EqualTo(VisibilityKind.Public), "PackageableElement::visibility has the metamodel default public");
                Assert.That(classC.OwnedAttribute.Single(x => x.Name == "explicitPublic").Visibility, Is.EqualTo(VisibilityKind.Public));
                Assert.That(classC.OwnedAttribute.Single(x => x.Name == "noVisibility").Visibility, Is.Null, "NamedElement::visibility has no default: absent is null, not public");
                Assert.That(operation.OwnedParameter.Single(x => x.Name == "create").Effect, Is.EqualTo(ParameterEffectKind.Create));
                Assert.That(operation.OwnedParameter.Single(x => x.Name == "noEffect").Effect, Is.Null, "absent is null, not create");
                Assert.That(classC.Generalization.Single().IsSubstitutable, Is.True, "the metamodel default");
                Assert.That(classD.Generalization.Single().IsSubstitutable, Is.False);
                Assert.That(operation.Lower, Is.Null, "no return parameter");
            }
        }

        [Test]
        public void Verify_that_a_read_write_cycle_keeps_explicit_values_and_does_not_invent_absent_ones()
        {
            var xmiReaderResult = this.CreateReader().Read(Path.Combine(this.rootPath, "optional-values.xmi"));

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create().WithLogger(NullLoggerFactory.Instance).Build();
            writer.Write(xmiReaderResult.QueryRoot("p"), stream, "optional-values.xmi");

            var document = XDocument.Load(new MemoryStream(stream.ToArray()));
            var xmiId = XName.Get("id", "http://www.omg.org/spec/XMI/20131001");

            string Attribute(string id, string name) =>
                document.Descendants().Single(x => (string)x.Attribute(xmiId) == id).Attribute(name)?.Value;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(Attribute("explicitPublic", "visibility"), Is.EqualTo("public"), "an explicit value is written even when it is the first literal");
                Assert.That(Attribute("noVisibility", "visibility"), Is.Null, "an absent value is not invented");
                Assert.That(Attribute("create", "effect"), Is.EqualTo("create"), "an explicit value is written even when it is the first literal");
                Assert.That(Attribute("noEffect", "effect"), Is.Null);
                Assert.That(Attribute("c", "visibility"), Is.EqualTo("private"));
                Assert.That(Attribute("d", "visibility"), Is.Null, "equal to the metamodel default public");
                Assert.That(Attribute("g1", "isSubstitutable"), Is.Null, "equal to the metamodel default true");
                Assert.That(Attribute("g2", "isSubstitutable"), Is.EqualTo("false"));
                Assert.That(Attribute("zeroReal", "value"), Is.EqualTo("0"), "LiteralReal::value is mandatory without a metamodel default: 0 is a value, it is written");
                Assert.That(Attribute("zeroInteger", "value"), Is.Null, "equal to the metamodel default 0 of LiteralInteger::value");
            }
        }
    }
}
