// -------------------------------------------------------------------------------------------------
// <copyright file="Generator.cs" company="Starion Group S.A.">
//
//   Copyright 2019-2024 Starion Group S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, softwareUseCases
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace uml4net.CodeGenerator.Generators
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Formatting;

    /// <summary>
    /// Abstract class from which all generators derive
    /// </summary>
    public abstract class Generator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Generator"/> class.
        /// </summary>
        protected Generator()
        {
            var assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            this.TemplateFolderPath = Path.Combine(assemblyFolder, "Templates");
        }

        /// <summary>
        /// Gets the path where the template are stored
        /// </summary>
        public string TemplateFolderPath { get; private set; }

        /// <summary>
        /// perform code cleanup
        /// </summary>
        /// <param name="generatedCode">
        /// The generated code that needs to be cleaned
        /// </param>
        /// <returns>
        /// cleaned up code
        /// </returns>
        protected virtual string CodeCleanup(string generatedCode)
        {
            if (string.IsNullOrEmpty(generatedCode))
            {
                throw new ArgumentNullException($"{nameof(generatedCode)} may not be null or empty");
            }

            generatedCode = generatedCode.Replace("&nbsp;", " ");
            var workspace = new AdhocWorkspace();
            var syntaxTree = CSharpSyntaxTree.ParseText(generatedCode);
            var root = syntaxTree.GetRoot();
            var formattedSyntaxNode = Formatter.Format(root, workspace);
            generatedCode = formattedSyntaxNode.SyntaxTree.GetText().ToString();

            return generatedCode;
        }

        /// <summary>
        /// Writes the generated code to disk
        /// </summary>
        /// <param name="generatedCode">
        /// he generated code that needs to be written to disk
        /// </param>
        /// <param name="outputDirectory">
        /// The target <see cref="DirectoryInfo"/>
        /// </param>
        /// <param name="fileName">
        /// The name of the file
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        protected static async Task WriteAsync(string generatedCode, DirectoryInfo outputDirectory, string fileName)
        {
            if (string.IsNullOrEmpty(generatedCode))
            {
                throw new ArgumentNullException($"{nameof(generatedCode)} may not be null or empty");
            }

            if (outputDirectory == null)
            {
                throw new ArgumentNullException($"{nameof(outputDirectory)} may not be null");
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException($"{nameof(fileName)} may not be null or empty");
            }

            var filePath = Path.Combine(outputDirectory.FullName, fileName);

            await File.WriteAllTextAsync(filePath, generatedCode, Encoding.UTF8);
        }
    }
}
