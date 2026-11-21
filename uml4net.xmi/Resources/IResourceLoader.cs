// -------------------------------------------------------------------------------------------------
// <copyright file="IResourceLoader.cs" company="Starion Group S.A.">
//
//   SPDX-FileCopyrightText: 2019-2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.xmi.Resources
{
    using System.IO;

    /// <summary>
    /// The <see cref="IResourceLoader"/> isresponsible for loading embedded resources.
    /// </summary>
    public interface IResourceLoader
    {
        /// <summary>
        /// Tries to load a know resource by its name and returns it as a <see cref="Stream"/>
        /// </summary>
        /// <param name="resourceName">
        /// the name of the know resource
        /// </param>
        /// <param name="resourceStream">
        /// The resulting <see cref="Stream"/> that contains the content of the know resource
        /// </param>
        /// <returns>
        /// true if the know resource could be loaded, false if not
        /// </returns>
        bool TryLoadKnownResource(string resourceName, out Stream resourceStream);

        /// <summary>
        /// Load an embedded resource
        /// </summary>
        /// <param name="path">
        /// The path of the embedded resource
        /// </param>
        /// <returns>
        /// a string containing the contents of the embedded resource
        /// </returns>
        string LoadEmbeddedResource(string path);
    }
}
