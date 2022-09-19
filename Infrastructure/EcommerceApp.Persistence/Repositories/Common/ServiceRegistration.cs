using ECommerceApp.Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Persistence.Repositories.Common
{
    public static class ServiceRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerOrderRepository, CustomerOrderRepository>();
            services.AddTransient<ICustomerOrderProductRelRepository, CustomerOrderProductRelRepository>();
        }
    }
}
