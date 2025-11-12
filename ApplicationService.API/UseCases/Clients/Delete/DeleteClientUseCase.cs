using ApplicationService.API.Entities;
using ApplicationService.API.Infrastructure;
using ApplicationService.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApplicationService.API.UseCases.Clients.Delete;

public class DeleteClientUseCase
{
    ApplicationServiceDbContext _dbContext;

    public DeleteClientUseCase(ApplicationServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Execute(Guid id)
    {
        Client entity = _dbContext.Clients.FirstOrDefault(client => client.Id == id)!;

        if (entity is null) throw new NotFoundException("Cliente não encontrado.");

        _dbContext.Clients.Remove(entity);
        _dbContext.SaveChanges();
    }
}
