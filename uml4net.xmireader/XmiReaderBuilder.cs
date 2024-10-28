// -------------------------------------------------------------------------------------------------
//  <copyright file="XmiReaderBuilderExtensions.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2024 Starion Group S.A.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, softwareUseCases
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
//  </copyright>
//  ------------------------------------------------------------------------------------------------

namespace uml4net.xmi
{
    using Autofac;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Settings;
    using System;
    using System.Net.Http;
    using Readers;

    /// <summary>
    /// Provides builder methods to configure and create an instance of <see cref="IXmiReader"/>.
    /// </summary>
    public static class XmiReaderBuilder
    {
        /// <summary>
        /// Delegate for configuring IXmiReaderSettings.
        /// </summary>
        /// <param name="settings">The settings instance to configure.</param>
        public delegate void ConfigureXmiReaderSettings(IXmiReaderSettings settings);

        /// <summary>
        /// Creates a new instance of <see cref="XmiReaderScope"/> used to configure services for an XMI reader.
        /// </summary>
        /// <returns>
        /// A new <see cref="XmiReaderScope"/> to configure and build the XMI reader.
        /// </returns>
        public static XmiReaderScope Create()
        {
            return new XmiReaderScope();
        }

        /// <summary>
        /// Configures the <see cref="XmiReaderScope"/> using a builder delegate to set properties of the <see cref="IXmiReaderSettings"/> instance.
        /// </summary>
        /// <param name="scope">The <see cref="XmiReaderScope"/> being configured.</param>
        /// <param name="configure">The delegate to configure the <see cref="IXmiReaderSettings"/>.</param>
        /// <returns>
        /// The configured <see cref="XmiReaderScope"/> instance.
        /// </returns>
        public static XmiReaderScope UsingSettings(this XmiReaderScope scope, ConfigureXmiReaderSettings configure)
        {
            var settings = new DefaultSettings();
            configure(settings);
            scope.ContainerBuilder.RegisterInstance(settings).As<IXmiReaderSettings>();
            return scope;
        }

        /// <summary>
        /// Configures the <see cref="XmiReaderScope"/> to use the provided <see cref="IXmiReaderSettings"/> instance.
        /// </summary>
        /// <param name="scope">The <see cref="XmiReaderScope"/> being configured.</param>
        /// <param name="settings">The <see cref="IXmiReaderSettings"/> to be used by the XMI reader.</param>
        /// <returns>
        /// The configured <see cref="XmiReaderScope"/> instance.
        /// </returns>
        public static XmiReaderScope UsingSettings(this XmiReaderScope scope, IXmiReaderSettings settings)
        {
            scope.ContainerBuilder.RegisterInstance(settings).As<IXmiReaderSettings>();
            return scope;
        }

        /// <summary>
        /// Configures the <see cref="XmiReaderScope"/> to use the provided <see cref="ILoggerFactory"/> for logging.
        /// </summary>
        /// <param name="scope">The <see cref="XmiReaderScope"/> being configured.</param>
        /// <param name="loggerFactory">The <see cref="ILoggerFactory"/> to be used for logging.</param>
        /// <returns>
        /// The configured <see cref="XmiReaderScope"/> instance.
        /// </returns>
        public static XmiReaderScope WithLogger(this XmiReaderScope scope, ILoggerFactory loggerFactory)
        {
            scope.ContainerBuilder.RegisterInstance(loggerFactory).As<ILoggerFactory>().SingleInstance();
            return scope;
        }

        /// <summary>
        /// Builds and configures the <see cref="IXmiReader"/> based on the services added to the <see cref="XmiReaderScope"/>.
        /// </summary>
        /// <param name="scope">The <see cref="XmiReaderScope"/> being used to build the XMI reader.</param>
        /// <returns>
        /// A fully configured instance of <see cref="IXmiReader"/>.
        /// </returns>
        public static IXmiReader Build(this XmiReaderScope scope)
        {
            scope.CreateScope();
            return scope.Scope.Resolve<IXmiReader>();
        }
    }
}
