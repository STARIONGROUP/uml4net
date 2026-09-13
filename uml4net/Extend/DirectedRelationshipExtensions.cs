// -------------------------------------------------------------------------------------------------
// <copyright file="DirectedRelationshipExtensions.cs" company="Starion Group S.A.">
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

namespace uml4net.CommonStructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using uml4net.Classification;
    using uml4net.Deployments;
    using uml4net.InformationFlows;
    using uml4net.Packages;
    using uml4net.SimpleClassifiers;
    using uml4net.StateMachines;
    using uml4net.StructuredClassifiers;
    using uml4net.UseCases;

    /// <summary>
    /// The <see cref="DirectedRelationshipExtensions"/> class provides extensions methods for <see cref="IDirectedRelationship"/>
    /// </summary>
    internal static class DirectedRelationshipExtensions
    {
        /// <summary>
        /// Queries the target Element(s) of the DirectedRelationship.
        /// </summary>
        /// <param name="directedRelationship">
        /// The subject <see cref="IDirectedRelationship"/>
        /// </param>
        /// <returns>
        /// the target Element(s) of the DirectedRelationship.
        /// </returns>
        /// <remarks>
        /// <c>DirectedRelationship::target</c> is a derived union without OCL body: its value is the union of the
        /// properties that subset it (per the <c>[SubsettedProperty]</c> metadata of the generated interfaces):
        /// <see cref="IGeneralization.General"/>, <see cref="IDependency.Supplier"/>, <see cref="IElementImport.ImportedElement"/>,
        /// <see cref="IPackageImport.ImportedPackage"/>, <see cref="IPackageMerge.MergedPackage"/>,
        /// <see cref="IProfileApplication.AppliedProfile"/>, <see cref="IProtocolConformance.GeneralMachine"/>,
        /// <see cref="ITemplateBinding.Signature"/>, <see cref="IInformationFlow.InformationTarget"/>,
        /// <see cref="IExtend.ExtendedCase"/> and <see cref="IInclude.Addition"/>. The specializations of
        /// <see cref="IDependency"/> hold properties that subset <c>Dependency::supplier</c> in their own lists, which are
        /// added as well: <see cref="IComponentRealization.Abstraction"/>, <see cref="IInterfaceRealization.Contract"/>,
        /// <see cref="ISubstitution.Contract"/>, <see cref="IDeployment.DeployedArtifact"/> and
        /// <see cref="IManifestation.UtilizedElement"/>. <see cref="IComponentRealization.Abstraction"/> subsets
        /// <c>Element::owner</c> and is not serialized in XMI; when it is null the <see cref="IElement.Owner"/> is used
        /// instead. Unset values are skipped and duplicates are removed.
        /// </remarks>
        internal static List<IElement> QueryTarget(this IDirectedRelationship directedRelationship)
        {
            if (directedRelationship == null)
            {
                throw new ArgumentNullException(nameof(directedRelationship));
            }

            var target = new List<IElement>();

            if (directedRelationship is IGeneralization generalization)
            {
                target.Add(generalization.General);
            }

            if (directedRelationship is IDependency dependency)
            {
                target.AddRange(dependency.Supplier);

                if (dependency is IComponentRealization componentRealization)
                {
                    target.Add(componentRealization.Abstraction ?? componentRealization.Owner as IComponent);
                }

                if (dependency is IInterfaceRealization interfaceRealization)
                {
                    target.Add(interfaceRealization.Contract);
                }

                if (dependency is ISubstitution substitution)
                {
                    target.Add(substitution.Contract);
                }

                if (dependency is IDeployment deployment)
                {
                    target.AddRange(deployment.DeployedArtifact);
                }

                if (dependency is IManifestation manifestation)
                {
                    target.Add(manifestation.UtilizedElement);
                }
            }

            if (directedRelationship is IElementImport elementImport)
            {
                target.Add(elementImport.ImportedElement);
            }

            if (directedRelationship is IPackageImport packageImport)
            {
                target.Add(packageImport.ImportedPackage);
            }

            if (directedRelationship is IPackageMerge packageMerge)
            {
                target.Add(packageMerge.MergedPackage);
            }

            if (directedRelationship is IProfileApplication profileApplication)
            {
                target.Add(profileApplication.AppliedProfile);
            }

            if (directedRelationship is IProtocolConformance protocolConformance)
            {
                target.Add(protocolConformance.GeneralMachine);
            }

            if (directedRelationship is ITemplateBinding templateBinding)
            {
                target.Add(templateBinding.Signature);
            }

            if (directedRelationship is IInformationFlow informationFlow)
            {
                target.AddRange(informationFlow.InformationTarget);
            }

            if (directedRelationship is IExtend extend)
            {
                target.Add(extend.ExtendedCase);
            }

            if (directedRelationship is IInclude include)
            {
                target.Add(include.Addition);
            }

            return target.Where(element => element != null).Distinct().ToList();
        }

        /// <summary>
        /// Queries the source Element(s) of the DirectedRelationship.
        /// </summary>
        /// <param name="directedRelationship">
        /// The subject <see cref="IDirectedRelationship"/>
        /// </param>
        /// <returns>
        /// the source Element(s) of the DirectedRelationship.
        /// </returns>
        /// <remarks>
        /// <c>DirectedRelationship::source</c> is a derived union without OCL body: its value is the union of the
        /// properties that subset it (per the <c>[SubsettedProperty]</c> metadata of the generated interfaces):
        /// <see cref="IGeneralization.Specific"/>, <see cref="IDependency.Client"/>, <see cref="IElementImport.ImportingNamespace"/>,
        /// <see cref="IPackageImport.ImportingNamespace"/>, <see cref="IPackageMerge.ReceivingPackage"/>,
        /// <see cref="IProfileApplication.ApplyingPackage"/>, <see cref="IProtocolConformance.SpecificMachine"/>,
        /// <see cref="ITemplateBinding.BoundElement"/>, <see cref="IInformationFlow.InformationSource"/>,
        /// <see cref="IExtend.Extension"/> and <see cref="IInclude.IncludingCase"/>. The specializations of
        /// <see cref="IDependency"/> hold properties that subset <c>Dependency::client</c> in their own lists, which are
        /// added as well: <see cref="IComponentRealization.RealizingClassifier"/>,
        /// <see cref="IInterfaceRealization.ImplementingClassifier"/>, <see cref="ISubstitution.SubstitutingClassifier"/>
        /// and <see cref="IDeployment.Location"/>. The ends that subset <c>Element::owner</c> (or
        /// <c>NamedElement::namespace</c>) are not serialized in XMI and are left null by the reader; for those the
        /// <see cref="IElement.Owner"/> is used instead. Unset values are skipped and duplicates are removed.
        /// </remarks>
        internal static List<IElement> QuerySource(this IDirectedRelationship directedRelationship)
        {
            if (directedRelationship == null)
            {
                throw new ArgumentNullException(nameof(directedRelationship));
            }

            var source = new List<IElement>();

            // Most source ends subset Element::owner (or NamedElement::namespace) and are not serialized in XMI:
            // the reader leaves them null, so the owner is used when the end itself is not set.
            if (directedRelationship is IGeneralization generalization)
            {
                source.Add(generalization.Specific ?? generalization.Owner as IClassifier);
            }

            if (directedRelationship is IDependency dependency)
            {
                source.AddRange(dependency.Client);

                if (dependency is IComponentRealization componentRealization)
                {
                    source.AddRange(componentRealization.RealizingClassifier);
                }

                if (dependency is IInterfaceRealization interfaceRealization)
                {
                    source.Add(interfaceRealization.ImplementingClassifier ?? interfaceRealization.Owner as IBehavioredClassifier);
                }

                if (dependency is ISubstitution substitution)
                {
                    source.Add(substitution.SubstitutingClassifier ?? substitution.Owner as IClassifier);
                }

                if (dependency is IDeployment deployment)
                {
                    source.Add(deployment.Location ?? deployment.Owner as IDeploymentTarget);
                }
            }

            if (directedRelationship is IElementImport elementImport)
            {
                source.Add(elementImport.ImportingNamespace ?? elementImport.Owner as INamespace);
            }

            if (directedRelationship is IPackageImport packageImport)
            {
                source.Add(packageImport.ImportingNamespace ?? packageImport.Owner as INamespace);
            }

            if (directedRelationship is IPackageMerge packageMerge)
            {
                source.Add(packageMerge.ReceivingPackage ?? packageMerge.Owner as IPackage);
            }

            if (directedRelationship is IProfileApplication profileApplication)
            {
                source.Add(profileApplication.ApplyingPackage ?? profileApplication.Owner as IPackage);
            }

            if (directedRelationship is IProtocolConformance protocolConformance)
            {
                source.Add(protocolConformance.SpecificMachine ?? protocolConformance.Owner as IProtocolStateMachine);
            }

            if (directedRelationship is ITemplateBinding templateBinding)
            {
                source.Add(templateBinding.BoundElement ?? templateBinding.Owner as ITemplateableElement);
            }

            if (directedRelationship is IInformationFlow informationFlow)
            {
                source.AddRange(informationFlow.InformationSource);
            }

            if (directedRelationship is IExtend extend)
            {
                source.Add(extend.Extension ?? extend.Owner as IUseCase);
            }

            if (directedRelationship is IInclude include)
            {
                source.Add(include.IncludingCase ?? include.Owner as IUseCase);
            }

            return source.Where(element => element != null).Distinct().ToList();
        }
    }
}
