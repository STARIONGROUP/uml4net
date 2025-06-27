// -------------------------------------------------------------------------------------------------
//  <copyright file="ExtendedPropertyExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.xmi.Extensions.EnterpriseArchitect.Extensions
{
    using System.Linq;

    using uml4net.Classification;
    using uml4net.xmi.Extensions.EntrepriseArchitect.Structure;

    /// <summary>
    /// Extensions methods for <see cref="IProperty" />
    /// </summary>
    public static class ExtendedPropertyExtensions
    {
        /// <summary>
        /// Pattern that represent the exported value of the isID attribute from Enterprise Architect
        /// </summary>
        private const string IsIdPattern = "$TYP=attribute property$TYP;$VIS=Public$VIS;$PAR=0$PAR;$DES=@PROP=@NAME=isID@ENDNAME;@TYPE=Boolean@ENDTYPE;@VALU=1@ENDVALU;@PRMT=@ENDPRMT;@ENDPROP;";
        
        /// <summary>
        /// Asserts that a <see cref="IProperty"/> have the <see cref="IProperty.IsID"/> value
        /// </summary>
        /// <param name="property">The <see cref="IProperty"/></param>
        /// <returns>True if the <see cref="IProperty.IsID"/> is set or if the xrefs of a linked extension contains the <see cref="IsIdPattern"/></returns>
        public static bool QueryIsId(this IProperty property)
        {
            return property.IsID ||  property.Extensions.OfType<IAttribute>()
                .SelectMany(x => x.Xrefs)
                .Any(x => !string.IsNullOrEmpty(x.Value) && x.Value.Contains(IsIdPattern));
        }
    }
}
