using ApplicationService.Communication.Responses;
using ApplicationService.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApplicationService.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ApplicationServiceException ex)
        {
            context.HttpContext.Response.StatusCode = (int)ex.GetHttpStatusCode();
            context.Result = new ObjectResult(ex.GetErrors());
        }
        else
        {
            ThrowUnknowError(context);
        }
    }
    
    public void ThrowUnknowError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorMessageJson("Ocorreu um erro desconhecido."));
    }
}
