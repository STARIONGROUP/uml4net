// -------------------------------------------------------------------------------------------------
// <copyright file="XmiReadException.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Readers
{
    using System;

    using uml4net.xmi.Settings;

    /// <summary>
    /// The exception that is thrown when an XMI document contains a value that is not valid according to
    /// XMI 2.5.1 and <see cref="IXmiReaderSettings.UseStrictReading"/> is set
    /// </summary>
    public class XmiReadException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmiReadException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message that describes the invalid value
        /// </param>
        /// <param name="elementType">
        /// The type of the element that is being read
        /// </param>
        /// <param name="xmiId">
        /// The xmi:id of the element that is being read, may be null
        /// </param>
        /// <param name="propertyName">
        /// The name of the property whose value is invalid
        /// </param>
        /// <param name="lineNumber">
        /// The line number in the document at which the invalid value was found
        /// </param>
        /// <param name="linePosition">
        /// The position in the line at which the invalid value was found
        /// </param>
        public XmiReadException(string message, string elementType, string xmiId, string propertyName, int lineNumber, int linePosition)
            : base($"{message}: {elementType} [{xmiId}] property [{propertyName}] at line:position {lineNumber}:{linePosition}")
        {
            this.ElementType = elementType;
            this.XmiId = xmiId;
            this.PropertyName = propertyName;
            this.LineNumber = lineNumber;
            this.LinePosition = linePosition;
        }

        /// <summary>
        /// Gets the type of the element that was being read
        /// </summary>
        public string ElementType { get; }

        /// <summary>
        /// Gets the xmi:id of the element that was being read, may be null
        /// </summary>
        public string XmiId { get; }

        /// <summary>
        /// Gets the name of the property whose value is invalid
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Gets the line number in the document at which the invalid value was found
        /// </summary>
        public int LineNumber { get; }

        /// <summary>
        /// Gets the position in the line at which the invalid value was found
        /// </summary>
        public int LinePosition { get; }
    }
}
