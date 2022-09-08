using Entities;
using Entities.MangaS;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IMangaInterfaces
{
    public interface IMangaDAL : IMangaGet, IMangaPost,ICRUD<Manga>
    {
        
    }
}
