namespace GlobalErrorHandling.Services;

public interface IUserService
{
    public IEnumerable<User> GetUsers();

    public User GetUserById(int id);

    public void InsertUser(User user);

    public void DeleteUser(int id);
}
