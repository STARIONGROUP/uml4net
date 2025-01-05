// -------------------------------------------------------------------------------------------------
//  <copyright file="NamedElementExtensionsTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
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

namespace uml4net.Tests.Extend
{
    using CommonStructure;
    using NUnit.Framework;

    using uml4net.Packages;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class NamedElementExtensionsTestFixture
    {
        [Test]
        public void Verify_that_the_fully_qualified_name_of_a_class_returns_the_expected_result()
        {
            var rootPackage = new Package { Name = "root" };
            var package = new Package { Name = "sub" };
            var @class = new Class { Name = "class_A" };

            rootPackage.PackagedElement.Add(package);
            package.PackagedElement.Add(@class);

            Assert.That(rootPackage.QualifiedName, Is.EqualTo("root"));
            Assert.That(package.QualifiedName, Is.EqualTo("root::sub"));
            Assert.That(@class.QualifiedName, Is.EqualTo("root::sub::class_A"));
        }

        [Test]
        public void Verify_that_QueryNamespace_returns_the_expected_result()
        {
            var rootPackage = new Package { Name = "root" };
            var package = new Package { Name = "sub" };
            var @class = new Class { Name = "class_A" };

            rootPackage.PackagedElement.Add(package);
            package.PackagedElement.Add(@class);

            Assert.That(@class.Namespace, Is.EqualTo(package));
            Assert.That(package.Namespace, Is.EqualTo(rootPackage));
            Assert.That(rootPackage.Namespace, Is.Null);
        }

        [Test]
        public void Verify_that_when_NamedElement_is_null_argument_exception_is_thrown()
        {
            Class @class = null;

            Assert.That(() => NamedElementExtensions.QueryQualifiedName(@class),
                Throws.ArgumentNullException);

            Assert.That(() => NamedElementExtensions.QueryNamespace(@class),
                Throws.ArgumentNullException);
        }
    }
}
