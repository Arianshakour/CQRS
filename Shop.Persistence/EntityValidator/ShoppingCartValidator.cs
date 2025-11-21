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
    public class ShoppingCartValidator : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("ShoppingCart");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.items)
                .WithOne(x => x.ShoppingCart).HasForeignKey(x => x.ShoppingCartId);
            builder.HasOne(x => x.User)
                .WithMany(x => x.ShoppingCarts).HasForeignKey(x => x.UserId);
        }
    }
}
