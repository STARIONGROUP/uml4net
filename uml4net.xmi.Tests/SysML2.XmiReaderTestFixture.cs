// -------------------------------------------------------------------------------------------------
// <copyright file="SysML2.XmiReaderTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;
    using NUnit.Framework;
    using Serilog;

    using uml4net.Classification;
    using uml4net.Packages;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi;

    [TestFixture]
    public class SysML2XmiReaderTestFixture
    {
        private ILoggerFactory loggerFactory;

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
        }

        [Test]
        public void Verify_that_SysML_XMI_can_be_read()
        {
            var reader = XmiReaderBuilder.Create()
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult =
                reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SysML.uml"));

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiReaderResult.XmiRoot, Is.Not.Null);
                Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(1));

                var model = xmiReaderResult.QueryRoot("_kUROkM9FEe6Zc_le1peNgQ") as IModel;

                Assert.That(model.XmiId, Is.EqualTo("_kUROkM9FEe6Zc_le1peNgQ"));
                Assert.That(model.Name, Is.EqualTo("sysml"));
            }
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Verify_that_SysML_XMI_pathmap_references_can_be_read(bool usingSettings)
        {
            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                    x.PathMaps = usingSettings ? new Dictionary<string, string> { ["pathmap://UML_LIBRARIES/UMLPrimitiveTypes.library.uml"] = Path.Combine("TestData", "PrimitiveTypes.xmi") } : [])
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SysML.uml"));

            Assert.That(xmiReaderResult.XmiRoot, Is.Not.Null);

            var model = xmiReaderResult.QueryRoot("_kUROkM9FEe6Zc_le1peNgQ") as IModel;

            var sysmlTypClass = model.PackagedElement.OfType<IClass>().FirstOrDefault(x => x.Name == "Type");
            var isAbstractProperty = sysmlTypClass?.OwnedAttribute.FirstOrDefault(x => x.Name == "isAbstract");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(xmiReaderResult.Packages.Count, Is.EqualTo(usingSettings ? 2 : 1));

                Assert.That(model.XmiId, Is.EqualTo("_kUROkM9FEe6Zc_le1peNgQ"));
                Assert.That(model.Name, Is.EqualTo("sysml"));

                Assert.That(sysmlTypClass, Is.Not.Null);
                Assert.That(isAbstractProperty, Is.Not.Null);
                Assert.That(isAbstractProperty.Type, usingSettings ? Is.Not.Null : Is.Null);
            }
        }

        [Test]
        public void Verify_that_bare_same_document_href_references_are_resolved()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x =>
                {
                    x.LocalReferenceBasePath = rootPath;
                    x.PathMaps = new Dictionary<string, string>
                    {
                        ["pathmap://UML_LIBRARIES/UMLPrimitiveTypes.library.uml"] = Path.Combine(rootPath, "PrimitiveTypes.xmi")
                    };
                })
                .WithLogger(this.loggerFactory)
                .Build();

            var xmiReaderResult = reader.Read(Path.Combine(rootPath, "SysML_only_xmi.uml"));

            // The 'directedUsage' ownedAttribute of the 'Definition' class carries two <subsettedProperty> children:
            //   href="KerML_only_xmi.uml#..."  -> 'directedFeature' (cross-document reference, always resolved)
            //   href="#..."                    -> 'usage' (bare same-document fragment, dropped before the #192 fix)
            var directedUsage = AllProperties(xmiReaderResult.Packages)
                .Single(x => x.XmiId == "_18_5_3_12e503d9_1565495064714_974634_26150");

            var subsettedPropertyNames = directedUsage.SubsettedProperty.Select(x => x.Name).ToList();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(directedUsage.Name, Is.EqualTo("directedUsage"));
                Assert.That(directedUsage.SubsettedProperty, Has.Count.EqualTo(2));
                Assert.That(subsettedPropertyNames, Does.Contain("directedFeature"));
                Assert.That(subsettedPropertyNames, Does.Contain("usage"));
            }
        }

        /// <summary>
        /// Recursively enumerates every <see cref="IProperty"/> owned by the <see cref="IClass"/>es
        /// contained (directly or transitively) in the provided <paramref name="packages"/>
        /// </summary>
        private static IEnumerable<IProperty> AllProperties(IEnumerable<IPackage> packages)
        {
            foreach (var package in packages)
            {
                foreach (var property in AllProperties(package))
                {
                    yield return property;
                }
            }
        }

        /// <summary>
        /// Recursively enumerates every <see cref="IProperty"/> owned by the <see cref="IClass"/>es
        /// contained (directly or transitively) in the provided <paramref name="package"/>
        /// </summary>
        private static IEnumerable<IProperty> AllProperties(IPackage package)
        {
            foreach (var packagedElement in package.PackagedElement)
            {
                if (packagedElement is IClass @class)
                {
                    foreach (var attribute in @class.OwnedAttribute)
                    {
                        yield return attribute;
                    }
                }

                if (packagedElement is IPackage nestedPackage)
                {
                    foreach (var property in AllProperties(nestedPackage))
                    {
                        yield return property;
                    }
                }
            }
        }
    }
}
