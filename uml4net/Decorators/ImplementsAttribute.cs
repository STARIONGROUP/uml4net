// -------------------------------------------------------------------------------------------------
// <copyright file="ImplementsAttribute.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Decorators
{
    using System;
    
    /// <summary>
    /// Attribute used to decorate properties with to indicate which class/property
    /// is being implemented
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class ImplementsAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImplementsAttribute"/> class.
        /// </summary>
        public ImplementsAttribute(string implementation)
        { 
            this.Implementations = implementation;
        }

        /// <summary>
        /// Gets or sets the names of the properties that are being implemented
        /// ClassName.AttributeName or ClassName.OperationName
        /// </summary>
        public string Implementations { get; set; }
    }
}
