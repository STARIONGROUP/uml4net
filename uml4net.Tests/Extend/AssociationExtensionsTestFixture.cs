// -------------------------------------------------------------------------------------------------
// <copyright file="AssociationExtensionsTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Tests.Extend
{
    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// Suite of tests for the <see cref="AssociationExtensions"/> class.
    /// </summary>
    [TestFixture]
    public class AssociationExtensionsTestFixture
    {
        [Test]
        public void Verify_that_QueryEndType_returns_the_types_of_all_member_ends()
        {
            var association = new Association();
            var classA = new Class { Name = "A" };
            var classB = new Class { Name = "B" };
            var ownedEnd = new Property { Type = classA };
            var classOwnedEnd = new Property { Type = classB };

            association.OwnedEnd.Add(ownedEnd);
            classA.OwnedAttribute.Add(classOwnedEnd);
            association.MemberEnd.Add(ownedEnd);
            association.MemberEnd.Add(classOwnedEnd);

            Assert.That(association.QueryEndType(), Is.EquivalentTo([classA, classB]));
        }

        [Test]
        public void Verify_that_QueryEndType_of_a_self_association_returns_the_type_once()
        {
            var association = new Association();
            var classA = new Class { Name = "A" };

            association.MemberEnd.Add(new Property { Name = "parent", Type = classA });
            association.MemberEnd.Add(new Property { Name = "children", Type = classA });

            Assert.That(association.QueryEndType(), Is.EquivalentTo([classA]));
        }

        [Test]
        public void Verify_that_QueryEndType_of_an_Extension_reads_the_type_of_the_ExtensionEnd()
        {
            var metaclass = new Class { Name = "Class" };
            var stereotype = new Stereotype { Name = "Stereotype" };
            var extensionEnd = new ExtensionEnd { Name = "extension_Stereotype", Type = stereotype };

            var extension = new Extension();
            extension.OwnedEnd.Add(extensionEnd);
            extension.MemberEnd.Add(new Property { Name = "base_Class", Type = metaclass });
            extension.MemberEnd.Add(extensionEnd);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(extension.QueryEndType(), Is.EquivalentTo(new IType[] { metaclass, stereotype }));
                Assert.That(extension.EndType, Is.EquivalentTo(new IType[] { metaclass, stereotype }));
            }
        }

        [Test]
        public void Verify_that_QueryEndType_skips_untyped_member_ends()
        {
            var association = new Association();
            association.MemberEnd.Add(new Property { Name = "untyped" });

            Assert.That(association.QueryEndType(), Is.Empty);
        }

        [Test]
        public void Verify_that_QueryEndType_throws_when_association_is_null()
        {
            Assert.That(() => AssociationExtensions.QueryEndType(null), Throws.ArgumentNullException);
        }
    }
}
