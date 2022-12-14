using EcommerceApp.Domain.Common;
using EcommerceApp.Domain.Entities;
using ECommerceApp.Application.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Repositories
{
    public interface ICustomerOrderRepository : IGenericRepository<CustomerOrder>
    {
        public Task<List<CustomerOrder>> GetAllCustomerOrdersWithProductsAsync(int orderId);
    }
}
