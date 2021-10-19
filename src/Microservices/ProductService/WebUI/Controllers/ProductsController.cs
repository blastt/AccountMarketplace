using Application.Common.Models;
using Application.Products.Queries;
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
        
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PaginatedList<ProductDto>>> GetProducts([FromQuery] GetProductsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
