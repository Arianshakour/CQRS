using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Interfaces.Category;
using Shop.Domain.Interfaces.Product;
using Shop.Domain.Interfaces.User;
using Shop.Persistence.Context;
using Shop.Persistence.Repository.Category;
using Shop.Persistence.Repository.Product;
using Shop.Persistence.Repository.User;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShopContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ShopContext")));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// sabte MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.Load("Shop.Application"));
});

// sabte autoMapper
//faqat package DependencyInjection nasb kon oon sadaro nasb nakon
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(Assembly.Load("Shop.Application"));
});

// sabte FluentValidation
builder.Services.AddValidatorsFromAssembly(Assembly.Load("Shop.Application"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
