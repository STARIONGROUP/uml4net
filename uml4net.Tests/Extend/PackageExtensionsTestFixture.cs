// -------------------------------------------------------------------------------------------------
//  <copyright file="PackageExtensionsTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Tests.Extend
{
    using System.Collections.Generic;
    using System.Linq;
    
    using NUnit.Framework;

    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class PackageExtensionsTestFixture
    {
        [Test]
        public void Verify_that_QueryNestedPackage_returns_expected_result()
        {
            var root = new Package();
            var subPackage_1 = new Package();
            var subPackage_2 = new Package();
            var @class_1 = new Class();
            var @class_2 = new Class();

            root.PackagedElement.Add(subPackage_1);
            root.PackagedElement.Add(subPackage_2);
            root.PackagedElement.Add(@class_1);
            root.PackagedElement.Add(@class_2);

            Assert.That(root.NestedPackage.ToList(), Is.EquivalentTo( new List<IPackage> { subPackage_1 , subPackage_2} ));
        }

        [Test]
        public void Verify_that_QueryOwnedStereotype_returns_expected_result()
        {
            var root = new Package();

            Assert.That(root.OwnedStereotype.ToList(), Is.Empty);

            var stereoType_1 = new Stereotype();
            var stereoType_2 = new Stereotype();

            root.PackagedElement.Add(stereoType_1);
            root.PackagedElement.Add(stereoType_2);

            Assert.That(root.OwnedStereotype.ToList(), Is.EquivalentTo(new List<IStereotype> { stereoType_1, stereoType_2 }));
        }

        [Test]
        public void Verify_that_QueryOwnedType_returns_expected_result()
        {
            var root = new Package();

            Assert.That(root.OwnedType.ToList(), Is.Empty);

            var @class = new Class();
            var primitiveType = new PrimitiveType();
            var enumeration = new Enumeration();

            root.PackagedElement.Add(@class);
            root.PackagedElement.Add(primitiveType);
            root.PackagedElement.Add(enumeration);

            Assert.That(root.OwnedType.ToList(), Is.EquivalentTo(new List<IType> { @class, primitiveType, enumeration }));
        }

        [Test]
        public void Verify_that_when_Package_is_null_argument_null_exception_is_thrown()
        {
            IPackage package = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => PackageExtensions.QueryNestedPackage(package), Throws.ArgumentNullException);
                Assert.That(() => PackageExtensions.QueryOwnedStereotype(package), Throws.ArgumentNullException);
                Assert.That(() => PackageExtensions.QueryOwnedType(package), Throws.ArgumentNullException);
            }
        }
    }
}
