using AgroHub.Application.Request;
using FluentValidation;

namespace AgroHub.Application.Validations
{
    public class CreateProductRequestValidator : AbstractValidator<ProductRequest>
    {

        public CreateProductRequestValidator()
        {
            RuleForEach(x => x.Data).SetValidator(new ProductDtoValidator());
        }

    }
}
