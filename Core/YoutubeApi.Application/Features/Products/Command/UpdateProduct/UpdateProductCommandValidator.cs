using FluentValidation;

namespace YoutubeApi.Application.Features.Products.Command.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.BrandId).GreaterThan(0);
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.Discount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CategoryIds).NotEmpty().Must(c => c.Any());
    }
}
