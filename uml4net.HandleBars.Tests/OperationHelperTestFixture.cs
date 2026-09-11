// -------------------------------------------------------------------------------------------------
// <copyright file="OperationHelperTestFixture.cs" company="Starion Group S.A.">
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
    using uml4net.SimpleClassifiers;
    using uml4net.StructuredClassifiers;

    /// <summary>
    /// Suite of tests for the <see cref="OperationHelper"/> class.
    /// </summary>
    [TestFixture]
    public class OperationHelperTestFixture
    {
        private IHandlebars handlebarsContext;

        [SetUp]
        public void SetUp()
        {
            this.handlebarsContext = Handlebars.Create();
            this.handlebarsContext.Configuration.FormatProvider = CultureInfo.InvariantCulture;
            OperationHelper.RegisterOperationHelper(this.handlebarsContext);
        }

        private static Operation CreateOperation(IClass owner, string name)
        {
            var operation = new Operation { Name = name, XmiId = $"{owner.Name}-{name}" };
            owner.OwnedOperation.Add(operation);

            var input = new Parameter { Name = "count", Direction = ParameterDirectionKind.In, Type = new PrimitiveType { Name = "Integer", XmiId = "Integer" } };
            operation.OwnedParameter.Add(input);

            var returnParameter = new Parameter { Name = "result", Direction = ParameterDirectionKind.Return, Type = new PrimitiveType { Name = "Boolean", XmiId = "Boolean" } };
            operation.OwnedParameter.Add(returnParameter);

            return operation;
        }

        [Test]
        public void Verify_that_WriteForPOCOInterface_writes_the_expected_signature()
        {
            var owner = new Class { Name = "MyClass" };
            var operation = CreateOperation(owner, "doSomething");

            var template = "{{ #Operation.WriteForPOCOInterface this }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(operation);

            Assert.That(result.Trim(), Does.StartWith("bool"));
            Assert.That(result, Does.Contain("DoSomething("));
            Assert.That(result, Does.Contain("count"));
        }

        [Test]
        public void Verify_that_WriteForPOCOInterface_writes_void_when_there_is_no_return_parameter()
        {
            var owner = new Class { Name = "MyClass" };
            var operation = new Operation { Name = "doSomething" };
            owner.OwnedOperation.Add(operation);

            var template = "{{ #Operation.WriteForPOCOInterface this }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(operation);

            Assert.That(result.Trim(), Does.StartWith("void DoSomething("));
        }

        [Test]
        public void Verify_that_WriteForPOCOInterface_writes_new_when_the_operation_shadows_a_redefined_one()
        {
            var owner = new Class { Name = "MyClass" };
            var operation = CreateOperation(owner, "doSomething");
            operation.RedefinedOperation.Add(new Operation { Name = "doSomething" });

            var template = "{{ #Operation.WriteForPOCOInterface this }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(operation);

            Assert.That(result, Does.StartWith("new "));
        }

        [Test]
        public void Verify_that_WriteForPOCOInterface_throws_when_argument_is_not_an_operation()
        {
            var template = "{{ #Operation.WriteForPOCOInterface this }}";
            var action = this.handlebarsContext.Compile(template);

            Assert.That(() => action(5), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Verify_that_WriteForPOCOExtend_writes_the_expected_signature()
        {
            var owner = new Class { Name = "MyClass" };
            var operation = CreateOperation(owner, "doSomething");

            var template = "{{ #Operation.WriteForPOCOExtend this }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(operation);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Does.StartWith("internal static bool"));
                Assert.That(result, Does.Contain("ComputeDoSomethingOperation(this IMyClass myClassSubject"));
                Assert.That(result, Does.Contain("count"));
            }
        }

        [Test]
        public void Verify_that_WriteForPOCOExtend_uses_the_redefined_method_name_when_the_operation_shadows_one()
        {
            var owner = new Class { Name = "MyClass" };
            var operation = CreateOperation(owner, "doSomething");
            operation.RedefinedOperation.Add(new Operation { Name = "doSomething" });

            var template = "{{ #Operation.WriteForPOCOExtend this }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(operation);

            Assert.That(result, Does.Contain("ComputeRedefinedDoSomethingOperation"));
        }

        [Test]
        public void Verify_that_WriteForPOCOExtend_throws_when_argument_is_not_an_operation()
        {
            var template = "{{ #Operation.WriteForPOCOExtend this }}";
            var action = this.handlebarsContext.Compile(template);

            Assert.That(() => action(5), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Verify_that_WriteForPOCOClass_writes_a_public_forwarding_method_when_not_redefined()
        {
            var owner = new Class { Name = "MyClass" };
            var operation = CreateOperation(owner, "doSomething");

            var template = "{{ #Operation.WriteForPOCOClass operation owner }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(new { operation, owner });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Does.StartWith("public bool"));
                Assert.That(result, Does.Contain("DoSomething("));
                Assert.That(result, Does.Contain("=> this.ComputeDoSomethingOperation("));
            }
        }

        [Test]
        public void Verify_that_WriteForPOCOClass_writes_an_explicit_interface_forward_when_redefined()
        {
            var owner = new Class { Name = "MyClass" };
            var operation = CreateOperation(owner, "doSomething");

            var redefiningClass = new Class { Name = "MySubClass" };
            var redefiningOperation = CreateOperation(redefiningClass, "doSomethingElse");
            redefiningOperation.RedefinedOperation.Add(operation);

            var template = "{{ #Operation.WriteForPOCOClass operation owner }}";
            var action = this.handlebarsContext.Compile(template);

            var result = action(new { operation, owner = redefiningClass });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Does.Contain("IMyClass.DoSomething("));
                Assert.That(result, Does.Contain("=> this.DoSomethingElse("));
            }
        }

        [Test]
        public void Verify_that_WriteForPOCOClass_throws_when_arguments_are_invalid()
        {
            var template = "{{ #Operation.WriteForPOCOClass operation owner }}";
            var action = this.handlebarsContext.Compile(template);

            Assert.That(() => action(new { operation = 5, owner = new Class() }), Throws.TypeOf<ArgumentException>());
        }
    }
}
