namespace GlobalErrorHandling.Services;

public class UserService : IUserService
{
    public void DeleteUser(int id)
    {
        var users = StaticDataStore.GetUsers();

        var user = users
            .SingleOrDefault(x => x.Id == id);

        if (user != null)
        {
            users.Remove(user);
        }
        else
        {
            throw new Exception("User not found");
        }
    }

    public User GetUserById(int id)
    {
        var users = StaticDataStore.GetUsers();

        var user = users
            .SingleOrDefault(x => x.Id == id);

        return user;
    }

    public IEnumerable<User> GetUsers()
    {
        return StaticDataStore.GetUsers();
    }

    public void InsertUser(User user)
    {
        if (user == null)
        {
            throw new Exception("User is null");
        }

        var users = StaticDataStore.GetUsers();

        if (users.Any(x => x.Id == user.Id))
        {
            throw new Exception("User already exists");
        }

        users.Add(user);
    }
}
