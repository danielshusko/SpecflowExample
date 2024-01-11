using System;
using System.Net.Http;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using TechTalk.SpecFlow;

namespace SpecFlowExample.Grpc.Integration.Tests.Framework
{
    [Binding]
    public class IntegrationTestServer : IDisposable
    {
        public GrpcChannel Channel { get; }
        public HttpClient HttpClient { get; }

        public IntegrationTestServer()
        {
            var factory = new IntegrationTestWebApplicationFactory<Program>();
            var options = new GrpcChannelOptions { HttpHandler = factory.Server.CreateHandler() };
            Channel = GrpcChannel.ForAddress(factory.Server.BaseAddress, options);
            HttpClient = factory.Server.CreateClient();
        }

        public void Dispose()
        {
            Channel.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    public class IntegrationTestWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {
        public IntegrationTestWebApplicationFactory()
        {
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Development");
        }
    }
}
