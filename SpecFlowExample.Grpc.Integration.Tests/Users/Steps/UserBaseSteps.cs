using SpecFlowExample.Grpc.Integration.Tests.Users.Clients;
using TechTalk.SpecFlow;

namespace SpecFlowExample.Grpc.Integration.Tests.Users.Steps;

[Binding]
public class UserBaseSteps
{
    protected readonly ScenarioContext ScenarioContext;
    protected IUserClient UserClient => ScenarioContext.Get<IUserClient>();

    public UserBaseSteps(ScenarioContext scenarioContext)
    {
        ScenarioContext = scenarioContext;
    }
}