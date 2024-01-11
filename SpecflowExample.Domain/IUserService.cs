namespace SpecflowExample.Domain;

public interface IUserService
{
    User Create(int id, string name);
    User? GetUser(int id);
}