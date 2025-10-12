// -------------------------------------------------------------------------------------------------
//  <copyright file="ExtensionTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Tests.CommonStructureExtension
{
    using NUnit.Framework;

    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.xmi.Extensions.EntrepriseArchitect.Structure;

    using Extension = EntrepriseArchitect.Structure.Extension;

    /// <summary>
    /// Tests for the <see cref="Extension"/> class.
    /// </summary>
    [TestFixture]
    public class ExtensionTestFixture
    {
        [Test]
        public void PrimitivesTypes_is_initialized_on_first_access()
        {
            var extension = new Extension();

            var first = extension.PrimitivesTypes;
            var second = extension.PrimitivesTypes;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(first, Is.Not.Null);
                Assert.That(second, Is.SameAs(first));
            }
        }

        [Test]
        public void PrimitivesTypes_setter_replaces_value()
        {
            var extension = new Extension();
            var list = new ContainerList<IPackageableElement>(extension);

            extension.PrimitivesTypes = list;

            Assert.That(extension.PrimitivesTypes, Is.SameAs(list));
        }

        [Test]
        public void Profiles_behave_like_PrimitivesTypes()
        {
            var extension = new Extension();

            var first = extension.Profiles;
            var second = extension.Profiles;

            Assert.That(first, Is.Not.Null);
            Assert.That(second, Is.SameAs(first));

            var list = new ContainerList<IProfile>(extension);
            extension.Profiles = list;

            Assert.That(extension.Profiles, Is.SameAs(list));
        }
    }
}
