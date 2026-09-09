using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using eCommerce.BusinessLogicLayer.ServiceContracts;
using eCommerce.BusinessLogicLayer.Validator;
using eCommerce.BusinessLogicLayer.Service;
using eCommerce.BusinessLogicLayer.Mapper;

namespace eCommerce.BusinessLogicLayer
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductAddRequestToProductMappingProfile).Assembly);

            services.AddValidatorsFromAssemblyContaining<ProductAddRequestValidator>();

            services.AddScoped<IProductsService, ProductsService>();

            return services;
        }
    }
}

