using Entities.MangaS;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces.IMangaInterfaces
{
    public interface IMangaGet
    {
        Task<DataResponse<Manga>> GetByUserCount(int skip, int take);
        Task<DataResponse<Manga>> GetByFavorites(int skip, int take);
        Task<DataResponse<Manga>> Get(string name);
    }
}
