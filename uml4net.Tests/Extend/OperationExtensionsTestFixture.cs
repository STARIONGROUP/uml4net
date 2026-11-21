// -------------------------------------------------------------------------------------------------
// <copyright file="OperationExtensionsTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
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
                Assert.That(operation.Lower, Is.Null, "lower = if returnResult()->notEmpty() then ... else null");
                Assert.That(operation.Type, Is.Null);
                Assert.That(operation.Upper, Is.Null, "upper = if returnResult()->notEmpty() then ... else null");
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
