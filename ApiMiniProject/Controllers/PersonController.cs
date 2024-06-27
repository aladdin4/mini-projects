using DemoLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;

        }
        // POST api/Person
        [HttpPost]
        public void Post([FromBody] PersonModel person)
        {
            _logger.LogInformation("Person {0} {1} added", person.FirstName, person.LastName);
        }

      

    }
}
