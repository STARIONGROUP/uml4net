// -------------------------------------------------------------------------------------------------
// <copyright file="DeploymentTargetExtensionsTestFixture.cs" company="Starion Group S.A.">
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

namespace uml4net.Tests.Extend
{
    using NUnit.Framework;

    using uml4net.Classification;
    using uml4net.CommonStructure;
    using uml4net.Deployments;
    using uml4net.StructuredClassifiers;

    [TestFixture]
    public class DeploymentTargetExtensionsTestFixture
    {
        [Test]
        public void Verify_that_when_deploymentTarget_is_null_argument_exception_is_thrown()
        {
            Node deploymentTarget = null;

            Assert.That(() => DeploymentTargetExtensions.QueryDeployedElement(deploymentTarget), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_DeployedElement_is_empty_when_there_are_no_deployments()
        {
            var node = new Node { Name = "Node" };

            Assert.That(node.DeployedElement, Is.Empty);
        }

        [Test]
        public void Verify_that_DeployedElement_ignores_deployedArtifacts_that_are_not_Artifacts()
        {
            var node = new Node { Name = "Node" };

            var deployment = new Deployment();
            deployment.DeployedArtifact.Add(new InstanceSpecification { Name = "NotAnArtifact" });

            node.Deployment.Add(deployment);

            Assert.That(node.DeployedElement, Is.Empty);
        }

        [Test]
        public void Verify_that_DeployedElement_returns_the_utilizedElements_of_the_deployed_Artifacts_manifestations()
        {
            var node = new Node { Name = "Node" };

            var utilizedElement1 = new Class { Name = "Component1" };
            var utilizedElement2 = new Class { Name = "Component2" };

            var artifact = new Artifact { Name = "Artifact" };
            artifact.Manifestation.Add(new Manifestation { UtilizedElement = utilizedElement1 });
            artifact.Manifestation.Add(new Manifestation { UtilizedElement = utilizedElement2 });

            var deployment = new Deployment();
            deployment.DeployedArtifact.Add(artifact);

            node.Deployment.Add(deployment);

            Assert.That(node.DeployedElement, Is.EquivalentTo(new IPackageableElement[] { utilizedElement1, utilizedElement2 }));
        }

        [Test]
        public void Verify_that_DeployedElement_is_deduplicated_across_deployments()
        {
            var node = new Node { Name = "Node" };

            var utilizedElement = new Class { Name = "Component" };

            var artifact1 = new Artifact { Name = "Artifact1" };
            artifact1.Manifestation.Add(new Manifestation { UtilizedElement = utilizedElement });

            var artifact2 = new Artifact { Name = "Artifact2" };
            artifact2.Manifestation.Add(new Manifestation { UtilizedElement = utilizedElement });

            var deployment1 = new Deployment();
            deployment1.DeployedArtifact.Add(artifact1);

            var deployment2 = new Deployment();
            deployment2.DeployedArtifact.Add(artifact2);

            node.Deployment.Add(deployment1);
            node.Deployment.Add(deployment2);

            Assert.That(node.DeployedElement, Is.EquivalentTo(new[] { utilizedElement }));
        }
    }
}
