using Entities.Manga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserToManga
    {
        public int Id { get; set; }
        public User Users { get; set; }
        public List<Manga.Manga> Mangas { get; set; }
    }
}
