using EcommerceApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Domain.Entities
{
    // sipariş içerisinde hangi ürünlerin olduğu bilgisi tutulur.
    public class CustomerOrderProductRel : BaseEntity
    {

        public int CustomerOrderId { get; set; }
        public CustomerOrder CustomerOrder { get; set; } = new();


        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = new();


        public int Quantity { get; set; } = 1;

    }
}
