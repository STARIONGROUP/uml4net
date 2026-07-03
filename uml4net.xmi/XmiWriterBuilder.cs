// -------------------------------------------------------------------------------------------------
// <copyright file="XmiWriterBuilder.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi
{
    using Autofac;

    using Microsoft.Extensions.Logging;

    using uml4net.xmi.Settings;
    using uml4net.xmi.Writers;

    /// <summary>
    /// Provides builder methods to configure and create an instance of <see cref="IXmiWriter" />.
    /// </summary>
    public static class XmiWriterBuilder
    {
        /// <summary>
        /// Delegate for configuring IXmiWriterSettings.
        /// </summary>
        /// <param name="settings">The settings instance to configure.</param>
        public delegate void ConfigureXmiWriterSettings(IXmiWriterSettings settings);

        /// <summary>
        /// Creates a new instance of <see cref="XmiWriterScope" /> used to configure services for an XMI writer.
        /// </summary>
        /// <returns>
        /// A new <see cref="XmiWriterScope" /> to configure and build the XMI writer.
        /// </returns>
        public static XmiWriterScope Create()
        {
            return new XmiWriterScope();
        }

        /// <summary>
        /// Configures the <see cref="XmiWriterScope" /> using a builder delegate to set properties of the
        /// <see cref="IXmiWriterSettings" /> instance.
        /// </summary>
        /// <param name="scope">The <see cref="XmiWriterScope" /> being configured.</param>
        /// <param name="configure">The delegate to configure the <see cref="IXmiWriterSettings" />.</param>
        /// <returns>
        /// The configured <see cref="XmiWriterScope" /> instance.
        /// </returns>
        public static XmiWriterScope UsingSettings(this XmiWriterScope scope, ConfigureXmiWriterSettings configure)
        {
            var settings = new DefaultWriterSettings();
            configure(settings);
            scope.ContainerBuilder.RegisterInstance(settings).As<IXmiWriterSettings>();
            return scope;
        }

        /// <summary>
        /// Configures the <see cref="XmiWriterScope" /> to use the provided <see cref="IXmiWriterSettings" /> instance.
        /// </summary>
        /// <param name="scope">The <see cref="XmiWriterScope" /> being configured.</param>
        /// <param name="settings">The <see cref="IXmiWriterSettings" /> to be used by the XMI writer.</param>
        /// <returns>
        /// The configured <see cref="XmiWriterScope" /> instance.
        /// </returns>
        public static XmiWriterScope UsingSettings(this XmiWriterScope scope, IXmiWriterSettings settings)
        {
            scope.ContainerBuilder.RegisterInstance(settings).As<IXmiWriterSettings>();
            return scope;
        }

        /// <summary>
        /// Configures the <see cref="XmiWriterScope" /> to use the provided <see cref="ILoggerFactory" /> for logging.
        /// </summary>
        /// <param name="scope">The <see cref="XmiWriterScope" /> being configured.</param>
        /// <param name="loggerFactory">The <see cref="ILoggerFactory" /> to be used for logging.</param>
        /// <returns>
        /// The configured <see cref="XmiWriterScope" /> instance.
        /// </returns>
        public static XmiWriterScope WithLogger(this XmiWriterScope scope, ILoggerFactory loggerFactory)
        {
            scope.ContainerBuilder.RegisterInstance(loggerFactory).As<ILoggerFactory>().SingleInstance();
            return scope;
        }

        /// <summary>
        /// Builds and configures the <see cref="IXmiWriter" /> based on the services added to the <see cref="XmiWriterScope" />.
        /// </summary>
        /// <param name="scope">The <see cref="XmiWriterScope" /> being used to build the XMI writer.</param>
        /// <returns>
        /// A fully configured instance of <see cref="IXmiWriter" />.
        /// </returns>
        public static IXmiWriter Build(this XmiWriterScope scope)
        {
            scope.CreateScope();
            return scope.Scope.Resolve<IXmiWriter>();
        }
    }
}
