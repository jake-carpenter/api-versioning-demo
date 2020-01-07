using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiVersioningDemo.Todos
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("todos")] // Will match to /todos and call DEFAULT VERSION actions (currently 1.0)
    [Route("v{v:apiVersion}/todos")] // will match to /v#/todos and call specified version actions
    public class TodoController : ControllerBase
    {
        public static List<Todo> TodosV1 = new List<Todo>
        {
            new Todo { Id = 1, Value = "one" },
            new Todo { Id = 2, Value = "two" },
            new Todo { Id = 3, Value = "three" },
            new Todo { Id = 4, Value = "four" },
            new Todo { Id = 5, Value = "five" },
        };

        public static List<Todo> Todos = new List<Todo>
        {
            new Todo { Id = 1, Value = "ONE" },
            new Todo { Id = 2, Value = "TWO" },
            new Todo { Id = 3, Value = "THREE" },
            new Todo { Id = 4, Value = "FOUR" },
            new Todo { Id = 5, Value = "FIVE" },
        };

        [HttpGet]
        [MapToApiVersion("1.0")]
        public virtual ActionResult<List<Todo>> ListV1()
        {
            return TodosV1;
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public virtual ActionResult<List<Todo>> List()
        {
            return Todos;
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult<Todo> GetV1(int id)
        {
            return TodosV1.Find(x => x.Id == id);
        }

        [HttpGet("{id}")]
        [MapToApiVersion("2.0")]
        public ActionResult<Todo> Get(int id)
        {
            return Todos.Find(x => x.Id == id);
        }

        // Version agnostic
        [HttpGet("test")]
        public ActionResult<Todo> Test()
        {
            return Ok("Test");
        }
    }
}
