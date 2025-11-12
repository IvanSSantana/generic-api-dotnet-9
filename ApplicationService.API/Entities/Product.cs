namespace ApplicationService.API.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Brand { get; set; } = String.Empty;
    public decimal Price { get; set; }
    public Guid ClientId { get; set; }
    public Client Client { get; set; } = default!;
}

