// -------------------------------------------------------------------------------------------------
// <copyright file="StereoTypeApplicationResolverTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Tests.Readers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.Packages;
    using uml4net.Profiling;
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;
    using uml4net.xmi.Readers;

    /// <summary>
    /// Verifies that the stereotype applications of a document are resolved: linked to their stereotype and extended
    /// element, with typed tagged values, and registered with the extended element (UML 2.5.1 clause 12.3.3)
    /// </summary>
    [TestFixture]
    public class StereoTypeApplicationResolverTestFixture
    {
        private XmiReaderResult xmiReaderResult;

        private CapturingLoggerProvider loggerProvider;

        private Dictionary<string, StereoTypeApplication> applications;

        [SetUp]
        public void SetUp()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "StereotypeApplications");

            this.loggerProvider = new CapturingLoggerProvider();

            using var loggerFactory = LoggerFactory.Create(builder => builder.AddProvider(this.loggerProvider));

            using var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(loggerFactory)
                .Build();

            this.xmiReaderResult = reader.Read(Path.Combine(rootPath, "profile-and-applications.xmi"));
            this.applications = this.xmiReaderResult.XmiRoot.StereoTypeApplications.ToDictionary(x => x.XmiId);
        }

        [Test]
        public void Verify_that_an_application_is_resolved_through_the_nsURI_tag_of_its_profile()
        {
            var requirement = this.applications["requirementA"];
            var classA = this.QueryClass("a");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(requirement.NamespaceUri, Is.EqualTo("http://example.org/profiles/Demo/1.0/Demo.xmi"), "not the URI of the profile, but its org.omg.xmi.nsURI tag");
                Assert.That(requirement.DocumentName, Is.EqualTo("profile-and-applications.xmi"));
                Assert.That(requirement.Stereotype, Is.Not.Null);
                Assert.That(requirement.Stereotype.XmiId, Is.EqualTo("Requirement"), "a stereotype of a package nested in the profile");
                Assert.That(requirement.ExtendedElement, Is.SameAs(classA));
                Assert.That(classA.QueryStereoTypeApplications(), Is.EqualTo(new[] { requirement }), "the application is registered with the extended element");
                Assert.That(classA.QueryStereoTypeApplication("Requirement"), Is.SameAs(requirement));
            }
        }

        [Test]
        public void Verify_that_the_tagged_values_are_typed_by_the_properties_of_the_stereotype()
        {
            var requirement = this.applications["requirementA"];
            var classB = this.QueryClass("b");
            var classC = this.QueryClass("c");

            using (Assert.EnterMultipleScope())
            {
                Assert.That(requirement.QueryTaggedValue("isMandatory").Values, Is.EqualTo(new object[] { true }));
                Assert.That(requirement.QueryTaggedValue("priority").Values, Is.EqualTo(new object[] { 3 }));
                Assert.That(requirement.QueryTaggedValue("weight").Values, Is.EqualTo(new object[] { 0.5d }));
                Assert.That(requirement.QueryTaggedValue("maximum").Values, Is.EqualTo(new object[] { int.MaxValue }), "* is represented by int.MaxValue");
                Assert.That(requirement.QueryTaggedValue("text").Values, Is.EqualTo(new object[] { "first", "second" }), "a multi-valued property serialized as child elements");
                Assert.That(requirement.QueryTaggedValue("owner").Values, Is.EqualTo(new object[] { "team" }), "a property inherited from the general stereotype");
                Assert.That(requirement.QueryTaggedValue("owner").Property.XmiId, Is.EqualTo("Tracked-owner"));

                var level = requirement.QueryTaggedValue("level");
                Assert.That(level.Values.Single(), Is.InstanceOf<IEnumerationLiteral>().With.Property("Name").EqualTo("high"));

                var tracedTo = requirement.QueryTaggedValue("tracedTo");
                Assert.That(tracedTo.Values, Is.EqualTo(new object[] { classB, classC }), "references serialized as an attribute, separated by spaces");
                Assert.That(tracedTo.IsReference, Is.True);
                Assert.That(tracedTo.IsReadAsAttribute, Is.True);

                var refines = requirement.QueryTaggedValue("refines");
                Assert.That(refines.Values, Has.Count.EqualTo(2), "references serialized as child elements, with an xmi:idref and an href");
                Assert.That(refines.Values[0], Is.SameAs(classB));
                Assert.That(refines.Values[1], Is.InstanceOf<IClass>().With.Property("Name").EqualTo("Class"), "the href resolves to the UML metaclass");
                Assert.That(refines.RawValues, Is.EqualTo(new[] { "b", "http://www.omg.org/spec/UML/20161101/UML.xmi#Class" }));
            }
        }

        [Test]
        public void Verify_that_a_tagged_value_that_cannot_be_typed_is_kept_as_read()
        {
            var requirement = this.applications["requirementB"];
            var warnings = this.loggerProvider.Messages.Where(x => x.Level == LogLevel.Warning).Select(x => x.Message).ToList();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(requirement.ExtendedElement?.XmiId, Is.EqualTo("b"), "the base_ reference as a child element");

                var priority = requirement.QueryTaggedValue("priority");
                Assert.That(priority.Property?.Name, Is.EqualTo("priority"));
                Assert.That(priority.Values, Is.Empty);
                Assert.That(priority.RawValues, Is.EqualTo(new[] { "not-a-number" }));

                var unknown = requirement.QueryTaggedValue("unknown");
                Assert.That(unknown.Property, Is.Null);
                Assert.That(unknown.RawValues, Is.EqualTo(new[] { "kept" }));

                Assert.That(warnings, Has.Some.Contains("The tagged value priority of the stereotype application requirementB cannot be converted"));
                Assert.That(warnings, Has.Some.Contains("The tagged value unknown of the stereotype application requirementB is not a property of the stereotype Requirement"));
            }
        }

        [Test]
        public void Verify_that_applications_that_cannot_be_resolved_completely_are_kept_and_reported()
        {
            var warnings = this.loggerProvider.Messages.Where(x => x.Level == LogLevel.Warning).Select(x => x.Message).ToList();

            using (Assert.EnterMultipleScope())
            {
                var missingStereotype = this.applications["missingStereotype"];
                Assert.That(missingStereotype.Stereotype, Is.Null);
                Assert.That(missingStereotype.ExtendedElement?.XmiId, Is.EqualTo("c"));
                Assert.That(warnings, Has.Some.Contains("The stereotype Missing of the stereotype application missingStereotype is not found in the profile Demo"));

                var missingElement = this.applications["missingElement"];
                Assert.That(missingElement.Stereotype?.Name, Is.EqualTo("Requirement"));
                Assert.That(missingElement.ExtendedElement, Is.Null);
                Assert.That(warnings, Has.Some.EqualTo("1 stereotype applications extend an element that is not found, for example doesNotExist by missingElement"));

                var other = this.applications["otherApplication"];
                Assert.That(other.Stereotype, Is.Null, "no profile of the namespace is available");
                Assert.That(other.ExtendedElement?.XmiId, Is.EqualTo("c"), "the extended element is resolved nevertheless");
                Assert.That(other.TaggedValues.Select(x => $"{x.Name}:{string.Join(",", x.RawValues)}:{x.IsReference}:{x.IsReadAsAttribute}"),
                    Is.EqualTo(new[] { "note:kept:False:True", "related:a,other.xmi#x:True:False", "comment:free text:False:False" }));
                Assert.That(other.TaggedValues.SelectMany(x => x.Values), Is.Empty);
                Assert.That(warnings, Has.Some.EqualTo("1 stereotype applications of the namespace http://example.org/profiles/Other are not resolved, the profile is not available"));

                var classC = this.QueryClass("c");
                Assert.That(classC.QueryStereoTypeApplications().Select(x => x.XmiId), Is.EqualTo(new[] { "missingStereotype", "otherApplication" }));
                Assert.That(classC.QueryStereoTypeApplication("Marker"), Is.SameAs(other), "an unresolved application is found by the name that was read");
            }
        }

        [Test]
        public void Verify_that_a_profile_stereotype_and_property_are_found_by_their_name_without_the_characters_illegal_in_an_XML_name()
        {
            // as in an Eclipse UML2 export: the profile "Second Profile" has no URI and its applications use the prefix
            // SecondProfile, the stereotype "Spaced Stereotype" is SpacedStereotype and the property "Display Name" is DisplayName
            var spaced = this.applications["spacedApplication"];

            using (Assert.EnterMultipleScope())
            {
                Assert.That(spaced.Stereotype?.XmiId, Is.EqualTo("Spaced"));
                Assert.That(spaced.QueryTaggedValue("Display Name")?.Values, Is.EqualTo(new object[] { "shown" }));
                Assert.That(spaced.QueryTaggedValue("Display Name")?.Name, Is.EqualTo("DisplayName"), "the name as read");
                Assert.That(XmlNameConverter.ToXmlName("Display Name"), Is.EqualTo("DisplayName"));
                Assert.That(XmlNameConverter.ToXmlName(null), Is.Null);
                Assert.That(XmlNameConverter.ToXmlName(string.Empty), Is.Empty);
            }
        }

        [Test]
        public void Verify_that_the_resolver_checks_its_arguments_and_ignores_a_result_without_applications()
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => new StereoTypeApplicationResolver(null, NullLoggerFactory.Instance), Throws.ArgumentNullException);

                var resolver = new StereoTypeApplicationResolver(new XmiElementCache(), null);
                Assert.That(() => resolver.Resolve(null), Throws.ArgumentNullException);
                Assert.That(() => resolver.Resolve(new XmiReaderResult()), Throws.Nothing);
            }
        }

        private IClass QueryClass(string xmiId)
        {
            return this.xmiReaderResult.QueryRoot("model").PackagedElement.OfType<IClass>().Single(x => x.XmiId == xmiId);
        }

        /// <summary>
        /// An <see cref="ILoggerProvider"/> that captures the formatted log messages
        /// </summary>
        private sealed class CapturingLoggerProvider : ILoggerProvider
        {
            public List<(LogLevel Level, string Message)> Messages { get; } = [];

            public ILogger CreateLogger(string categoryName) => new CapturingLogger(this.Messages);

            public void Dispose()
            {
            }

            private sealed class CapturingLogger(List<(LogLevel Level, string Message)> messages) : ILogger
            {
                public IDisposable BeginScope<TState>(TState state) where TState : notnull => null;

                public bool IsEnabled(LogLevel logLevel) => true;

                public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
                {
                    lock (messages)
                    {
                        messages.Add((logLevel, formatter(state, exception)));
                    }
                }
            }
        }
    }
}
