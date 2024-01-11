using System.Net;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace SpecFlowExample.Grpc.Integration.Tests.Framework;

[Binding]
public sealed class CommonRestThenSteps
{
    private readonly ScenarioContext _scenarioContext;

    public CommonRestThenSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Then(@"a Rest response is returned with code ""([^""]*)""")]
    public void ThenARestResponseIsReturnedWithCode(HttpStatusCode statusCode)
    {
        var response = _scenarioContext.Get<ServiceResponse>();
        response.StatusCode.Should().Be((int)statusCode);
    }
}