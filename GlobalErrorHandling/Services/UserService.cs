using GlobalErrorHandling.Common.Errors;

namespace GlobalErrorHandling.Services;

public class UserService : IUserService
{
    public bool DeleteUser(int id)
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
            throw new UserNotFoundException();
        }

        return true;
    }

    public User GetUserById(int id)
    {
        var users = StaticDataStore.GetUsers();

        var user = users
            .SingleOrDefault(x => x.Id == id);

        if (user == null)
        {
            throw new UserNotFoundException();
        }

        return user;
    }

    public IEnumerable<User> GetUsers()
    {
        return StaticDataStore.GetUsers();
    }

    public bool InsertUser(User user)
    {
        if (user == null)
        {
            throw new InvalidInputException();
        }

        var users = StaticDataStore.GetUsers();

        if (users.Any(x => x.Id == user.Id))
        {
            throw new UserAlreadyExistsException();
        }

        users.Add(user);

        return true;
    }
}
