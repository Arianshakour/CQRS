using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EntityValidator
{
    public class UserValidator : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(80);
        }
    }
}
