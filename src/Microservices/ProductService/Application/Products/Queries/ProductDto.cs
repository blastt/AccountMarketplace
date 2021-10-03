using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries
{
    public class ProductDto : IMapFrom<Product>
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Login { get; set; }
    }
}
