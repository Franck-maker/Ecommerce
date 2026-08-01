using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Specifications;
using System.Diagnostics;

namespace Catalog.Application.Mappers
{
    public static class ProductMapper
    {
        public static ProductResponse ToResponse( this Product product)
        {
            if (product == null) return null; 
            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Summary = product.Summary,
                Description = product.Description,
                ImageFile = product.ImageFile,
                Brand = product.Brand,
                Type = product.Type,
                Price = product.Price,
                CreatedDate = product.CreatedDate
            };
        }

        public static Pagination<ProductResponse> ToResponse(this Pagination<Product> pagination)
            => new Pagination<ProductResponse>(
                pagination.PageIndex,
                pagination.PageSize,
                pagination.Count,
                pagination.Data.Select(p => p.ToResponse()).ToList()
            );

        public static IList<ProductResponse> ToResponseList(this IEnumerable<Product> products)
            => products.Select(p => p.ToResponse()).ToList();
    }
}
