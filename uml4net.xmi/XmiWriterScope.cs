// -------------------------------------------------------------------------------------------------
// <copyright file="XmiWriterScope.cs" company="Starion Group S.A.">
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
    using System;

    using Autofac;

    using Microsoft.Extensions.Logging;

    using uml4net.xmi.Settings;
    using uml4net.xmi.Writers;

    /// <summary>
    /// Represents the scope for configuring and managing services used by the XMI writer.
    /// </summary>
    public class XmiWriterScope : IXmiWriterScope
    {
        /// <summary>
        /// Gets the Autofac container builder for configuring services.
        /// </summary>
        internal ContainerBuilder ContainerBuilder { get; } = new();

        /// <summary>
        /// Gets the Autofac container for resolving services.
        /// </summary>
        internal IContainer Container { get; private set; }

        /// <summary>
        /// Gets the service scope which provides a scoped lifetime for services.
        /// </summary>
        internal ILifetimeScope Scope { get; private set; }

        /// <summary>
        /// Builds the service provider and service scope from the configured service collection.
        /// </summary>
        internal void CreateScope()
        {
            this.Container = this.ContainerBuilder.Build();
            this.Scope = this.Container.BeginLifetimeScope();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiWriterScope"/> class and configures default services.
        /// </summary>
        internal XmiWriterScope()
        {
            // Overridable services
            this.ContainerBuilder.RegisterType<DefaultWriterSettings>().As<IXmiWriterSettings>();

            // Required services
            this.ContainerBuilder.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>));
            this.ContainerBuilder.RegisterInstance(this).As<IXmiWriterScope>().SingleInstance();

            this.ContainerBuilder.RegisterType<ReferenceClosureCalculator>().As<IReferenceClosureCalculator>().SingleInstance();

            // Writers
            this.ContainerBuilder.RegisterType<XmiElementWriterFacade>().As<IXmiElementWriterFacade>().SingleInstance();
            this.ContainerBuilder.RegisterType<XmiWriter>().As<IXmiWriter>();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">
        /// A value indicating whether this class is being disposed of
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Container?.Dispose();
            }
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~XmiWriterScope()
        {
            this.Dispose(false);
        }
    }
}
