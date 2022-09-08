﻿using Entities.UserS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{
    internal class UserMangaItemMapConfig : IEntityTypeConfiguration<UserMangaItem>
    {
        public void Configure(EntityTypeBuilder<UserMangaItem> builder)
        {
            builder.ToTable("UserMangaItem");
            builder.Property(m => m.StartDate).HasColumnType("datetime2");
            builder.Property(m => m.FinishDate).HasColumnType("datetime2");
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.User)
                .WithMany(u => u.MangaList)
                .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(m => m.Manga)
            //    .WithOne()
            //    .IsRequired();
        }
    }
}
