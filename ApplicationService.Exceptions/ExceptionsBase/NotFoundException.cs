using System.Net;

namespace ApplicationService.Exceptions.ExceptionsBase;

public class NotFoundException : ApplicationServiceException
{
    public NotFoundException(string errorMessage) : base(string.Empty)
    {
    }

    public override List<string> GetErrors() => new List<string> { Message };
    // [ Message ]

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
}