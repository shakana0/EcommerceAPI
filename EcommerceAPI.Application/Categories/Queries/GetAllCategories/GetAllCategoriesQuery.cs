using EcommerceAPI.Application.Categories.Dtos;
using MediatR;

namespace EcommerceAPI.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}
