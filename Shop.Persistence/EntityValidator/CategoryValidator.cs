using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EntityValidator
{
    public class CategoryValidator : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Des).HasMaxLength(200);
            builder.Property(x=>x.CreateDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
