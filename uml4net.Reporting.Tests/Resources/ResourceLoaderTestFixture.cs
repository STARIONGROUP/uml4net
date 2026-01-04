// -------------------------------------------------------------------------------------------------
//  <copyright file="ResourceLoaderTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2026 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.Reporting.Tests.Resources
{
    using System.Resources;

    using NUnit.Framework;

    using uml4net.Reporting.Resources;

    [TestFixture]
    public class ResourceLoaderTestFixture
    {
        [Test]
        public void LoadEmbeddedResource_ReturnsContent()
        {
            var content = ResourceLoader.LoadEmbeddedResource("uml4net.Reporting.Templates.uml-to-html-docs.hbs");
            Assert.That(content, Does.Contain("uml4net.Reporting library"));
        }

        [Test]
        public void LoadEmbeddedResource_InvalidPath_Throws()
        {
            Assert.That(() => ResourceLoader.LoadEmbeddedResource("unknown.resource"),
                Throws.TypeOf<MissingManifestResourceException>());
        }
    }
}
