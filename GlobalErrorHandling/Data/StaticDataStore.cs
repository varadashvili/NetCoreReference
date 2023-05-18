namespace GlobalErrorHandlingDemo.Data;

internal static class StaticDataStore
{
    private static List<User> users { get; set; } = new List<User>
    {
        new User(){ Id=1, FirstName="John", LastName="Balck" },
        new User(){ Id=2, FirstName="Anna", LastName="Green" },
        new User(){ Id=3, FirstName="Mike", LastName="Gray" },
        new User(){ Id=4, FirstName="Lionel", LastName="Messi" }
    };

    public static List<User> GetUsers()
    {
        return users;
    }
}
