// -------------------------------------------------------------------------------------------------
//  <copyright file="AssociationDiagramRendererTestFixture.cs" company="Starion Group S.A.">
//
//    Copyright (C) 2019-2026 Starion Group S.A.
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

namespace uml4net.Reporting.Tests.Drawing
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.Reporting.Drawing;
    using uml4net.Reporting.Payload;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi;
    using uml4net.xmi.Readers;

    [TestFixture]
    public class AssociationDiagramRendererTestFixture
    {
        private ILoggerFactory loggerFactory;

        private AssociationDiagramRenderer associationDiagramRenderer;

        private XmiReaderResult xmiReaderResult;

        private HandlebarsPayload payload;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });

            this.xmiReaderResult = this.LoadModel("UML.xmi");
            this.payload = HandlebarsPayloadFactory.CreateHandlebarsPayload(this.xmiReaderResult, "_0", "UML");
        }

        [SetUp]
        public void SetUp()
        {
            this.associationDiagramRenderer = new AssociationDiagramRenderer(this.loggerFactory.CreateLogger<AssociationDiagramRenderer>());
        }

        [Test]
        public void Verify_that_SvgRenderForClass_returns_svg_for_class_with_associations()
        {
            var targetClass = this.payload.Classes.First(c => c.Name == "Class");

            var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, this.payload);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(svg, Is.Not.Null.And.Not.Empty);
                Assert.That(svg, Does.Contain("<svg"));
                Assert.That(svg, Does.Contain($"id=\"association-diagram-{targetClass.XmiId}\""));
                Assert.That(svg, Does.Contain(targetClass.Name));
            }
        }

        [Test]
        public void Verify_that_SvgRenderForClass_returns_svg_containing_multiplicity()
        {
            var targetClass = this.payload.Classes.First(c => c.Name == "Class");

            var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, this.payload);

            Assert.That(svg, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void Verify_that_SvgRenderForClass_returns_empty_for_class_with_no_associations()
        {
            var targetClass = this.payload.Classes.FirstOrDefault(c =>
                !c.OwnedAttribute.Any(p => p.Type is IClass tc && this.payload.Classes.Contains(tc))
                && !this.payload.Classes.Any(other => other != c && other.OwnedAttribute.Any(p => p.Type == c)));

            if (targetClass != null)
            {
                var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, this.payload);

                Assert.That(svg, Is.Empty);
            }
        }

        [Test]
        public void Verify_that_SvgRenderForClass_returns_svg_for_behavior_class()
        {
            var targetClass = this.payload.Classes.First(c => c.Name == "Behavior");

            var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, this.payload);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(svg, Is.Not.Null.And.Not.Empty);
                Assert.That(svg, Does.Contain("<svg"));
                Assert.That(svg, Does.Contain("Behavior"));
            }
        }

        [Test]
        public void Verify_that_SvgRenderForClass_contains_class_tooltip()
        {
            var targetClass = this.payload.Classes.First(c => c.Name == "Class");

            var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, this.payload);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(svg, Does.Contain("<title>"));
                Assert.That(svg, Does.Contain("Name: Class"));
                Assert.That(svg, Does.Contain("Is Abstract:"));
                Assert.That(svg, Does.Contain("Superclasses:"));
                Assert.That(svg, Does.Contain("Description:"));
            }
        }

        [Test]
        public void Verify_that_SvgRenderForClass_contains_edge_tooltip()
        {
            var targetClass = this.payload.Classes.First(c => c.Name == "Class");

            var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, this.payload);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(svg, Does.Contain("Source:"));
                Assert.That(svg, Does.Contain("Target:"));
                Assert.That(svg, Does.Contain("Property:"));
                Assert.That(svg, Does.Contain("Multiplicity:"));
                Assert.That(svg, Does.Contain("Aggregation:"));
            }
        }

        [Test]
        public void Verify_that_SvgRenderForClass_contains_marker_definitions()
        {
            var targetClass = this.payload.Classes.First(c => c.Name == "Class");

            var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, this.payload);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(svg, Does.Contain($"id=\"composition-diamond-{targetClass.XmiId}\""));
                Assert.That(svg, Does.Contain($"id=\"aggregation-diamond-{targetClass.XmiId}\""));
                Assert.That(svg, Does.Contain($"id=\"navigable-arrow-{targetClass.XmiId}\""));
            }
        }

        [Test]
        public void Verify_that_SvgRenderForClass_contains_navigability_arrow_marker_on_edges()
        {
            var targetClass = this.payload.Classes.First(c => c.Name == "Class");

            var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, this.payload);

            Assert.That(svg, Does.Contain($"url(#navigable-arrow-{targetClass.XmiId})"));
        }

        [Test]
        public void Verify_that_SvgRenderForClass_contains_border_rectangle()
        {
            var targetClass = this.payload.Classes.First(c => c.Name == "Class");

            var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, this.payload);

            Assert.That(svg, Does.Contain("<rect"));
        }

        [Test]
        public void Verify_that_SvgRenderForClass_contains_neighbour_classes()
        {
            var targetClass = this.payload.Classes.First(c => c.Name == "Class");

            var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, this.payload);

            var neighbourNames = targetClass.OwnedAttribute
                .Where(p => p.Type is IClass tc && this.payload.Classes.Contains(tc))
                .Select(p => ((IClass)p.Type).Name)
                .Distinct()
                .ToList();

            using (Assert.EnterMultipleScope())
            {
                foreach (var name in neighbourNames)
                {
                    Assert.That(svg, Does.Contain(name));
                }
            }
        }

        [Test]
        public void Verify_that_SvgRenderForClass_contains_anchor_links()
        {
            var targetClass = this.payload.Classes.First(c => c.Name == "Class");

            var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, this.payload);

            Assert.That(svg, Does.Contain($"#{targetClass.XmiId}"));
        }

        [Test]
        public void Verify_that_SvgRenderForClass_for_abstract_class_uses_italic_font()
        {
            var targetClass = this.payload.Classes.First(c => c.Name == "Behavior");

            var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, this.payload);

            Assert.That(svg, Does.Contain("font-style=\"italic\""));
        }

        [Test]
        public void Verify_that_SvgRenderForClass_renders_incoming_associations()
        {
            var targetClass = this.payload.Classes.First(c => c.Name == "Class");

            var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, this.payload);

            var incomingClasses = this.payload.Classes
                .Where(other => other != targetClass && other.OwnedAttribute.Any(p => p.Type == targetClass))
                .Select(c => c.Name)
                .Distinct()
                .ToList();

            using (Assert.EnterMultipleScope())
            {
                foreach (var name in incomingClasses)
                {
                    Assert.That(svg, Does.Contain(name));
                }
            }
        }

        [Test]
        public void Verify_that_SvgRenderForClass_renders_multiple_classes_with_tooltips()
        {
            var classNames = new[] { "Class", "Property", "Package", "Behavior", "Association" };

            foreach (var className in classNames)
            {
                var targetClass = this.payload.Classes.FirstOrDefault(c => c.Name == className);

                if (targetClass == null)
                {
                    continue;
                }

                var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, this.payload);

                if (string.IsNullOrEmpty(svg))
                {
                    continue;
                }

                using (Assert.EnterMultipleScope())
                {
                    Assert.That(svg, Does.Contain("<title>"), $"Missing tooltip for {className}");
                    Assert.That(svg, Does.Contain($"Name: {className}"), $"Missing class name in tooltip for {className}");
                }
            }
        }

        [Test]
        public void Verify_that_SvgRenderForClass_contains_hit_area_for_edge_hover()
        {
            var targetClass = this.payload.Classes.First(c => c.Name == "Class");

            var svg = this.associationDiagramRenderer.SvgRenderForClass(targetClass, this.payload);

            Assert.That(svg, Does.Contain("stroke-width=\"12\""));
        }

        /// <summary>
        /// loads a UML model and returns an <see cref="XmiReaderResult"/>
        /// </summary>
        /// <param name="name">
        /// the name of the Uml model, e.g. UML.xmi
        /// </param>
        /// <returns>
        /// The <see cref="XmiReaderResult"/> that contains the content of a UML model
        /// </returns>
        private XmiReaderResult LoadModel(string name)
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var pathMaps = new Dictionary<string, string>
            {
                ["pathmap://UML_LIBRARIES/UMLPrimitiveTypes.library.uml"] =
                    Path.Combine(rootPath, "PrimitiveTypes.xmi")
            };

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.LocalReferenceBasePath = rootPath;
                    x.PathMaps = pathMaps;
                })
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData",
                name));

            return xmiReaderResult;
        }
    }
}
