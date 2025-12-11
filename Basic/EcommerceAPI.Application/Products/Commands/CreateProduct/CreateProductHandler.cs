using MediatR;
using AutoMapper;
using EcommerceAPI.Domain.Entities;
using EcommerceAPI.Domain.Interfaces;
using EcommerceAPI.Application.Products.Dtos;

namespace EcommerceAPI.Application.Products.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            await _productRepository.AddAsync(product, cancellationToken);

            var created = await _productRepository.GetByIdAsync(product.Id, cancellationToken);

            return _mapper.Map<ProductDto>(created);
        }
    }
}
