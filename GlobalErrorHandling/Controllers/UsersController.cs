using Microsoft.AspNetCore.Mvc;

namespace GlobalErrorHandling.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IUserService _userService;

    public UsersController(ILogger<UsersController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    // GET: api/<UsersController>
    [HttpGet]
    public IEnumerable<User> Get()
    {
        return _userService.GetUsers();
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public User Get(int id)
    {
        var getUserResult = _userService.GetUserById(id);

        return getUserResult;
    }

    // POST api/<UsersController>
    [HttpPost]
    public bool Post([FromBody] User user)
    {
        var insertUserResult = _userService.InsertUser(user);

        return insertUserResult;
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    public bool Delete(int id)
    {
        var deleteUserResult = _userService.DeleteUser(id);

        return deleteUserResult;
    }
}