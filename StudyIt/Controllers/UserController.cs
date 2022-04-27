using Microsoft.AspNetCore.Mvc;
using StudyIt.MongoDB.Models;
using StudyIt.MongoDB.Services;

namespace StudyIt.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService) =>
        _userService = userService;

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> PostUser(User newUser)
    {
        await _userService.CreateUser(newUser);
        
        Console.WriteLine(newUser);

        return CreatedAtAction(nameof(GetUser), new { email = newUser.email }, newUser);
    }

    [HttpGet]
    public async Task<ActionResult<User>> GetUser(string email)
    {
        var user = await _userService.GetUser(email);
        
        Console.WriteLine(user);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }
}