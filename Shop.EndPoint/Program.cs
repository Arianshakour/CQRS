using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shop.Domain.Interfaces.Cart;
using Shop.Domain.Interfaces.Category;
using Shop.Domain.Interfaces.Product;
using Shop.Domain.Interfaces.User;
using Shop.Persistence.Context;
using Shop.Persistence.Repository.Cart;
using Shop.Persistence.Repository.Category;
using Shop.Persistence.Repository.Product;
using Shop.Persistence.Repository.User;
using System.Reflection;
using System.Text;

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
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();

// sabte MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.Load("Shop.Application"));
});

// sabte autoMapper
//faqat package AutoMapper.DependencyInjection nasb kon oon saadaro nasb nakon
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(Assembly.Load("Shop.Application"));
});

// sabte FluentValidation
builder.Services.AddValidatorsFromAssembly(Assembly.Load("Shop.Application"));

// download package System.IdentityModel.Tokens.Jwt ar laye Application va Endpoint
// sabte JWT va download package Authentication.JWTBearer dar laye Application va Endpoint
// albate Application chon faqat tolide token hast niazi be JWTBearer nadare vali gozashtim behtare nabashe
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
