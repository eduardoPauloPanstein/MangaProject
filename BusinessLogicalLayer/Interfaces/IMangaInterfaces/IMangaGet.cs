using Entities.MangaS;
using Shared.Responses;

namespace BusinessLogicalLayer.Interfaces.IMangaInterfaces
{
    public interface IMangaGet
    {
        Task<DataResponse<Manga>> GetByUserCount(int skip, int take);
        Task<DataResponse<Manga>> GetByFavorites(int skip, int take);
        Task<DataResponse<Manga>> GetByRating(int skip, int take);
        Task<DataResponse<Manga>> Get(string name);
    }
}
