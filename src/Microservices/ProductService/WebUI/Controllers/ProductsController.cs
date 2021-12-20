using Application.Common.Models;
using Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        public ProductsController(ISender mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Buyer")]
        public async Task<ActionResult<PaginatedList<ProductDto>>> GetProducts([FromQuery] GetProductsWithPaginationQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
