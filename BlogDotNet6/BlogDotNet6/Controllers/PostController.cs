using BlogDotNet6.Data;
using BlogDotNet6.Models;
using BlogDotNet6.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace BlogDotNet6.Controllers;

[ApiController]
public class PostController : ControllerBase
{
    [HttpGet("v1/posts")]
    public async Task<IActionResult> GetAsync(
        [FromServices] BlogDataContext context,
        [FromServices] IMemoryCache cache,
        int page = 0,
        int pageSize = 5
        )
    {
        var cacheKey = $"PostCache-{page}-{pageSize}";
        if (!cache.TryGetValue(cacheKey, out List<PostViewModel> posts))
        {
            posts = await context.Posts
                .AsNoTracking()
                .Include(x => x.Author)
                .Include(x => x.Category)
                .OrderByDescending(x => x.LastUpdateDate)
                .Select(x => new PostViewModel
                {
                    Title = x.Title,
                    Slug = x.Slug,
                    Author = x.Author.Name,
                    Category = x.Category.Name
                })
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(5)); // Cache for 5 minutes

            cache.Set(cacheKey, posts, cacheEntryOptions);
        }

        var count = await context.Posts.CountAsync();
        return Ok(new { posts, count });
    }
    
    [HttpGet("v1/posts/{id}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromServices] BlogDataContext context,
        [FromRoute] int id
        )
    {
        var post = await context.Posts
            .AsNoTracking()
            .Include(x => x.Author)
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (post == null)
            return NotFound(new ResultViewModel<dynamic>("Post not found"));

        return Ok(new ResultViewModel<PostViewModel>(new PostViewModel
        {
            Title = post.Title,
            Slug = post.Slug,
            Author = post.Author.Name,
            Category = post.Category.Name
        }));
    }
    
    [HttpGet("v1/posts/category/{category}")]
    public async Task<IActionResult> GetByCategoryAsync(
        [FromServices] BlogDataContext context,
        [FromRoute] string category,
        int page = 0,
        int pageSize = 5
        )
    {
        var count = await context.Posts.CountAsync(x => x.Category.Slug == category);
        var posts =  await context.Posts
            .AsNoTracking()
            .Include(x => x.Author)
            .Include(x => x.Category)
            .Where(x => x.Category.Slug == category)
            .OrderByDescending(x => x.LastUpdateDate)
            .Select(x => new PostViewModel
            {
                Title = x.Title,
                Slug = x.Slug,
                Author = x.Author.Name,
                Category = x.Category.Name
            })
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return Ok(new ResultViewModel<dynamic>(new
        {
            count,
            posts,
            page,
        }));
    }
}