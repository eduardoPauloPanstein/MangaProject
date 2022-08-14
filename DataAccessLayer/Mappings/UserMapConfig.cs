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

            builder.Property(u => u.Nickname).IsRequired().HasMaxLength(LocationConstants.NicknameMaxLength).IsUnicode(true);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(LocationConstants.EmailMaxLength).IsUnicode(true);
            builder.Property(p => p.CreatedAt).IsRequired().HasColumnType("date");
            builder.Property(p => p.LastLogin).HasColumnType("date");

        }
    }
}
