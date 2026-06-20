using Catalog.Core.Entities;
using Catalog.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Pagination<Product>> GetProducts(CatalogSpecParams specParams); 
        Task<IEnumerable<Product>> GetProductsByName(string name);
        Task<IEnumerable<Product>> GetProductsByBrand(string brandName);
        Task<Product> GetProductById(string productId);
        Task<Product> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string productId); 
        Task<ProductBrand> GetBrandsByIdAsync(string brandId);
        Task<ProductType> GetTypesByIdAsync (string typeId);
    }
}
