// -------------------------------------------------------------------------------------------------
//  <copyright file="ResourceLoader.cs" company="Starion Group S.A.">
// 
//    Copyright 2019-2025 Starion Group S.A.
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

namespace uml4net.xmi.Resources
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Resources;

    /// <summary>
    /// The <see cref="ResourceLoader"/> isresponsible for loading embedded resources.
    /// </summary>
    public class ResourceLoader : IResourceLoader
    {
        /// <summary>
        /// A dictionary of known (embedded) resources
        /// </summary>
        private readonly Dictionary<string, string> knownExternalReferences = new Dictionary<string, string>
        {
            { "http://www.omg.org/spec/UML/20161101/StandardProfile.xmi", "uml4net.xmi.Resources.StandardProfile.xmi" },
            { "https://www.omg.org/spec/UML/20161101/StandardProfile.xmi", "uml4net.xmi.Resources.StandardProfile.xmi" },
            { "StandardProfile.xmi", "uml4net.xmi.Resources.StandardProfile.xmi" },
            { "StandardProfile", "uml4net.xmi.Resources.StandardProfile.xmi" },

            { "http://www.omg.org/spec/UML/20161101/UML.xmi", "uml4net.xmi.Resources.UML.xmi" },
            { "https://www.omg.org/spec/UML/20161101/UML.xmi", "uml4net.xmi.Resources.UML.xmi" },
            { "UML.xmi", "uml4net.xmi.Resources.UML.xmi" },
            { "UML", "uml4net.xmi.Resources.UML.xmi" },

            { "http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi", "uml4net.xmi.Resources.PrimitiveTypes.xmi" },
            { "https://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi", "uml4net.xmi.Resources.PrimitiveTypes.xmi" },
            { "PrimitiveTypes.xmi", "uml4net.xmi.Resources.UML.xmi" },
            { "PrimitiveTypes", "uml4net.xmi.Resources.UML.xmi" },
        };

        /// <summary>
        /// Try to load a know resource by its name and returns it as a <see cref="Stream"/>
        /// </summary>
        /// <param name="resourceName">
        /// the name of the know resource
        /// </param>
        /// <param name="resourceStream">
        /// The resulting <see cref="Stream"/> that contains the content of the know resource
        /// </param>
        /// <returns>
        /// <c>true</c> if the know resource could be loaded, <c>false</c> if not
        /// </returns>
        public bool TryLoadKnownResource(string resourceName, out Stream resourceStream)
        {
            if (string.IsNullOrEmpty(resourceName))
            {
                throw new ArgumentNullException(nameof(resourceName));
            }

            if (Uri.TryCreate(resourceName, UriKind.Absolute, out var uri))
            {
                resourceName = uri.GetLeftPart(UriPartial.Path);

                return this.TryLoadKnownEmbeddedResource(resourceName, out resourceStream);
            }

            if (resourceName.IndexOf('#') is var index && index > 0)
            {
                resourceName = resourceName.Substring(0, index);

                return this.TryLoadKnownEmbeddedResource(resourceName, out resourceStream);
            }

            resourceStream = null;
            return false;
        }

        /// <summary>
        /// Try to load a know resource by its name and returns it as a <see cref="Stream"/>
        /// </summary>
        /// <param name="resourceName">
        /// The name of the resource
        /// </param>
        /// <param name="resourceStream">
        /// The resulting <see cref="Stream"/> that contains the content of the know resource
        /// </param>
        /// <returns>
        /// <c>true</c> if the know resource could be loaded, <c>false</c> if not
        /// </returns>
        private bool TryLoadKnownEmbeddedResource(string resourceName, out Stream resourceStream)
        {
            if (this.knownExternalReferences.TryGetValue(resourceName, out var resourcePath))
            {
                var assembly = Assembly.GetExecutingAssembly();

                resourceStream = assembly.GetManifestResourceStream(resourcePath);

                return true;
            }

            resourceStream = null;
            return false;
        }

        /// <summary>
        /// Load an embedded resource
        /// </summary>
        /// <param name="path">
        /// The path of the embedded resource
        /// </param>
        /// <returns>
        /// a string containing the contents of the embedded resource
        /// </returns>
        public string LoadEmbeddedResource(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(path);
            }

            var assembly = Assembly.GetExecutingAssembly();

            using var stream = assembly.GetManifestResourceStream(path);

            using var reader = new StreamReader(stream ?? throw new MissingManifestResourceException());

            return reader.ReadToEnd();
        }
    }
}
