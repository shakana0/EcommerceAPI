using AutoMapper;
using EcommerceAPI.Application.Categories.Dtos;
using EcommerceAPI.Domain.Entities;
using EcommerceAPI.Domain.Interfaces;
using MediatR;

namespace EcommerceAPI.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);

            var created = await _categoryRepository.AddAsync(category, cancellationToken);

            return _mapper.Map<CategoryDto>(created);
        }
    }
}
