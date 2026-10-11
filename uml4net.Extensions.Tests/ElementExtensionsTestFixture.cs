// -------------------------------------------------------------------------------------------------
// <copyright file="ElementExtensionsTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Extensions.Tests
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class ElementExtensionsTestFixture
    {
        private Package outerPackage;

        private Package innerPackage;

        private Class outerClass;

        private Class nestedClass;

        private Class specializationOfNestedClass;

        private Component component;

        private Class classPackagedInComponent;

        private Interface realizedInterface;

        [SetUp]
        public void SetUp()
        {
            // outerPackage
            //   innerPackage
            //     outerClass (nestedClassifier: nestedClass, a composite attribute typed by nestedClass)
            //     specializationOfNestedClass
            //     component (packagedElement: classPackagedInComponent)
            //   realizedInterface
            //   a Realization from classPackagedInComponent to realizedInterface
            this.outerPackage = new Package { XmiId = "outerPackage", Name = "outerPackage" };
            this.innerPackage = new Package { XmiId = "innerPackage", Name = "innerPackage" };
            this.outerPackage.PackagedElement.Add(this.innerPackage);

            this.outerClass = new Class { XmiId = "outerClass", Name = "OuterClass" };
            this.nestedClass = new Class { XmiId = "nestedClass", Name = "NestedClass" };
            this.outerClass.NestedClassifier.Add(this.nestedClass);
            this.outerClass.OwnedAttribute.Add(new Property { XmiId = "part", Name = "part", Type = this.nestedClass, Aggregation = AggregationKind.Composite });
            this.innerPackage.PackagedElement.Add(this.outerClass);

            this.specializationOfNestedClass = new Class { XmiId = "specializationOfNestedClass", Name = "SpecializationOfNestedClass" };
            this.specializationOfNestedClass.Generalization.Add(new Generalization { XmiId = "generalization", General = this.nestedClass, Specific = this.specializationOfNestedClass });
            this.innerPackage.PackagedElement.Add(this.specializationOfNestedClass);

            this.component = new Component { XmiId = "component", Name = "Component" };
            this.classPackagedInComponent = new Class { XmiId = "classPackagedInComponent", Name = "ClassPackagedInComponent" };
            this.component.PackagedElement.Add(this.classPackagedInComponent);
            this.innerPackage.PackagedElement.Add(this.component);

            this.realizedInterface = new Interface { XmiId = "realizedInterface", Name = "RealizedInterface" };
            this.outerPackage.PackagedElement.Add(this.realizedInterface);

            var realization = new Realization { XmiId = "realization" };
            realization.Client.Add(this.classPackagedInComponent);
            realization.Supplier.Add(this.realizedInterface);
            this.outerPackage.PackagedElement.Add(realization);
        }

        [Test]
        public void Verify_that_the_documentation_uses_every_owned_comment_and_keeps_the_words_of_adjacent_lines_apart()
        {
            var element = new Class { Name = "Documented" };
            element.OwnedComment.Add(new Comment { Body = "The first sentence ends here.\nThe second one\r\n   starts on the next line." });
            element.OwnedComment.Add(new Comment());
            element.OwnedComment.Add(new Comment { Body = "A <p>second</p> comment.\r\n\r\nWith a blank line." });

            var longComment = new Class { Name = "Long" };
            longComment.OwnedComment.Add(new Comment { Body = string.Join("\n", Enumerable.Repeat("word", 30)) });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(element.QueryRawDocumentation(), Is.EqualTo("The first sentence ends here. The second one starts on the next line. A second comment. With a blank line."));
                Assert.That(element.QueryDocumentation(), Is.EqualTo(new[]
                {
                    "The first sentence ends here. The second one starts on the next line.",
                    "A second comment. With a blank line."
                }), "every comment starts on a new line");

                Assert.That(longComment.QueryDocumentation().Count(), Is.EqualTo(2), "wrapped at 100 characters");
                Assert.That(string.Join(" ", longComment.QueryDocumentation()), Is.EqualTo(string.Join(" ", Enumerable.Repeat("word", 30))));

                Assert.That(new Class().QueryDocumentation(), Is.Empty);
                Assert.That(new Class().QueryRawDocumentation(), Is.Empty);
                Assert.That(() => ElementExtensions.QueryDocumentation(null), Throws.ArgumentNullException);
                Assert.That(() => ElementExtensions.QueryRawDocumentation(null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_QueryRootPackage_returns_the_outermost_package_whatever_the_kinds_of_the_owners_in_between()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(this.outerPackage.QueryRootPackage(), Is.SameAs(this.outerPackage), "the element itself");
                Assert.That(this.innerPackage.QueryRootPackage(), Is.SameAs(this.outerPackage));
                Assert.That(this.outerClass.QueryRootPackage(), Is.SameAs(this.outerPackage));
                Assert.That(this.nestedClass.QueryRootPackage(), Is.SameAs(this.outerPackage), "owned by a Class");
                Assert.That(this.outerClass.OwnedAttribute.Single().QueryRootPackage(), Is.SameAs(this.outerPackage), "owned by a Class");
                Assert.That(this.classPackagedInComponent.QueryRootPackage(), Is.SameAs(this.outerPackage), "owned by a Component");

                var classWithoutPackage = new Class();
                var nestedClassWithoutPackage = new Class();
                classWithoutPackage.NestedClassifier.Add(nestedClassWithoutPackage);

                Assert.That(classWithoutPackage.QueryRootPackage(), Is.Null);
                Assert.That(nestedClassWithoutPackage.QueryRootPackage(), Is.Null);

                Assert.That(() => ElementExtensions.QueryRootPackage(null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_the_helpers_that_start_at_the_root_package_work_for_elements_not_owned_by_a_package()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(this.nestedClass.QueryContainers(), Is.EqualTo(new[] { this.outerClass }));
                Assert.That(this.nestedClass.QueryAllSpecializations(), Is.EqualTo(new[] { this.specializationOfNestedClass }));
                Assert.That(this.classPackagedInComponent.QueryInterfaces(), Is.EqualTo(new[] { this.realizedInterface }));
            }
        }

        [Test]
        public void Verify_that_the_helpers_that_start_at_the_root_package_return_nothing_without_a_package()
        {
            var classWithoutPackage = new Class { XmiId = "classWithoutPackage" };

            using (Assert.EnterMultipleScope())
            {
                Assert.That(classWithoutPackage.QueryContainers(), Is.Empty);
                Assert.That(classWithoutPackage.QueryAllSpecializations(), Is.Empty);
                Assert.That(classWithoutPackage.QueryInterfaces(), Is.Empty);
            }
        }

        [Test]
        public void Verify_that_QueryAnnotatingComments_returns_the_owned_comments_and_the_comments_of_the_owners_that_annotate_the_element()
        {
            var rootPackage = new Package { Name = "root" };
            var package = new Package { Name = "package" };
            var @class = new Class { Name = "Tank" };
            var otherClass = new Class { Name = "Pump" };
            var property = new Property { Name = "volume" };

            rootPackage.PackagedElement.Add(package);
            package.PackagedElement.Add(@class);
            package.PackagedElement.Add(otherClass);
            @class.OwnedAttribute.Add(property);

            var ownedComment = new Comment { Body = "owned by the class" };
            @class.OwnedComment.Add(ownedComment);

            var packageComment = new Comment { Body = "owned by the package, annotates the class" };
            packageComment.AnnotatedElement.Add(@class);
            package.OwnedComment.Add(packageComment);

            var rootPackageComment = new Comment { Body = "owned by the root package, annotates the class" };
            rootPackageComment.AnnotatedElement.Add(@class);
            rootPackage.OwnedComment.Add(rootPackageComment);

            var commentOnOtherClass = new Comment { Body = "owned by the package, annotates another class" };
            commentOnOtherClass.AnnotatedElement.Add(otherClass);
            package.OwnedComment.Add(commentOnOtherClass);

            var commentOnProperty = new Comment { Body = "owned by the class, annotates the property" };
            commentOnProperty.AnnotatedElement.Add(property);
            @class.OwnedComment.Add(commentOnProperty);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(@class.QueryAnnotatingComments(), Is.EqualTo(new[] { ownedComment, commentOnProperty, packageComment, rootPackageComment }), "owned comments first, then nearest owner first");
                Assert.That(property.QueryAnnotatingComments(), Is.EqualTo(new[] { commentOnProperty }));
                Assert.That(otherClass.QueryAnnotatingComments(), Is.EqualTo(new[] { commentOnOtherClass }));
                Assert.That(new Class().QueryAnnotatingComments(), Is.Empty);
                Assert.That(@class.QueryRawDocumentation(), Does.Not.Contain("owned by the package"), "the documentation only reads the owned comments");
                Assert.That(() => ElementExtensions.QueryAnnotatingComments(null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_QuerySummary_returns_the_first_sentence_shortened_to_the_maximum_length()
        {
            var twoSentences = new Class();
            twoSentences.OwnedComment.Add(new Comment { Body = "A tank holds a fluid. It has a volume." });

            var oneSentence = new Class();
            oneSentence.OwnedComment.Add(new Comment { Body = "A tank holds a fluid" });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(twoSentences.QuerySummary(), Is.EqualTo("A tank holds a fluid."));
                Assert.That(oneSentence.QuerySummary(), Is.EqualTo("A tank holds a fluid"), "no full stop that is followed by a space");
                Assert.That(twoSentences.QuerySummary(21), Is.EqualTo("A tank holds a fluid."), "exactly the maximum length");
                Assert.That(twoSentences.QuerySummary(12), Is.EqualTo("A tank holds…"));
                Assert.That(twoSentences.QuerySummary(7), Is.EqualTo("A tank…"), "the space before the ellipsis is removed");
                Assert.That(new Class().QuerySummary(), Is.Empty);

                Assert.That(() => ElementExtensions.QuerySummary(null), Throws.ArgumentNullException);
                Assert.That(() => twoSentences.QuerySummary(0), Throws.TypeOf<ArgumentOutOfRangeException>());
            }
        }
    }
}
