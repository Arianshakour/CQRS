using Microsoft.EntityFrameworkCore;
using Shop.Domain.Base;
using Shop.Domain.Entities.Categories;
using Shop.Domain.Entities.Products;
using Shop.Domain.Entities.Users;
using Shop.Persistence.EntityValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Context
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryValidator());
            modelBuilder.ApplyConfiguration(new ProductValidator());
            modelBuilder.ApplyConfiguration(new UserValidator());
        }
    }
}
