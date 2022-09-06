using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{
    internal class UserMapConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(u => u.Nickname).IsRequired().HasMaxLength(LocationConstants.Nickname.MaxLength).IsUnicode(true);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(LocationConstants.EmailMaxLength).IsUnicode(true);
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.ConfirmPassword).IsRequired();
            builder.Property(u => u.CreatedAt).IsRequired().HasColumnType("datetime2");
            builder.Property(u => u.LastLogin).HasColumnType("datetime2");

        }
    }
}
