using FluentAssertions;
using SpecFlowExample.Grpc.Integration.Tests.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowExample.Grpc.Integration.Tests.Users.Steps;

[Binding]
public sealed class UserThenSteps : UserBaseSteps
{
    public UserThenSteps(ScenarioContext scenarioContext)
        : base(scenarioContext)
    {
    }

    [Then(@"the users name is ""([^""]*)""")]
    public void ThenTheUsersNameIs(string name)
    {
        var response = ScenarioContext.Get<ServiceResponse<SpecflowExample.Domain.User>>();
        response.Data.Name.Should().Be(name);
    }
}