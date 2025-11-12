using ApplicationService.API.Filters;
using ApplicationService.API.Infrastructure;
using ApplicationService.API.UseCases.Clients.Delete;
using ApplicationService.API.UseCases.Clients.GetAll;
using ApplicationService.API.UseCases.Clients.GetById;
using ApplicationService.API.UseCases.Clients.Register;
using ApplicationService.API.UseCases.Clients.Update;
using ApplicationService.API.UseCases.Products.Delete;
using ApplicationService.API.UseCases.Products.Register;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();  

// Adiciona serviços do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>();
});

builder.Services.AddDbContext<ApplicationServiceDbContext>();
builder.Services.AddScoped<RegisterClientUseCase>();
builder.Services.AddScoped<RegisterProductUseCase>();
builder.Services.AddScoped<DeleteProductUseCase>();
builder.Services.AddScoped<GetAllClientsUseCase>();
builder.Services.AddScoped<UpdateClientUseCase>();
builder.Services.AddScoped<DeleteClientUseCase>();
builder.Services.AddScoped<GetClientByIdUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
