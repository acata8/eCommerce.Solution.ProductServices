using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using eCommerce.DataAccessLayer;
using eCommerce.DataAccessLayer.Repositories;
using eCommerce.DataAccessLayer.RepositoryContracts;

namespace eCommerce.DataAccessLayer
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<ProductServiceDbContext>(options =>
                options.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString), // interroga il server per rilevare versione MySQL/MariaDB
                    mySqlOptions => mySqlOptions
                        .EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null)
                        .MigrationsAssembly(typeof(ProductServiceDbContext).Assembly.GetName().Name)
                ));

            services.AddScoped<IProductsRepository, ProductsRepository>();

            return services;
        }
    }
}

