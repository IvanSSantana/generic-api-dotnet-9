using ApplicationService.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationService.API.Infrastructure;

public class ApplicationServiceDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; } = default!;
    public DbSet<Product> Products { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Data/app.db");
    }
}