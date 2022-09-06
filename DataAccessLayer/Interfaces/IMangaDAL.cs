using Entities;
using Entities.Manga;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IMangaDAL
    {
        Task<Response> Insert(Manga manga);

        Task<DataResponse<Manga>> GetAll();

        Task<DataResponse<Manga>> GetTopSixFavorites();
        Task<DataResponse<Manga>> GetAllByFavorites();

        Task<DataResponse<Manga>> GetPerPage(int page);
        Task<SingleResponse<Manga>> GetByID(int id);
        Task<DataResponse<Manga>> GetMorePopular();
        Task<DataResponse<Manga>> GetByName(string name);
        Task<Response> DeleteAllDatas();
        Task<DataResponse<UserToManga>> GetUserFavorites(int UserID);
        //etc todo
    }
}
