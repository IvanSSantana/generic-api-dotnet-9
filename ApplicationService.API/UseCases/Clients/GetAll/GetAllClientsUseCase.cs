using ApplicationService.API.Entities;
using ApplicationService.API.Infrastructure;
using ApplicationService.Communication.Responses;

namespace ApplicationService.API.UseCases.Clients.GetAll;

public class GetAllClientsUseCase
{
    ApplicationServiceDbContext _dbContext;

    public GetAllClientsUseCase(ApplicationServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ResponseAllClientsJson Execute()
    {
        List<Client> clients = _dbContext.Clients.ToList();

        var shortResponseClients = clients.Select(client => new ResponseShortClientJson
        {
            Id = client.Id,
            Name = client.Name
        })
        .ToList();

        return new ResponseAllClientsJson
        {
            Clients = shortResponseClients
        };
        
    }
}
