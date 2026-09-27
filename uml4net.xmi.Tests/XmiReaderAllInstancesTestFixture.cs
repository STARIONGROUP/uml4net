// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderAllInstancesTestFixture.cs" company="Starion Group S.A.">
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
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Verifies that the derivations that use OCL <c>allInstances()</c> find the elements of every root element and of
    /// every document of a read, also once the reader has been disposed
    /// </summary>
    [TestFixture]
    public class XmiReaderAllInstancesTestFixture
    {
        private string rootPath;

        [SetUp]
        public void SetUp()
        {
            this.rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "AllInstances");
        }

        private XmiReaderResult Read()
        {
            using var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = this.rootPath)
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            return reader.Read(Path.Combine(this.rootPath, "model.xmi"));
        }

        [Test]
        public void Verify_that_allInstances_covers_every_root_and_every_document_of_a_read()
        {
            var xmiReaderResult = this.Read();

            var client = xmiReaderResult.QueryRoot("Components").PackagedElement.OfType<IClass>().Single();
            var traces = xmiReaderResult.QueryRoot("Traces").PackagedElement.OfType<IDependency>().ToList();
            var clientTrace = traces.Single(x => x.XmiId == "ClientTrace");
            var baseTrace = traces.Single(x => x.XmiId == "BaseTrace");
            var @base = (IClass)clientTrace.Supplier.Single();

            var profile = xmiReaderResult.QueryRoot("Profile");
            var extension = profile.PackagedElement.OfType<IExtension>().Single();
            var metaclass = (IClass)profile.PackagedElement.OfType<IStereotype>().Single().OwnedAttribute.Single().Type;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(@base.DocumentName, Is.EqualTo("library.xmi"));
                Assert.That(metaclass.DocumentName, Is.EqualTo("library.xmi"));

                Assert.That(client.ClientDependency, Is.EqualTo(new[] { clientTrace }), "a Dependency in another root element of the document");
                Assert.That(@base.ClientDependency, Is.EqualTo(new[] { baseTrace }), "a Dependency in the main document of a Class of an external document");
                Assert.That(metaclass.Extension, Is.EqualTo(new[] { extension }), "an Extension in a Profile of the main document of a metaclass of an external document");
            }
        }
    }
}
