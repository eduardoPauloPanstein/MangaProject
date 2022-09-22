using Entities.AnimeS;
using Shared.Responses;

namespace BusinessLogicalLayer.Interfaces.IAnimeInterfaces
{
    public interface IAnimeGet
    {
        Task<DataResponse<Anime>> GetByUserCount(int skip, int take);
        Task<DataResponse<Anime>> GetByFavorites(int skip, int take);
        Task<DataResponse<Anime>> Get(string name);
    }
}
