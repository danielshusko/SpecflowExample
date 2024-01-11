using FluentAssertions;
using Grpc.Core;
using OpenTelemetry.Trace;
using TechTalk.SpecFlow;

namespace SpecFlowExample.Grpc.Integration.Tests.Framework;

[Binding]
public sealed class CommonGrpcThenSteps
{
    private readonly ScenarioContext _scenarioContext;
    public CommonGrpcThenSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Then(@"a Grpc response is returned with code '([^']*)'")]
    public void ThenAGrpcResponseIsReturnedWithCode(StatusCode statusCode)
    {
        var response = _scenarioContext.Get<ServiceResponse>();
        response.StatusCode.Should().Be((int)statusCode);
    }
}