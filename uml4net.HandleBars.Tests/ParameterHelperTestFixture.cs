// -------------------------------------------------------------------------------------------------
// <copyright file="ParameterHelperTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
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
    using uml4net.SimpleClassifiers;

    /// <summary>
    /// Suite of tests for the <see cref="ParameterHelper"/> class.
    /// </summary>
    [TestFixture]
    public class ParameterHelperTestFixture
    {
        private IHandlebars handlebarsContext;

        [SetUp]
        public void SetUp()
        {
            this.handlebarsContext = Handlebars.Create();
            this.handlebarsContext.Configuration.FormatProvider = CultureInfo.InvariantCulture;
            ParameterHelper.RegisterParameterHelper(this.handlebarsContext);
        }

        [Test]
        public void Verify_that_WriteTypeAndName_writes_void_when_type_is_null()
        {
            var parameter = new Parameter { Name = "count", Direction = ParameterDirectionKind.In };

            var template = "{{ #Parameter.WriteTypeAndName this }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(parameter);

            Assert.That(result, Is.EqualTo("In void"));
        }

        [Test]
        public void Verify_that_WriteTypeAndName_writes_the_type_and_name_for_a_non_return_parameter()
        {
            var type = new PrimitiveType { Name = "Integer", XmiId = "Integer" };
            var parameter = new Parameter { Name = "count", Direction = ParameterDirectionKind.In, Type = type };

            var template = "{{ #Parameter.WriteTypeAndName this }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(parameter);

            Assert.That(result, Is.EqualTo("In <a href=#Integer>Integer</a> count [1..1]"));
        }

        [Test]
        public void Verify_that_WriteTypeAndName_omits_the_name_for_a_return_parameter()
        {
            var type = new PrimitiveType { Name = "Integer", XmiId = "Integer" };
            var parameter = new Parameter { Name = "result", Direction = ParameterDirectionKind.Return, Type = type };

            var template = "{{ #Parameter.WriteTypeAndName this }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(parameter);

            Assert.That(result, Is.EqualTo("Return <a href=#Integer>Integer</a> [1..1]"));
        }

        [Test]
        public void Verify_that_WriteTypeAndName_throws_when_argument_is_not_a_parameter()
        {
            var template = "{{ #Parameter.WriteTypeAndName this }}";
            var action = this.handlebarsContext.Compile(template);

            Assert.That(() => action(5), Throws.TypeOf<ArgumentException>());
        }
    }
}
