using FluentValidation;

namespace EcommerceAPI.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("Product Id must be greater than zero.");

            RuleFor(p => p.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must be greater than zero.");

            RuleFor(p => p.Name)
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
                .When(p => !string.IsNullOrWhiteSpace(p.Name));

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.")
                .When(p => !string.IsNullOrWhiteSpace(p.Description));

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.")
                .When(p => p.Price != default);

            RuleFor(p => p.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("StockQuantity cannot be negative.")
                .When(p => p.StockQuantity != default);
        }
    }
}
