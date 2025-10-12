// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiElementReaderTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
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

namespace uml4net.xmi.Tests.Resources
{
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
    }
}
