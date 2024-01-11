using TechTalk.SpecFlow;

namespace SpecFlowExample.Grpc.Integration.Tests.Users.Steps;

[Binding]
public sealed class UserWhenSteps : UserBaseSteps
{
    public UserWhenSteps(ScenarioContext scenarioContext)
        : base(scenarioContext)
    {
    }

    [When(@"a user is requested for id '([^']*)'")]
    public void WhenAUserIsRequestedForId(int id)
    {
        UserClient.GetUser(id);
    }
}