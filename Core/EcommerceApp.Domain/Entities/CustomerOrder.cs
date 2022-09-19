using EcommerceApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Domain.Entities
{
    // bir kullanıcının birden fazla siparişi olabilir.
    public class CustomerOrder : BaseEntity
    {

        public string Address { get; set; } = string.Empty; // shipping address

        public int CustomerId { get; set; } = 0;
        public virtual Customer Customer { get; set; } = new();


        // siparişlerin ürünler ile bağlandığı ara tablo
        public virtual ICollection<CustomerOrderProductRel> CustomerOrderProductRels { get; set; } = new List<CustomerOrderProductRel>();

    }
}
