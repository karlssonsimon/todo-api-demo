using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Domain;

namespace TodoApi.Controllers
{
    [Route("api/todo")]
    public class TodoController : Controller
    {
        private readonly ApplicationContext _context;

        public TodoController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.Todos.ToList());

        [HttpGet("{id:int}", Name = "Todo")]
        public IActionResult Get(int id)
        {
            var result = _context.Todos.FirstOrDefault(todo => todo.Id == id);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Todo item)
        {
            _context.Todos.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("Todo", new { id = item.Id }, item);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Todo item)
        {
            if(_context.Todos.Any(todo => todo.Id == item.Id))
            {
                _context.Todos.Update(item);
                _context.SaveChanges();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _context.Todos.FirstOrDefault(todo => todo.Id == id);

            if(result != null)
            {
                _context.Entry(result).State = EntityState.Deleted;
                _context.SaveChanges();
            }

            return NoContent();
        }
    }
}
