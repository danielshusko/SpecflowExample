using SpecflowExample.Grpc.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpcServices();

var app = builder.Build();
app.MapGrpcServices();
app.Run();