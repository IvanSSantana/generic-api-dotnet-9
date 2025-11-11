using ApplicationService.Communication.Requests;
using FluentValidation;

namespace ApplicationService.API.UseCases.Products.SharedValidator;

public class RequestProductValidator : AbstractValidator<RequestProductJson>
{
    public RequestProductValidator()
    {
        RuleFor(product => product.Name).NotEmpty().WithMessage("O nome do produto não pode ser vazio.");
        RuleFor(product => product.Brand).NotEmpty().WithMessage("A marca não pode ser vazia.");
        RuleFor(product => product.Price).GreaterThan(0).WithMessage("O preço não pode ser vazio.");
    }
}