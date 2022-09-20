using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.DTOs.CustomerOrders
{
    public class GetOrderListDTO
    {
        public int OrderId { get; set; }
        public string Address { get; set; }
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();


        public class ProductDTO
        {
            public int ProductId { get; set; }
            public string Name { get; set; } = string.Empty;
            public decimal Price { get; set; }
        }
    }


}
