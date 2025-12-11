using FluentValidation;

namespace EcommerceAPI.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("Category Id must be greater than 0.");
        }
    }
}
