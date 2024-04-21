using Aplication.Interfaces;
using Aplication.Interfaces.Categorias;
using Aplication.Interfaces.Planes;
using Aplication.Interfaces.Products;
using Aplication.UseCases.Categorias;
using Aplication.UseCases.Planes;
using Aplication.UseCases.Products;
using Infraestructure.Commands;
using Infraestructure.Persistence;
using Infraestructure.Querys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<PlanesContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddTransient<ICategoriaService, CategoriaService>();
builder.Services.AddTransient<ICategoriaQuery, CategoriaQuery>();
builder.Services.AddTransient<ICategoriaCommand, CategoriaCommand>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductQuery, ProductQuery>();
builder.Services.AddTransient<IProductCommand, ProductCommand>();
builder.Services.AddTransient<IPlanService, PlanService>();
builder.Services.AddTransient<IPlanQuery, PlanQuery>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
