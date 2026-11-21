// -------------------------------------------------------------------------------------------------
// <copyright file="ResourceLoader.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.Tools.Resources
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Resources;
    
    /// <summary>
    /// Class responsible for loading embedded resources.
    /// </summary>
    public static class ResourceLoader
    {
        /// <summary>
        /// Load an embedded resource
        /// </summary>
        /// <param name="path">
        /// The path of the embedded resource
        /// </param>
        /// <returns>
        /// a string containing the contents of the embedded resource
        /// </returns>
        public static string LoadEmbeddedResource(string path)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(path);

            var assembly = Assembly.GetExecutingAssembly();

            using var stream = assembly.GetManifestResourceStream(path);

            using var reader = new StreamReader(stream ?? throw new MissingManifestResourceException());

            return reader.ReadToEnd();
        }

        /// <summary>
        /// queries the version number from the executing assembly
        /// </summary>
        /// <returns>
        /// a string representation of the version of the application
        /// </returns>
        public static string QueryVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetName().Version?.ToString();
        }

        /// <summary>
        /// Queries the logo with version info from the embedded resources
        /// </summary>
        /// <returns>
        /// the logo
        /// </returns>
        public static string QueryLogo()
        {
            var version = QueryVersion();

            var logo = LoadEmbeddedResource("uml4net.Tools.Resources.ascii-art.txt")
                .Replace("uml4netToolsVersion", version);

            return logo;
        }
    }
}
