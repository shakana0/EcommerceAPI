using MediatR;
using EcommerceAPI.Domain.Interfaces;

namespace EcommerceAPI.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.DeleteAsync(request.Id, cancellationToken);
            return result;
        }
    }
}
