using EcommerceApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Domain.Entities
{
    public class CustomerOrder : BaseEntity
    {
        public int CustomerId { get; set; } = 0;
        public virtual Customer Customer { get; set; } = new Customer();


        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
