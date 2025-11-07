using System.Net;

namespace ApplicationService.Exceptions.ExceptionsBase;

public abstract class ApplicationServiceException : SystemException
{
    public ApplicationServiceException(string errorMessage) : base(errorMessage)
    {
    }

    public abstract List<string> GetErrors();
    public abstract HttpStatusCode GetHttpStatusCode();
}