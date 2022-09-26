using Entities.MangaS;
using Shared;
using Shared.Responses;

namespace MvcPresentationLayer.Apis.MangaProjectApi.Mangas
{
    public interface IMangaProjectApiMangaService : IMangaProjectApiService<Manga>
    {
        Task<DataResponse<Manga>> Get(string title);
        Task<DataResponse<Manga>> GetByFavorites(int skip = 0, int take = 25);
        Task<DataResponse<Manga>> GetByUserCount(int skip = 0, int take = 25);
        Task<DataResponse<Manga>> GetByRating(int skip, int take);

    }
}
