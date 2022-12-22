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
        return _userService.GetUserById(id);
    }

    // POST api/<UsersController>
    [HttpPost]
    public void Post([FromBody] User user)
    {
        _userService.InsertUser(user);
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _userService.DeleteUser(id);
    }
}
