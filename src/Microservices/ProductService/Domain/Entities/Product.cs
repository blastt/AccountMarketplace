﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : AuditableEntity
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Login { get; set; }
    }
}
