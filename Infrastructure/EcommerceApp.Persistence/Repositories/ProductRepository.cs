using EcommerceApp.Domain.Entities;
using EcommerceApp.Persistence.DatabaseContext;
using EcommerceApp.Persistence.Repositories.Common;
using ECommerceApp.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }


    }
}
