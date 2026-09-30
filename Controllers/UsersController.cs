using Microsoft.AspNetCore.Mvc;
using UsersApi.Dtos;
using UsersApi.Models;
using UsersApi.Services;

namespace UsersApi.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAll()
    {
        return await _userService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Create(CreateUserRequest request)
    {
        var user = await _userService.CreateAsync(request.Name, request.Role!.Value);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<User>> Update(int id, UpdateUserRequest request)
    {
        var user = await _userService.UpdateAsync(id, request.Name, request.Role);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _userService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}