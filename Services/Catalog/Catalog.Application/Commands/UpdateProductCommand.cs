using Catalog.Application.Responses;
using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Commands
{
    public record UpdateProductCommand : IRequest<bool>
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Summary { get; set; }
        public string Description { get; init; }
        public string ImageFile { get; set; }

        public string BrandId { get; init; }

        public string TypeId { get; init; }
        public decimal Price { get; init; }

        internal object ToEntity(Task<ProductBrand> brand, Task<ProductType> type)
        {
            throw new NotImplementedException();
        }
    }
    
}
