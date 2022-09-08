using Entities.MangaS;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IMangaInterfaces
{
    public interface IMangaGet
    {
        Task<DataResponse<Manga>> GetTopSixFavorites();
        Task<DataResponse<Manga>> GetAllByFavorites();
        Task<DataResponse<Manga>> GetPerPage(int page);
        Task<DataResponse<Manga>> GetMorePopular();
        Task<DataResponse<Manga>> GetByName(string name);
    }
}
