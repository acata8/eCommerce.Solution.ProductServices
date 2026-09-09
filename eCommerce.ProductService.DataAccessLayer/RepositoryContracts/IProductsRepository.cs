using eCommerce.ProductService.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.ProductService.DataAccessLayer.RepositoryContracts
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<IEnumerable<Product?>> GetProductsByCondition(Expression<Func<Product, bool>> conditionExpression);

        Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> conditionExpression);

        Task<Product?> AddProduct(Product product);

        Task<Product?> UpdateProduct(Product product);

        Task<bool> DeleteProduct(Guid productId);
    }
}
