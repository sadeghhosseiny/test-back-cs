using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersApi.Services;
using UsersApi.Data;
using UsersApi.Dtos;

namespace UsersApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IJwtService _jwtService;

    public AuthController(AppDbContext context, IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<object>> Login([FromBody] LoginRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Name == request.Name);

        if (user == null)
        {
            return Unauthorized(new { message = "نام کاربری نامعتبر است." });
        }

        var token = _jwtService.GenerateToken(user);

        return Ok(new 
        { 
            message = "ورود با موفقیت انجام شد.",
            token = token 
        });
    }
}
