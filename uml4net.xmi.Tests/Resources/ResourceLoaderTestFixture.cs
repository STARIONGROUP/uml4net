// -------------------------------------------------------------------------------------------------
// <copyright file="XmiElementReaderTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests.Resources
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using NUnit.Framework;

    using uml4net.xmi.Resources;

    [TestFixture]
    public class ResourceLoaderTestFixture
    {
        [Test]
        public void TryLoadKnownResource_WithFragment_IsHandled()
        {
            var loader = new ResourceLoader();
            var result = loader.TryLoadKnownResource("http://www.omg.org/spec/UML/20161101/UML.xmi#fragment", out var stream);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.True);
                Assert.That(stream, Is.Not.Null);
            }
        }

        [Test]
        public void LoadEmbeddedResource_ReturnsContent()
        {
            var loader = new ResourceLoader();
            var content = loader.LoadEmbeddedResource("uml4net.xmi.Resources.UML.xmi");
            Assert.That(content, Does.Contain("xmi:XMI"));
        }

        [TestCase("PrimitiveTypes.xmi#Boolean")]
        [TestCase("PrimitiveTypes#Boolean")]
        public void Verify_that_bare_PrimitiveTypes_key_resolves_to_the_PrimitiveTypes_embedded_resource(string resourceName)
        {
            var loader = new ResourceLoader();
            var result = loader.TryLoadKnownResource(resourceName, out var stream);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.True);
                Assert.That(stream, Is.Not.Null);
            }

            using var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();

            Assert.That(content, Does.Contain("xmi:id=\"Boolean\""));
        }

        [Test]
        public void Verify_that_every_known_external_reference_resolves_to_an_existing_embedded_resource()
        {
            var field = typeof(ResourceLoader).GetField("knownExternalReferences", BindingFlags.NonPublic | BindingFlags.Instance);
            var knownExternalReferences = (Dictionary<string, string>)field.GetValue(new ResourceLoader());

            var manifestResourceNames = typeof(ResourceLoader).Assembly.GetManifestResourceNames();

            using (Assert.EnterMultipleScope())
            {
                foreach (var resourcePath in knownExternalReferences.Values.Distinct())
                {
                    Assert.That(manifestResourceNames, Does.Contain(resourcePath),
                        $"'{resourcePath}' is not an embedded resource of the {typeof(ResourceLoader).Assembly.GetName().Name} assembly");
                }
            }
        }
    }
}
