using ECommerceApp.Application.Repositories;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Persistence.DatabaseContext;

namespace EcommerceApp.Persistence.Repositories
{
    public class CustomerOrderProductRelRepository : GenericRepository<CustomerOrderProductRel>, ICustomerOrderProductRelRepository
    {
        public CustomerOrderProductRelRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }


    }
}
