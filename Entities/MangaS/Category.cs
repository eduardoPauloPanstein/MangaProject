﻿using Entities.AnimeS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.MangaS
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Manga> MangasID { get; set; }
        public ICollection<Anime> AnimesID { get; set; }

    }
}
