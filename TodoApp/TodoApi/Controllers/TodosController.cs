using Microsoft.AspNetCore.Mvc;
using TodoLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        // GET: api/Todos
        [HttpGet]
        public ActionResult<IEnumerable<TodoModel>> Get()
        {
            return Ok();
        }

        // GET api/Todos/5
        [HttpGet("{id}")]
        public ActionResult<TodoModel> Get(int id)
        {
            return Ok();
        }

        // POST api/Todos
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok();
        }

        // PUT api/Todos/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // PUT api/Todos/5/complete
        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {
            return Ok();
        }

        // DELETE api/Todos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
