using Grpc.Core;
using SpecflowExample.Domain;
using User.Grpc.proto;

namespace SpecflowExample.Grpc
{
    public class UserGrpcService : Users.UsersBase
    {
        private readonly IUserService _userService;

        public UserGrpcService(IUserService userService)
        {
            _userService = userService;
        }

        public override Task<UserMessage> CreateUser(UserMessage request, ServerCallContext context)
        {
            var user = _userService.Create(request.Id, request.Name);
            return Task.FromResult(new UserMessage
            {
                Id = user.Id,
                Name = user.Name
            });
        }

        public override Task<UserMessage> GetUser(IdMessage request, ServerCallContext context)
        {
            var user = _userService.GetUser(request.Id);
            return user == null
                ? throw new RpcException(new Status(StatusCode.NotFound, "Not Found"))
                : Task.FromResult(new UserMessage
                {
                    Id = request.Id,
                    Name = Guid.NewGuid().ToString()
                });
        }
    }
}
