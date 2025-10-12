// -------------------------------------------------------------------------------------------------
//  <copyright file="VersionCheckerTestFixture.cs" company="Starion Group S.A.">
// 
//    Copyright (C) 2019-2025 Starion Group S.A.
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

namespace uml4net.Tools.Tests.Services
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    using NUnit.Framework;

    using Serilog;

    using uml4net.Tools.Services;

    [TestFixture]
    public class VersionCheckerTestFixture
    {
        private VersionChecker versionChecker;

        private ILoggerFactory loggerFactory;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });
        }

        [SetUp]
        public void SetUp()
        {
            var httpClient = new HttpClient(new SuccessHandler())
            {
                Timeout = TimeSpan.FromSeconds(5)
            };

            this.versionChecker = new VersionChecker(httpClient, this.loggerFactory);
        }

        private class SuccessHandler : HttpMessageHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var json = "{\"tag_name\":\"1.2.3\",\"body\":\"notes\",\"html_url\":\"https://example.com\"}";
                return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new StringContent(json)
                });
            }
        }

        [Test]
        public async Task Verify_that_Query_version_returns_result()
        {
            var result = await this.versionChecker.QueryLatestReleaseAsync();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.TagName, Is.EqualTo("1.2.3"));
                Assert.That(result.Body, Is.EqualTo("notes"));
                Assert.That(result.HtmlUrl, Is.EqualTo("https://example.com"));
            }
        }

        private class TimeoutHandler : HttpMessageHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                throw new TaskCanceledException();
            }
        }

        [Test]
        public async Task Verify_that_timeout_returns_null()
        {
            var timeoutClient = new HttpClient(new TimeoutHandler()) { Timeout = TimeSpan.FromSeconds(1) };
            var checker = new VersionChecker(timeoutClient, this.loggerFactory);
            var result = await checker.QueryLatestReleaseAsync();
            Assert.That(result, Is.Null);
        }
    }
}
