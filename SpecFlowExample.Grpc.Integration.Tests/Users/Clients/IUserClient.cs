using SpecFlowExample.Grpc.Integration.Tests.Framework;

namespace SpecFlowExample.Grpc.Integration.Tests.Users.Clients
{
    public interface IUserClient
    {
        ServiceResponse<SpecflowExample.Domain.User> Create(int id, string name);
        ServiceResponse<SpecflowExample.Domain.User> GetUser(int id);
    }
}