using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly ISender _mediator;

        public ApiControllerBase(ISender mediator)
        {
            _mediator = mediator;
        }
    }
}
