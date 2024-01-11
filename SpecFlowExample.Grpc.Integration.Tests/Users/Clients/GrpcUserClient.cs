using System;
using Grpc.Core;
using SpecFlowExample.Grpc.Integration.Tests.Framework;
using TechTalk.SpecFlow;
using User.Grpc.proto;

namespace SpecFlowExample.Grpc.Integration.Tests.Users.Clients;

public class GrpcUserClient : IUserClient
{
    private readonly ScenarioContext _scenarioContext;
    private readonly User.Grpc.proto.Users.UsersClient _client;

    public GrpcUserClient(IntegrationTestServer testServer, ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _client = new(testServer.Channel);
    }

    public ServiceResponse<SpecflowExample.Domain.User> Create(int id, string name)
    {
        var createMethod = _client.CreateUserAsync(new UserMessage
        {
            Id = id,
            Name = name
        });

        return ExecuteCall(createMethod, x => new SpecflowExample.Domain.User(x.Id, x.Name));
    }

    public ServiceResponse<SpecflowExample.Domain.User> GetUser(int id)
    {
        var getMethod = _client.GetUserAsync(new IdMessage { Id = id });
        return ExecuteCall(getMethod, x => new SpecflowExample.Domain.User(x.Id, x.Name));
    }

    protected ServiceResponse<TOut> ExecuteCall<TResponse, TOut>(AsyncUnaryCall<TResponse> call, Func<TResponse, TOut> mapFunc)
    {
        ServiceResponse<TOut> response;
        try
        {
            var result = call.ResponseAsync.Result;
            response = new ServiceResponse<TOut>((int)call.GetStatus().StatusCode, mapFunc(result));
        }
        catch (Exception ex)
        {
            response = new ServiceResponse<TOut>((int)call.GetStatus().StatusCode, ex);
        }

        _scenarioContext.Set(response);
        _scenarioContext.Set((ServiceResponse)response);

        return response;
    }
}