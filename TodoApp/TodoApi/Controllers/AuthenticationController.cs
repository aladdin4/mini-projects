using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TodoApi.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AuthenticationController(IConfiguration config)        //what is this config? and why are we feeding it to the constructor?
        {
            _config = config;
        }


        public record AuthenticationData(string? Username, string? Password);
        public record UserData (string Id, string FirstName, string LastName, string Username); //feels like a DB record.


        [HttpPost("token")]
        [AllowAnonymous]
        public ActionResult<string> Authenticate([FromBody] AuthenticationData data)
        {

            var user = ValidateData(data);
            if(user is null)
            {
                return Unauthorized();
            }
            var token = GenerateToken(user);
            return Ok(token);
        }

        private UserData? ValidateData(AuthenticationData data)
        {
            //This is not a production code - replace with a call to your Auth system.
            if(CompareValues(data.Username, "tcorey") && CompareValues(data.Password, "Test123"))
            {
                return new UserData("1", "Tim", "Corey", data.Username!);
            }

            if (CompareValues(data.Username, "sstorm") && CompareValues(data.Password, "Test123"))
            {
                return new UserData("2", "Sue", "Storm", data.Username!);
            }

            return null;
        }

        private bool CompareValues(string? actual, string expected)
        {
            if(!string.IsNullOrEmpty(actual) && actual.Equals(expected))
            {
                return true;
            }
            return false;
        }

        private string GenerateToken(UserData user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetValue<string>("Authentication:SecretKey")));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, user.Username));
            claims.Add(new Claim (JwtRegisteredClaimNames.GivenName, user.FirstName));
            claims.Add(new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName));

            var token = new JwtSecurityToken(
                _config.GetValue<string>("Authentication:Issuer"),
                _config.GetValue<string>("Authentication:Audience"),
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(5),
                signingCredentials
                );

            // Use JwtSecurityTokenHandler to write the token into a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
