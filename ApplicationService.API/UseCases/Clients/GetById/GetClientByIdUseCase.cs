using ApplicationService.API.Entities;
using ApplicationService.API.Infrastructure;
using ApplicationService.Communication.Responses;
using ApplicationService.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore;

namespace ApplicationService.API.UseCases.Clients.GetById;

public class GetClientByIdUseCase
{
    ApplicationServiceDbContext _dbContext;

    public GetClientByIdUseCase(ApplicationServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ResponseClientJson Execute(Guid id)
    {
        Client entity = _dbContext
            .Clients
            .Include(client => client.Products)
            .FirstOrDefault(client => client.Id == id)!;

        if (entity is null) throw new NotFoundException("Cliente não encontrado.");

        return new ResponseClientJson
        {
            Id = id,
            Name = entity.Name,
            Email = entity.Email,
            Products = entity.Products.Select(product => new ResponseShortProductJson
            {
                Id = product.Id,
                Name = product.Name
            })
            .ToList()
        };
    }
}
