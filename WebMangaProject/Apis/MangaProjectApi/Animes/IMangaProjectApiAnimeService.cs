using Entities.AnimeS;
using Shared.Responses;

namespace MvcPresentationLayer.Apis.MangaProjectApi.Animes
{
    public interface IMangaProjectApiAnimeService : IMangaProjectApiService<Anime>
    {
        Task<DataResponse<Anime>> Get(string title);
        Task<DataResponse<Anime>> GetByFavorites(int skip = 0, int take = 25);
        Task<DataResponse<Anime>> GetByUserCount(int skip = 0, int take = 25);
        Task<DataResponse<Anime>> GetByRating(int skip, int take);

    }
}
