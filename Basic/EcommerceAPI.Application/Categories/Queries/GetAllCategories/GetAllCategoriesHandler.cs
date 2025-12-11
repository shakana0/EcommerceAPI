using AutoMapper;
using EcommerceAPI.Application.Categories.Dtos;
using EcommerceAPI.Domain.Interfaces;
using MediatR;

namespace EcommerceAPI.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
    {
        public readonly ICategoryRepository _categoryRepository;
        public readonly IMapper _mapper;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync(cancellationToken);

            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
