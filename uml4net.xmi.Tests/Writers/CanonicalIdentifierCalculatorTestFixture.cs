// -------------------------------------------------------------------------------------------------
// <copyright file="CanonicalIdentifierCalculatorTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests.Writers
{
    using NUnit.Framework;

    using uml4net.xmi.Writers;

    /// <summary>
    /// Verifies the derivation of the Canonical XMI identifiers (XMI 2.5.1 Annex B.6)
    /// </summary>
    [TestFixture]
    public class CanonicalIdentifierCalculatorTestFixture
    {
        [Test]
        public void Verify_that_the_identifiers_follow_the_rules_of_Annex_B6()
        {
            var package = new CanonicalObjectRecord("package", "uml:Package", "My Package-1", true);
            var unnamedRoot = new CanonicalObjectRecord("unnamedRoot", "uml:Comment", null, true);
            var digitRoot = new CanonicalObjectRecord("digitRoot", "uml:Class", "9lives", true);

            var classA = new CanonicalObjectRecord("classA", "packagedElement", "A", false);
            var duplicateA = new CanonicalObjectRecord("duplicateA", "packagedElement", "A", false);
            var a2 = new CanonicalObjectRecord("a2", "packagedElement", "A_2", false);
            var thirdA = new CanonicalObjectRecord("thirdA", "packagedElement", "A", false);
            var firstComment = new CanonicalObjectRecord("firstComment", "ownedComment", string.Empty, false);
            var secondComment = new CanonicalObjectRecord("secondComment", "ownedComment", null, false);
            var nested = new CanonicalObjectRecord("nested", "ownedAttribute", "x", false);
            var withoutObject = new CanonicalObjectRecord(null, "ownedRule", null, false);

            package.Children.AddRange([classA, duplicateA, a2, thirdA, firstComment, secondComment, withoutObject]);
            classA.Children.Add(nested);

            var identifiers = CanonicalIdentifierCalculator.Calculate([package, unnamedRoot, digitRoot]);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(identifiers["package"], Is.EqualTo("My_Package_1"), "rule 3: invalid characters and hyphens become '_'");
                Assert.That(identifiers["unnamedRoot"], Is.EqualTo("_1"), "rule 2 and 4: a top-level object without identifier is '_' with a sequence number from 1");
                Assert.That(identifiers["digitRoot"], Is.EqualTo("_9lives"), "rule 3: a top-level base name starts with a letter or '_'");

                Assert.That(identifiers["classA"], Is.EqualTo("My_Package_1-A"), "rule 5: the parent identifier, '-' and the base name");
                Assert.That(identifiers["duplicateA"], Is.EqualTo("My_Package_1-A_2"), "rule 4: a duplicate named object is numbered from 2");
                Assert.That(identifiers["a2"], Is.EqualTo("My_Package_1-A_2_2"), "a name that collides with an earlier numbered sibling is numbered in turn");
                Assert.That(identifiers["thirdA"], Is.EqualTo("My_Package_1-A_3"), "rule 4: the sequence number is incremented until it is unique");
                Assert.That(identifiers["firstComment"], Is.EqualTo("My_Package_1-ownedComment_1"), "rule 2: the name of the containing property, numbered from 1");
                Assert.That(identifiers["secondComment"], Is.EqualTo("My_Package_1-ownedComment_2"));
                Assert.That(identifiers["nested"], Is.EqualTo("My_Package_1-A-x"));
                Assert.That(identifiers, Has.Count.EqualTo(10), "a record without object gets no identifier");
                Assert.That(() => CanonicalIdentifierCalculator.Calculate(null), Throws.ArgumentNullException);
            }
        }
    }
}
