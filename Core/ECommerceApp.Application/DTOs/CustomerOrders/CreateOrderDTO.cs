using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.DTOs.CustomerOrders
{
    public class CreateOrderDTO
    {
        public string Address { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public List<ProductDTO> Products { get; set; } = new();


        public class ProductDTO
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

    }
}
