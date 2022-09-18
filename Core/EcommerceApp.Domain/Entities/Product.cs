using EcommerceApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public decimal Price { get; set; } = 0;


        public virtual ICollection<CustomerOrderProductRel> CustomerOrderProductRel { get; set; } = new List<CustomerOrderProductRel>();


    }
}
