// -------------------------------------------------------------------------------------------------
// <copyright file="EnumerationLiteralWriterTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests.Writers
{
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.Activities;
    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Interactions;
    using uml4net.Packages;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// Verifies that enumeration values are written with the name of the literal as defined in the UML metamodel
    /// (XMI 2.5.1 clause 9.5.2 rule 2i), not with the first letter of the C# member lower-cased
    /// </summary>
    [TestFixture]
    public class EnumerationLiteralWriterTestFixture
    {
        [Test]
        public void Verify_that_enumeration_values_are_written_with_the_literal_name_of_the_metamodel()
        {
            var package = new Package { XmiId = "p", Name = "P", DocumentName = "enums.xmi" };

            var activity = new Activity { XmiId = "act", Name = "A", DocumentName = "enums.xmi" };
            var node = new CentralBufferNode { XmiId = "n", Name = "N", DocumentName = "enums.xmi", Ordering = ObjectNodeOrderingKind.LIFO };
            activity.Node.Add(node);
            package.PackagedElement.Add(activity);

            var @class = new Class { XmiId = "c", Name = "C", DocumentName = "enums.xmi", Visibility = VisibilityKind.Private };
            var operation = new Operation { XmiId = "op", Name = "op", DocumentName = "enums.xmi" };
            var parameter = new Parameter { XmiId = "par", Name = "result", DocumentName = "enums.xmi", Direction = ParameterDirectionKind.Return, Effect = ParameterEffectKind.Update };
            operation.OwnedParameter.Add(parameter);
            @class.OwnedOperation.Add(operation);
            var attribute = new Property { XmiId = "attr", Name = "attr", DocumentName = "enums.xmi", Aggregation = AggregationKind.Composite };
            @class.OwnedAttribute.Add(attribute);
            package.PackagedElement.Add(@class);

            var interaction = new Interaction { XmiId = "i", Name = "I", DocumentName = "enums.xmi" };
            var message = new Message { XmiId = "m", Name = "m", DocumentName = "enums.xmi", MessageSort = MessageSort.AsynchCall };
            interaction.Message.Add(message);
            package.PackagedElement.Add(interaction);

            using var stream = new MemoryStream();
            var writer = XmiWriterBuilder.Create().WithLogger(NullLoggerFactory.Instance).Build();
            writer.Write(package, stream, "enums.xmi");

            var document = XDocument.Load(new MemoryStream(stream.ToArray()));
            string Attribute(string xmiId, string attributeName) => document.Descendants().Single(x => (string)x.Attribute(XName.Get("id", "http://www.omg.org/spec/XMI/20131001")) == xmiId).Attribute(attributeName)?.Value;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(Attribute("n", "ordering"), Is.EqualTo("LIFO"));
                Assert.That(Attribute("c", "visibility"), Is.EqualTo("private"));
                Assert.That(Attribute("par", "direction"), Is.EqualTo("return"));
                Assert.That(Attribute("par", "effect"), Is.EqualTo("update"));
                Assert.That(Attribute("attr", "aggregation"), Is.EqualTo("composite"));
                Assert.That(Attribute("m", "messageSort"), Is.EqualTo("asynchCall"));
            }
        }
    }
}
