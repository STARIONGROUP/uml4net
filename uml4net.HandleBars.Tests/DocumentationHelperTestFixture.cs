// -------------------------------------------------------------------------------------------------
// <copyright file="DocumentationHelperTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.HandleBars.Tests
{
    using System;
    using System.Globalization;

    using HandlebarsDotNet;

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// Suite of tests for the <see cref="DocumentationHelper"/> class.
    /// </summary>
    [TestFixture]
    public class DocumentationHelperTestFixture
    {
        private IHandlebars handlebarsContext;

        [SetUp]
        public void SetUp()
        {
            this.handlebarsContext = Handlebars.Create();
            this.handlebarsContext.Configuration.FormatProvider = CultureInfo.InvariantCulture;
            DocumentationHelper.RegisterDocumentationHelper(this.handlebarsContext);
        }

        [Test]
        public void Verify_that_Documentation_writes_a_summary_block()
        {
            var @class = new Class { Name = "MyClass" };
            @class.OwnedComment.Add(new Comment { Body = "Short description." });

            var template = "{{ #Documentation this }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(@class);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Does.StartWith("/// <summary>"));
                Assert.That(result, Does.Contain("/// Short description."));
                Assert.That(result, Does.Contain("/// </summary>"));
            }
        }

        [Test]
        public void Verify_that_Documentation_throws_when_context_is_invalid()
        {
            var template = "{{ #Documentation this }}";
            var action = this.handlebarsContext.Compile(template);

            Assert.That(() => action(5), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Verify_that_RawDocumentation_writes_the_comment_body()
        {
            var @class = new Class { Name = "MyClass" };
            @class.OwnedComment.Add(new Comment { Body = "Short description." });

            var template = "{{ #RawDocumentation this }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(@class);

            Assert.That(result, Is.EqualTo("Short description."));
        }

        [Test]
        public void Verify_that_RawDocumentation_writes_a_placeholder_when_there_is_no_comment()
        {
            var @class = new Class { Name = "MyClass" };

            var template = "{{ #RawDocumentation this }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(@class);

            Assert.That(result, Is.EqualTo("No Documentation Provided"));
        }

        [Test]
        public void Verify_that_RawDocumentation_throws_when_context_is_invalid()
        {
            var template = "{{ #RawDocumentation this }}";
            var action = this.handlebarsContext.Compile(template);

            Assert.That(() => action(5), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Verify_that_ParameterDocumentation_writes_param_and_returns_tags()
        {
            var operation = new Operation { Name = "DoSomething" };

            var inputParameter = new Parameter { Name = "count", Direction = ParameterDirectionKind.In };
            inputParameter.OwnedComment.Add(new Comment { Body = "The number of items." });
            operation.OwnedParameter.Add(inputParameter);

            var returnParameter = new Parameter
            {
                Name = "result",
                Direction = ParameterDirectionKind.Return,
                Type = new PrimitiveType { Name = "Integer", XmiId = "Integer" }
            };
            operation.OwnedParameter.Add(returnParameter);

            var template = "{{ #ParameterDocumentation this }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(operation);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Does.Contain("/// <param name=\"count\">"));
                Assert.That(result, Does.Contain("The number of items."));
                Assert.That(result, Does.Contain("/// </param>"));
                Assert.That(result, Does.Contain("/// <returns>"));
                Assert.That(result, Does.Contain("/// </returns>"));
            }
        }

        [Test]
        public void Verify_that_ParameterDocumentation_omits_the_returns_tag_when_the_operation_returns_void()
        {
            var operation = new Operation { Name = "DoSomething" };

            var template = "{{ #ParameterDocumentation this }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(operation);

            Assert.That(result, Does.Not.Contain("/// <returns>"));
        }

        [Test]
        public void Verify_that_ParameterDocumentation_throws_when_argument_is_not_an_operation()
        {
            var template = "{{ #ParameterDocumentation this }}";
            var action = this.handlebarsContext.Compile(template);

            Assert.That(() => action(5), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Verify_that_DocumentationSummary_writes_the_first_sentence()
        {
            var @class = new Class();
            @class.OwnedComment.Add(new Comment { Body = "A tank holds a fluid. It has a volume." });

            var template = this.handlebarsContext.Compile("{{ #DocumentationSummary this }}");
            var templateWithMaxLength = this.handlebarsContext.Compile("{{ #DocumentationSummary this 12 }}");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(template(@class), Is.EqualTo("A tank holds a fluid."));
                Assert.That(templateWithMaxLength(@class), Is.EqualTo("A tank holds…"));
                Assert.That(template(new Class()), Is.Empty);
                Assert.That(() => template("not an element"), Throws.ArgumentException);
                Assert.That(() => this.handlebarsContext.Compile("{{ #DocumentationSummary this 12 13 }}")(@class), Throws.TypeOf<HandlebarsException>());
            }
        }

        [Test]
        public void Verify_that_QueryAnnotatingComments_returns_the_comments_that_annotate_the_element()
        {
            var package = new Package { Name = "package" };
            var @class = new Class { Name = "Tank" };
            package.PackagedElement.Add(@class);

            @class.OwnedComment.Add(new Comment { Body = "owned" });

            var packageComment = new Comment { Body = "annotating" };
            packageComment.AnnotatedElement.Add(@class);
            package.OwnedComment.Add(packageComment);

            var template = this.handlebarsContext.Compile("{{#each (#Element.QueryAnnotatingComments this) as | comment |}}{{ comment.Body }};{{/each}}");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(template(@class), Is.EqualTo("owned;annotating;"));
                Assert.That(template(package), Is.EqualTo("annotating;"), "the comment that the package owns");
                Assert.That(() => template("not an element"), Throws.ArgumentException);
                Assert.That(() => this.handlebarsContext.Compile("{{#each (#Element.QueryAnnotatingComments this this)}}x{{/each}}")(@class), Throws.TypeOf<HandlebarsException>());
            }
        }
    }
}
