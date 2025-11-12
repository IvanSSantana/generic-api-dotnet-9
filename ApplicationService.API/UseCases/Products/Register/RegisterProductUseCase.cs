using ApplicationService.Communication.Responses;
using ApplicationService.Communication.Requests;
using ApplicationService.Exceptions.ExceptionsBase;
using ApplicationService.API.Infrastructure;
using ApplicationService.API.Entities;
using ApplicationService.API.UseCases.Products.SharedValidator;

namespace ApplicationService.API.UseCases.Products.Register;

public class RegisterProductUseCase
{
    private readonly ApplicationServiceDbContext _dbContext;

    public RegisterProductUseCase(ApplicationServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ResponseShortProductJson Execute(Guid clientId, RequestProductJson request)
    {
        Validate(clientId, request);

        Product entity = new()
        {
            Name = request.Name,
            Brand = request.Brand,
            Price = request.Price,
            ClientId = clientId
        };

        _dbContext.Products.Add(entity);
        _dbContext.SaveChanges();

        return new ResponseShortProductJson
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
    
    public void Validate(Guid clientId, RequestProductJson request)
    {
        bool clientExists = _dbContext.Clients.Any(client => client.Id == clientId);

        if (!clientExists) throw new NotFoundException("Cliente inexistente.");

        var validator = new RequestProductValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages: errors);
        }
    }
}