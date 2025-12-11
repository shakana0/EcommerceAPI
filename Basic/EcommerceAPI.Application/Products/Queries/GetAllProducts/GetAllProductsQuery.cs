using MediatR;
using EcommerceAPI.Application.Products.Dtos;

namespace EcommerceAPI.Application.Products.Queries.GetProducts
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}
