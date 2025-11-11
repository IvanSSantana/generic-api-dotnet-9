using ApplicationService.Communication.Responses;
using ApplicationService.Communication.Requests;
using ApplicationService.Exceptions.ExceptionsBase;
using ApplicationService.API.Infrastructure;
using ApplicationService.API.Entities;
using ApplicationService.API.UseCases.Clients.SharedValidator;

namespace ApplicationService.API.UseCases.Clients.Register;

public class RegisterClientUseCase
{
    private readonly ApplicationServiceDbContext _dbContext;

    public RegisterClientUseCase(ApplicationServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ResponseShortClientJson Execute(RequestClientJson request)
    {
        Validate(request);

        Client entity = new()
        {
            Name = request.Name,
            Email = request.Email
        };

        _dbContext.Clients.Add(entity);
        _dbContext.SaveChanges();

        return new ResponseShortClientJson
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
    
    public void Validate(RequestClientJson request)
    {
        var validator = new RequestClientValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages: errors);
        }
    }
}