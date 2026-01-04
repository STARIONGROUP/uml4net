// -------------------------------------------------------------------------------------------------
//  <copyright file="Documentation.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Xmi
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The Documentation class contains information about the XMI document or stream being transmitted,
    /// </summary>
    public class Documentation
    {
        /// <summary>
        /// Name or details for a document contact person or point of contact.
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// Human-readable name of the exporting tool or system.
        /// </summary>
        public string Exporter { get; set; }

        /// <summary>
        /// Version string of the exporting tool.
        /// </summary>
        public string ExporterVersion { get; set; }

        /// <summary>
        /// Non-standard convenience field for an exporter identifier.
        /// </summary>
        public string ExporterID { get; set; }

        /// <summary>
        /// Zero or more long, free-text descriptions of the document.
        /// </summary>
        public List<string> LongDescription { get; set; } = [];

        /// <summary>
        /// Zero or more short descriptions or summaries of the document.
        /// </summary>
        public List<string> ShortDescription { get; set; } = [];

        /// <summary>
        /// Zero or more copyright or legal notices associated with the document.
        /// </summary>
        public List<string> Notice { get; set; } = [];

        /// <summary>
        /// Zero or more owners (individuals or organizations) of the document.
        /// </summary>
        public List<string> Owner { get; set; } = [];

        /// <summary>
        /// <see cref="DateTime"/> at which the document was created or exported 
        /// </summary>
        public DateTime TimeStamp { get; set; }
    }
}
