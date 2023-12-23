using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Model;

namespace TodoList.Controllers
{    
    [ApiController] 
    public class HomeController : ControllerBase 
    { 
        [HttpGet("/")] 
        public IActionResult Get(
            [FromServices] AppDbContext dbContext
        ) 
        => Ok(dbContext.Todos.ToList());
         

        [HttpGet("/{id}")]
        public IActionResult Get(
            [FromServices] AppDbContext dbContext,
            int id
        ) 
        { 
            return Ok(dbContext.Todos.Find(id));

        }
        
        [HttpDelete("/{id}")]
        
        public IActionResult Delete(
            [FromServices] AppDbContext dbContext,
            int id
        ) 
        { 
            var todo = dbContext.Todos.Find(id);
            if (todo == null) return NotFound();
            dbContext.Todos.Remove(todo);
            dbContext.SaveChanges();
            return Ok();
        }
        

        [HttpPost("/")]
        
        public IActionResult Post(
            [FromServices] AppDbContext dbContext,
            [FromBody] Todo todo
        ) 
        { 
            dbContext.Todos.Add(todo);
            dbContext.SaveChanges();
            return Created($"{todo.Id}", todo);
        }

        [HttpPut("/{id}")]

        public IActionResult Put(
            [FromServices] AppDbContext dbContext,
            [FromBody] Todo todo,
            int id
        ) 
        { 
            var todoToUpdate = dbContext.Todos.Find(id);
            if (todoToUpdate == null) return NotFound();
            todoToUpdate.Title = todo.Title;
            todoToUpdate.IsCompleted = todo.IsCompleted;
            dbContext.SaveChanges();
            return Ok(todoToUpdate);
        }
    }
}