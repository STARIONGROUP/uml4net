// -------------------------------------------------------------------------------------------------
//  <copyright file="DocumentationHelperTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Reporting.Tests.Helpers
{
    using System;
    using System.Collections.Generic;

    using HandlebarsDotNet;

    using NUnit.Framework;

    using uml4net.StructuredClassifiers;
    using uml4net.Reporting.Helpers;
    using xmi.Extensions.EntrepriseArchitect.Structure;
    using IElement = CommonStructure.IElement;


    [TestFixture]
    public class DocumentationHelperTestFixture
    {
        private IHandlebars handlebars;

        [SetUp]
        public void SetUp()
        {
            this.handlebars = Handlebars.Create();
            DocumentationHelper.RegisterDocumentationHelper(this.handlebars);
        }

        [Test]
        public void Documentation_helper_writes_expected_format()
        {
            var eaElement = new Element();
            eaElement.Properties.Add(new ElementProperties { Documentation = "My documentation" });
            var element = new Class { Extensions = new List<IElement> { eaElement } };

            var template = this.handlebars.Compile("{{#Documentation this}}");
            var result = template(element);

            var expected = $"/// <summary>{Environment.NewLine}/// My documentation{Environment.NewLine}/// </summary>{Environment.NewLine}";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void RawDocumentation_returns_content_or_default()
        {
            var template = this.handlebars.Compile("{{#RawDocumentation this}}");

            var eaElement = new Element();
            eaElement.Properties.Add(new ElementProperties { Documentation = "Doc" });
            var element = new Class { Extensions = new List<IElement> { eaElement } };
            var resultWithDoc = template(element);
            Assert.That(resultWithDoc, Is.EqualTo("Doc"));

            var noDocElement = new Class { Extensions = new List<IElement>() };
            var resultWithoutDoc = template(noDocElement);
            Assert.That(resultWithoutDoc, Is.EqualTo("No Documentation Provided"));
        }

        [Test]
        public void Helpers_throw_when_context_is_not_IElement()
        {
            var docTemplate = this.handlebars.Compile("{{#Documentation this}}");
            var rawTemplate = this.handlebars.Compile("{{#RawDocumentation this}}");

            Assert.That(() => docTemplate("not an element"), Throws.ArgumentException);
            Assert.That(() => rawTemplate(42), Throws.ArgumentException);
        }
    }
}
