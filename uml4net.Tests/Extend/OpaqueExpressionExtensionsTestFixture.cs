// -------------------------------------------------------------------------------------------------
// <copyright file="OpaqueExpressionExtensionsTestFixture.cs" company="Starion Group S.A.">
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
    using uml4net.CommonBehavior;
    using uml4net.Values;

    [TestFixture]
    public class OpaqueExpressionExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_opaqueExpression_is_null_argument_null_exception_is_thrown()
        {
            OpaqueExpression opaqueExpression = null;

            Assert.That(() => OpaqueExpressionExtensions.QueryResult(opaqueExpression), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_Result_is_null_when_behavior_is_not_set()
        {
            var opaqueExpression = new OpaqueExpression();

            Assert.That(opaqueExpression.Result, Is.Null);
        }

        [Test]
        public void Verify_that_Result_is_null_when_behavior_has_no_ownedParameter()
        {
            var opaqueExpression = new OpaqueExpression { Behavior = new FunctionBehavior() };

            Assert.That(opaqueExpression.Result, Is.Null);
        }

        [Test]
        public void Verify_that_Result_is_the_first_ownedParameter_of_the_behavior()
        {
            // per the OMG UML 2.5.1 metamodel (and clause 8.6.16), OpaqueExpression::/result is
            // derived as "behavior.ownedParameter->first()" - not by selecting the return-directed
            // parameter - so the first owned parameter is returned even when it is not the one
            // whose direction is Return.
            var returnParameter = new Parameter { Name = "returnParameter", Direction = ParameterDirectionKind.Return };
            var inParameter = new Parameter { Name = "inParameter", Direction = ParameterDirectionKind.In };

            var behavior = new FunctionBehavior();
            behavior.OwnedParameter.Add(inParameter);
            behavior.OwnedParameter.Add(returnParameter);

            var opaqueExpression = new OpaqueExpression { Behavior = behavior };

            Assert.That(opaqueExpression.Result, Is.SameAs(inParameter));
        }
    }
}
