using Application.Users.Commands;
using Application.Users.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : ApiControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegistrationCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
