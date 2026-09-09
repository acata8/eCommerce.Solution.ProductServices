using eCommerce.ProductService.BusinessLogicLayer.DTOs;
using eCommerce.ProductService.DataAccessLayer.Entities;
using System.Linq.Expressions;

namespace eCommerce.ProductService.BusinessLogicLayer.ServiceContracts;

public interface IProductsService
{
    Task<List<ProductResponse?>> GetProducts();

    Task<List<ProductResponse?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression);

    Task<ProductResponse?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression);

    Task<ProductResponse?> AddProduct(ProductAddRequest productAddRequest);

    Task<ProductResponse?> UpdateProduct(ProductUpdateRequest productUpdateRequest);

    Task<bool> DeleteProduct(Guid productID);
}