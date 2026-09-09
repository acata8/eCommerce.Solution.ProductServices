using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using eCommerce.ProductService.DataAccessLayer;
using eCommerce.ProductService.DataAccessLayer.Repositories;
using eCommerce.ProductService.DataAccessLayer.RepositoryContracts;

namespace eCommerce.ProductService.DataAccessLayer
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")!;

            connectionString = connectionString.Replace("$MYSQL_HOST", Environment.GetEnvironmentVariable("MYSQL_HOST"));
            connectionString = connectionString.Replace("$MYSQL_PASSWORD", Environment.GetEnvironmentVariable("MYSQL_PASSWORD"));
            //connectionString = connectionString.Replace("$MYSQL_PORT$", Environment.GetEnvironmentVariable("MYSQL_PORT") ?? "3306");

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

