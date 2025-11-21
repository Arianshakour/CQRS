using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EntityValidator
{
    public class CartItemValidator : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItem");
            builder.HasKey(x => x.Id);

            //niazi be zadan dar Product nabood
            builder.HasOne(x => x.product).WithMany().HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.ShoppingCart).WithMany(x => x.items).HasForeignKey(x => x.ShoppingCartId);
        }
    }
}
