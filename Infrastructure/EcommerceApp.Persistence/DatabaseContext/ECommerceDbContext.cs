using EcommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Persistence.DatabaseContext
{
    //dotnet ef migrations add QuantityAndAddressColumnsAdded --project Infrastructure\EcommerceApp.Persistence\EcommerceApp.Persistence.csproj --startup-project Presentation\EcommerceApp.WebAPI\EcommerceApp.WebAPI.csproj
    public class ECommerceDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<CustomerOrderProductRel> CustomerOrderProductRels { get; set; }


        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
