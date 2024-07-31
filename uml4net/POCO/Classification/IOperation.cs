// -------------------------------------------------------------------------------------------------
// <copyright file="IOperation.cs" company="Starion Group S.A.">
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

namespace uml4net.POCO.Classification
{
    using uml4net.POCO.CommonStructure;

    /// <summary>
    /// An Operation is a BehavioralFeature of a Classifier that specifies the name, type, parameters, 
    /// and constraints for invoking an associated Behavior. An Operation may invoke both the execution of 
    /// method behaviors as well as other behavioral responses. Operation specializes TemplateableElement in 
    /// order to support specification of template operations and bound operations. Operation specializes 
    /// ParameterableElement to specify that an operation can be exposed as a formal template parameter, 
    /// and provided as an actual parameter in a binding of a template.
    /// </summary>
    public interface IOperation : ITemplateableElement, IParameterableElement, IBehavioralFeature
    {
    }
}
