using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersApi.Data;
using UsersApi.Dtos;
using UsersApi.Models;
using UsersApi.Services;

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

    [AllowAnonymous] // ثبت‌نام نیازی به توکن ندارد
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        // بررسی عدم وجود شماره همراه یا نام تکراری
        var existingUser = await _context.Users
            .AnyAsync(u => u.PhoneNumber == request.PhoneNumber);

        if (existingUser)
        {
            return BadRequest(new { message = "کاربری با این شماره همراه قبلاً ثبت‌نام کرده است." });
        }

        // ساخت کاربر جدید
        var newUser = new User
        {
            Name = request.Name,
            PhoneNumber = request.PhoneNumber,
            Role = Role.User
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        // تولید توکن جهت ورود بلافاصله‌ی کاربر پس از ثبت‌نام
        var token = _jwtService.GenerateToken(newUser);

        return Ok(new
        {
            message = "ثبت‌نام با موفقیت انجام شد.",
            token = token,
            user = new { newUser.Id, newUser.Name, newUser.PhoneNumber, newUser.Role }
        });
    }

    [AllowAnonymous] // ورود هم نیازی به توکن ندارد
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Name == request.Name);

        if (user == null)
        {
            return Unauthorized(new { message = "نام کاربری یافت نشد." });
        }

        var token = _jwtService.GenerateToken(user);

        return Ok(new
        {
            message = "ورود با موفقیت انجام شد.",
            token = token
        });
    }
}