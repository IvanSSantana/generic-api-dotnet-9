using ApplicationService.Communication.Requests;
using FluentValidation;

namespace ApplicationService.API.UseCases.Clients.SharedValidator;

public class RequestClientValidator : AbstractValidator<RequestClientJson>
{
    public RequestClientValidator()
    {
        RuleFor(client => client.Name).NotEmpty().WithMessage("O nome não pode ser vazio.");
        RuleFor(client => client.Email).EmailAddress().WithMessage("O e-mail não pode ser inválido.");
    }
}