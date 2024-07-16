using AgroHub.Application.Dtos;
using FluentValidation;

namespace AgroHub.Application.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.Value)
                .GreaterThan(0).WithMessage("Value must be greater than 0.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity must be greater than or equal to 0.");

            RuleFor(x => x.Unit)
                .NotEmpty().WithMessage("Unit is required.")
                .MaximumLength(2).WithMessage("Unit must not exceed 2 characters.");
        }
    }
}
