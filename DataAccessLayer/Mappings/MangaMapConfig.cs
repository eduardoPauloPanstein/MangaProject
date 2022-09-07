using Entities.MangaS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{
    internal class MangaMapConfig : IEntityTypeConfiguration<Manga>
    {
        public void Configure(EntityTypeBuilder<Manga> builder)
        {
            builder.ToTable("Mangas");
        }
    }
}
