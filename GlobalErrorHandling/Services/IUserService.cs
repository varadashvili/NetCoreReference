
namespace GlobalErrorHandlingDemo.Services;

public interface IUserService
{
    public IEnumerable<User> GetUsers();

    public User GetUserById(int id);

    public bool InsertUser(User user);

    public bool DeleteUser(int id);
}
