﻿using ECommerceApp.Application.Repositories;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Persistence.Repositories
{
    public class CustomerOrderRepository : GenericRepository<CustomerOrder>, ICustomerOrderRepository
    {
        public CustomerOrderRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<CustomerOrder>> GetAllCustomerOrdersWithProductsAsync()
        {
            var dbResult = await base.table
                .Include(n => n.CustomerOrderProductRels)
                .ThenInclude(n => n.Product)
                .ToListAsync();

            return dbResult;
        }
    }
}
