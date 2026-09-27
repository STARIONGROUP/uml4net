// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderOwnerEndsTestFixture.cs" company="Starion Group S.A.">
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

    using uml4net.Actions;
    using uml4net.Activities;
    using uml4net.Packages;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Verifies that the owner end of a composite association - which an XMI document does not serialize, since it is
    /// implied by the nesting of the XML elements - is set on a model that was read, and is not written back
    /// </summary>
    [TestFixture]
    public class XmiReaderOwnerEndsTestFixture
    {
        private string rootPath;

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "OwnerEnds");
        }

        private IXmiReader CreateReader()
        {
            return XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = this.rootPath)
                .WithLogger(NullLoggerFactory.Instance)
                .Build();
        }

        [Test]
        public void Verify_that_the_owner_ends_are_set_on_a_model_that_was_read()
        {
            var xmiReaderResult = this.CreateReader().Read(Path.Combine(this.rootPath, "owner-ends.xmi"));

            var package = xmiReaderResult.QueryRoot("p");
            var nestedPackage = package.PackagedElement.OfType<IPackage>().Single();
            var classA = package.PackagedElement.OfType<IClass>().Single(x => x.XmiId == "a");
            var classB = package.PackagedElement.OfType<IClass>().Single(x => x.XmiId == "b");
            var generalization = classA.Generalization.Single();
            var attribute = classA.OwnedAttribute.Single();
            var operation = classA.OwnedOperation.Single();
            var parameter = operation.OwnedParameter.Single();
            var stateMachine = classA.OwnedBehavior.OfType<IStateMachine>().Single();
            var region = stateMachine.Region.Single();
            var state = region.Subvertex.OfType<IState>().First();
            var transition = region.Transition.Single();
            var activity = classA.OwnedBehavior.OfType<IActivity>().Single();
            var structuredNode = activity.StructuredNode.Single();
            var action = structuredNode.Node.OfType<IOpaqueAction>().Single();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(package.PackageImport.Single().ImportingNamespace, Is.SameAs(package));
                Assert.That(nestedPackage.NestingPackage, Is.SameAs(package), "the owner end of the derived Package::nestedPackage");
                Assert.That(classA.Package, Is.SameAs(package), "Type::package, the owner end of the derived Package::ownedType");
                Assert.That(generalization.Specific, Is.SameAs(classA));
                Assert.That(generalization.General, Is.SameAs(classB));
                Assert.That(attribute.Class, Is.SameAs(classA));
                Assert.That(operation.Class, Is.SameAs(classA));
                Assert.That(parameter.Operation, Is.SameAs(operation));
                Assert.That(region.StateMachine, Is.SameAs(stateMachine));
                Assert.That(state.Container, Is.SameAs(region));
                Assert.That(transition.Container, Is.SameAs(region));
                Assert.That(structuredNode.Activity, Is.SameAs(activity));
                Assert.That(action.InStructuredNode, Is.SameAs(structuredNode));

                Assert.That(state.Outgoing, Is.EquivalentTo(new[] { transition }), "derived properties that navigate through the owner ends work on a read model");
                Assert.That(state.RedefinitionContext, Is.SameAs(stateMachine));
                Assert.That(action.Context, Is.SameAs(classA));
                Assert.That(classA.SuperClass, Is.EquivalentTo(new[] { classB }));
            }
        }

        [Test]
        public void Verify_that_the_owner_ends_are_not_written_and_are_set_again_after_a_round_trip()
        {
            var xmiReaderResult = this.CreateReader().Read(Path.Combine(this.rootPath, "owner-ends.xmi"));

            using var stream = new MemoryStream();

            var writer = XmiWriterBuilder.Create().WithLogger(NullLoggerFactory.Instance).Build();
            writer.Write(xmiReaderResult.QueryRoot("p"), stream, "owner-ends.xmi");

            var document = XDocument.Load(new MemoryStream(stream.ToArray()));

            var ownerEndNames = new[]
            {
                "specific", "class", "operation", "importingNamespace", "nestingPackage", "package", "stateMachine", "container",
                "activity", "inStructuredNode"
            };

            var serializedOwnerEnds = document.Descendants()
                .SelectMany(x => x.Attributes().Select(a => a.Name.LocalName).Concat(x.Elements().Select(e => e.Name.LocalName)))
                .Where(ownerEndNames.Contains)
                .Distinct()
                .ToList();

            Assert.That(serializedOwnerEnds, Is.Empty, "the owner end of a composite association is implied by the nesting and is not serialized");

            stream.Position = 0;

            var reread = this.CreateReader().Read(stream, "owner-ends.xmi").QueryRoot("p");
            var classA = reread.PackagedElement.OfType<IClass>().Single(x => x.XmiId == "a");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classA.Generalization.Single().Specific, Is.SameAs(classA));
                Assert.That(classA.Package, Is.SameAs(reread));
                Assert.That(classA.OwnedBehavior.OfType<IStateMachine>().Single().Region.Single().Subvertex.First().Container, Is.Not.Null);
            }
        }
    }
}
