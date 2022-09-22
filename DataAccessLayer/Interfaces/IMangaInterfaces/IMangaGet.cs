using Entities.MangaS;
using Shared.Responses;

namespace DataAccessLayer.Interfaces.IMangaInterfaces
{
    public interface IMangaGet
    {
        Task<DataResponse<Manga>> GetByUserCount(int skip, int take);
        Task<DataResponse<Manga>> GetByFavorites(int skip, int take);
        Task<DataResponse<Manga>> Get(string name);
        Task<int> GetLastIndexCategory();
        Task<int> GetLastIndexManga();

    }
}
