using EcommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Persistence.DatabaseContext
{
    public class DatabaseSeed
    {
        private ECommerceDbContext db;

        public DatabaseSeed(ECommerceDbContext db)
        {
            this.db = db;
        }

        internal void SeedAll()
        {
            SeedCustomers();
            SeedProducts();

            db.SaveChanges();
        }

        private void SeedCustomers()
        {
            if (!db.Customers.Any())
            {
                db.Customers.AddRange(new List<Customer>
                {
                    new Customer{ Name = "Halid ŞENYİĞİT", Adress = "Altındağ/ANKARA"},
                    new Customer{ Name = "Name Data 1", Adress = "Adress Data 1"},
                    new Customer{ Name = "Name Data 2", Adress = "Adress Data 2"}
                });
            }
        }

        private void SeedProducts()
        {
            if (!db.Products.Any())
            {
                db.Products.AddRange(new List<Product>
                {
                    new Product{ Name = "Telefon", Price = 4500, Barcode = "0101234567890128TEC-IT", Description = "Akıllı telefon", Quantity = 10},
                    new Product{ Name = "Tablet", Price = 4500, Barcode = "0101435257234561TEC-IT", Description = "Samsung Tablet", Quantity = 0},
                    new Product{ Name = "Notebook", Price = 4500, Barcode = "0101652345241189TEC-IT", Description = "Notebook description", Quantity = 50},
                });
            }
        }
    }
}
