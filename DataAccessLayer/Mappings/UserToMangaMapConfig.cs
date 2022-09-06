using Entities;
using Entities.Manga;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{
    internal class UserToMangaMapConfig : IEntityTypeConfiguration<UserToManga>
    {
        public void Configure(EntityTypeBuilder<UserToManga> builder)
        {
            builder.ToTable("UserToManga");
        }
    }
}
