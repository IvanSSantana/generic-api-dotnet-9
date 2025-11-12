namespace ApplicationService.API.Entities;

public class Client
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public List<Product> Products { get; set; } = [];
}

