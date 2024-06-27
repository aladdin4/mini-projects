using DemoLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiMiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private readonly ILogger<AddressController> _logger;

        public AddressController(ILogger<AddressController> logger)
        {
            _logger = logger;
        }
     

        //POST api/Address
        public void Post([FromBody] AddressModel address)
        {
            _logger.LogInformation("Address {0} {1} {2} {3} added", address.StreetAddress, address.City, address.State, address.ZipCode);
        }
    }
}
