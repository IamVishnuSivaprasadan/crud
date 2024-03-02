using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private static List<User> _users = new List<User>();

    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        user.Id = _users.Count + 1;
        _users.Add(user);
        return Ok(user);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return NotFound();

        _users.Remove(user);
        return NoContent();
    }

    [HttpGet]
    public IActionResult ListUsers()
    {
        return Ok(_users);
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
