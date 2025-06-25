using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoLibrary.DataAccess;
using TodoLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {

        private readonly ITodoData _data;

        public TodosController(ITodoData data)
        {
            _data = data;
        }

        private int GetUserId()
        {
             var userText = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(userText!);
        }
        // GET: api/Todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoModel>>> Get()
        {
            var result = await _data.GetAllAssigned(GetUserId());
            return Ok(result); // we like to be explicit.
        }

        // GET api/Todos/5
        [HttpGet("{todoId}")]
        public async Task<ActionResult<TodoModel>> Get(int todoId)
        {
            var result = await _data.GetOneAssigned(GetUserId(), todoId);
            return Ok(result);
        }

        // POST api/Todos
        [HttpPost]
        public async Task<ActionResult<TodoModel>> Post([FromBody] string task)
        {
            var result = await _data.Create(GetUserId(), task);
            return Ok(result);
        }

        // PUT api/Todos/5
        [HttpPut("{todoId}")]
        public async Task<ActionResult> Put(int todoId, [FromBody] string task)
        {
            await _data.UpdateTask(task, GetUserId(), todoId);
            return Ok();
        }

        // PUT api/Todos/5/complete
        [HttpPut("{todoId}/complete")]
        public async Task<IActionResult>  Complete(int todoId)
        {
            await _data.CompleteTodo(GetUserId(), todoId);
            return Ok();
        }

        // DELETE api/Todos/5
        [HttpDelete("{todoId}")]
        public async Task<IActionResult> Delete(int todoId)
        {
            await _data.DeleteTodo(GetUserId(), todoId);
            return Ok();
        }
    }
}
