using ApplicationService.API.Entities;
using ApplicationService.API.Infrastructure;
using ApplicationService.Exceptions.ExceptionsBase;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApplicationService.API.UseCases.Products.Delete;

public class DeleteProductUseCase
{
    ApplicationServiceDbContext _dbContext;

    public DeleteProductUseCase(ApplicationServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Execute(Guid id)
    {
        Product entity = _dbContext.Products.FirstOrDefault(product => product.Id == id)!;

        if (entity is null) throw new NotFoundException("Produto não encontrado.");

        _dbContext.Products.Remove(entity);
        _dbContext.SaveChanges();
    }
}
