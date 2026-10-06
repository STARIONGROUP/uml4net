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

namespace uml4net.Extensions.Tests
{
    using System.IO;
    using System.Linq;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Extensions;
    using uml4net.StructuredClassifiers;
    using uml4net.Values;
    using uml4net.xmi;

    [TestFixture]
    public class OperationExtensionsTestFixture
    {
        [Test]
        public void Verify_that_QueryBodyConditionText_returns_the_body_of_the_body_condition()
        {
            var opaqueExpression = new OpaqueExpression();
            opaqueExpression.Body.Add("result = (name)\r\n");

            var bodyCondition = new Constraint();
            bodyCondition.Specification.Add(opaqueExpression);

            var operation = new Operation();
            operation.BodyCondition.Add(bodyCondition);

            Assert.That(operation.QueryBodyConditionText(), Is.EqualTo("result = (name)"));
        }

        [Test]
        public void Verify_that_QueryBodyConditionText_ignores_the_rules_of_the_owning_class()
        {
            var opaqueExpression = new OpaqueExpression();
            opaqueExpression.Body.Add("true");

            var classRule = new Constraint();
            classRule.Specification.Add(opaqueExpression);

            var operation = new Operation();

            var @class = new Class();
            @class.OwnedRule.Add(classRule);
            @class.OwnedOperation.Add(operation);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(operation.QueryBodyConditionText(), Is.Empty);
                Assert.That(() => OperationExtensions.QueryBodyConditionText(null), Throws.ArgumentNullException);
            }
        }

        [Test]
        public void Verify_that_QueryBodyConditionText_reads_the_body_condition_from_the_UML_model()
        {
            var rootPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData");

            var reader = XmiReaderBuilder.Create()
                .UsingSettings(x => x.LocalReferenceBasePath = rootPath)
                .WithLogger(NullLoggerFactory.Instance)
                .Build();

            var root = reader.Read(Path.Combine(rootPath, "UML.xmi")).QueryRoot(xmiId: "_0", name: "UML");

            var element = root.NestedPackage.Single(x => x.Name == "CommonStructure")
                .PackagedElement.OfType<IClass>().Single(x => x.Name == "Element");

            var allOwnedElements = element.OwnedOperation.Single(x => x.Name == "allOwnedElements");

            Assert.That(allOwnedElements.QueryBodyConditionText(), Is.EqualTo("result = (ownedElement->union(ownedElement->collect(e | e.allOwnedElements()))->asSet())"));
        }
    }
}
