using Application.Common.Models;
using Application.Products.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        //[HttpGet]
        //public async Task<ActionResult<PaginatedList<ProductDto>>> GetProducts([FromQuery] GetProductsQuery query)
        //{
        //    return await Mediator.Send(query);
        //}

        [HttpGet]
        public async Task<ActionResult<PaginatedList<ProductDto>>> GetProducts()
        {
            return await Mediator.Send(new GetProductsQuery());
        }
    }
}
