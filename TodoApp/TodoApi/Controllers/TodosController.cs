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
        private readonly ILogger<TodosController> _logger;

        public TodosController(ITodoData data, ILogger<TodosController> logger)
        {
            _data = data;
            _logger = logger;
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
            _logger.LogInformation("GET: api/Todos - Start");
            try
            {
                var result = await _data.GetAllAssigned(GetUserId());
                _logger.LogInformation("GET: api/Todos - Success");
                return Ok(result); // we like to be explicit.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GET: api/Todos - Failed");
                return BadRequest();
            }
        }

        // GET: api/Todos/5
        [HttpGet("{todoId}")]
        public async Task<ActionResult<TodoModel>> Get(int todoId)
        {
            _logger.LogInformation($"GET: api/Todos/{todoId} - Start");
            try
            {
                var result = await _data.GetOneAssigned(GetUserId(), todoId);
                _logger.LogInformation($"GET: api/Todos/{todoId} - Success");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GET: api/Todos/{todoId} - Failed");
                return BadRequest();
            }
        }

        // POST: api/Todos
        [HttpPost]
        public async Task<ActionResult<TodoModel>> Post([FromBody] string task)
        {
            _logger.LogInformation($"POST: api/Todos - Start");
            _logger.LogInformation($"Adding: {task}");
            try
            {
                var result = await _data.Create(GetUserId(), task);
                _logger.LogInformation($"POST: api/Todos - Success");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"POST: api/Todos - Failed");
                return BadRequest();
            }
        }

        // PUT: api/Todos/5
        [HttpPut("{todoId}")]
        public async Task<ActionResult> Put(int todoId, [FromBody] string task)
        {
            _logger.LogInformation($"PUT: api/Todos/{todoId} - Start");
            _logger.LogInformation($"Updating With: {task}");
            try
            {
                await _data.UpdateTask(task, GetUserId(), todoId);
                _logger.LogInformation($"PUT: api/Todos/{todoId} - Success");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"PUT: api/Todos/{todoId} - Failed");
                return BadRequest();
            }
        }

        // PUT: api/Todos/5/complete
        [HttpPut("{todoId}/complete")]
        public async Task<IActionResult>  Complete(int todoId)
        {
            _logger.LogInformation($"PUT: api/Todos/{todoId}/complete - Start");
            try
            {
                await _data.CompleteTodo(GetUserId(), todoId);
                _logger.LogInformation($"PUT: api/Todos/{todoId}/complete - Success");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"PUT: api/Todos/{todoId}/complete - Failed");
                return BadRequest();
            }
        }

        // DELETE: api/Todos/5
        [HttpDelete("{todoId}")]
        public async Task<IActionResult> Delete(int todoId)
        {
            _logger.LogInformation($"DELETE: api/Todos/{todoId} - Start");
            try
            {
                await _data.DeleteTodo(GetUserId(), todoId);
                _logger.LogInformation($"DELETE: api/Todos/{todoId} - Success");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"DELETE: api/Todos/{todoId} - Failed");
                return BadRequest();
            }
        }
    }
}
