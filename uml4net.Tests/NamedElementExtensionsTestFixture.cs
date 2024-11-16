// -------------------------------------------------------------------------------------------------
//  <copyright file="NamedElementExtensionsTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.Tests
{
    using NUnit.Framework;
    using POCO.Packages;
    using POCO.StructuredClassifiers;

    [TestFixture]
    public class NamedElementExtensionsTestFixture
    {

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Verify_that_the_fully_qualified_name_of_a_class_returns_the_expected_result()
        {
            var rootPackage = new Package { Name = "root"};
            var package = new Package { Name = "sub" };
            var @class = new Class { Name = "class_A" };

            rootPackage.PackagedElement.Add(package);
            package.PackagedElement.Add(@class);

            Assert.That(rootPackage.QualifiedName, Is.EqualTo("root"));
            Assert.That(package.QualifiedName, Is.EqualTo("root::sub"));
            Assert.That(@class.QualifiedName, Is.EqualTo("root::sub::class_A"));
        }
    }
}
