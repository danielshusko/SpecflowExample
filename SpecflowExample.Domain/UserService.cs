namespace SpecflowExample.Domain;

public class UserService : IUserService
{
    private readonly Dictionary<int, User> _users = new();

    public User Create(int id, string name)
    {
        var user = new User(id, name);
        _users[id] = user;
        return user;
    }

    public User? GetUser(int id)
    {
        return _users.TryGetValue(id, out var user) ? user : null;
    }
}