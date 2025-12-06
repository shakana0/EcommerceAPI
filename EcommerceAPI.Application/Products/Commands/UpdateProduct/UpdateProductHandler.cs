using MediatR;
using AutoMapper;
using EcommerceAPI.Domain.Interfaces;
using EcommerceAPI.Application.Products.Dtos;

namespace EcommerceAPI.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductDto?>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var updatedProduct = await _productRepository.UpdateAsync(
                request.Id,
                request.Name,
                request.Description,
                request.Price,
                request.StockQuantity,
                request.CategoryId,
                cancellationToken);

            if (updatedProduct == null)
                return null;
            return _mapper.Map<ProductDto>(updatedProduct);
        }
    }
}
