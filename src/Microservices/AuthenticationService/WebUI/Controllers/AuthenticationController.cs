using Application.Users.Commands;
using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : ApiControllerBase
    {
        public AuthenticationController(ISender mediator) : base(mediator)
        {
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegistrationCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
