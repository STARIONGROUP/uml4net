// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiInspectorTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Reporting.Tests.Generators
{
    using System;
    using System.IO;

    using Microsoft.Extensions.Logging;
    
    using NUnit.Framework;
    
    using Serilog;
    
    using uml4net.Reporting.Generators;

    [TestFixture]
    public class XmiInspectorTestFixture
    {
        private ILoggerFactory loggerFactory;

        private XmiInspector xmiInspector;

        private FileInfo umlModelFileInfo;

        private FileInfo sysml2ModelFileInfo;

        [SetUp]
        public void SetUp()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

            this.loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });

            this.umlModelFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "UML.xmi"));
            this.sysml2ModelFileInfo = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "SysML.uml"));
        }

        [Test]
        public void Verify_that_the_report_generator_generates_a_report_of_uml()
        {
            this.xmiInspector = new XmiInspector(this.loggerFactory);

            Assert.That(() =>
            {
                var result = this.xmiInspector.Inspect(this.umlModelFileInfo);
                Console.WriteLine(result);

            }, Throws.Nothing);
        }

        [Test]
        public void Verify_that_the_report_generator_generates_a_report_of_sysml2()
        {
            this.xmiInspector = new XmiInspector(this.loggerFactory);

            Assert.That(() =>
            {
                var result = this.xmiInspector.Inspect(this.sysml2ModelFileInfo);
                Console.WriteLine(result);

            }, Throws.Nothing);
        }
    }
}