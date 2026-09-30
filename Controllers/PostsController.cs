using Microsoft.AspNetCore.Mvc;
using UsersApi.Dtos;
using UsersApi.Models;
using UsersApi.Services;

namespace UsersApi.Controllers;

[ApiController]
[Route("posts")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> Create(CreatePostRequest request)
    {
        var post = await _postService.CreateAsync(request.Title, request.Content, request.UserId!.Value);

        if (post is null)
        {
            return NotFound(new { message = "User not found" });
        }

        return Created($"/posts/{post.Id}", post);
    }
}