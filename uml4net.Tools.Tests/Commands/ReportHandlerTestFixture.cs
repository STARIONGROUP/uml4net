// -------------------------------------------------------------------------------------------------
//  <copyright file="ReportHandlerTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Tools.Tests.Commands
{
    using System;
    using System.ComponentModel;

    using Moq;

    using NUnit.Framework;

    using uml4net.Reporting.Generators;
    using uml4net.Tools.Commands;
    using uml4net.Tools.Services;

    /// <summary>
    /// Suite of tests for the best-effort report opening behaviour of the <see cref="ReportHandler"/> class.
    /// </summary>
    [TestFixture]
    public class ReportHandlerTestFixture
    {
        [Test]
        public void Verify_that_TryOpenReport_returns_true_when_the_report_can_be_opened()
        {
            var handler = new TestableReportHandler(exceptionToThrow: null);

            var success = handler.InvokeTryOpenReport(out var failureReason);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(success, Is.True);
                Assert.That(failureReason, Is.Null);
            }
        }

        [Test]
        public void Verify_that_TryOpenReport_returns_false_and_a_reason_when_opening_fails()
        {
            var handler = new TestableReportHandler(new Win32Exception("Access is denied"));

            var success = handler.InvokeTryOpenReport(out var failureReason);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(success, Is.False);
                Assert.That(failureReason, Is.EqualTo("Access is denied"));
            }
        }

        /// <summary>
        /// Test double that overrides the actual process launch so the best-effort open logic can be exercised
        /// without starting an external process.
        /// </summary>
        private sealed class TestableReportHandler : ReportHandler
        {
            private readonly Exception exceptionToThrow;

            public TestableReportHandler(Exception exceptionToThrow)
                : base(Mock.Of<IReportGenerator>(), Mock.Of<IVersionChecker>())
            {
                this.exceptionToThrow = exceptionToThrow;
            }

            public bool InvokeTryOpenReport(out string failureReason)
            {
                return this.TryOpenReport(out failureReason);
            }

            protected override void OpenReport()
            {
                if (this.exceptionToThrow != null)
                {
                    throw this.exceptionToThrow;
                }
            }
        }
    }
}
