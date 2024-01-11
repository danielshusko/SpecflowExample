using System;
using System.Linq;
using SpecFlowExample.Grpc.Integration.Tests.Users.Clients;
using TechTalk.SpecFlow;

namespace SpecFlowExample.Grpc.Integration.Tests.Framework
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public void FeatureSetup(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            var integrationTestServer = new IntegrationTestServer();
            if (featureContext.FeatureInfo.Tags.Contains("grpc", StringComparer.OrdinalIgnoreCase))
            {
                var userClient = new GrpcUserClient(integrationTestServer, scenarioContext);
                scenarioContext.Set<IUserClient>(userClient);
            }
            else
            {
                var userClient = new RestUserClient(integrationTestServer, scenarioContext);
                scenarioContext.Set<IUserClient>(userClient);
            }
        }
    }
}
