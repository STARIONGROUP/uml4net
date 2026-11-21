// -------------------------------------------------------------------------------------------------
// <copyright file="ReportHandlerTestFixture.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tools.Tests.Commands
{
    using System;
    using System.Collections.Generic;
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

        [Test]
        public void Verify_that_OpenGeneratedReport_reports_success_when_the_report_can_be_opened()
        {
            var handler = new TestableReportHandler(exceptionToThrow: null);

            var statuses = new List<string>();

            handler.InvokeOpenGeneratedReport(statuses.Add);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(statuses, Does.Contain("Opening generated report"));
                Assert.That(statuses, Does.Contain("Generated report opened"));
            }
        }

        [Test]
        public void Verify_that_OpenGeneratedReport_reports_failure_when_opening_fails()
        {
            var handler = new TestableReportHandler(new Win32Exception("Access is denied"));

            var statuses = new List<string>();

            handler.InvokeOpenGeneratedReport(statuses.Add);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(statuses, Does.Contain("Opening of generated report failed, please open manually"));
                Assert.That(statuses, Does.Not.Contain("Generated report opened"));
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

            public void InvokeOpenGeneratedReport(Action<string> updateStatus)
            {
                this.OpenGeneratedReport(updateStatus);
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
