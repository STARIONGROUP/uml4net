// -------------------------------------------------------------------------------------------------
// <copyright file="OperationExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    using uml4net.SimpleClassifiers;
    using uml4net.Values;

    [TestFixture]
    public class OperationExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_operation_is_null_argument_exception_is_thrown()
        {
            Operation operation = null;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(() => OperationExtensions.QueryIsOrdered(operation), Throws.ArgumentNullException);
                Assert.That(() => OperationExtensions.QueryIsUnique(operation), Throws.ArgumentNullException);
                Assert.That(() => OperationExtensions.QueryLower(operation), Throws.ArgumentNullException);
                Assert.That(() => OperationExtensions.QueryType(operation), Throws.ArgumentNullException);
                Assert.That(() => OperationExtensions.QueryUpper(operation), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_when_no_return_parameter_exists_default_values_are_returned()
        {
            var operation = new Operation();

            operation.OwnedParameter.Add(new Parameter { Direction = ParameterDirectionKind.In });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(operation.IsOrdered, Is.False);
                Assert.That(operation.IsUnique, Is.True);
                Assert.That(operation.Lower, Is.EqualTo(0));
                Assert.That(operation.Type, Is.Null);
                Assert.That(operation.Upper, Is.EqualTo("0"));
            }
        }

        [Test]
        public void Verify_that_when_return_parameter_exists_its_values_are_returned()
        {
            var returnType = new PrimitiveType { Name = "String" };

            var returnParameter = new Parameter
            {
                Direction = ParameterDirectionKind.Return,
                Type = returnType,
                IsOrdered = true,
                IsUnique = false
            };

            returnParameter.LowerValue.Add(new LiteralInteger { Value = 1 });
            returnParameter.UpperValue.Add(new LiteralUnlimitedNatural { Value = "1" });

            var operation = new Operation();
            operation.OwnedParameter.Add(new Parameter { Direction = ParameterDirectionKind.In });
            operation.OwnedParameter.Add(returnParameter);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(operation.IsOrdered, Is.True);
                Assert.That(operation.IsUnique, Is.False);
                Assert.That(operation.Lower, Is.EqualTo(1));
                Assert.That(operation.Type, Is.SameAs(returnType));
                Assert.That(operation.Upper, Is.EqualTo("1"));
            }
        }
    }
}
