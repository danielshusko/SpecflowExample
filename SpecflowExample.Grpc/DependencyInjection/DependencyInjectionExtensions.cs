using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SpecflowExample.Grpc.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class DependencyInjectionExtensions
{
   public static IServiceCollection AddGrpcServices(
        this IServiceCollection serviceCollection,
        params Type[] interceptorsTypes)
    {
        serviceCollection
            .AddGrpc()
            .AddJsonTranscoding();

        serviceCollection.AddGrpcReflection();
        serviceCollection.AddGrpcHealthChecks();

        return serviceCollection;
    }

    /// <summary>
    ///     Maps the Grpc services.
    /// </summary>
    /// <param name="webApplication">The web application.</param>
    public static WebApplication MapGrpcServices(this WebApplication webApplication)
    {
        webApplication.MapGrpcService<UserGrpcService>();
        webApplication.MapGrpcReflectionService();
        webApplication.MapGrpcHealthChecksService();

        return webApplication;
    }
}