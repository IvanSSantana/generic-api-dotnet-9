using ApplicationService.Communication.Responses;
using ApplicationService.Communication.Requests;
using ApplicationService.Exceptions.ExceptionsBase;

namespace ApplicationService.API.UseCases.Clients.Register;

public class RegisterClientUseCase
{
    public ResponseClientJson Execute(RequestClientJson request)
    {
        var validator = new RegisterClientValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages: errors);
        }

        return new ResponseClientJson();
    }
}