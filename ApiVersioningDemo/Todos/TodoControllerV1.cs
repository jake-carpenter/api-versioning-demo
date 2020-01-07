using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiVersioningDemo.Todos
{
    [ApiController]
    [Route("todos")]
    public class TodoControllerV1 : ControllerBase
    {
        public static List<Todo> Todos = new List<Todo>
        {
            new Todo { Id = 1, Value = "one" },
            new Todo { Id = 2, Value = "two" },
            new Todo { Id = 3, Value = "three" },
            new Todo { Id = 4, Value = "four" },
            new Todo { Id = 5, Value = "five" },
        };

        [HttpGet]
        public ActionResult<List<Todo>> List()
        {
            return Todos;
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> Get(int id)
        {
            return Todos.Find(x => x.Id == id);
        }
    }
}
