using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Managers.Products
{
    public class CreateOrUpdateProductsRequest
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public Guid TypeProductId { get; set; }
    }
}
