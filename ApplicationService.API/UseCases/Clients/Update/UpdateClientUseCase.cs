using ApplicationService.API.Entities;
using ApplicationService.API.Infrastructure;
using ApplicationService.API.UseCases.Clients.SharedValidator;
using ApplicationService.Communication.Requests;
using ApplicationService.Exceptions.ExceptionsBase; 

namespace ApplicationService.API.UseCases.Clients.Update;

public class UpdateClientUseCase
{
    ApplicationServiceDbContext _dbContext;

    public UpdateClientUseCase(ApplicationServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Execute(Guid clientId, RequestClientJson request)
    {
        Validate(request);

        Client entity = _dbContext.Clients.FirstOrDefault(client => client.Id == clientId)!;

        if (entity is null)
        {
            throw new NotFoundException("Cliente não encontrado.");
        };

        entity.Name = request.Name;
        entity.Email = request.Email;

        _dbContext.Update(entity);
        _dbContext.SaveChanges();
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
