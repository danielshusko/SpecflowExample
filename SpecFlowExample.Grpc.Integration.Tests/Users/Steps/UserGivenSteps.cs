using FluentAssertions;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowExample.Grpc.Integration.Tests.Users.Steps;

[Binding]
public sealed class UserGivenSteps : UserBaseSteps
{
    public UserGivenSteps(ScenarioContext scenarioContext)
        : base(scenarioContext)
    {
    }

    [Given(@"a user exists with id '([^']*)' and name '([^']*)'")]
    public void GivenAUserExistsWithIdAndName(int id, string name)
    {
        var response = UserClient.Create(id, name);
        response.IsSuccessful.Should().BeTrue();
    }
}