using BlogDotNet6.Data;
using BlogDotNet6.Models;
using BlogDotNet6.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogDotNet6.Controllers
{
    [ApiController]
    
    public class CategoryController : ControllerBase
    {
        [HttpGet("v1/categories")]
        public async Task<IActionResult> GetAsync(
          [FromServices]BlogDataContext context  )
        {
            var categories = await context.Categories.ToListAsync();
            return Ok(categories);
            
        }


        [HttpGet("v1/categories/{id}")]
        
        public async Task<IActionResult> GetByIdAsync(
            [FromServices]BlogDataContext context,
            [FromRoute]int id
            )
        {
            try
            {
                var category = await context.Categories.FindAsync(id);
                if (category == null)
                    return NotFound(new ResultViewModel<Category>("01 - The category couldn't be found" ));
                return Ok(new ResultViewModel<Category>(category));
            }
            catch (Exception)
            {
                return BadRequest(new ResultViewModel<Category>("01 - The category couldn't be found"));
            }
        }
        
        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync(
            [FromServices]BlogDataContext context,
            [FromBody] EditorCategoryViewModel model
            )
        {
            try
            {
                var category = new Category
                {
                    Name = model.Name,
                    Slug = model.Name.ToLower().Replace(" ", "-")
                };

                context.Categories.Add(category);
                await context.SaveChangesAsync();
                return Created($"v1/categories/{category.Id}", category);
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ResultViewModel<Category>("01 - The category couldn't be saved"));
            }
        }
        
        [HttpPut("v1/categories/{id}")]
        
        public async Task<IActionResult> PutAsync(
            [FromServices]BlogDataContext context,
            [FromBody]EditorCategoryViewModel model,
            [FromRoute]int id
            )
        {
            var category = await context.Categories.FindAsync(id);
            if(category == null)
                return NotFound();
            
            category.Name = model.Name;
            category.Slug = model.Slug;
            context.Categories.Update(category);
            
            await context.SaveChangesAsync();
            
            return Ok( new ResultViewModel<Category>(category));
            
        }
        
        [HttpDelete("v1/categories/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices]BlogDataContext context,
            [FromRoute]int id
            )
        {
            var category = await context.Categories.FindAsync(id);
            if(category == null)
                return NotFound();
            
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}

