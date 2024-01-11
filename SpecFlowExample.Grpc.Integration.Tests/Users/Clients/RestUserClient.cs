using System;
using RestSharp;
using SpecFlowExample.Grpc.Integration.Tests.Framework;
using TechTalk.SpecFlow;
using User.Grpc.proto;

namespace SpecFlowExample.Grpc.Integration.Tests.Users.Clients;

public class RestUserClient : IUserClient
{
    private readonly ScenarioContext _scenarioContext;
    private readonly RestClient _client;
    public RestUserClient(IntegrationTestServer testServer, ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _client = new RestClient(testServer.HttpClient);
    }

    public ServiceResponse<SpecflowExample.Domain.User> Create(int id, string name)
    {
        //TODO:
        throw new NotImplementedException();
    }

    public ServiceResponse<SpecflowExample.Domain.User> GetUser(int id)
    {
        var request = new RestRequest($"/api/users/{id}");
        return ExecuteRequest<UserMessage, SpecflowExample.Domain.User>(request, x => new SpecflowExample.Domain.User(x.Id, x.Name));
    }

    public ServiceResponse<TOut> ExecuteRequest<TResponse, TOut>(RestRequest request, Func<TResponse, TOut> mapFunc)
    {
        var restResponse = _client.Execute<TResponse>(request);

        var serviceResponse = restResponse.IsSuccessful
            ? new ServiceResponse<TOut>(
                (int)restResponse.StatusCode,
                mapFunc(restResponse.Data!)
            )
            : new ServiceResponse<TOut>((int)restResponse.StatusCode, new Exception());

        _scenarioContext.Set(serviceResponse);
        _scenarioContext.Set((ServiceResponse)serviceResponse);
        return serviceResponse;
    }
}