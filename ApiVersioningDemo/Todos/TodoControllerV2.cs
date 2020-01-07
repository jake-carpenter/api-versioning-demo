using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiVersioningDemo.Todos
{
    [ApiController, ApiVersion("2.0")]
    [Route("v{v:apiVersion}/todos")]
    public class TodoControllerV2 : ControllerBase
    {
        public static List<Todo> Todos = new List<Todo>
        {
            new Todo { Id = 1, Value = "ONE" },
            new Todo { Id = 2, Value = "TWO" },
            new Todo { Id = 3, Value = "THREE" },
            new Todo { Id = 4, Value = "FOUR" },
            new Todo { Id = 5, Value = "FIVE" },
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
