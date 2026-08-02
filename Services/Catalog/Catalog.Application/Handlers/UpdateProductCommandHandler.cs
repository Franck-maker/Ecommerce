using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository; 

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existing = await _productRepository.GetProductById(request.Id);
            if(existing == null)
            {
                throw new KeyNotFoundException($"Product with Id {request.Id} not found"); 
            }
            //Fetch Brand and type
            var brand = await _productRepository.GetBrandByIdAsync(request.BrandId);
            var type = await _productRepository.GetTypeByIdAsync(request.TypeId);
            if(brand == null || type == null)
            {
                throw new ApplicationException("invalid Brand or Type speciied");
            }
            // Mapper role
            var updatedProduct = request.ToUpdateEntity(existing, brand, type);
            //Save the record
            return await _productRepository.UpdateProduct(updatedProduct);
        }
    }
}
