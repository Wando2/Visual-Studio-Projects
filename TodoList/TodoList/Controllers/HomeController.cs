using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Model;

namespace TodoList.Controllers
{    
    [ApiController] 
    public class HomeController : ControllerBase 
    { 
        [HttpGet("/")] 
        public List<Todo> Get(
            [FromServices] AppDbContext dbContext
        ) 
        { 
            return dbContext.Todos.ToList();
        } 

        [HttpGet("/{id}")]
        public Todo Get(
            [FromServices] AppDbContext dbContext,
            int id
        ) 
        { 
            return dbContext.Todos.Find(id);

        }

        [HttpPost("/")]
        
        public Todo Post(
            [FromServices] AppDbContext dbContext,
            [FromBody] Todo todo
        ) 
        { 
            dbContext.Todos.Add(todo);
            dbContext.SaveChanges();
            return todo;
        }

        [HttpPut("/{id}")]

        public Todo Put(
            [FromServices] AppDbContext dbContext,
            [FromBody] Todo todo,
            int id
        ) 
        { 
            var todoToUpdate = dbContext.Todos.Find(id);
            if (todoToUpdate == null) return null;
            todoToUpdate.Title = todo.Title;
            todoToUpdate.IsCompleted = todo.IsCompleted;
            dbContext.SaveChanges();
            return todoToUpdate;
        }
    }
}