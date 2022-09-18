using ECommerceApp.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceApp.Persistence.DatabaseContext
{
    public static class ServiceRegistration
    {

        public static void AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ECommerceDbContext>(opt => opt.UseSqlServer(connectionString));

            MigrateDatabase(services);
        }

        private static void MigrateDatabase(IServiceCollection services)
        {
            var db = services.BuildServiceProvider().GetRequiredService<ECommerceDbContext>();

            db.Database.Migrate();

            new DatabaseSeed(db).SeedAll();
        }

    }
}
