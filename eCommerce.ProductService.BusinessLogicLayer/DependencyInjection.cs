using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using eCommerce.ProductService.BusinessLogicLayer.ServiceContracts;
using eCommerce.ProductService.BusinessLogicLayer.Validator;
using eCommerce.ProductService.BusinessLogicLayer.Service;
using eCommerce.ProductService.BusinessLogicLayer.Mapper;

namespace eCommerce.ProductService.BusinessLogicLayer
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

