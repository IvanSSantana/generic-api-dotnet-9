using System.Net;

namespace ApplicationService.Exceptions.ExceptionsBase;

public class ErrorOnValidationException : ApplicationServiceException
{
    private readonly List<string> _errors;

    public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
    {
        _errors = errorMessages;
    }

    public override List<string> GetErrors() => _errors;
    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
}