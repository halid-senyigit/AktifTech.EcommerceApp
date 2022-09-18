using EcommerceApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
    }
}
